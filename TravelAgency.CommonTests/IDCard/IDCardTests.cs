using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common.IDCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Model;

namespace TravelAgency.Common.IDCard.Tests
{
    [TestClass()]
    public class IDCardTests
    {
        [TestMethod()]
        public void IDCardTest()
        {
           int ret =  IDCardDll.LoadImageToMemory(@"I:\PassportPics\E00626332.jpg", 1); //0成功
            ret = IDCardDll.RecogIDCardEX(13,1); //>0 表示成功

            int MAX_CH_NUM = 256;
            char[] cArrFieldValue = new char[MAX_CH_NUM];
            char[] cArrFieldName = new char[MAX_CH_NUM];

            StringBuilder sb= new StringBuilder();
            //返回的model
            TravelAgency.Model.VisaInfo_Tmp visaInfo = new VisaInfo_Tmp();
            sb.Clear();
            int nRet = 0;
            //string info = "";
            for (int i = 1; ; i++)
            {
                nRet = IDCardDll.GetRecogResult(i, cArrFieldValue, ref MAX_CH_NUM);
                if (nRet == 3)
                {
                    break;
                }
                IDCardDll.GetFieldName(i, cArrFieldName, ref MAX_CH_NUM);

                //对返回的model进行修改

                string strFiledValue = new string(cArrFieldValue);
                strFiledValue = strFiledValue.Substring(0, strFiledValue.IndexOf('\0'));
                string strFiledName = new string(cArrFieldName);
                strFiledName = strFiledName.Substring(0, strFiledName.IndexOf('\0'));

                sb.Append(strFiledName);
                sb.Append(":");
                sb.Append(strFiledValue);
                sb.Append("\n");

            }
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

        [TestMethod()]
        public void LoadKernelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FreeKernelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RecogoInfoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AutoClassAndRecognizeTest()
        {
            Assert.Fail();
        }
    }
}