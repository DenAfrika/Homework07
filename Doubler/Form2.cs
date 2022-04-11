using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
{
    public partial class Form2 : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;


        public Form2()
        {
            InitializeComponent();
            Update(userNumber, random.Next(101));
        }

        private void Update(int userNumber, int computerNumber)
        {
            this.computerNumber = computerNumber;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox.Text, out userNumber);
            CheckWin();
        }

        private void CheckWin()
        {
            if (computerNumber == userNumber)
            {
                MessageBox.Show("Вы завершили игру!", "Угадай число", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Хотите сыграть ещё раз?", "Угадай число", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    userNumber = 0;
                    Update(userNumber, random.Next(100));
                }
                else
                {
                    Close();
                }
            }
            else if (computerNumber < userNumber)
            {
                label.Text = "Задуманное число меньше";
            }
            else { label.Text = "Задуманное число больше"; }
        }
    }
}
