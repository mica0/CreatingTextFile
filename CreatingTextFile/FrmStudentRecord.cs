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

namespace CreatingTextFile
{
    public partial class FrmStudentRecord : Form
    {
        public FrmStudentRecord()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.Show();
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\\Users\\vcaga\\OneDrive\\Desktop\\Micaela Files\\3RD YR\\Event\\Files";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DisplayToList();
        }
        private void DisplayToList()
        {
            openFileDialog1.ShowDialog();

            string path = openFileDialog1.FileName; 

            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line); 
                        lvRecord.Items.Add(line);
                    }
                }
            } else
            {
                MessageBox.Show("Selected file does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private void btnUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Uploaded!");
            lvRecord.Items.Clear();
        }
    }
}
