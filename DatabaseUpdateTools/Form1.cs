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
using TravelAgency.Model;

namespace DatabaseUpdateTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 给ActionRecords加上国家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            new Thread(UpdateActionList) { IsBackground = true }.Start();
        }

        private void UpdateActionList()
        {
            this.Invoke(new Action(() =>
            {
                buttonX2.Enabled = false;
                buttonX1.Enabled = false;
                var bllAction = new TravelAgency.BLL.ActionRecords();
                var bllVisaInfo = new TravelAgency.BLL.VisaInfo();

                var actionlist = bllAction.GetModelList(string.Empty);
                progressBarX1.Value = 0;
                progressBarX1.Maximum = actionlist.Count;

                //var modellist = bllVisaInfo.GetModelList(string.Empty);
                for (int i = 0; i < actionlist.Count; i++)
                {
                    var list = bllVisaInfo.GetModelList("visainfo_id = '" + actionlist[i].VisaInfo_id + "' ");
                    if (list.Count < 1 || string.IsNullOrEmpty(list[0].Country))
                        continue;
                    actionlist[i].Country = list[0].Country;
                    if (!bllAction.Update(actionlist[i]))
                        MessageBoxEx.Show("id = " + actionlist[i].id + "更新失败!");
                    progressBarX1.Value++;
                }
                buttonX2.Enabled = true;
                buttonX1.Enabled = true;
            }));
            MessageBoxEx.Show("更新完成!");

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            new Thread(UpdateScanedInfo) { IsBackground = true }.Start();
        }

        private void UpdateScanedInfo()
        {
            this.Invoke(new Action(() =>
            {
                buttonX2.Enabled = false;
                buttonX1.Enabled = false;
                var bllAction = new TravelAgency.BLL.ActionRecords();
                var bllVisaInfo = new TravelAgency.BLL.VisaInfo();
                var bllUser = new TravelAgency.BLL.AuthUser();

                var visainfoList = bllVisaInfo.GetModelList(string.Empty);
                progressBarX1.Maximum = visainfoList.Count;
                progressBarX1.Value = 0;

                foreach (var visaInfo in visainfoList)
                {
                    TravelAgency.Model.ActionRecords log = new TravelAgency.Model.ActionRecords();
                    log.ActType = "00录入(扫描)";
                    if (!string.IsNullOrEmpty(visaInfo.CheckPerson))
                    {
                        log.UserName = visaInfo.CheckPerson;
                        var userlist = bllUser.GetModelList(" username ='" + visaInfo.CheckPerson + " '");
                        if (userlist.Count > 0)
                        {
                            log.WorkId = userlist[0].WorkId;
                        }
                    }
                    log.VisaInfo_id = visaInfo.VisaInfo_id;
                    log.EntryTime = visaInfo.EntryTime;
                    log.Country = visaInfo.Country;

                    if (bllAction.Add(log) <= 0)
                        MessageBoxEx.Show("更新失败！");
                    progressBarX1.Value += 1;
                }
                buttonX2.Enabled = true;
                buttonX1.Enabled = true;
            }));
            MessageBoxEx.Show("更新完成!");

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            TravelAgency.BLL.Visa bllVisa = new TravelAgency.BLL.Visa();
            var list = bllVisa.GetModelList(string.Empty);
            


        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            TravelAgency.BLL.DeniedVisaInfo deniedVisaInfo = new TravelAgency.BLL.DeniedVisaInfo();
            TravelAgency.BLL.VisaInfo visaInfoBll = new TravelAgency.BLL.VisaInfo();
            var list = deniedVisaInfo.GetModelList("");
            foreach (var deniedVisainfo in list)
            {
               var visainfoModel =  visaInfoBll.GetLatestModelByPassportNo(deniedVisainfo.PassportNo);
                deniedVisaInfo.
            }


        }
    }

    
}
