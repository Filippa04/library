using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Windows_forms.Form1;

namespace Windows_forms
{
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }

        private class User
        {
            public string Name { get; set; }
            public string lastName { get; set; }
            public string SSN { get; set; }
            public string Password { get; set; }
            public string status { get; set; }

            public string PrepareForFile()
            {
                return Name + " " + lastName + " " + SSN + " " + Password + " " + status + " ,";
            }
        }

        public void changePassword()
        {
            var writtenPassword = textBox1.Text;
            var users = File.ReadAllText(@"C:\Users\filippa.olsson7\Desktop\programmering2\Windows_forms\names.txt").Split(',').ToList().Where(x => !String.IsNullOrWhiteSpace(x));

            List<User> myUsers = new List<User>();
            foreach (var user in users)
            {
                var information = user.Split(' ');
                User temp = new User();
                temp.Name = information[0].Trim();
                temp.lastName = information[1].Trim();
                temp.SSN = information[2].Trim();
                temp.Password = information[3].Trim();
                temp.status = information[4].Trim();
                myUsers.Add(temp);
            }

            //checks if it match and then change the password
            var selectedUser = myUsers.Where(x => x.SSN == Globals.personnr).SingleOrDefault();
            myUsers.Remove(selectedUser);
            selectedUser.Password = writtenPassword;
            myUsers.Add(selectedUser);

            List<string> formatForFile = new List<string>();
            foreach (var item in myUsers)
            {
                formatForFile.Add(item.PrepareForFile());
            }
            File.WriteAllLines(@"C:\Users\filippa.olsson7\Desktop\programmering2\Windows_forms\names.txt", formatForFile.ToArray());

            Console.WriteLine("Lösenordet har nu ändrats");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePassword();
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }
    }
}
