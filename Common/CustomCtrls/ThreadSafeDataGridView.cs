using System;
using System.Windows.Forms;

namespace TravelAgency.Common.CustomCtrls
{
    public class ThreadSafeDataGridView : System.Windows.Forms.DataGridView
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch (Exception ex)
            {
                GlobalUtils.Logger.Warn($"catched exception:{ex.Message}");
                Invalidate();
                //throw;
            }

        }
    }
}
