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
    public partial class Form1 : Form
    {
        private int computerNumber;
        private Stack<int> userNumber = new Stack<int>();
        private int NumberInstruction;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            userNumber.Push(0);
            Update(userNumber.Peek(), random.Next(100));
        }

        private void Update(int userNumber)
        {
            labelUserNumber.Text = $"Текущее число: {userNumber}";
            labelNumberInstruction.Text = $"Колличесво команд: {NumberInstruction}";
            NumberInstruction++;
        }
        private void Update(int userNumber, int computerNumber)
        {
            Update(userNumber);
            this.computerNumber = computerNumber;
            labelComputerNumber.Text = $"Получите число: {computerNumber}";
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            userNumber.Clear();
            userNumber.Push(0);
            NumberInstruction = 0;
            Update(userNumber.Peek(), random.Next(100));
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            userNumber.Push(userNumber.Peek() + 1);
            Update(userNumber.Peek());
            CheckWin();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            userNumber.Push(userNumber.Peek() * 2);
            Update(userNumber.Peek());
            CheckWin();
        }
        private void CheckWin()
        {
            if(computerNumber == userNumber.Peek())
            {
                MessageBox.Show("Вы завершили игру!", "Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(MessageBox.Show("Хотите сыграть ещё раз?", "Удвоитель", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    userNumber.Clear();
                    userNumber.Push(0);
                    NumberInstruction = 0;
                    Update(userNumber.Peek(), random.Next(100));
                }
                else
                {
                    Close();
                }
            }else if(computerNumber < userNumber.Peek())
            {
                MessageBox.Show("Вы ошиблись!", "Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Хотите сыграть ещё раз?", "Удвоитель", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    userNumber.Clear();
                    userNumber.Push(0);
                    NumberInstruction = 0;
                    Update(userNumber.Peek(), random.Next(100));
                }
                else
                {
                    Close();
                }
            }
        }

        private void игратьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Вы должны получить число {computerNumber} за минимальное количество ходов", "Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            if (userNumber.Count() != 1)
            {
                userNumber.Pop();
                Update(userNumber.Peek());
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
