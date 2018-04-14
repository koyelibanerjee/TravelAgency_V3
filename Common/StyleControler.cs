using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Common
{
    public class StyleControler
    {
        public static void SetDgvStyle(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.ReadOnly = true;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
 

            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 10.0f, FontStyle.Bold);
            //dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 174, 210);
            //dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 174, 219);
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            //dataGridView1.GridColor = Color.FromArgb(224, 224, 224);
            //dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 227, 242);
            //dataGridView1.RowHeadersDefaultCellStyle.Font = new Font("Consolas", 10.0f, FontStyle.Bold);
            //dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;


            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10.0f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(48, 126, 204);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(234, 242, 251); 
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 227, 242);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.RowHeadersDefaultCellStyle.Font = new Font("Consolas", 10.0f, FontStyle.Bold);
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(234,242,251);
            dgv.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(48, 126, 204);
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 227, 242);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dgv.GridColor = Color.FromArgb(224, 224, 224);


            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 227, 242);
            dgv.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(110, 110, 110);

        }

 
    }
}
