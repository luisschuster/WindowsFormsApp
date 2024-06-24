using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Timer timer;
        int rounds = 3;
        int timerPerRound = 4;
        
        string[] CPUchoiceList = { "rock", "paper", "scissors", "paper", "rock", "scissors" };

        int randomNumber = 0;

        Random rnd = new Random();

        string CPUChoice;

        string PlayerChoice;

        int playerScore = 0;
        int CPUScore = 0;



        public Form1()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.SelectedTab = tabPage4;
            operationComboBox.Items.Add("Addition");
            operationComboBox.Items.Add("Subtraction");
            operationComboBox.Items.Add("Multiplication");
            operationComboBox.Items.Add("Division");
            operationComboBox.Items.Add("Square Root");
            operationComboBox.Items.Add("percent of");
            operationComboBox.Items.Add("to the power of");
            textBox2.Text = "0";
            tabPage1.Text = "Bad Calculator";
            tabPage2.Text = "Russian Roulette";
            tabPage3.Text = "Rock, Paper, Scissors";
            tabPage4.Text = "Reaction Game";
            tabPage5.Text = "Settings";
            numericUpDown1.Value = 1;
            numericUpDown1.Maximum = 6;
            numericUpDown1.Minimum = 1;
            countdowntimer.Enabled = false;
            PlayerChoice = "none";
            countdowntxt.Text = "3";

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(ChangeBackgroundColor);
            timer.Enabled = false;
        }

        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            tabPage1.BackColor = randomColor;
            tabPage2.BackColor = randomColor;
            tabPage3.BackColor = randomColor;
            tabPage4.BackColor = randomColor;
            tabPage5.BackColor = randomColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculateResult();
        }
        private void CalculateResult()
        {
            if (double.TryParse(textBox1.Text, out double value1) && double.TryParse(textBox2.Text, out double value2))
            {
                double result = 0;
                string selectedOperation = operationComboBox.SelectedItem as string;

                switch (selectedOperation)
                {
                    case "Addition":
                        result = value1 + value2;
                        break;
                    case "Subtraction":
                        result = value1 - value2;
                        break;
                    case "Multiplication":
                        result = value1 * value2;
                        break;
                    case "Division":
                        if (value2 != 0)
                            result = value1 / value2;
                        else
                            MessageBox.Show("Division by zero is not allowed.", "Error", MessageBoxButtons.OK);
                        break;
                    case "Square Root":
                        if (value1 >= 0)
                            result = Math.Sqrt(value1);
                        else
                            MessageBox.Show("Cannot calculate square root of a negative number.", "Error", MessageBoxButtons.OK);
                        break;
                    case "percent of":
                        result = value1 / 100 * value2;
                        break;
                    case "to the power of":
                        result = Math.Pow(value1, value2);
                        break;

                }
                result = Math.Ceiling(result * 100) / 100;

                textBox3.Text = result.ToString("0.00");

            }
            else
            {
                MessageBox.Show("Gib Zahlen ein, du Affe.", "Error.", MessageBoxButtons.OK);
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=za3FN2fvXa8");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            tabPage1.BackColor = Color.White;
            tabPage2.BackColor = Color.White;
            tabPage3.BackColor = Color.White;
            tabPage4.BackColor = Color.White;
            tabPage5.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int gun = rnd.Next(1, 7);

            int numericUpDownValue = (int)numericUpDown1.Value;

            if (numericUpDownValue >= gun)
            {
                MessageBox.Show("u r ded");
            }
            else
            {
                MessageBox.Show("u live (this time)");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer.Enabled = false;
            tabPage1.BackColor = Color.Gray;
            tabPage2.BackColor = Color.Gray;
            tabPage3.BackColor = Color.Gray;
            tabPage4.BackColor = Color.Gray;
            tabPage5.BackColor = Color.Gray;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            timer.Enabled = false;
            tabPage1.BackColor = Color.Purple;
            tabPage2.BackColor = Color.Purple;
            tabPage3.BackColor = Color.Purple;
            tabPage4.BackColor = Color.Purple;
            tabPage5.BackColor = Color.Purple;
        }


        private void rockbtn_Click(object sender, EventArgs e)
        {
            playerpic.Image = Properties.Resources.rock_sus;
            PlayerChoice = "rock";
        }

        private void paperbtn_Click(object sender, EventArgs e)
        {
            playerpic.Image = Properties.Resources.paper4;
            PlayerChoice = "paper";
        }

        private void scissorsbtn_Click(object sender, EventArgs e)
        {
            playerpic.Image = Properties.Resources.scissors1;
            PlayerChoice = "scissors";
        }



        private void countdowntimer_Tick(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            countdowntxt.Text = timerPerRound.ToString();

            roundstxt.Text = "Rounds: " + rounds;


            if (timerPerRound < 1)
            {
                countdowntimer.Enabled = false;

                timerPerRound = 4;

                randomNumber = rnd.Next(0, CPUchoiceList.Length);

                CPUChoice = CPUchoiceList[randomNumber];

                switch (CPUChoice)
                {
                    case "rock":
                        cpupic.Image = Properties.Resources.rock_sus;
                        break;
                    case "paper":
                        cpupic.Image = Properties.Resources.paper4;
                        break;
                    case "scissors":
                        cpupic.Image = Properties.Resources.scissors1;
                        break;
                }
                checkGame();

                scoretxt.Text = "Player: " + playerScore + " - CPU: " + CPUScore;
                roundstxt.Text = "Rounds: " + rounds;
                cpupic.Image = Properties.Resources.qq;




            }

        }


        private void checkGame()
        {

            if (PlayerChoice == "rock" && CPUChoice == "paper")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Paper Covers Rock");
            }
            else if (PlayerChoice == "scissors" && CPUChoice == "rock")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Rock Breaks Scissors");
            }
            else if (PlayerChoice == "paper" && CPUChoice == "scissors")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Scissors Cut Paper");

            }
            else if (PlayerChoice == "rock" && CPUChoice == "scissors")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Rock Breaks Scissors");
            }
            else if (PlayerChoice == "paper" && CPUChoice == "rock")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Paper Covers Rock");
            }
            else if (PlayerChoice == "scissors" && CPUChoice == "paper")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Scissors Cut Paper");
            }
            else if (PlayerChoice == "none")
            {
                MessageBox.Show("Make a choice");
            }
            else
            {
                MessageBox.Show("Draw!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

            countdowntimer.Enabled = true;
            if (rounds == 0)
            {
                countdowntimer.Enabled = false;



                if (playerScore > CPUScore)
                {
                    MessageBox.Show("You win! :D");
                }
                else
                {
                    MessageBox.Show("You lose! :(");
                }
                reset();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            countdowntimer.Enabled = true;
        }

        private void reset()
        {
            playerScore = 0;
            CPUScore = 0;
            rounds = 3;
            roundstxt.Text = "Rounds: " + rounds;
            scoretxt.Text = "Player: " + playerScore + " - CPU: " + CPUScore;
            countdowntxt.Text = "3";
            PlayerChoice = "none";
            playerpic.Image = Properties.Resources.qq;
            cpupic.Image = Properties.Resources.qq;
            countdowntimer.Enabled = false;


        }

        private void restartbtn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void lsd_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void calcTabBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void RRBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void RPSswitchBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void mainbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void mainbtn1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void mainbtn2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void mainbtn3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }
    }
}