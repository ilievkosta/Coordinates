using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Windows.Markup;

namespace Coordinates
{
    public partial class Form1 : Form
    {
       


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x,y;
            double.TryParse(textBox1.Text, out x);
            double.TryParse(textBox2.Text, out y);
            x += 4580000;
            y += 9430000;
            string myStringX = x.ToString();
            string myStringY = y.ToString();
            this.textBox3.Text = myStringX;
            this.textBox4.Text = myStringY;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x, y;
            double.TryParse(textBox3.Text, out x);
            double.TryParse(textBox4.Text, out y);
            x -= 4580000;
            y -= 9430000;
            string myStringX = x.ToString();
            string myStringY = y.ToString();
            this.textBox1.Text = myStringX;
            this.textBox2.Text = myStringY;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (((tb.Text.Length == 0) && (e.KeyChar == 48)) ||
            ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar < 43|| e.KeyChar > 45) && e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fileOpenLittle();
        }
        private void fileOpenLittle()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(theDialog.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> listC = new List<string>();

                using (var reader = new  StreamReader(fs))
                {
                    
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        listA.Add(values[0]);
                        listB.Add(values[1]);
                        listC.Add(values[2]);
                    }
                }

                List<double> listA_double = listA.Select(x => double.Parse(x)).ToList();
                List<double> listB_double = listB.Select(x => double.Parse(x)).ToList();

                for (var i = 0; i < listA_double.Count; i++)
                {
                    listA_double[i] = listA_double[i] + 4580000;
                }


                for (var i = 0; i < listB_double.Count; i++)
                {
                    listB_double[i] = listB_double[i] + 9430000;
                }

                string CoordString="";
                for (var i = 0; i < listA_double.Count; i++) { 
                    CoordString += listA_double[i]+";"+ listB_double[i]+";"+listC[i]+ "\r\n";
                }

                this.textBox5.Text = CoordString;

                sr.Close();
                fs.Close();
                fs.Dispose();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void save1_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files | *.txt";
            saveFileDialog1.Title = "Save an Text File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();

                StreamWriter m_WriterParameter = new StreamWriter(fs);
                m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
                m_WriterParameter.Write(this.textBox5.Text);
                m_WriterParameter.Flush();
                m_WriterParameter.Close();
                


                fs.Close();
            }
        }

       
    }
}
