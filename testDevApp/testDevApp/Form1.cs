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
            


            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    
                    this.richTextBox1.Visible = true;
                    string content = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    List<string> array = new List<string>();

                    for (int i = 0; i < content.Length; i++)
                    {
                        if (content[i].ToString() != ",")
                        {
                            int intvariable;
                            if (Int32.TryParse(content[i].ToString(), out intvariable) && i + 1 < content.Length)
                            {
                                if (Int32.TryParse(content[i + 1].ToString(), out intvariable))
                                {
                                    array.Add(content[i].ToString() + content[i + 1].ToString());
                                    i = i + 1;
                                }
                                else
                                {
                                    array.Add(content[i].ToString());
                                }
                            }
                        }

                    }

                    List<string> arrayFiltrado = new List<string>();
                    foreach (var item in array)
                    {
                        if (Convert.ToInt32(item) % 5 != 0)
                        {
                            arrayFiltrado.Add(item);
                        }
                    }

                    if (array.Count >= 1)
                        {
                            richTextBox1.Text = "Transpose: " + "\n\r";
                            foreach (var item in arrayFiltrado)
                            {
                               int intVariable;
                               if (Int32.TryParse(item, out intVariable))
                               {

                                    int firstNumber, secondNumber;
                                    firstNumber = intVariable +5;
                                    secondNumber = intVariable + 10;
                                    if (this.richTextBox1.Text.Contains(item.Last()))
                                    {
                                        break;
                                    }
                                    if(Convert.ToInt32(item) < firstNumber && Convert.ToInt32(item) < secondNumber)
                                    {
                                        this.richTextBox1.Text += intVariable + ", " + (intVariable + 5) + ", " + (intVariable + 10); this.richTextBox1.Text += "\n\r";
                                    }
                               }
                         
                            }
                        }
                    else
                    {
                        MessageBox.Show("This file is Empty !!");

                    }
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
