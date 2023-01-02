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

namespace SystAnalys_lr1
{
    public partial class OpenForm : Form
    {
        public OpenForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Closed += (s, args) =>
            {
                Form1 form1form1 = (Form1)s;
                if (form1form1.closeApp)
                    this.Close();
                else
                    this.Show();
            };
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Json files(*.json)|*.json";
            openFile.Title = "Выберите файл проекта";
            DialogResult res = openFile.ShowDialog();

            if (res == DialogResult.OK)
            {
                string filename = openFile.FileName;
                string readFile = File.ReadAllText(filename);
                this.Hide();
                Form1 form = new Form1(readFile, filename);
                form.Closed += (s, args) =>
                {
                    Form1 form1form1 = (Form1)s;
                    if (form1form1.closeApp)
                        this.Close();
                    else
                        this.Show();
                };
                form.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
