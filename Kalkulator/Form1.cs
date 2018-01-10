using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        Double wartosc = 0;
        String operacja = "";
        bool sprawdz = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

                if ((wynik.Text == "0") || (sprawdz))
                    wynik.Clear();

                sprawdz = false;
                wynik.Text = wynik.Text + b.Text;
            
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (wartosc != 0)
            {
                button17.PerformClick();
                sprawdz = true;
                operacja = b.Text;
            }

            else
            {

                operacja = b.Text;
                wartosc = Double.Parse(wynik.Text);
                sprawdz = true;
            }
        }

        private void rownanie_Click(object sender, EventArgs e)
        {
            switch(operacja)
            {
                case "+":
                    wynik.Text=(wartosc+Double.Parse(wynik.Text)).ToString();
                    break;

                case "-":
                    wynik.Text = (wartosc - Double.Parse(wynik.Text)).ToString();
                    break;

                case "/":
                    if (wynik.Text == "0")
                    {
                        SystemSounds.Exclamation.Play();
                        MessageBox.Show("Nie można dzielic przez 0!!!");
                        wartosc = 0;
                        sprawdz = true;
                    }
                    else
                    wynik.Text = (wartosc / Double.Parse(wynik.Text)).ToString();
                    break;

                case "*":
                    wynik.Text = (wartosc * Double.Parse(wynik.Text)).ToString();
                    break;
                default:
                    break;
            }// koniec switcha
            wartosc = Double.Parse(wynik.Text);
            operacja = "";
        }

        private void wyczysc_Click(object sender, EventArgs e)
        {
            wartosc = 0;
            wynik.Text = "0";
            operacja = "";
            sprawdz = false;
        }
    }
}
