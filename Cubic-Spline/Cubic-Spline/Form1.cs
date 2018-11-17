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
using System.Diagnostics;

namespace Cubic_Spline
{
    public partial class Form1 : Form
    {
        TextBox[] box = new TextBox[8];
        Label[] label = new Label[8];
        int size = 0;
        public Form1()
        {
            InitializeComponent();
            box[0] = textBox2;
            box[1] = textBox3;
            box[2] = textBox4;
            box[3] = textBox5;
            box[4] = textBox6;
            box[5] = textBox7;
            box[6] = textBox8;
            box[7] = textBox9;
            label[0] = label2;
            label[1] = label6;
            label[2] = label3;
            label[3] = label7;
            label[4] = label4;
            label[5] = label8;
            label[6] = label5;
            label[7] = label9;
            foreach (TextBox b in box)
                b.Visible = false;
            foreach (Label l in label)
                l.Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                foreach (TextBox b in box)
                    b.Visible = false;
                foreach (Label l in label)
                    l.Visible = false;
                return;
            }
            try
            {
                if (Convert.ToInt64(textBox1.Text) < 0 || Convert.ToInt64(textBox1.Text) > 8) return;
            }
            catch
            {
                return;
            }
            size = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < size; ++i)
            {
                box[i].Visible = true;
                label[i].Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (size < 0 || size == 0 || size > 8) return;
            for (int i = 0; i < size; ++i)
                if (box[i].Text == "") return;
            string buf = "";
            for (int i = 0; i < size; ++i)
            {
                String[] tmp;
                tmp = box[i].Text.Split(',');
                buf += tmp[0] + " " + tmp[1] + Environment.NewLine;
            }

            
             using (FileStream fstream = new FileStream(@"../../../../dots.txt", FileMode.OpenOrCreate))
             {
                 // преобразуем строку в байты
                 byte[] array = System.Text.Encoding.Default.GetBytes(buf);
                 // запись массива байтов в файл
                 fstream.Write(array, 0, array.Length); 
             }
            
            const string commands = @"@echo off
                                    cd ../../../../
                                     python main.py";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false

                }
            };
            process.Start();
            
            using (StreamWriter pWriter = process.StandardInput)
            {
                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (var line in commands.Split('\n'))
                        pWriter.WriteLine(line);
                }

            }
        }
    }
}
