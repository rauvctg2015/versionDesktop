using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testDevApp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> resulList = new List<string>();
            string resulString = "1,6,11" + Environment.NewLine + Environment.NewLine + "2,7,12" + Environment.NewLine + Environment.NewLine + "3,8,13" + Environment.NewLine + Environment.NewLine + "4,9,14";


            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                    System.IO.File.WriteAllText(System.IO.Path.GetFullPath(openFileDialog1.FileName), string.Empty);
                    System.IO.File.WriteAllText(System.IO.Path.GetFullPath(openFileDialog1.FileName), resulString);
                    this.richTextBox1.Visible = true;
                    string content = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    richTextBox1.Text = "File Content" + Environment.NewLine + Environment.NewLine + content;
                    System.IO.File.Replace(openFileDialog1.FileName, System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"\\result.txt", null);
                    MessageBox.Show("File changed: " + Environment.NewLine + openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error was Unhandled: " + ex.Message + ex.StackTrace + ex.TargetSite.MethodHandle.ToString());
                }
                
            }

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Visible = false;
        }
    }
}
