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

        private void InvokeClick(string id)
        {
            InvokeMember(id, "click");
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
            var str = ctrl.GetAttribute("value");
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
                    TypeIn1stPage();
                    break;
                case 1:
                    TypeIn2ndPage();
                    break;
                case 2:
                    TypeIn3rdPage();
                    break;
                case 3:
                    TypeIn4thPage();
                    break;
                case 4:
                    TypeIn5thPage(); //护照信息
                    break;
                case 5: //以前在美国的经历
                    TypeIn6thPage();
                    break;
                case 6: //美国联系人
                    TypeIn7thPage();
                    break;
                case 7: //亲属
                    TypeIn8thPage();
                    break;
                case 8: //伴侣
                    TypeIn9thPage();
                    break;
                case 9: //当前工作教育信息
                    TypeIn10thPage();
                    break;
                case 10: //以前的工作教育信息
                    TypeIn11thPage();
                    break;
                case 11: //额外的工作教育信息
                    TypeIn12thPage();
                    break;
                case 12: //背景和安全
                    TypeIn13thPage();
                    break;
            }
        }

        private void TypeIn6thPage()
        {
            if (ctl00_SiteContentPlaceHolder_FormView1_rblPREV_US_TRAVEL_IND_0.Checked) //曾到过美国
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPREV_US_TRAVEL_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPREV_US_TRAVEL_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblPREV_VISA_IND_0.Checked) //
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPREV_VISA_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPREV_VISA_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblPREV_VISA_REFUSED_IND_0.Checked) //
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPREV_VISA_REFUSED_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPREV_VISA_REFUSED_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblIV_PETITION_IND_0.Checked) //
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblIV_PETITION_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblIV_PETITION_IND_1);
        }

        #region 页面输入
        private void TypeIn1stPage()
        {

            //地区下拉框
            ComboBoxInput(ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation);
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

        private void TypeIn5thPage()
        {
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_TYPE); //护照类型
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_ISSUED_CNTRY); //护照发行地

            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxPPT_NUM);//护照号码
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxPPT_BOOK_NUM);//护照本号码

            DateInput(ctl00_SiteContentPlaceHolder_FormView1_tbxPPT_ISSUEDYear, //发行日期
                ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_ISSUED_DTEMonth,
                ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_ISSUED_DTEDay);

            DateInput(ctl00_SiteContentPlaceHolder_FormView1_tbxPPT_EXPIREYear, //过期日期
                ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_EXPIRE_DTEMonth,
                ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_EXPIRE_DTEDay);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblLOST_PPT_IND_0.Checked) //护照遗失过
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblLOST_PPT_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblLOST_PPT_IND_1);

            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxPPT_ISSUED_IN_CITY);
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxPPT_ISSUED_IN_STATE);
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_ISSUED_IN_CNTRY);
        }

        private void TypeIn7thPage()
        {
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxUS_POC_SURNAME);
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxUS_POC_GIVEN_NAME);
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxUS_POC_ORGANIZATION);
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlUS_POC_REL_TO_APP);

        }

        private void TypeIn8thPage()
        {
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxFATHER_SURNAME);
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxFATHER_GIVEN_NAME);

            DateInput(ctl00_SiteContentPlaceHolder_FormView1_tbxFathersDOBYear, 
                ctl00_SiteContentPlaceHolder_FormView1_ddlFathersDOBMonth,
                ctl00_SiteContentPlaceHolder_FormView1_ddlFathersDOBDay);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblFATHER_LIVE_IN_US_IND_0.Checked) //父在美国
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblFATHER_LIVE_IN_US_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblFATHER_LIVE_IN_US_IND_1);

            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxMOTHER_SURNAME);
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxMOTHER_GIVEN_NAME);

            DateInput(ctl00_SiteContentPlaceHolder_FormView1_tbxMothersDOBYear,
                ctl00_SiteContentPlaceHolder_FormView1_ddlMothersDOBMonth,
                ctl00_SiteContentPlaceHolder_FormView1_ddlMothersDOBDay);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblMOTHER_LIVE_IN_US_IND_0.Checked) //母在美国
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblMOTHER_LIVE_IN_US_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblMOTHER_LIVE_IN_US_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblUS_IMMED_RELATIVE_IND_0.Checked) //除父母外还有其他亲属在美国
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblUS_IMMED_RELATIVE_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblUS_IMMED_RELATIVE_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblUS_OTHER_RELATIVE_IND_0.Checked) //还有其他亲属在美国
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblUS_OTHER_RELATIVE_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblUS_OTHER_RELATIVE_IND_1);

            
        }

        private void TypeIn9thPage()
        {
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxFATHER_SURNAME);
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxFATHER_GIVEN_NAME);

            DateInput(ctl00_SiteContentPlaceHolder_FormView1_tbxFathersDOBYear, ctl00_SiteContentPlaceHolder_FormView1_ddlFathersDOBMonth, ctl00_SiteContentPlaceHolder_FormView1_ddlFathersDOBDay);

            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseNatDropDownList);
            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxSpousePOBCity);
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlSpousePOBCountry);
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseAddressType);
        }

        private void TypeIn10thPage()
        {
            ComboBoxInput(ctl00_SiteContentPlaceHolder_FormView1_ddlPresentOccupation);
        }


        private void TypeIn11thPage()
        {
            if (ctl00_SiteContentPlaceHolder_FormView1_rblPreviouslyEmployed_0.Checked) //以前是否有其他工作
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPreviouslyEmployed_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblPreviouslyEmployed_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblOtherEduc_0.Checked) //以前是否有其他教育经历:
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblOtherEduc_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblOtherEduc_1);

        }


        private void TypeIn12thPage()
        {
            if (ctl00_SiteContentPlaceHolder_FormView1_rblCLAN_TRIBE_IND_0.Checked) //属于宗教或团体
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblCLAN_TRIBE_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblCLAN_TRIBE_IND_1);

            TextBoxInput(ctl00_SiteContentPlaceHolder_FormView1_tbxSpousePOBCity); //使用的语言


            if (ctl00_SiteContentPlaceHolder_FormView1_rblCOUNTRIES_VISITED_IND_0.Checked) //去其他国家旅游过
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblCOUNTRIES_VISITED_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblCOUNTRIES_VISITED_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblORGANIZATION_IND_0.Checked) //是否曾经在专业、社会、公益组织工作过:
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblORGANIZATION_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblORGANIZATION_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblSPECIALIZED_SKILLS_IND_0.Checked) //是否有某项特殊技能如:核能、生物学、化学等
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblSPECIALIZED_SKILLS_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblSPECIALIZED_SKILLS_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblMILITARY_SERVICE_IND_0.Checked) //是否服过兵役
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblMILITARY_SERVICE_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblMILITARY_SERVICE_IND_1);

            if (ctl00_SiteContentPlaceHolder_FormView1_rblINSURGENT_ORG_IND_0.Checked) //你是否曾在准军事部队、义务警员、叛乱组织、游击队或叛乱组织服役、或参与其中
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblINSURGENT_ORG_IND_0);
            else
                RadioButtonInput(ctl00_SiteContentPlaceHolder_FormView1_rblINSURGENT_ORG_IND_1);



        }

        private void TypeIn13thPage()
        {
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
            ctl00_SiteContentPlaceHolder_FormView1_ddlPPT_ISSUED_IN_CNTRY.Items.Add(new ComboBoxItem("CHINA", "CHIN")); //护照发行 国家

            #endregion

            #region 美国联系人

            ctl00_SiteContentPlaceHolder_FormView1_ddlUS_POC_REL_TO_APP.Items.Add(new ComboBoxItem("RELATIVE", "R"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlUS_POC_REL_TO_APP.Items.Add(new ComboBoxItem("SPOUSE", "S"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlUS_POC_REL_TO_APP.Items.Add(new ComboBoxItem("FRIEND", "F"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlUS_POC_REL_TO_APP.Items.Add(new ComboBoxItem("BUSINESS ASSOCIATE", "B"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlUS_POC_REL_TO_APP.Items.Add(new ComboBoxItem("SCHOOL OFFICIAL", "H"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlUS_POC_REL_TO_APP.Items.Add(new ComboBoxItem("OTHER", "O"));

            #endregion

            #region 伴侣信息

            ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseNatDropDownList.Items.Add(new ComboBoxItem("CHINA", "CHIN"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlSpousePOBCountry.Items.Add(new ComboBoxItem("CHINA", "CHIN"));

            //伴侣地址类型
            ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseAddressType.Items.Add(new ComboBoxItem("Same as Home Address", "H"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseAddressType.Items.Add(new ComboBoxItem("Same as Mailing Address", "M"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseAddressType.Items.Add(new ComboBoxItem("Same as U.S. Contact Address", "U"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseAddressType.Items.Add(new ComboBoxItem("Do Not Know", "D"));
            ctl00_SiteContentPlaceHolder_FormView1_ddlSpouseAddressType.Items.Add(new ComboBoxItem("Other (Specify Address)", "O"));


            #endregion


            #region 工作信息
            ctl00_SiteContentPlaceHolder_FormView1_ddlPresentOccupation.Items.Add(new ComboBoxItem("RETIRED", "RT"));// TODO:还有其他的

            #endregion

        }




        private void btnGetAppId_Click(object sender, EventArgs e)
        {
            //获得申请ID
            var ctrl = webBrowser1.Document.GetElementById("ctl00_SiteContentPlaceHolder_lblBarcode");
            txtApplicationID.Text = ctrl.InnerHtml;
        }


        #region 安全和背景

        private void btnOneyKeyTypeInPart1_Click(object sender, EventArgs e)
        {
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblDisease_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblDisorder_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblDruguser_1");
        }


        #endregion

        private void btnOneyKeyTypeInPart2_Click(object sender, EventArgs e)
        {
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblArrested_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblControlledSubstances_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblProstitution_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblMoneyLaundering_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblHumanTrafficking_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblAssistedSevereTrafficking_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblHumanTraffickingRelated_1");
        }

        private void btnOneyKeyTypeInPart3_Click(object sender, EventArgs e)
        {
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblIllegalActivity_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblTerroristActivity_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblTerroristSupport_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblTerroristOrg_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblGenocide_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblTorture_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblExViolence_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblChildSoldier_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblReligiousFreedom_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblPopulationControls_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblTransplant_1");

        }

        private void btnOneyKeyTypeInPart4_Click(object sender, EventArgs e)
        {
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblImmigrationFraud_1");
        }

        private void btnOneyKeyTypeInPart5_Click(object sender, EventArgs e)
        {
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblChildCustody_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblVotingViolation_1");
            InvokeClick("ctl00_SiteContentPlaceHolder_FormView1_rblRenounceExp_1");
        }
    }
}
