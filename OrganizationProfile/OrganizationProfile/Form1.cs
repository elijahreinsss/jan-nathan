using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        private void frmRegistration_Load(object sender, EventArgs e)
     
                {

            string[] Gender = new string[] {
            "Male",
            "Female",

            };
            for (int i = 0; i < 2; i++)
            {

                cbGender.Items.Add(Gender[i].ToString());
            }


            string[] ListOfProgram = new string[]{
 "BS Information Technology",
 "BS Computer Science",
 "BS Information Systems",
 "BS in Accountancy",
 "BS in Hospitality Management",
 "BS in Tourism Management"
 };
 for (int i = 0; i < 6; i++) 
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }
        }
        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            StudentInformationClass.SetFullName = FullName(txtLastName.Text,
            txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbProgram.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(text1.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyyMM-dd");
           
            Form2 frm = new Form2();
            
            frm.ShowDialog();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }
    }
}

