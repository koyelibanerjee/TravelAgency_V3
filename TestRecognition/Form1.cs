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
using TravelAgency.Common.IDCard;
using TravelAgency.Model;

namespace TestRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int nRet;
            nRet = IDCardDll.LoadLibrary("IDCard");

            //Load engine
            string userID = "65205296201279543068";
            char[] arr = userID.ToCharArray();
            nRet = IDCardDll.InitIDCard(arr, 1, null);
            if (nRet != 0)
            {
                //MessageBoxEx.Show("Failed to initialize the recognition engine.\r\n");
                MessageBoxEx.Show("初始化失败,请检查机器是否连接正常!\r\n");
                //String strtmp = nRet.ToString();
                //textBoxDisplayResult.Text += "Return Value：" + strtmp;
                //return;
            }
            IDCardDll.SetSpecialAttribute(1, 1);
            bool _kernelLoaded = true;

            int ret = IDCardDll.LoadImageToMemory(textBoxX2.Text, 1); //0成功
            ret = IDCardDll.RecogIDCardEX(13, 0); //>0 表示成功

            int MAX_CH_NUM = 256;
            char[] cArrFieldValue = new char[MAX_CH_NUM];
            char[] cArrFieldName = new char[MAX_CH_NUM];

            StringBuilder sb = new StringBuilder();
            //返回的model
            TravelAgency.Model.VisaInfo_Tmp visaInfo = new VisaInfo_Tmp();
            sb.Clear();

            //string info = "";
            for (int i = 1; ; i++)
            {
                nRet = IDCardDll.GetRecogResult(i, cArrFieldValue, ref MAX_CH_NUM);
                if (nRet == 3)
                {
                    MessageBoxEx.Show("nRet == 3");
                    break;
                }
                IDCardDll.GetFieldName(i, cArrFieldName, ref MAX_CH_NUM);

                //对返回的model进行修改

                string strFiledValue = new string(cArrFieldValue);
                strFiledValue = strFiledValue.Substring(0, strFiledValue.IndexOf('\0'));
                string strFiledName = new string(cArrFieldName);
                strFiledName = strFiledName.Substring(0, strFiledName.IndexOf('\0'));
                MessageBoxEx.Show(strFiledName);
                MessageBoxEx.Show(strFiledValue);
                sb.Append(strFiledName);
                sb.Append(":");
                sb.Append(strFiledValue);
                sb.Append("\n");

            }
            MessageBoxEx.Show("识别成功!");
            textBoxX1.Text = sb.ToString();

            string[] infos = sb.ToString().Split('\n');

            try
            {
                visaInfo.PassportNo = infos[0].Split(':')[1];
                visaInfo.Name = infos[1].Split(':')[1];
                visaInfo.EnglishName = infos[2].Split(':')[1];
                visaInfo.Sex = infos[3].Split(':')[1];
                visaInfo.Birthday = DateTime.Parse(infos[4].Split(':')[1]);
                visaInfo.ExpiryDate = DateTime.Parse(infos[5].Split(':')[1]);
                visaInfo.Birthplace = infos[13].Split(':')[1];
                visaInfo.IssuePlace = infos[14].Split(':')[1];
                visaInfo.LicenceTime = DateTime.Parse(infos[15].Split(':')[1]);
                visaInfo.BirthPlaceEnglish = infos[18].Split(':')[1];
                visaInfo.IssuePlaceEnglish = infos[19].Split(':')[1];
            }
            catch (Exception)
            {
                //MessageBoxEx.Show("解析信息出现错误，请放好签证后重新进行识别!");
                //return null;
            }
        }
    }
}
