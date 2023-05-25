using Microsoft.VisualBasic.Logging;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        static bool UserRegistered(string personalNumber)
        {
            string[] users = System.IO.File.ReadAllLines(@"C:\Users\filippa.olsson7\Desktop\programmering2\Windows_forms\names.txt");

            for (int i = 0; i < users.Length; i++)
            {
                var line = users[i].Trim();
                string[] parts = line.Split(' ');

                var currentPersonalNumber = parts[2];

                if (currentPersonalNumber == personalNumber)
                {
                    return true;
                }
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.firstName = textBox1.Text;
            Globals.lastName = textBox2.Text;
            Globals.personnr = textBox3.Text;
            Globals.password = textBox4.Text;

            if (UserRegistered(Globals.personnr))
            {
                label6.Text = "Du är redan registerad";
            }

            var line = $"{Globals.firstName} {Globals.lastName} {Globals.personnr} {Globals.password} {"medlem"} {","}";
            string[] lines = { line };

            File.AppendAllLines(@"C:\Users\filippa.olsson7\Desktop\programmering2\Windows_forms\names.txt", lines);

            label6.Text = "Du är registerad och du kan logga in nu :D";

            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
