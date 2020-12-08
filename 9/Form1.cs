using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib7;
namespace _9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Кнопка "Справка"
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Практическая работа №9. Бороненкова Дария, гр.ИСП - 31.\n" +
                "Заполнить таблицу со списком телефонных абонентов на 7 человек с полями:\n" +
                "ФИО, номер телефона, адрес.\n" +
                "Вывести результат на экран.\n" +
                "Вывести список абонентов живущих на заданной улице.",
                "О программе");
        }
        //Кнопка "Выход"
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Создание объекта
        Abonent[] abonent1;
        Abonent[] abonent2;

        //Ввод информации об абоненте
        private void button1_Click(object sender, EventArgs e)
        {
            //Определение позиции
            int pos = (int)numericUpDown1.Value;

            abonent1[pos].Surname = textBox1.Text;
            abonent1[pos].Name = textBox2.Text;
            abonent1[pos].Patronymic = textBox3.Text;

            abonent1[pos].City = textBox5.Text;
            abonent1[pos].Street = textBox6.Text;

            dataGridView1[0, pos].Value = textBox1.Text;
            dataGridView1[1, pos].Value = textBox2.Text;
            dataGridView1[2, pos].Value = textBox3.Text;

            dataGridView1[4, pos].Value = textBox5.Text;
            dataGridView1[5, pos].Value = textBox6.Text;


            //Проверка номера телефона
            if (Int32.TryParse(textBox4.Text, out int n1))
            {
                if (n1 > 0)
                {
                    abonent1[pos].PhoneNumber = Convert.ToInt32(textBox4.Text);
                    dataGridView1[2, pos].Value = textBox4.Text;
                }
                else
                {
                    MessageBox.Show("Номер телефона введен неверно");
                }
            }
            //Проверка номера дома
            if (Int32.TryParse(textBox7.Text, out int n2))
            {
                if (n2 > 0)
                {
                    abonent1[pos].House = Convert.ToInt32(textBox7.Text);
                    dataGridView1[6, pos].Value = textBox7.Text;
                }
                else
                {
                    MessageBox.Show("Номер дома введен неверно");
                }
            }
            //Проверка номера квартиры
            if (Int32.TryParse(textBox8.Text, out int n3))
            {
                if (n3 > 0)
                {
                    abonent1[pos].Apartment = Convert.ToInt32(textBox8.Text);
                    dataGridView1[7, pos].Value = textBox8.Text;
                }
                else
                {
                    MessageBox.Show("Номер квартиры введен неверно");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                abonent1 = new Abonent[10];
                dataGridView1.ColumnCount = 8;
                dataGridView1.RowCount = 10;
                numericUpDown1.Value = 1;
                dataGridView1[0, 0].Value = "Фамилия";
                dataGridView1[1, 0].Value = "Имя";
                dataGridView1[2, 0].Value = "Отчество";

                dataGridView1[3, 0].Value = "Телефонный номер";

                dataGridView1[4, 0].Value = "Город";
                dataGridView1[5, 0].Value = "Улица";
                dataGridView1[6, 0].Value = "Дом";
                dataGridView1[7, 0].Value = "Квартира";

                abonent2 = new Abonent[10];
                dataGridView2.ColumnCount = 4;
                dataGridView2.RowCount = 9;
                dataGridView2[0, 0].Value = "Фамилия";
                dataGridView2[1, 0].Value = "Имя";
                dataGridView2[2, 0].Value = "Отчество";
                dataGridView2[3, 0].Value = "Улица";
            }
        }

        //Поиск абонентов по адресу
        private void button2_Click(object sender, EventArgs e)
        {
            string street = textBox10.Text;
            for (int i = 1; i < dataGridView1.RowCount; i++)
            {
                if (street == abonent1[i].Street)
                {
                    dataGridView2[0, i].Value = abonent1[i].Surname;
                    dataGridView2[1, i].Value = abonent1[i].Name;
                    dataGridView2[2, i].Value = abonent1[i].Patronymic;
                    dataGridView2[3, i].Value = abonent1[i].Street;
                }
            }
        }

    }
}
