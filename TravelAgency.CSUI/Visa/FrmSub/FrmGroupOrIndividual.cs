using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.Model;
using TravelAgency.Model.Enums;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmGroupOrIndividual : Form
    {
        List<Model.VisaInfo> _list; //传过来的list，再传给设置团号的页面
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托，再传给设置团号的页面
        private readonly int _curPage; //主界面更新数据库需要一个当前页，再传给设置团号的页面
        private Model.Visa _visaModel; //_model,更改团队的类型用的
        private BLL.Visa _bllVisa = new BLL.Visa();
        private BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();

        /// <summary>
        /// 从visamodel初始化，修改团的类型
        /// </summary>
        /// <param name="visamodel"></param>
        /// <param name="del"></param>
        /// <param name="page"></param>
        public FrmGroupOrIndividual(Model.Visa visamodel, Action<int> del, int page)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            //_list = list;
            _visaModel = visamodel;
            _updateDel = del;
            _curPage = page;


        }

        public FrmGroupOrIndividual(List<Model.VisaInfo> list, Action<int> del, int page)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            _list = list;
            _updateDel = del;
            _curPage = page;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Form frmSetGroup = null;
            if (_visaModel == null) //从List初始化，设置团号
            {
                if (rbtnIndividual.Checked)
                {
                    frmSetGroup = new FrmSetGroup(_list, _updateDel, _curPage, Types.Individual);
                }
                else if (rBtnTeam.Checked)
                {
                    frmSetGroup = new FrmSetTeamVisaGroup(_list, _updateDel, _curPage);
                }
                else if (rbtnTeamToInd.Checked)
                {
                    frmSetGroup = new FrmSetGroup(_list, _updateDel, _curPage, Types.Team2Individual);
                }
                else
                {
                    frmSetGroup = new FrmSetGroup(_list, _updateDel, _curPage, Types.Default);
                }
                frmSetGroup.Show();
            }
            else //从model初始化,更改团的类型
            {
                string type = string.Empty;
                if (rbtnIndividual.Checked)
                    type = Types.Individual;
                else if (rBtnTeam.Checked)
                    type = Types.Team;
                else if (rbtnTeamToInd.Checked)
                    type = Types.Team2Individual;
                else
                    type = Types.Default;
                if (type != _visaModel.Types)
                {
                    //执行更新
                    //更新visa
                    _visaModel.Types = type;
                    if (!_bllVisa.Update(_visaModel))
                    {
                        MessageBoxEx.Show("更改团号类型失败,请重试!");
                        return;
                    }

                    //更新对应的visainfo
                    var visainfolist = _bllVisaInfo.GetModelListByVisaIdOrderByPosition(_visaModel.Visa_id);
                    for (int i = 0; i < visainfolist.Count; i++)
                        visainfolist[i].Types = type;
                    int res = _bllVisaInfo.UpdateByList(visainfolist);
                    if (res != visainfolist.Count)
                        MessageBoxEx.Show(res + "条记录更新成功," + (visainfolist.Count - res) + "条记录更新失败.");
                    else
                        MessageBoxEx.Show(res + "条记录更新成功.");
                    _updateDel(_curPage);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
            FrmsManager.OpenedForms.Add(frmSetGroup);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmGroupOrIndividual_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            rbtnIndividual.Checked = true;

            if (_visaModel == null)
                return;
            if (_visaModel.Types == Types.Individual)
            {
                rbtnIndividual.Checked = true;
            }
            else if (_visaModel.Types == Types.Team2Individual)
            {
                rbtnTeamToInd.Checked = true;
            }
            else if (_visaModel.Types == Types.Team)
            {
                rBtnTeam.Checked = true;
            }
            else
            {
                rbtnDefault.Checked = true;
            }

        }
    }
}
