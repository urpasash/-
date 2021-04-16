using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string FilePath;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileName = @"data\Text2.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                FilePath = dialog.FileName;
                textBox1.Text = File.ReadAllText(FilePath);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Undo();

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Cut();
        
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Copy();
        
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Paste();
       
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Clear();

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Text += DateTime.Now;

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.SelectAll();

        private void настройкиФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.ShowDialog();
                textBox1.BackColor = dialog.Color;
            }
        }

        private void переносПоСловамToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            переносПоСловамToolStripMenuItem1.Checked = !переносПоСловамToolStripMenuItem1.Checked;
            textBox1.WordWrap = переносПоСловамToolStripMenuItem1.Checked;
        }

        private void шрифтToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Font = dialog.Font;
                }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                DialogResult res = MessageBox.Show("Вы хотите сохранить данные изменения?", "Блокнот", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                    }

                    textBox1.Clear();
                }
                if (res == DialogResult.No)
                {
                    textBox1.Clear();
                }
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
               printDocument1.Print();
            }
        }

        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 form = new AboutBox1();
            form.Show();
        }
    }
}
