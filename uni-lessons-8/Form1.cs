using System;
using System.Globalization;
using System.Windows.Forms;

namespace uni_lessons_8
{
    public partial class Form1 : Form
    {
        decimal toplam = 0;

        public Form1()
        {
            InitializeComponent();

         
            button1.Click -= Button1_Click;
            button1.Click += Button1_Click;

            button2.Click -= button2_Click;
            button2.Click += button2_Click;

          
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("gul", "Gül növü");
            dataGridView1.Columns.Add("say", "Satış sayı");
            dataGridView1.Columns.Add("qiymet", "Qiyməti");
            dataGridView1.Columns.Add("yekun", "Yekun qiyməti");

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            maskedTextBox1.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            label5.Text = "0.00";
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" ||
                maskedTextBox1.Text.Trim() == "" ||
                textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Bütün xanaları doldurun.");
                return;
            }

            int count;
            decimal price;

            if (!int.TryParse(maskedTextBox1.Text, out count))
            {
                MessageBox.Show("Sayı düzgün tam ədəd olaraq yazın.");
                return;
            }

            if (!decimal.TryParse(
                textBox2.Text.Trim().Replace(',', '.'),
                NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                out price))
            {
                MessageBox.Show("Qiyməti düzgün yazın.");
                return;
            }

            if (count <= 0 || price <= 0)
            {
                MessageBox.Show("Say və qiymət sıfırdan böyük olmalıdır.");
                return;
            }

            decimal result = count * price;

            dataGridView1.Rows.Add(
                textBox1.Text.Trim(),
                count.ToString(),
                price.ToString("F2"),
                result.ToString("F2")
            );

            toplam += result;
            label5.Text = toplam.ToString("F2");

            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox2.Clear();

            textBox1.Focus();
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show(
                "Çıxış edilsinmi?",
                "Çıxış",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cavab == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}