using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.Common;
using TravelAgency.CSUI.FrmSub;
using Color = System.Drawing.Color;

namespace TravelAgency.CSUI.FrmMain
{

    public partial class FrmGaoPaiManage : Form
    {
        class NodeTag
        {
            public object data { get; set; }
            public NodeLevel level { get; set; }

            public static NodeTag CreateTag(object tag, NodeLevel level)
            {
                NodeTag nt = new NodeTag();
                nt.data = tag;
                nt.level = level;
                return nt;
            }
        }
        public enum NodeLevel
        {
            Month, Day, ImageType
        }

        private double[] sizeArr = new double[] { 0.6, 0.8, 1.0, 1.2, 1.4, 1.6, 1.8, 2.0 };
        private List<string> _imagenames; //维持一个当前listview展示的文件列表
        private Size _origThumbSize = new Size(97, 129);
        private readonly ImageList _imageList = new ImageList() { ImageSize = new Size(97, 129) }; //用于listView展示用的图片集合
        private bool _startLoading = false; //方便终止原来的后台进程
        private GaopaiPicHandler _gaopaiPicHandler = new GaopaiPicHandler(GaopaiPicHandler.PictureType.Type01_Normal);

        private Dictionary<string, List<string>> _daysOfMonthDictionary = new Dictionary<string, List<string>>();



        public FrmGaoPaiManage()
        {
            InitializeComponent();
        }

        #region Utils
        private string GenChinaDate(string date)
        {
            if (date.Length == 6)
                return date.Substring(0, 4) + "年" + date.Substring(4, 2) + "月";

            if (date.Length == 8)
                return date.Substring(0, 4) + "年" + date.Substring(4, 2) + "月" + date.Substring(6, 2) + "日";
            else
                return string.Empty;
        }
        private string GetMonthName(string date)
        {
            return date.Substring(0, 6);
        }

        private NodeTag GetNodeTag(Node node)
        {
            if (node != null && node.Tag != null)
                return (node.Tag as NodeTag);
            else return null;
        }

        private string GetNodeTagData(Node node)
        {
            return GetNodeTag(node).data.ToString();
        }

        private NodeTag GetSelectedNodeTag()
        {
            return GetNodeTag(advTree1.SelectedNode);
        }

        private string GetSelectedNodeTagData()
        {
            return GetNodeTagData(advTree1.SelectedNode);
        }
        #endregion

        #region 窗体消息响应

        private void UpdateLabels()
        {
            lbCount.Text = "共有图像" + lvPics.Items.Count + "张。";
        }

        private void FrmGaoPaiManage_Load(object sender, EventArgs e)
        {
            InitThumbSizeSlider();
            SetAdvStyle();

            new Thread(LoadDataToAdvTree) { IsBackground = true }.Start();
            UpdateLabels();
        }

        private void InitThumbSizeSlider()
        {
            sliderPicSize.Step = 1;
            sliderPicSize.Maximum = 7;
            sliderPicSize.Minimum = 0;
            sliderPicSize.Value = 2; //对于slider采用 0.6 0.8 1.0 依次到2.0的倍数，对应下标从0-7，初始下标为2，对应倍数1.0
        }




        /// <summary>
        /// 设置树形控件的style
        /// </summary>
        private void SetAdvStyle()
        {
            advTree1.Nodes.Clear();
            advTree1.View = eView.Tile;
            // Define group node style
            ElementStyle groupStyle = new ElementStyle();
            groupStyle.TextColor = Color.Navy;
            groupStyle.Font = new Font("微软雅黑", 14.0f, FontStyle.Bold);

            groupStyle.Name = "groupstyle";
            advTree1.Styles.Add(groupStyle);


            ElementStyle dayStyle = new ElementStyle();
            dayStyle.TextColor = Color.ForestGreen;
            dayStyle.Font = new Font("微软雅黑", 10.0f, FontStyle.Bold);

            dayStyle.Name = "daystyle";
            advTree1.Styles.Add(dayStyle);


            // Define sub-item style, simply to make text gray
            ElementStyle subItemStyle = new ElementStyle();
            subItemStyle.TextColor = Color.OrangeRed;
            //subItemStyle.Font = new Font(advTree1.Font.FontFamily);
            //subItemStyle.Font = 
            subItemStyle.Name = "subitemstyle";
            advTree1.Styles.Add(subItemStyle);
        }




