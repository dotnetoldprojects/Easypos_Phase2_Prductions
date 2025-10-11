using Domain.Models;
using Easypos;
using GUIForms.Forms.SendMessages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UOW;

namespace GUIForms
{
    internal static class Program
    {
        private static IUnitofwork _IUW;
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
            _IUW = new Unitofwork(new EasyposEntities());
            try
            {
                // تحليل مكان الخطأ من StackTrace
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(st.FrameCount - 1); // آخر Frame غالبًا هو مكان الخطأ الفعلي

                string fileName = frame?.GetFileName() ?? "Unknown File";
                int lineNumber = frame?.GetFileLineNumber() ?? 0;
                string methodName = frame?.GetMethod()?.Name ?? "Unknown Method";
                string className = frame?.GetMethod()?.DeclaringType?.FullName ?? "Unknown Class";

                // اسم الفورم الحالية (لو في واجهة مفتوحة)
                string currentForm = Application.OpenForms.Count > 0
                    ? Application.OpenForms[0].Name
                    : "No Active Form";

                // تسجيل في قاعدة البيانات
                _IUW.exceptionpros.Insert(new exceptionpro
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace ?? "",
                    ClassName = className,
                    MethodName = methodName,
                    FileName = fileName,
                    LineNumber = lineNumber.ToString(),
                    FormName = currentForm,
                    Date = DateTime.Now
                });
                _IUW.Complete();
                MessageBox.Show(
                    $"حدث خطأ وتم تسجيله:\n\n{ex.Message}",
                    "خطأ في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception logEx)
            {
                MessageBox.Show($"تعذر تسجيل الخطأ: {logEx.Message}", "Fatal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        }
}
