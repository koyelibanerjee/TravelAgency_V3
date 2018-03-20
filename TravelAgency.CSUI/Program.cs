using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TravelAgency.Common;

namespace TravelAgency.CSUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.ThreadException += Application_ThreadException; //未捕捉异常监听
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain.FrmLogin());
        }


        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(string.Format("捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}\r\nCLR即将退出：{3}", ex.GetType(),
                ex.Message, ex.StackTrace, e.IsTerminating));

            GlobalUtils.Logger.Error("--------------未捕获异常--------------",ex);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            GlobalUtils.Logger.Error("--------------未捕获异常--------------", ex);
            MessageBox.Show(string.Format("捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}", ex.GetType(), ex.Message, ex.StackTrace));
        }

    }
}
