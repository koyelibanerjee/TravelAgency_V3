using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SteelManagement.Common;

namespace SteelManagement.CSUI.FrmSub
{
    public partial class FrmAddSaleBill : Form
    {
        private readonly BLL.SaleBill _bllSaleBill = new BLL.SaleBill();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly SteelManagement.Model.SaleBill _model = null;
        private readonly SteelManagement.Model.SaleInfo _saleInfoModel = null;

        public FrmAddSaleBill(Action<int> updateDel, int curPage, bool is4Modify = false, SteelManagement.Model.SaleBill model = null)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            _updateDel = updateDel;
            _curPage = curPage;
            _is4Modify = is4Modify;
            _model = model;
        }

        public FrmAddSaleBill(Action<int> updateDel, int curPage, SteelManagement.Model.SaleInfo model)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            _updateDel = updateDel;
            _curPage = curPage;
            _saleInfoModel = model;
        }

        private void FrmAddSaleBill_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitComboBoxs();
            if (_saleInfoModel != null)
                InitCtrlsBySaleInfoModel();

            if (_is4Modify)
            {
                //把选中的加载到这里面
                txtCorporation.Text = _model.Corporation;
                txtProject.Text = _model.Project;
                txtSupplier.Text = _model.Supplier;
                txtDuiZhang.Text = DecimalHandler.DecimalToString(_model.DuiZhang);
                txtAmount.Text = DecimalHandler.DecimalToString(_model.Amount);
                txtInvoiceNum.Text = DecimalHandler.DecimalToString(_model.InvoiceNum);
                txtReceiptNum.Text = DecimalHandler.DecimalToString(_model.ReceiptNum);
                txtInvoiceDate.Text = _model.InvoiceDate.ToString();
                txtReceiptDate.Text = _model.ReceiptDate.ToString();

                this.Text = "修改销售收款";
            }
        }

        #region 窗体初始化
        private void InitCtrlsBySaleInfoModel()
        {
            txtCorporation.Text = _saleInfoModel.Corporation;
            txtProject.Text = _saleInfoModel.Project;
            txtSupplier.Text = _saleInfoModel.Supplier;

        }

        private void InitComboBoxs()
        {
            string tablename = "SaleBill";

            var list = BLL.CommonBll.GetFieldList(tablename, "Corporation");
            if (list != null)
                foreach (var item in list)
                    txtCorporation.Items.Add(item);

            list = BLL.CommonBll.GetFieldList(tablename, "Project");
            if (list != null)
                foreach (var item in list)
                    txtProject.Items.Add(item);

            list = BLL.CommonBll.GetFieldList(tablename, "Supplier");
            if (list != null)
                foreach (var item in list)
                    txtSupplier.Items.Add(item);
        }
        #endregion



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_is4Modify)
            {
                try
                {
                    _model.Corporation = txtCorporation.Text;
                    if (string.IsNullOrEmpty(txtProject.Text))
                    {
                        MessageBoxEx.Show("必须填写项目名称!");
                        return;
                    }
                    _model.Project = txtProject.Text;
                    _model.Supplier = txtSupplier.Text;
                    _model.Amount = DecimalHandler.Parse(txtAmount.Text);
                    _model.DuiZhang = DecimalHandler.Parse(txtDuiZhang.Text);


                    _model.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text);
                    _model.ReceiptDate = DateTime.Parse(txtReceiptDate.Text);
                    _model.InvoiceNum = DecimalHandler.Parse(txtInvoiceNum.Text);
                    _model.ReceiptNum = DecimalHandler.Parse(txtReceiptNum.Text);

                    //下面的字段暂时不进行修改
                    //_model.EntryTime = DateTime.Now;
                    //_model.SerialNo = SerialNoGenerator.GetSerialNo(SerialNoGenerator.Type.Type03Receipt);
                    //_model.OperatorId = GlobalUtils.LoginUser.Id;
                    if (!_bllSaleBill.Update(_model))
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
                    MessageBoxEx.Show("请检查输入是否有误，价格为0请填入0!");
                    //throw;
                }
            }
            else
            {
                SteelManagement.Model.SaleBill model = new SteelManagement.Model.SaleBill();
                try
                {
                    model.Corporation = txtCorporation.Text;
                    if (string.IsNullOrEmpty(txtProject.Text))
                    {
                        MessageBoxEx.Show("必须填写项目名称!");
                        return;
                    }
                    model.Project = txtProject.Text;
                    model.Supplier = txtSupplier.Text;
                    model.Amount = DecimalHandler.Parse(txtAmount.Text);
                    model.DuiZhang = DecimalHandler.Parse(txtDuiZhang.Text);

                    model.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text);
                    model.ReceiptDate = DateTime.Parse(txtReceiptDate.Text);
                    model.InvoiceNum = DecimalHandler.Parse(txtInvoiceNum.Text);
                    model.ReceiptNum = DecimalHandler.Parse(txtReceiptNum.Text);
                    model.EntryTime = DateTime.Now;
                    model.SerialNo = SerialNoGenerator.GetSerialNo(SerialNoGenerator.Type.Type05SaleBill);
                    model.OperatorId = GlobalUtils.LoginUser.Id;

                    if (_bllSaleBill.Add(model) <= 0)
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
                    MessageBoxEx.Show("请检查输入是否有误，价格为0请填入0!");
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
