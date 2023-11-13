using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmRegistration : Form
    {
        private string Fullnames;
        private int Ages;
        private long ContactNo;
        private long StudentNo;
        public FrmRegistration()
        {
            InitializeComponent();
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    Fullnames = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    throw new FormatException("Sorry, Input was incorrect, Please try again");
                }
            }
            catch (FormatException fn)
            {
                MessageBox.Show(fn.Message);
            }return Fullnames;
        }
        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    Ages = Int32.Parse(age);
                }
                else
                {
                    throw new OverflowException("Sorry, Your Age Input was Incorrect Please Try again");
                }
            }
            catch (OverflowException a)
            {
                MessageBox.Show(a.Message);
            }
            finally
            { 
                Console.WriteLine("Finally block executed.");
            }return Ages;
        }
        public long ContactNumber(string Contact) 
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new FormatException("Contact Number should be exactly 11 digits. ");
                }
            }
            catch (FormatException cn)
            {
                MessageBox.Show(cn.Message);
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }
            return ContactNo;
        }

        public long StudentNumber(string studNum) 
        {
            try
            {
                if (string.IsNullOrEmpty(studNum))
                {
                    throw new ArgumentException("Student No. must be fill up!");
                }
                else
                {
                    StudentNo = long.Parse(studNum);    
                }
            }catch (ArgumentException sn) 
            {
                MessageBox.Show(sn.Message);
            }return StudentNo;
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[] {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            try
            {
                if (ListOfProgram.Length == 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        cbProgram.Items.Add(ListOfProgram[i].ToString());
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException p)
            {
                MessageBox.Show(p.Message);

            }
            string[] ListOfGender = new string[]
                {
                    "Female",
                    "Male"
                };
            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString()); 
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fileName = $"{txtLastName.Text}_{txtFirstName.Text}_{txtMiddle.Text}.txt";
            string filePath = Path.Combine("C:\\Users\\vcaga\\OneDrive\\Desktop\\Micaela Files\\3RD YR\\Event\\Files", fileName);
            try 
            {
                using (StreamWriter sw = File.CreateText(filePath)) 
                {
                sw.WriteLine($"Student No. : {txtSN.Text}");
                sw.WriteLine($"Program: {cbProgram.Text}");
                sw.WriteLine($"Full Name: {txtLastName.Text + ", " + txtFirstName.Text + " " + txtMiddle.Text}");
                sw.WriteLine($"Age: {txtAge.Text}");
                sw.WriteLine($"Gender: {cbGender.Text}");
                sw.WriteLine($"Birthday: {dateTimePicker1.Value.ToShortDateString()}");
                sw.WriteLine($"Contact: {txtContact.Text}");
                }
                FrmFileName.SetFileName = fileName;
                this.Hide();

            }catch (Exception ex) 
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            FrmStudentRecord studentdataForm = new FrmStudentRecord();
            studentdataForm.ShowDialog();
            this.Hide();
        }
    }
}
