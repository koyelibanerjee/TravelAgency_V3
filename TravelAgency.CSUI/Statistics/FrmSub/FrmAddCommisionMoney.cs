using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmAddCommisionMoney : Form
    {
        private BLL.CommisionMoney _bllCommisionMoney = new BLL.CommisionMoney();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly Model.CommisionMoney _model = null;



        public FrmAddCommisionMoney(Action<int> updateDel, int curPage, bool is4Modify = false, Model.CommisionMoney model=null)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            _updateDel = updateDel;
            _curPage = curPage;
            _is4Modify = is4Modify;
            _model = model;
        }

        private void FrmAddCommisionMoney_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            
            var list = new BLL.Visa().GetCountryList();
            foreach (var item in list)
            {
                cbCountry.Items.Add(item);
            }

            if (_is4Modify)
            {
                //把选中的加载到这里面
                cbCountry.Text = _model.Type;
                txtType00.Text = _model.Type00ScanedIn.ToString();
                txtType02.Text = _model.Type02TypeInData.ToString();
                txtType05.Text = _model.Type05SendSubmission.ToString();
                txtType06.Text = _model.Type06GetSubmission.ToString();
                txtType07.Text = _model.Type07AccompanySubmission.ToString();
                txtType08.Text = _model.Type08Plan.ToString();
                this.Text = "修改提成配置";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (_is4Modify)
            {
                try
                {
                    _model.Type = cbCountry.Text;
                    _model.Type00ScanedIn = decimal.Parse(txtType00.Text);
                    _model.Type02TypeInData = decimal.Parse(txtType02.Text);
                    _model.Type05SendSubmission = decimal.Parse(txtType05.Text);
                    _model.Type06GetSubmission = decimal.Parse(txtType06.Text);
                    _model.Type07AccompanySubmission = decimal.Parse(txtType07.Text);
                    _model.Type08Plan = decimal.Parse(txtType08.Text);
                    if (!_bllCommisionMoney.Update(_model))
                    {
                        MessageBoxEx.Show("更新失败，请稍后重试!");
                        return;
                    }
                    MessageBoxEx.Show("更新成功!");
                    _updateDel(_curPage);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("请检查输入是否有误，若不统计请输入0!");
                    //throw;
                }
            }
            else
            {
                Model.CommisionMoney model = new Model.CommisionMoney();
                try
                {
                    model.Type = cbCountry.Text;
                    model.Type00ScanedIn = decimal.Parse(txtType00.Text);
                    model.Type02TypeInData = decimal.Parse(txtType02.Text);
                    model.Type05SendSubmission = decimal.Parse(txtType05.Text);
                    model.Type06GetSubmission = decimal.Parse(txtType06.Text);
                    model.Type07AccompanySubmission = decimal.Parse(txtType07.Text);
                    model.Type08Plan = decimal.Parse(txtType08.Text);
                    if (_bllCommisionMoney.Add(model) <= 0)
                    {
                        MessageBoxEx.Show("添加失败，请稍后重试!");
                        return;
                    }
                    MessageBoxEx.Show("添加成功");
                    _updateDel(_curPage);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("请检查输入是否有误，若不统计请输入0!");
                    //throw;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }




    }
}
