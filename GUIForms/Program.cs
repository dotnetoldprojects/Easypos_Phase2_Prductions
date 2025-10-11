using Easypos;
using GUIForms.Forms.SendMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ربط الأحداث اللي تمسك كل الأخطاء
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
        
        // الأخطاء اللي بتحصل داخل UI Thread
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        // الأخطاء اللي بتحصل في background threads
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        // هنا تسجل الخطأ في قاعدة البيانات
        private static void HandleException(Exception ex)
        {
            try
            {

                // مثال بسيط لتسجيل في قاعدة بيانات SQL
                using (var conn = new System.Data.SqlClient.SqlConnection("Your_Connection_String"))
                using (var cmd = new System.Data.SqlClient.SqlCommand(
                    "INSERT INTO ErrorLog (Message, StackTrace, Date) VALUES (@msg, @stack, @date)", conn))
                {
                    cmd.Parameters.AddWithValue("@msg", ex.Message);
                    cmd.Parameters.AddWithValue("@stack", ex.StackTrace ?? "");
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // ممكن كمان تعرض رسالة للمستخدم
                MessageBox.Show("حدث خطأ في النظام، تم تسجيله تلقائيًا.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                // لو حصل خطأ أثناء تسجيل الخطأ نفسه
                MessageBox.Show("تعذر تسجيل الخطأ.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