        /// <summary>
        /// 加载数据到treeView和设置ComboBox，按照年份月份分组
        /// </summary>
        private void LoadDataToAdvTree()
        {
            _daysOfMonthDictionary.Clear();
            this.Invoke(new Action(() =>
            {
                advTree1.Nodes.Clear();
            }));
            List<List<string>> folderList = _gaopaiPicHandler.GetFolderListGroupByMonth();
            foreach (var item in folderList)
                _daysOfMonthDictionary[GetMonthName(item[0])] = item;

            //按照年月分类
            if (folderList.Count == 0)
                return;

            for (int i = folderList.Count - 1; i >= 0; i--)
            {
                Node groupNode = new Node(GenChinaDate(GetMonthName(folderList[i][0])), advTree1.Styles["groupstyle"]);
                //groupNode.Expanded = true;
                groupNode.Expanded = false;
                groupNode.Tag = NodeTag.CreateTag(GetMonthName(folderList[i][0]), NodeLevel.Month); //存一个组名

                this.Invoke(new Action(() =>
                {
                    advTree1.Nodes.Add(groupNode);
                }));
            }
        }

        private void LoadDayAndTypeListOfMonth()
        {
            var nodeTag = advTree1.SelectedNode.Tag as NodeTag;
            if (nodeTag != null && nodeTag.level != NodeLevel.Month)
                return;
            List<string> dayList = _daysOfMonthDictionary[nodeTag.data.ToString()];

            for (int j = dayList.Count - 1; j >= 0; j--)
            {
                //Node subNode = CreateChildNode(GenChinaDate(folderList[i][j]),
                //    GenChinaDate(folderList[i][j]),
                //    Properties.Resources.Folder,
                //    advTree1.Styles["subitemstyle"]);
                Node subNode = new Node(GenChinaDate(dayList[j]), advTree1.Styles["daystyle"]);
                subNode.Tag = NodeTag.CreateTag(dayList[j], NodeLevel.Day); //存一个组名

                //每一个这个再添加几类图像名字
                try //用户来了一个20180832，在DateTime.ParseExact的时候就会直接报错
                {
                    List<string> typeList = _gaopaiPicHandler.GetFolderListByDate( //拿到未分类、团签、个签等分类的名字
                        DateTime.ParseExact(dayList[j], "yyyyMMdd",
                            System.Globalization.CultureInfo.CurrentCulture));
                    for (int i1 = 0; i1 < typeList.Count; ++i1)
                    {
                        Node subImtem = CreateChildNode(typeList[i1], typeList[i1], Properties.Resources.Folder,
                            advTree1.Styles["subitemstyle"]);
                        subImtem.Tag = NodeTag.CreateTag(typeList[i1], NodeLevel.ImageType);
                        this.Invoke(new Action(() =>
                        {
                            subNode.Nodes.Add(subImtem);
                        }));
                    }
                }
                catch (FormatException e)
                {
                    MessageBoxEx.Show($"{e.Message}");
                    continue;
                }
                this.Invoke(new Action(() =>
                {
                    advTree1.SelectedNode.Nodes.Add(subNode);
                }));
            }
        }

        private Node CreateChildNode(string nodeText, string subText, Image image, ElementStyle subItemStyle)
        {
            Node childNode = new Node(nodeText);
            childNode.Image = image;
            childNode.Cells.Add(new Cell(subText, subItemStyle));
            childNode.Editable = false;
            childNode.DragDropEnabled = false;
            return childNode;
        }
        #endregion

        #region advTree响应事件
        private void advTree1_Click(object sender, EventArgs e)
        {
            NodeTag nodeTag = GetSelectedNodeTag();
            if (nodeTag == null || nodeTag.level == NodeLevel.Month) //不是最底层节点
            {
                LoadDayAndTypeListOfMonth();
            }
            else if (nodeTag.level == NodeLevel.ImageType)
            {
                _startLoading = false; //杀死原来的线程
                LoadTypeImagesToLvPics();
                UpdateLabels();
            }
            else //day的是直接就加载了
            {

            }

        }

        private void LoadTypeImagesToLvPics()
        {
            NodeTag nodeTag = GetSelectedNodeTag();
            if (nodeTag == null || nodeTag.level != NodeLevel.ImageType) //不是最底层节点
                return;
            _imageList.Images.Clear();
            lvPics.Items.Clear();
            string day = GetNodeTagData(advTree1.SelectedNode.Parent);
            _imagenames =
               _gaopaiPicHandler.GetFileListByDateAndTypes(
                   DateTime.ParseExact(day, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture),
                   GetSelectedNodeTagData());
            if(_imagenames==null || _imagenames.Count==0)
                return;
            for (int i = 0; i < _imagenames.Count; ++i)
            {
                ListViewItem lvi = new ListViewItem(_imagenames[i] + "   ");//添加三个占位符，防止listview出现...的现象。。。
                lvi.Font = new Font("微软雅黑", 8.0f, FontStyle.Bold);
                lvPics.Items.Add(lvi);

                //_imageList.Images.Add(Properties.Resources.LoadingSmall);
                lvPics.Items[i].ImageIndex = i;
                lvPics.Items[i].Tag = _imagenames[i];
            }
            lvPics.LargeImageList = _imageList;
            _startLoading = true;
            //advTree1.SelectedNode.Text += "共" + _imagenames.Count + "本";
            new Thread(LoadImageToListView) { IsBackground = true }.Start();
        }

