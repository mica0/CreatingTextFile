using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmRegistration : Form
    {
        public static string StudentNumber;
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            StudentNumber = txtSN.Text;

            string fileName = StudentNumber + " .txt";

            string[] content = new string[]
            {
                "Student Number: " + txtSN.Text,
                "FullName: " + txtLastName.Text +  "," + txtFirstName.Text + "," + txtMiddle.Text,
                "Program: " + cbProgram.Text,
                "Gender: " + cbGender.Text,
                "Age: " + txtAge.Text,
                "Birthday: " + dateTimePicker1.Text,
                "Contact No. " + txtContact.Text,
            };

            System.IO.File.WriteAllLines(fileName, content);

            foreach (string line in content) 
            {
                Console.WriteLine(line);
            }



        }
    }
}
