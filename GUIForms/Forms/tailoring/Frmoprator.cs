using Domain.Models;
using GUIForms.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UOW;

namespace GUIForms.Forms.tailoring
{
    public partial class Frmoprator : Form
    {
        company DC;
        IUnitofwork _IUW;
        List<Tailopratordto> _LTO;
        public Frmoprator()
        {
            InitializeComponent();
            Loading();
        }
        public void Loading()
        {
            DC = (company)LanguageHelper.ApplyLanguage(this);
            _IUW = new Unitofwork(new EasyposEntities());
            _LTO = new List<Tailopratordto>();
            _LTO = _IUW.tailorheaders.GetQueryable()
                              .Include("thirdparty")
                              .Select(tailorheader => new Tailopratordto // <= استخدم الكلاس هنا
                              {
                                  Id = tailorheader.Id,
                                  Btcn = tailorheader.BTCNumber != null ? tailorheader.BTCNumber.Value : 0,
                                  ThirdPartyName = tailorheader.thirdparty != null ? tailorheader.thirdparty.Name : "عميل افتراضي",
                                  ClothesNumber = tailorheader.Clothesnumber != null ? tailorheader.Clothesnumber.Value : 0,
                                  ClothesReady = tailorheader.Clothesready == null ? 0 : tailorheader.Clothesready.Value, // تأكد من التعامل مع القيمة القابلة لـ Null
                                  ClothesRemining = tailorheader.Clothesremining != null ? tailorheader.Clothesremining.Value : 0
                              }).ToList();

            //dgvoprator.DataSource = _LTO;
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Btnsave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvoprator.Rows)
            {
                if (row.IsNewRow)
                    continue;
                var clothesCell = row.Cells["ClothesReady"]?.Value;
                // اقرأ الـ Id من الخلية (غير الاسم لو عمودك اسمه مختلف)
                var idCell = row.Cells["Id"]?.Value;
                if (idCell == null)
                    continue; // لو مفيش Id تجاهل الصف

                string idValue = idCell.ToString();

                string clothesValue = clothesCell?.ToString() ?? string.Empty;

                // جِب الكائن الأصلي من الريبوزيتوري/الـ UnitOfWork
                var originalHeader = _IUW.tailorheaders.Find(x => x.Id == idValue);
                if (originalHeader != null)
                {
                    var Clothesnumber = row.Cells["Clothesnumber"]?.Value;

                    // حدّث خاصية واحدة فقط
                    originalHeader.Clothesready = int.Parse(clothesValue);
                    if (int.Parse(clothesValue) > originalHeader.Clothesnumber)
                    {
                        MessageBox.Show("لا يمكن ان تكون الكميه المستلمه اكبر من المطلوبه","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // حدّث في الريبوزيتوري (لا تنفذ Complete هنا لكل صف)
                        _IUW.tailorheaders.Update(originalHeader);
                    }
                }
                // لو ما لقيتش originalHeader: ممكن تتجاهل أو تسجل لوج أو تضيف كائن جديد حسب حاجتك
            }

            // حفظ دفعة واحدة بعد الانتهاء من كل الصفوف
            _IUW.Complete();

            MessageBox.Show("تم تحديث حقل Clothesready لجميع الصفوف بنجاح ✅", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //// لف على كل الصفوف في DataGridView
            //foreach (DataGridViewRow row in dgvoprator.Rows)
            //{
            //    // تأكد إن الصف مش صف جديد (الصف الفاضي اللي في الآخر)
            //    if (!row.IsNewRow)
            //    {
            //        // حاول تحويل الـ DataBoundItem إلى الكائن بتاعك
            //        Tailopratordto editedRow = row.DataBoundItem as Tailopratordto;

            //        if (editedRow != null)
            //        {
            //            // تحميل الكائن الأصلي من قاعدة البيانات
            //            var originalHeader = _IUW.tailorheaders.Find(x => x.Id == editedRow.Id);
            //            if (originalHeader != null)
            //            {
            //                // حدّث الخصائص اللي ممكن تكون اتعدلت
            //                originalHeader.Clothesready = editedRow.ClothesReady;

            //                // حدث الكائن في الواجهة
            //                _IUW.tailorheaders.Update(originalHeader);
            //            }
            //        }
            //    }
            //}

            //// بعد ما تخلص كل الصفوف، اعمل حفظ واحد بس
            //_IUW.Complete();

            //MessageBox.Show("تم حفظ جميع التعديلات بنجاح ✅", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(textBox15.Text.Trim()))
                {
                    string searchText = textBox15.Text.Trim();

                    // 1. ابحث عن العنصر داخل القائمة الأصلية
                    var foundItem = _LTO.FirstOrDefault(x => x.Id == searchText || x.Btcn == int.Parse(searchText));

                    if (foundItem != null)
                    {
                        int newRowIndex = dgvoprator.Rows.Add();
                        dgvoprator.Rows[newRowIndex].Cells["Id"].Value = foundItem.Id;
                        dgvoprator.Rows[newRowIndex].Cells["ThirdPartyName"].Value = foundItem.ThirdPartyName;
                        dgvoprator.Rows[newRowIndex].Cells["ClothesNumber"].Value = foundItem.ClothesNumber;
                        dgvoprator.Rows[newRowIndex].Cells["ClothesReady"].Value = foundItem.ClothesReady;
                        dgvoprator.Rows[newRowIndex].Cells["ClothesRemining"].Value = foundItem.ClothesRemining;
                        textBox15.Clear();
                    }
                    else
                    {
                        // لو مش لاقي العنصر، ممكن تمسح كل الصفوف أو تعمل حاجة تانية
                        dgvoprator.Rows.Clear();
                    }
                }
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox15.Text.Trim()))
            {
                string searchText = textBox15.Text.Trim();

                // 1. ابحث عن العنصر داخل القائمة الأصلية
                var foundItem = _LTO.FirstOrDefault(x => x.Id == searchText || x.Btcn == int.Parse(searchText));

                if (foundItem != null)
                {
                    int newRowIndex = dgvoprator.Rows.Add();
                    dgvoprator.Rows[newRowIndex].Cells["Id"].Value = foundItem.Id;
                    dgvoprator.Rows[newRowIndex].Cells["ThirdPartyName"].Value = foundItem.ThirdPartyName;
                    dgvoprator.Rows[newRowIndex].Cells["ClothesNumber"].Value = foundItem.ClothesNumber;
                    dgvoprator.Rows[newRowIndex].Cells["ClothesReady"].Value = foundItem.ClothesReady;
                    dgvoprator.Rows[newRowIndex].Cells["ClothesRemining"].Value = foundItem.ClothesRemining;
                    textBox15.Clear();
                }
                else
                {
                    // لو مش لاقي العنصر، ممكن تمسح كل الصفوف أو تعمل حاجة تانية
                    dgvoprator.Rows.Clear();
                }
            }
        }
        private void dgvoprator_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var editedCell = dgvoprator.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var otherCell = dgvoprator.Rows[e.RowIndex].Cells[2];
            // تأكد إن القيم مش null
            if (editedCell.Value != null && otherCell.Value != null)
            {
                // حاول تحول القيم لأرقام (حسب نوع العمود)
                if (decimal.TryParse(editedCell.Value.ToString(), out decimal editedValue) &&
                    decimal.TryParse(otherCell.Value.ToString(), out decimal otherValue))
                {
                    if (editedValue > otherValue)
                    {
                        MessageBox.Show("لا يمكن ان تكون الكميه المستلمه اكبر من المطلوبه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
    }
}