        /// <summary>
        /// 加载所选组的缩略图
        /// </summary>
        private void LoadImageToListView()
        {
            this.Invoke(new Action(() =>
            {
                for (int i = 0; i < _imagenames.Count && _startLoading; i++)
                {
                    string types = GetSelectedNodeTagData();
                    Image img = null;
                    string day = GetNodeTagData(advTree1.SelectedNode.Parent);
                    if (types == "未分类")
                        img = _gaopaiPicHandler.GetGaoPaiImage(day + "/" +
                           _gaopaiPicHandler.GetThumbName(_imagenames[i]));
                    else
                        img = _gaopaiPicHandler.GetGaoPaiImage(day + "/" + types + "/" +
                          _gaopaiPicHandler.GetThumbName(_imagenames[i]));
                    if (img != null)
                        _imageList.Images.Add(img);
                }
            }));
        }

        #endregion
        #region listView响应事件

        /// <summary>
        /// 返回listview选中项的名字,xxx.jpg
        /// </summary>
        /// <returns></returns>
        public string GetListViewSelName()
        {
            return lvPics.SelectedItems[0].Tag.ToString();
        }

        /// <summary>
        /// 返回选中项的对应文件名 20171227/xxxx.jpg
        /// </summary>
        /// <returns></returns>
        private string GetSelFileName()
        {
            return GetSelectedNodeTagData() + "/" +
                   GetListViewSelName();
        }

        /// <summary>
        /// 返回多个选中项情况下的List
        /// </summary>
        /// <returns></returns>
        private List<string> GetSelFileList()
        {
            List<string> res = new List<string>();
            for (int i = 0; i < lvPics.SelectedItems.Count; i++)
            {
                res.Add(GetSelectedNodeTagData() + "/" + lvPics.SelectedItems[i].Tag.ToString());
            }
            return res;
        }


        private void lvPics_DoubleClick(object sender, EventArgs e)
        {
            if (lvPics.SelectedItems.Count == 1)
            {
                string types = GetSelectedNodeTagData();
                string day = GetNodeTagData(advTree1.SelectedNode.Parent);
                FrmShowPicture frm;
                if (types == "未分类")
                    frm = new FrmShowPicture(_imagenames, day, lvPics.SelectedItems[0].Index, GaopaiPicHandler.PictureType.Type01_Normal);
                //Image img = _gaopaiPicHandler.GetGaoPaiImage(GetSelFileName());
                else
                    frm = new FrmShowPicture(_imagenames, day + "/" +
                    GetSelectedNodeTagData(), lvPics.SelectedItems[0].Index, GaopaiPicHandler.PictureType.Type01_Normal);
                frm.Show();
            }
        }

        private void lvPics_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsListView.Show(MousePosition);
            }
        }

        #endregion
        #region listview右键菜单响应
        private void 保存图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvPics.SelectedItems.Count < 1)
                return;
            if (lvPics.SelectedItems.Count == 1)
            {
                string dstname = GlobalUtils.ShowSaveFileDlg(GetListViewSelName());
                if (!string.IsNullOrEmpty(dstname))
                    _gaopaiPicHandler.DownloadGaoPaiImage(GetSelFileName(), dstname);
            }
            else
            {
                string dstPath = GlobalUtils.ShowBrowseFolderDlg();
                if (!string.IsNullOrEmpty(dstPath))
                {
                    _gaopaiPicHandler.DownloadGaoPaiImageBatch(GetSelFileList(), dstPath);
                    if (MessageBoxEx.Show("成功保存图像:" + lvPics.SelectedItems.Count + "份.\n是否打开所在文件夹?",
                        "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    Process.Start(dstPath);
                }
            }
        }



        #endregion

        private void sliderPicSize_ValueChanged(object sender, EventArgs e)
        {
            _imageList.ImageSize = new Size(Math.Min((int)(_origThumbSize.Width * sizeArr[sliderPicSize.Value]), 256),
                Math.Min((int)(_origThumbSize.Height * sizeArr[sliderPicSize.Value]), 256));
            //lvPics.LargeImageList = null;
            LoadTypeImagesToLvPics();
        }
    }
}
