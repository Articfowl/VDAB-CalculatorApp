using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorAppLogic;

namespace CalculatorAppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var button in Controls.OfType<Button>())
            {
                button.Click += Button_Click;
            }
        }
        private bool controle = false;
        public double Getal1 = 0;
        public double Getal2 = 0;
        public string Teken = "";
        private void Button4_Click(object sender, EventArgs e)
        {
            if(txtOpgave.Text != "") {
                Getal2 = Double.Parse(txtCalc.Text);
                Berekening berekening = new Berekening(Teken, Getal1, Double.Parse(txtCalc.Text));
                berekening.Bereken();
                txtCalc.Text = berekening.Uitkomst;
                txtOpgave.Text = "";
            }
            else
            {
                Berekening berek = new Berekening(Teken, Double.Parse(txtCalc.Text), Getal2);
                berek.Bereken();
                txtCalc.Text = berek.Uitkomst;
                txtOpgave.Text = "";
            }
            

        }
        private void Button_Click(object sender, EventArgs eventArgs)
        {
            switch (((Button)sender).Text)
            {
                case "CE":
                    txtCalc.Text = "";
                    break;
                case "C":
                    txtOpgave.Text = "";
                    txtCalc.Text = "";
                    break;
                case "+/-":
                    if (controle)
                    {
                        txtCalc.Text = "-";
                    }
                    else
                    {
                        txtCalc.Text = (Convert.ToInt32(txtCalc.Text) * -1).ToString();
                    }

                    break;
                case "«":
                    txtCalc.Text = txtCalc.Text.Substring(0, txtCalc.Text.Length - 1);
                    break;
                case "%":
                    txtCalc.Text = (Getal1 * (Convert.ToDouble(txtCalc.Text) / 100)).ToString();
                    break;
                case "=":
                    break;
                case "√":
                    if (txtCalc.Text != "" && !controle)
                    {
                        txtCalc.Text = Math.Sqrt(Convert.ToDouble(txtCalc.Text)).ToString();
                    }
                    break;
                case "X²":
                    if (txtCalc.Text != "" && !controle)
                    {
                        txtCalc.Text = Math.Pow(Convert.ToDouble(txtCalc.Text), 2).ToString();
                    }
                    break;
                case "¹/x":
                    if (txtCalc.Text != "")
                    {
                        Berekening berek = new Berekening("÷", 1, Double.Parse(txtCalc.Text));
                        berek.Bereken();
                        txtCalc.Text = berek.Uitkomst;
                    }
                    break;
                default:
                    
                    break;
            }
        }

        private void ButtonNum_Click(object sender, EventArgs e)
        {
            if (Char.IsDigit(((Button)sender).Text[0])|| ((Button)sender).Text == ".")
            {
                if (controle)
                {
                    if (txtCalc.Text == "-")
                    {
                        controle = false;
                    }
                    else
                    {
                        txtCalc.Text = "";
                        controle = false;
                    }

                }
                txtCalc.Text += ((Button)sender).Text;
            }
            else
            {
                if (txtOpgave.Text != "")
                {
                    txtOpgave.Text += txtCalc.Text;
                    Berekening berekening = new Berekening(Teken, Getal1, Double.Parse(txtCalc.Text));
                    berekening.Bereken();
                    txtOpgave.Text += ((Button)sender).Text;
                    txtCalc.Text = berekening.Uitkomst;
                    Teken = ((Button)sender).Text;
                    Getal1 = Convert.ToDouble(berekening.Uitkomst);
                }
                else
                {
                    Getal1 = Convert.ToDouble(txtCalc.Text);
                    Teken = ((Button)sender).Text;
                    txtOpgave.Text += txtCalc.Text + ((Button)sender).Text;
                }
                controle = true;
            }
        }
    }

}
