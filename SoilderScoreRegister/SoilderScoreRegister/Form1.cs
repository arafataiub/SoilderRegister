using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilderScoreRegister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> SoilderNos = new List<string>();
        List<string> SoilderNames = new List<string>();
        List<int> T1Scores = new List<int>();
        List<int> T2Scores = new List<int>();
        List<int> T3Scores = new List<int>();
        List<int> T4Scores = new List<int>();

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int error = 0;

            if (textBoxSoilderNo.Text == null)
            {
                MessageBox.Show("Please Enter a Unique Soilder No");
                return;
            }
            else if(textBoxSoilderName.Text==null)
            {
                MessageBox.Show("Please Enter Soilder Name");
                return;

            }
            else if (textBox1Score.Text == null)
            {
                MessageBox.Show("Please Enter Target 1 Score");
                return;

            }
            else if (textBox2Score.Text == null)
            {
                MessageBox.Show("Please Enter Target 2 Score");
                return;

            }
            else if (textBox3Score.Text == null)
            {
                MessageBox.Show("Please Enter Target 3 Score");
                return;

            }
            else if (textBox4Score.Text == null)
            {
                MessageBox.Show("Please Enter Target 4 Score");
                return;

            }
            else if(CheckDuplicate(textBoxSoilderNo.Text)==true)
            {
                MessageBox.Show("Soilder Already Exists!!!");
                return;
            }
            else
            {
                try
                {
                    Convert.ToInt16(textBox1Score.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Fill Target 1 in correct format");
                    error = 1;
                    return;
                }
                try
                {
                    Convert.ToInt16(textBox2Score.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Fill Target 2 in correct format");
                    error = 1;
                    return;
                }
                try
                {
                    Convert.ToInt16(textBox3Score.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Fill Target 3 in correct format");
                    error = 1;
                    return;
                }
                try
                {
                    Convert.ToInt16(textBox4Score.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Fill Target 4 in correct format");
                    error = 1;
                    return;
                }

                if (error == 0)
                {
                    
                    SoilderNames.Add(textBoxSoilderName.Text);
                    SoilderNos.Add(textBoxSoilderNo.Text);
                    T1Scores.Add(Convert.ToInt32(textBox1Score.Text));
                    T2Scores.Add(Convert.ToInt32(textBox2Score.Text));
                    T3Scores.Add(Convert.ToInt32(textBox3Score.Text));
                    T4Scores.Add(Convert.ToInt32(textBox4Score.Text));

                    richTextBox1.Text = "Soilder Info:" + "\n" + "Name:" + textBoxSoilderName.Text + "\n" + "Soilder No:"
                                       + textBoxSoilderNo.Text + "\n" + "Target 1 Score:" + textBox1Score.Text + "\n"+ "Target 2 Score:" + textBox2Score.Text + "\n"+"Target 3 Score:" + textBox3Score.Text + "\n"+ "Target 4 Score:" + textBox4Score.Text;

                    ClearAllControls();
                }

                


            }


        }
        public bool CheckDuplicate(string cinput)
        {
            bool isduplicale = false;


            foreach (string c in SoilderNos)
            {
                if (c == cinput)
                {
                    isduplicale = true;
                    break;
                }
                else
                    continue;
            }
            return isduplicale;

        }
        private void ClearAllControls()
        {
            textBoxSoilderNo.Text = null;
            textBoxSoilderName.Text = null;
            textBox1Score.Text = null;
            textBox2Score.Text = null;
            textBox3Score.Text = null;
            textBox4Score.Text = null;


        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            string message = "";
            int topTotall = 0;
            int topAvg = 0;
            for (int i = 0; i < SoilderNos.Count(); i++)
            {
                message += "Soilder Info:" + "\n" + "Name:" + SoilderNames[i] + "\n" + "Soilder No:"
                           + SoilderNos[i] + "\n" + "Average Score" +
                           (T1Scores[i] + T2Scores[i] + T3Scores[i] + T4Scores[i]) / 4 + "\n" + "Totall Score" +
                           (T1Scores[i] + T2Scores[i] + T3Scores[i] + T4Scores[i]) + "\n";
            }
            richTextBox1.Text = message;
           
            


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int j = 0;
            bool found = false;
            if (radioButtonName.Checked == true || radioButtonNo.Checked == true)
            {
                if (radioButtonName.Checked == true)
                {
                    foreach (string c in SoilderNames)
                    {
                        
                        if (c == textBoxSearch.Text)
                        {
                            string message = "";
                            
                                message += "Soilder Info:" + "\n" + "Name:" + SoilderNames[j] + "\n" + "Soilder No:"
                                           + SoilderNos[j] + "\n" + "Average Score" +
                                           (T1Scores[j] + T2Scores[j] + T3Scores[j] + T4Scores[j]) / 4 + "\n" + "Totall Score" +
                                           (T1Scores[j] + T2Scores[j] + T3Scores[j] + T4Scores[j]) + "\n";
                           
                            richTextBox1.Text = message;
                            found = true;

                            break;
                        }
                        else
                        {
                            j++;
                            continue;
                        }
                            
                    }

                }
                if (radioButtonNo.Checked == true)
                {
                    foreach (string c in SoilderNos)
                    {

                        if (c == textBoxSearch.Text)
                        {
                            string message = "";

                            message += "Soilder Info:" + "\n" + "Name:" + SoilderNames[j] + "\n" + "Soilder No:"
                                       + SoilderNos[j] + "\n" + "Average Score" +
                                       (T1Scores[j] + T2Scores[j] + T3Scores[j] + T4Scores[j]) / 4 + "\n" + "Totall Score" +
                                       (T1Scores[j] + T2Scores[j] + T3Scores[j] + T4Scores[j]) ;

                            richTextBox1.Text = message;
                            found = true;

                            break;
                        }
                        else
                        {
                            j++;
                            continue;
                        }

                    }

                }

                if (found == false)
                {
                    MessageBox.Show("Soilder Not Found");
                    return;
                }


            }
            else
            {
                MessageBox.Show("Please select a searching criteria!");
            
                return;
            }
        }
    }
}
