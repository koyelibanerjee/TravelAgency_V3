using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.Model.Enums;

namespace TravelAgency.AmericanVisaAutoTyper
{
    public partial class FrmMain : Form
    {
        struct ComboBoxItem
        {
            public ComboBoxItem(string t, string v)
            {
                text = t;
                value = v;
            }
            public string text { get; }
            public string value { get; }
        }

        private string GetComboBoxItemValue(ComboBox cb)
        {
            return ((ComboBoxItem)(cb.SelectedItem)).value;
        }

        #region Utils

        private void TextBoxInput(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
                return;
            var ctrl = webBrowser1.Document.GetElementById(txt.Tag.ToString());
            if (ctrl == null)
                return;
            ctrl.SetAttribute("value", txt.Text);
        }

        private void ComboBoxInput(ComboBox cb)
        {
            if (string.IsNullOrEmpty(cb.Text))
                return;
            var ctrl = webBrowser1.Document.GetElementById(cb.Tag.ToString());
            if (ctrl == null)
                return;
            ctrl.SetAttribute("value", GetComboBoxItemValue(cb)); //不会触发点击的事件
        }

        private void RadioButtonInput(RadioButton rbtn)
        {
            var ctrl = webBrowser1.Document.GetElementById(rbtn.Tag.ToString());
            if (ctrl == null)
                return;
            ctrl.InvokeMember("click"); //触发指定事件
        }

        private void InvokeMember(string id, string e)
        {
            var ctrl = webBrowser1.Document.GetElementById(id);
            if (ctrl == null)
                return;
            ctrl.InvokeMember(e); //触发指定事件
        }

        private void DateInput(TextBox year, TextBox month, TextBox day)
        {
            //生日
            TextBoxInput(year); //年
            //日单独处理
            var ctrl = webBrowser1.Document.GetElementById(day.Tag.ToString());
            if (ctrl != null)
                ctrl.SetAttribute("value", day.Text.PadLeft(2, '0')); //TODO：正确性校验
            //月单独处理
            ctrl = webBrowser1.Document.GetElementById(month.Tag.ToString());
            if (ctrl != null)
                ctrl.SetAttribute("value", Month.list[int.Parse(month.Text) - 1]); //TODO：正确性校验
        }

