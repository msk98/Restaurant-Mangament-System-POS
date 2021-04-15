using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;

namespace rmsid2
{
    public partial class excelexportcs : Form
    {
        public excelexportcs()
        {
            InitializeComponent();
        }
        DataTableCollection tableCollection;

        private void buttonbrowse_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog=new OpenFileDialog() { Filter="Excel 97-2003 workbook|*.xls|Excel workbook|*.xlsx"})
            {
                if(openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    textBoxfiletext.Text = openFileDialog.FileName;
                    using(var stream =File.Open(openFileDialog.FileName,FileMode.Open,FileAccess.Read))
                    {
                        using(IExcelDataReader reader=ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            }) ;
                            tableCollection = result.Tables;
                            comboBoxsheet.Items.Clear();
                            foreach(DataTable table in tableCollection)
                            {
                                comboBoxsheet.Items.Add(table.TableName);
                            }
                        }
                    }
                }
            }
        }

        private void comboBoxsheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[comboBoxsheet.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
        }

        private void buttoninsert_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if(dataGridView1.Rows.Count>1)
            {
                foreach (DataGridViewRow dgRow in dataGridView1.Rows)
                {
                    conn.insertCustomers(dgRow.Cells[1].Value.ToString(), dgRow.Cells[0].Value.ToString(), dgRow.Cells[2].Value.ToString());
                }
            }
           
        }
    }
}
