using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace TravelAgency.UpdateTools
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            List<string> fileList = new List<string>
            {
                "TravelAgency.CSUI.exe",
                "TravelAgency.BLL.dll",
                "TravelAgency.Model.dll",
                "TravelAgency.DAL.dll",
                "TravelAgency.Common.dll",
                "TravelAgency.DBUtility.dll"
            };
            AddFileToListView(fileList.ToArray(), false);
            txtUpdateDetails.ScrollBars = ScrollBars.Vertical;
            txtUpdateSql.ScrollBars = ScrollBars.Vertical;
        }


        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            AddFileToListView(fileDialog.FileNames, true);
        }

        private void AddFileToListView(string[] list, bool removeRoot = true)
        {
            int startIdx = listViewEx1.Items.Count;
            for (int i = 0; i < list.Length; ++i)
            {
                string filename = null;
                if (removeRoot)
                {
                    if (!list[i].Contains(txtRootDir.Text))
                    {
                        MessageBox.Show("请选择根目录内的文件!");
                        return;
                    }
                    filename = list[i].Substring(txtRootDir.Text.Length + 1);
                }
                else
                    filename = list[i];

                ListViewItem liv = new ListViewItem((++startIdx).ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(liv, filename);
                liv.SubItems.Add(subItem);
                listViewEx1.Items.Add(liv);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("insert into ProgramVersion(version,update_files,udapte_details) ");
            sb.AppendLine($"values({txtVersion.Text},");
            for (int i = 0; i < listViewEx1.Items.Count; ++i)
            {
                string filename = listViewEx1.Items[i].SubItems[1].Text;
                if (i != 0)
                    sb.Append("'|");
                else sb.Append("'");
                sb.Append($"{filename}@01'");
                if (i != listViewEx1.Items.Count - 1)
                    sb.AppendLine("+");
                else sb.AppendLine();
            }
            sb.Append($",'{txtUpdateDetails.Text}')");
            txtUpdateSql.Text = sb.ToString();
        }

        private void btnCopyUpdateFiles_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtUpdateFilesSaveDir.Text))
            {
                Directory.CreateDirectory(txtUpdateFilesSaveDir.Text);
            }
            for (int i = 0; i < listViewEx1.Items.Count; ++i)
            {
                string updatefilename = listViewEx1.Items[i].SubItems[1].Text;
                string dstfilename = txtUpdateFilesSaveDir.Text + "/" + updatefilename;
                string srcfilename = txtRootDir.Text + "/" + updatefilename;
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(dstfilename)))
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dstfilename));
                File.Copy(srcfilename, dstfilename, true);
            }
            Process.Start(txtUpdateFilesSaveDir.Text);
        }
    }
}
