using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.BLL;
using TravelAgency.Common;
using TravelAgency.Common.QRCode;
using VisaInfo = TravelAgency.Model.VisaInfo;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmVisaInfoStatus : Form
    {

        private readonly BLL.ActionRecords _bllActionRecords = new ActionRecords();
        private List<Model.ActionRecords> _actionRecordses;
        private Model.VisaInfo _visaInfoModel;

        public FrmVisaInfoStatus(Model.VisaInfo model)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            _visaInfoModel = model;
            _actionRecordses = _bllActionRecords.GetVisaInfoStatusList(_visaInfoModel);
            InitializeComponent();
        }

        private void FrmVisaInfoStatus_Load(object sender, EventArgs e)
        {
            //this.labelX1.Text = @"<font color='#ED1C24'>labelX1</font>";
            labelX1.AutoSize = true;
            labelX1.WordWrap = true;
            labelX1.Text = GenStatusInfo(_actionRecordses);
            dgvStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dgvStatus.AutoGenerateColumns = false;
        }

        private string GenStatusInfo(List<Model.ActionRecords> list)
        {
            if (list == null || list.Count <= 0)
                return null;
            StringBuilder sb = new StringBuilder();
            //sb.Append(GenColorText("时间       用户       操作\r\n","#000000",12));
            for (int i = 0; i < list.Count; i++)
            {
                //if (list[i].ActType == Common.Enums.ActType._01TypeIn)
                //{

                //}
                //sb.Append("<font color='#ED1C24'>" + list[i].EntryTime.ToString() + "</font> " + list[i].UserName + " " + list[i].ActType + "\n");

                sb.Append(GenColorText("·" + list[i].EntryTime.ToString() + "\t", "#ED1C24", 12));
                sb.Append(" ");
                sb.Append(GenColorText(list[i].UserName + "\t", "#11FF11", 12));
                sb.Append(" ");
                sb.Append(GenColorText(list[i].ActType + "\t", "#000000", 14));
                sb.Append("\n");

            }

            return sb.ToString();
        }


        private string GenColorText(string info, string color, int fontSize)
        {
            return "<font color='" + color + "' size='" + fontSize + "' face='Consolas'>" + info + "</font>";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.dgvStatus.DataSource = _actionRecordses;
        }

        private void dgvStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }

        private void dgvStatus_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            var list = dgvStatus.DataSource as List<Model.ActionRecords>;

            for (int i = 0; i < dgvStatus.Rows.Count; i++)
            {
                DataGridViewRow row = dgvStatus.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();
                row.Cells["EntryTime"].Value = list[i].EntryTime + "  ("+
               DateTimeFormator.DateStringFromNow((DateTime)_actionRecordses[i].EntryTime) + ")";
            }
        }


    }
}
