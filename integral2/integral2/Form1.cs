using Integral2;
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
using static Integral2.Integrator1;

namespace Integral2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*        public delegate double Mod2(a);
                Mod2 mod2 = new (MyMod1);*/


        int function = 0;

        public double a = -10, b = 10, x = -10, N = 10, y = 3, x1=1, x2=2;


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            function = 1;
            textBox5.Text = "111111";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            function = 2;
            textBox5.Text = "222222";
        }
        

        private void построитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {

            x1 = Convert.ToDouble(textBoxX1.Text);
            x2 = Convert.ToDouble(textBoxX2.Text);
            N = Convert.ToDouble(textBoxH.Text);
            a = Convert.ToDouble(textBoxA.Text);


            this.chart1.Series[0].Points.Clear();
            if (function==1)
            {
                /*Equation equation = new Equation();*/
                double h = ((x2 - x1) / N);
                while (x1 <= x2)
                {
                    y = Math.Sin(a * x1) / x1;
                    this.chart1.Series[0].Points.AddXY(x1, y);
                    x1 += h;
                }
            }
            else if (function == 2)
            {
                double h = ((x2 - x1) / N);
                while (x1 <= x2)
                {
                    y =  a * x1 * Math.Abs(Math.Sin(x1));
                    this.chart1.Series[0].Points.AddXY(x1, y);
                    x1 += h;
                }
            }
            
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

         /*   if (function == 1)
            {*/
                x1 = Convert.ToDouble(textBoxX1.Text);
                x2 = Convert.ToDouble(textBoxX2.Text);
                N = Convert.ToDouble(textBoxH.Text);
                a = Convert.ToDouble(textBoxA.Text);

                textBox7.Text = Convert.ToString(x1);
                textBox8.Text = Convert.ToString(x2);
                textBox9.Text = Convert.ToString(N);
                textBox10.Text = Convert.ToString(a);
                Integrator2 integrator = new Integrator2();
                Equation eq;
                if (function == 1)
                {
                    eq = new MySin1(a);
                }
                else
                {
                    eq = new MyMod1(a); 
                }
                integrator.Integrator(eq);

                ResultTextBox.Text = Convert.ToString(Math.Round(integrator.Integrate(x1, x2,N),2));
      /*      }
            else if (function == 2)
            {
                x1 = Convert.ToDouble(textBox1.Text);
                x2 = Convert.ToDouble(textBox2.Text);
                N = Convert.ToDouble(textBox3.Text);
                a = Convert.ToDouble(textBox4.Text);

                textBox7.Text = Convert.ToString(x1);
                textBox8.Text = Convert.ToString(x2);
                textBox9.Text = Convert.ToString(N);
                textBox10.Text = Convert.ToString(a);
                Integrator2 integrator = new Integrator2();
                integrator.Integrator(new MyMod1(a));

                textBox6.Text = Convert.ToString(integrator.Integrate(x1, x2,N));
            }*/
            


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* if (function == 1)
            {*/
                x1 = Convert.ToDouble(textBoxX1.Text);
                x2 = Convert.ToDouble(textBoxX2.Text);
                N = Convert.ToDouble(textBoxH.Text);
                a = Convert.ToDouble(textBoxA.Text);

                textBox7.Text = Convert.ToString(x1);
                textBox8.Text = Convert.ToString(x2);
                textBox9.Text = Convert.ToString(N);
                textBox10.Text = Convert.ToString(a);

                void BeginCalculation()
                {






                    if (ResultList.Items != null)
                    {
                        ResultList.Items.Clear();
                    }
                    string[] strok = File.ReadAllLines("C:\\Users\\Михаил\\source\\repos\\integral2\\integral2\\methods\\List.txt");

                    if (strok.Length != 0)
                    {
                        File.Delete("C:\\Users\\Михаил\\source\\repos\\integral2\\integral2\\methods\\List.txt");
                    }
                    Equation eq;
                    if (function == 1)
                    {
                        eq = new MySin1(a);
                    }
                    else
                    {
                        eq = new MyMod1(a);
                    }
                     
                    Integrator1 integr = new Integrator1();
                    integr.Integrator(eq);
                    integr.OnStep += new IntStepDelegate(WriteToFile);
                    integr.OnStep += new IntStepDelegate(AddToListBox);
                    integr.OnFinish += (sum) =>
                    {
                        MessageBox.Show("Интеграл = {0}", Convert.ToString(sum));                //For LR 8 
                    };



                    ResultTextBox.BackColor = Color.Green;
                    



                    /*Integrator2 integrator = new Integrator2();*/
                    

                    ResultTextBox.Text = Convert.ToString(Math.Round(integr.Integrate(x1, x2, N),2));

                }


                void WriteToFile(double x, double f, double s)
                {
                    StreamWriter sw = new StreamWriter("C:\\Users\\Михаил\\source\\repos\\integral2\\integral2\\methods\\List.txt",true);
                    sw.WriteLine($"x({x}),y({Math.Round(f,2)}),sum({Math.Round(s,2)})");
                    sw.Close();
                }


                void AddToListBox(double x, double f, double s)
                {
                    string str = $"x({x}),y({Math.Round(f,2)}),sum({Math.Round(s,2)})";
                    ResultList.Items.Add(str);
                  
                }

                BeginCalculation();
                




        /*    }
            else if (function == 2)
            {
                x1 = Convert.ToDouble(textBox1.Text);
                x2 = Convert.ToDouble(textBox2.Text);
                N = Convert.ToDouble(textBox3.Text);
                a = Convert.ToDouble(textBox4.Text);

                textBox7.Text = Convert.ToString(x1);
                textBox8.Text = Convert.ToString(x2);
                textBox9.Text = Convert.ToString(N);
                textBox10.Text = Convert.ToString(a);
                Integrator2 integrator = new Integrator2();
                integrator.Integrator(new MyMod1(a));

                textBox6.Text = Convert.ToString(integrator.Integrate(x1, x2, N));
            }*/
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void очиститьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
        }
    }
}
