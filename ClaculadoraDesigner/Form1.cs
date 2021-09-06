using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDesigner
{
    public partial class FormDesigner : Form
    {
        Double valor = 0;
        String operador = "";
        bool acionaOperador = false;

        public FormDesigner()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (acionaOperador))
                textBox1.Clear();

            acionaOperador = false;

            Button b = (Button)sender;

            if (b.Text == ",")
            {
                if (!textBox1.Text.Contains(","))
                    textBox1.Text += b.Text;

                if (!textBox1.Text.Contains("0") && (textBox1.Text.Length > 0))
                    if (!textBox1.Text.Contains("1") && !textBox1.Text.Contains("2") && !textBox1.Text.Contains("3") &&
                        !textBox1.Text.Contains("4") && !textBox1.Text.Contains("5") && !textBox1.Text.Contains("6") &&
                        !textBox1.Text.Contains("7") && !textBox1.Text.Contains("8") && !textBox1.Text.Contains("9"))
                        textBox1.Text = "0,";
            }
            else
                textBox1.Text += b.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            valor = 0;
            equacao.Text = "";
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void operador_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if(valor != 0)
            {
                buttonIgual.PerformClick();
                acionaOperador = true;
                operador = b.Text;
                equacao.Text = valor + " " + operador;
            }
            else
            {
                operador = b.Text;
                valor = Double.Parse(textBox1.Text);
                acionaOperador = true;
                equacao.Text = valor + " " + operador;
            }          
        }

        private void buttonIgual_Click(object sender, EventArgs e)
        {
            try
            {
                equacao.Text = " ";
                switch (operador)
                {
                    case "+":
                        textBox1.Text = (valor + Double.Parse(textBox1.Text)).ToString();
                        break;

                    case "-":
                        textBox1.Text = (valor - Double.Parse(textBox1.Text)).ToString();
                        break;

                    case "/":
                        string result = (valor / Double.Parse(textBox1.Text)).ToString();
                        if (result == "∞")
                            textBox1.Text = "Erro";
                        else
                            textBox1.Text = result;
                        break;

                    case "*":
                        textBox1.Text = (valor * Double.Parse(textBox1.Text)).ToString();
                        break;

                    default:
                        break;
                }

                valor = Int32.Parse(textBox1.Text);
                operador = "";
            }
            catch
            {

            }
        }

        private void FormDesigner_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    button0.PerformClick();
                    break;
                case "1":
                    button1.PerformClick();
                    break;
                case "2":
                    button2.PerformClick();
                    break;
                case "3":
                    button3.PerformClick();
                    break;
                case "4":
                    button4.PerformClick();
                    break;
                case "5":
                    button5.PerformClick();
                    break;
                case "6":
                    button6.PerformClick();
                    break;
                case "7":
                    button7.PerformClick();
                    break;
                case "8":
                    button8.PerformClick();
                    break;
                case "9":
                    button9.PerformClick();
                    break;
                case ",":
                    buttonPoint.PerformClick();
                    break;
                case "+":
                    buttonSoma.PerformClick();
                    break;
                case "-":
                    buttonSub.PerformClick();
                    break;
                case "/":
                    buttonDiv.PerformClick();
                    break;
                case "*":
                    buttonMult.PerformClick();
                    break;
                case "=":
                    buttonIgual.PerformClick();
                    break;
                //case "enter":
                //    buttonIgual.PerformClick();
                //    break;
                default:
                    break;
            }
        }
    }
}
