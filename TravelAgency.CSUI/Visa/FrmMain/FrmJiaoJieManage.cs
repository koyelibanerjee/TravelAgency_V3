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
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;
using TravelAgency.CSUI.FrmSub;
using Color = System.Drawing.Color;

namespace TravelAgency.CSUI.FrmMain
{
    public partial class FrmJiaoJieManage : Form
    {
        private double[] sizeArr = new double[] { 0.6, 0.8, 1.0, 1.2, 1.4, 1.6, 1.8, 2.0 };
        private List<string> _imagenames; //维持一个当前listview展示的文件列表
        private Size _origThumbSize = new Size(97, 129);
        private readonly ImageList _imageList = new ImageList() { ImageSize = new Size(97, 129) }; //用于listView展示用的图片集合
        private bool _startLoading = false;
        public FrmJiaoJieManage()
        {
            InitializeComponent();
        }


        #region 窗体消息响应

        private void UpdateLabels()
        {
            lbCount.Text = "共有图像" + lvPics.Items.Count + "张。";
        }

        private void FrmJiaoJieManage_Load(object sender, EventArgs e)
        {
            sliderPicSize.Step = 1;
            sliderPicSize.Maximum = 7;
            sliderPicSize.Minimum = 0;
            sliderPicSize.Value = 2; //对于slider采用 0.6 0.8 1.0 依次到2.0的倍数，对应下标从0-7，初始下标为2，对应倍数1.0

            //lvPics.

            SetAdvStyle();
            LoadDataToAdvTree();
            UpdateLabels();

        }


        private string GenChinaDate(string date)
        {
            if (date.Length == 6)
            {
                return date.Substring(0, 4) + "年" + date.Substring(4, 2) + "月";
            }

            if (date.Length == 8)
            {
                return date.Substring(0, 4) + "年" + date.Substring(4, 2) + "月" + date.Substring(6, 2) + "日";
            }
            else
            {
                return string.Empty;
            }
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
            advTree1.Nodes.Clear();
            //cb_field.Items.Clear();
            //cb_field.Items.Add("全部");
            //遍历记载矿区节点
            //List<TblField> listFiled = filedBll.GetList();

            List<List<string>> folderList = JiaoJiePicHandler.GetFolderListGroupByMonth();
            //按照年月分类
            if(folderList==null || folderList.Count==0)
                return;
            
            for (int i = folderList.Count - 1; i >= 0; i--)
            {
                Node groupNode = new Node(GenChinaDate(folderList[i][0].Substring(0, 6)), advTree1.Styles["groupstyle"]);
                groupNode.Expanded = true;
                groupNode.Tag = folderList[i][0].Substring(0, 6); //存一个组名
                advTree1.Nodes.Add(groupNode);

                for (int j = folderList[i].Count - 1; j >= 0; j--)
                {
                    Node subNode = CreateChildNode(GenChinaDate(folderList[i][j]),
                        GenChinaDate(folderList[i][j]),
                        Properties.Resources.Folder,
                        advTree1.Styles["subitemstyle"]);
                    subNode.Tag = folderList[i][j]; //存一个组名
                    subNode.Editable = false;
                    subNode.DragDropEnabled = false;
                    groupNode.Nodes.Add(subNode);
                }

            }
        }
        private Node CreateChildNode(string nodeText, string subText, Image image, ElementStyle subItemStyle)
        {
            Node childNode = new Node(nodeText);
            childNode.Image = image;
            childNode.Cells.Add(new Cell(subText, subItemStyle));
            return childNode;
        }
        #endregion

        #region advTree响应事件
        private void advTree1_Click(object sender, EventArgs e)
        {
            if (advTree1.SelectedNode != null && advTree1.SelectedNode.Tag.ToString().Length == 8) //必须选中有效日期才行20171227这样
            {
                _startLoading = false; //杀死原来的线程
                LoadSelectItemToDgv();
                UpdateLabels();
            }
        }

        private void LoadSelectItemToDgv()
        {
            if (advTree1.SelectedNode == null || advTree1.SelectedNode.Tag == null)
                return;
            _imageList.Images.Clear();
            lvPics.Items.Clear();
            //_imageList.
            _imagenames =
               JiaoJiePicHandler.GetFileListByDate(DateTime.ParseExact(advTree1.SelectedNode.Tag.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture));

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
                    Image img = JiaoJiePicHandler.GetJiaoJieImage(advTree1.SelectedNode.Tag.ToString() + "/" +
                        JiaoJiePicHandler.GetThumbName(_imagenames[i]));
                    if (img != null)
                    {
                        //_imageList.Images[i].Dispose();
                        _imageList.Images.Add(img);
                    }
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
            return advTree1.SelectedNode.Tag.ToString() + "/" +
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
                res.Add(advTree1.SelectedNode.Tag.ToString() + "/" + lvPics.SelectedItems[i].Tag.ToString());
            }
            return res;
        }


        private void lvPics_DoubleClick(object sender, EventArgs e)
        {
            if (lvPics.SelectedItems.Count == 1)
            {
                //Image img = JiaoJiePicHandler.GetJiaoJieImage(GetSelFileName());
                FrmShowPicture frm = new FrmShowPicture(_imagenames, advTree1.SelectedNode.Tag.ToString(),lvPics.SelectedItems[0].Index);
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
                    JiaoJiePicHandler.DownloadJiaoJieImage(GetSelFileName(), dstname);
            }
            else
            {
                string dstPath = GlobalUtils.ShowBrowseFolderDlg();
                if (!string.IsNullOrEmpty(dstPath))
                {
                    JiaoJiePicHandler.DownloadJiaoJieImageBatch(GetSelFileList(), dstPath);
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
            LoadSelectItemToDgv();
        }
    }
}
