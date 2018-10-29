using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowserDemo
{
    public partial class Form1 : Form
    {
        private HtmlElement inputCtrl = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBox1.Text = "https://ceac.state.gov/genniv/";
            textBox1.Text = "file:///C:/TravelAgency_V3/WebBrowserDemo/HTMLPage1.html";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //inputCtrl = webBrowser1.Document.GetElementById("ctl00_SiteContentPlaceHolder_ucLocation_ddlLocation");
            ////inputCtrl.InnerText = "abc";
            //inputCtrl.SetAttribute("value", "CHE"); //不会触发点击的事件
            //inputCtrl.SetAttribute("selectedIndex", "12"); //同上
            //var ret = inputCtrl.InvokeMember("onchange"); //触发指定事件

            inputCtrl = webBrowser1.Document.GetElementById("checkbox1");
            inputCtrl.InvokeMember("click");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            inputCtrl = webBrowser1.Document.GetElementById("radioN");
            inputCtrl.InvokeMember("click");
        }
    }
}
