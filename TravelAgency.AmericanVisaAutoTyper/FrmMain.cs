using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.AmericanVisaAutoTyper
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnTypeInBrowser_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabIndex == 0)
            {
                //第一个页面
                TypeInFirstPage();
            }
        }

        private void TypeInFirstPage()
        {

            //地区下拉框
            var ctrl = webBrowser1.Document.GetElementById(ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation.Tag
                .ToString());
            ctrl.SetAttribute("value", ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation.Text); //不会触发点击的事件
            var ret = ctrl.InvokeMember("onchange"); //触发指定事件


            //验证码输入框
            ctrl = webBrowser1.Document.GetElementById(ctl00_SiteContentPlaceHolder_ucLocation_IdentifyCaptcha1_txtCodeTextBox.Tag
                .ToString());
            ctrl.SetAttribute("value", ctl00_SiteContentPlaceHolder_ucLocation_IdentifyCaptcha1_txtCodeTextBox.Text);

            


        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            webBrowser1.Url =  new Uri("https://ceac.state.gov/GenNIV/Default.aspx");
        }

        private void btnGetAppId_Click(object sender, EventArgs e)
        {
            //获得申请ID
            var ctrl = webBrowser1.Document.GetElementById("ctl00_SiteContentPlaceHolder_lblBarcode");
            lbApplicationID.Text = ctrl.InnerHtml;
        }
    }
}
