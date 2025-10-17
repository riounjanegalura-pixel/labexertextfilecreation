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

namespace labexertextfilecreation
{
    public partial class FrmRegistration: Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string studentNo = txtStudentNo.Text;
            string program = cmbProgram.Text;
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string age = txtAge.Text;
            string gender = cmbGender.Text;

            string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");

            string contactNo = txtContactNo.Text;

            string[] registrationData = new string[]
            {
               "Student No.:" + studentNo,
               "Full Name:" + lastName + ", " + firstName + ", " + middleInitial + ".",
               "Program: " + program,
               "Gender: " + gender,
               "Age: " + age,
               "Birthday: " + birthday,
               "Contact No.:" + contactNo
            };

            string fileName = studentNo + ".txt";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, fileName);

            try
            {
                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    foreach (string line in registrationData)
                    {
                        outputFile.WriteLine(line);
                    }
                }

                MessageBox.Show("Registration data has been saved to:\n" + filePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