        #endregion


        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnTypeInBrowser_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTabIndex)
            {
                case 0:
                    //第一个页面
                    TypeIn1stPage();
                    break;

                case 1:
                    //第一个页面
                    TypeIn2ndPage();
                    break;

                case 2:
                    //第一个页面
                    TypeIn3rdPage();
                    break;
                case 3:
                    //第一个页面
                    TypeIn4thPage();
                    break;
            }
        }


        #region 页面输入
        private void TypeIn1stPage()
        {

            //地区下拉框
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_TYPE);
            InvokeMember("ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation", "onchange"); //地区下拉框需要触发一下事件

            //验证码输入框
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxPPT_NUM);

        }

        private void TypeIn2ndPage()
        {
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_SURNAME);//英文姓
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_GIVEN_NAME); //英文名
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_FULL_NAME_NATIVE); //中文姓名
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_POB_CITY); //城市
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_POB_ST_PROVINCE); //省份
            DateInput(ctl00_SiteContentPlaceHolder_FormView1_tbxDOBYear,
                ctl00_SiteContentPlaceHolder_FormView1_ddlDOBMonth,
                ctl00_SiteContentPlaceHolder_FormView1_ddlDOBDay);


            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_POB_CNTRY); //国家
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS); //国家


            if (ctl00_SiteContentPlaceHolder_FormView1_rblOtherNames_0.Checked) //是否有曾用名
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblOtherNames_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblOtherNames_1);


            if (ctl00_SiteContentPlaceHolder_FormView1_rblTelecodeQuestion_0.Checked) //是否有姓名电码
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblTelecodeQuestion_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblTelecodeQuestion_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblAPP_GENDER_0.Checked) //性别
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblAPP_GENDER_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblAPP_GENDER_1);



        }



        private void TypeIn3rdPage()
        {
            InvokeMember("ctl00_SiteContentPlaceHolder_FormView1_cbexAPP_SSN_NA", "click"); //美国ID编辑框禁用
            InvokeMember("ctl00_SiteContentPlaceHolder_FormView1_cbexAPP_TAX_ID_NA", "click"); //美国税号禁用

            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_NATL); //国家

            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_NATIONAL_ID);//身份证

            if (ctl00_SiteContentPlaceHolder_FormView1_rblAPP_OTH_NATL_IND_0.Checked) //曾有其他国家国籍
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblAPP_OTH_NATL_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblAPP_OTH_NATL_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblPermResOtherCntryInd_0.Checked) //是其他国家常驻民
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPermResOtherCntryInd_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPermResOtherCntryInd_1);
        }

        private void TypeIn4thPage()
        {
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_ADDR_LN1);//街道地址1
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_ADDR_LN2);//街道地址2
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_ADDR_CITY);//城市
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_ADDR_STATE);//省份
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_ADDR_POSTAL_CD);//邮编

            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlCountry); //国家

            if (ctl00_SiteContentPlaceHolder_FormView1_rblMailingAddrSame_0.Checked) //通信地址同家庭地址
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblMailingAddrSame_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblMailingAddrSame_1);

            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_HOME_TEL);//联系方式1
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_MOBILE_TEL);//联系方式2
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_BUS_TEL);//工作电话
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxAPP_EMAIL_ADDR);//邮箱
        }

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("https://ceac.state.gov/GenNIV/Default.aspx");
            InitControls();
        }

        void InitControls()
        {
            #region 开始申请
            //领区下拉框
            ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation.Items.Add(new ComboBoxItem("CHINA, BEIJING", "BEJ"));
            ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation.Items.Add(new ComboBoxItem("CHINA, CHENGDU", "CHE"));
            ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation.Items.Add(new ComboBoxItem("CHINA, GUANGZHOU", "GUZ"));
            ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation.Items.Add(new ComboBoxItem("CHINA, SHANGHAI", "SHG"));
            ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation.Items.Add(new ComboBoxItem("CHINA, SHENYANG", "SNY"));

            #endregion

            #region 个人信息1
            //婚姻状况
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("MARRIED", "M"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("COMMON LAW MARRIAGE", "C"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("CIVIL UNION/DOMESTIC PARTNERSHIP", "P"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("SINGLE", "S"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("WIDOWED", "W"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("DIVORCED", "D"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("LEGALLY SEPARATED", "L"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_MARITAL_STATUS.Items.Add(new ComboBoxItem("OTHER", "O"));

            //国家
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_POB_CNTRY.Items.Add(new ComboBoxItem("CHINA", "CHIN"));

            #endregion

            #region 个人信息2
            ctl00_SiteContentPlaceHolder_FormView1_ddlAPP_NATL.Items.Add(new ComboBoxItem("CHINA", "CHIN")); //国家/地区
            #endregion

            #region 地址和联系方式
            ctl00_SiteContentPlaceHolder_FormView1_ddlCountry.Items.Add(new ComboBoxItem("CHINA", "CHIN")); //国家/地区
            #endregion

            #region 护照
            ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_TYPE.Items.Add(new ComboBoxItem("REGULAR", "R"));//护照类型
            ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_TYPE.Items.Add(new ComboBoxItem("OFFICIAL", "O"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_TYPE.Items.Add(new ComboBoxItem("DIPLOMATIC", "D"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_TYPE.Items.Add(new ComboBoxItem("LAISSEZ-PASSER", "L"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_TYPE.Items.Add(new ComboBoxItem("OTHER", "T"));

            ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_ISSUED_CNTRY.Items.Add(new ComboBoxItem("CHINA", "CHIN")); //护照发行地
            #endregion


        }




        private void btnGetAppId_Click(object sender, EventArgs e)
        {
            //获得申请ID
            var ctrl = webBrowser1.Document.GetElementById("ctl00_SiteContentPlaceHolder_lblBarcode");
            txtApplicationID.Text = ctrl.InnerHtml;
        }
    }
}
