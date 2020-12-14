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

namespace DI_Tema4_Ejer6
{
    public partial class Form1 : Form
    {
        Color original = (new Button()).BackColor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pass = "1234";
            Form2 f2 = new Form2();
            bool acerto = false;
            int contFallos = 0;
            DialogResult res;
            

              while (!acerto && contFallos < 3)
              {
                  res = f2.ShowDialog();
                  if (res == DialogResult.OK)
                  {
                      if (f2.textBox1.Text == pass)
                      {
                          acerto = true;
                      }
                      else
                      {
                          contFallos++;
                      }
                  }
                  else
                  {
                      this.Close();
                      contFallos = 4;
                  }

              }

              if (!acerto)
              {
                  this.Close();
              }
          



            //Esto ya una vez entrao
            int contH,contW;
                contH = 1;
                contW = 1;
            for(int i = 0; i < 12; i++)
            {
                Button bu = new Button();
                bu.Size = new Size(40, 40);
                bu.Location = new Point(contW * 50, contH * 50);
                contW++;
                if(contW == 4)
                {
                    contW = 1;
                    contH++;
                }
                if(i < 9)
                {
                    bu.Text = ""+(i+1);
                }
                else
                {
                    switch (i)
                    {
                        case 9:
                            bu.Text = "*";
                            break;
                        case 10:
                            bu.Text = "0";
                            break;
                        case 11:
                            bu.Text = "#";
                            break;
                    }
                   
                }
                bu.Name = "b" + i;
                bu.Visible = true;
                bu.Tag = false;
                bu.Click += button1_Click;
                bu.MouseEnter += button1_MouseEnter;
                bu.MouseLeave += button1_MouseLeave;
                this.Controls.Add(bu);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Button)sender).Tag = true;
            ((Button)sender).BackColor = Color.Yellow;
            textBox1.Text += ((Button)sender).Text;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (!(bool)((Button)sender).Tag)
            {
                ((Button)sender).BackColor = Color.Green;
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (!(bool)((Button)sender).Tag)
            {
                ((Button)sender).BackColor = original;
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string id = "";
            for(int i = 0; i < 12; i++)
            {
                id = "b" + i;
                ((Button)this.Controls[id]).BackColor = original;
            }
            textBox1.Text = "";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grabarNumeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (textBox1.Text != "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.ValidateNames = true;
                sfd.Filter = "Texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                sfd.OverwritePrompt = false;
                res = sfd.ShowDialog();
                if(res == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter s = new StreamWriter(sfd.FileName, true))
                        {
                            s.WriteLine(textBox1.Text);
                            
                        }
                    }catch(IOException)
                    {
                        MessageBox.Show("Error al crear archivo", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("El numero esta vacío tio, enrrollate", "Error");
            }
            
        }
    }
}
