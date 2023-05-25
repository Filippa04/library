using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Windows_forms.Form1;

namespace Windows_forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public static void LoginPage()
        {
            using (StreamReader sr = new StreamReader(File.Open(@"C:\Users\filippa.olsson7\Desktop\programmering2\Windows_forms\names.txt", FileMode.Open)))
            {
                string line;
                // Read one line at a time from file until end of file.
                while ((line = sr.ReadLine()) != null)
                {
                    // split the line by comma.
                    var creds = line.Split(' ');

                    // if the values match, set login to true and exit the while loop.  
                    if (Globals.personnr == creds[2] && Globals.password == creds[3])
                    {
                        Globals.loginSuccessful = true;
                        break;
                    }
                }
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e, bool loginSuccessful)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.personnr = textBox1.Text;
            Globals.password = textBox2.Text;
            LoginPage();
            if (Globals.loginSuccessful == true)
            {
                Form4 form4 = new Form4();
                form4.Show();
                Hide();
            }
            else
            {
                label4.Text = "Var god försök igen";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
