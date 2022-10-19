using System;
using System.Linq;
namespace NejoMainWindow
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Nejo.DataGenerator _generateDataMethod = new Nejo.DataGenerator();
        public Form1()
        {
            InitializeComponent();
            NumTxtQuantity.Maximum = 150;
            NumTxtQuantity.Minimum = 1;
            GetVersionNumber();
        }

        private void btnGenerate_Click(object sender, System.EventArgs e)
        {
            try
            {
                dgGeneratedData.Rows.Clear();
                System.Collections.Generic.List<Nejo.CustomClass.SuggestedData> _data = _generateDataMethod.GenerateData(NumTxtQuantity.Value);
                if (_data != null && _data.Any())
                    foreach (Nejo.CustomClass.SuggestedData item in _data)
                    {
                        dgGeneratedData.Rows.Add(item.UserName,
                            item.Password,
                            "mail",
                            item.ScreenName);
                    }
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            try
            {
                NumTxtQuantity.Maximum = 150;
                NumTxtQuantity.Minimum = 1;
                dgGeneratedData.Rows.Clear();
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private void btnCopyClipboard_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dgGeneratedData.Rows.Count == 0)
                {
                    System.Windows.Forms.MessageBox.Show("No available information");
                    return;
                }

                System.Text.StringBuilder _data = new System.Text.StringBuilder();
                foreach (System.Windows.Forms.DataGridViewRow row in dgGeneratedData.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (i == (row.Cells.Count - 1))
                            _data.Append(row.Cells[i].Value + System.Environment.NewLine);
                        else
                            _data.Append(row.Cells[i].Value + " ");
                    }
                }

                System.Windows.Forms.Clipboard.SetText(_data.ToString());
                System.Windows.Forms.MessageBox.Show("Copied to clipboard");
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private void dgGeneratedData_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgGeneratedData.Rows.Count == 0)
                    return;

                if (e.RowIndex == -1)
                    return;

                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    string _value = dgGeneratedData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgGeneratedData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty;
                    if (!string.IsNullOrEmpty(_value))
                        System.Windows.Forms.Clipboard.SetText(dgGeneratedData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    return;
                }
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private void GetVersionNumber()
        {
            try
            {
                string version = System.Windows.Forms.Application.ProductVersion;
                lblVersion.Text = String.Format("Version: {0}", version);
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
    }
}