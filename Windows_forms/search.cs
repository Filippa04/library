using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_forms
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchInput = textBox1.Text.ToLower();
            boksystem system = boksystem.GetInstance();

            var result = system.FindBook(searchInput);

            for (var i = 0; i < result.Count; i++)
            {
                var book = result[i];

                label2.Text = ($"Författare: {book.Author} Namn: {book.Name}");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }
    }
}
