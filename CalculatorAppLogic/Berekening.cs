using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAppLogic
{
    public class Berekening
    {
        public string Uitkomst { get; set; }
        public string Teken { get; set; }
        public double Getal1 { get; set; }
        public double Getal2 { get; set; }

        public Berekening(string teken, double getal1, double getal2)
        {
            Teken = teken;
            Getal1 = getal1;
            Getal2 = getal2;
        }

        public void Bereken()
        {
            switch (Teken)
            {
                case "+":
                    Uitkomst = (Getal1 + Getal2).ToString();
                    break;
                case "-":
                    Uitkomst = (Getal1 - Getal2).ToString();
                    break;
                case "×":
                    Uitkomst = (Getal1 * Getal2).ToString();
                    break;
                case "÷":
                    Uitkomst = (Getal1 / Getal2).ToString();
                    break;
                default:
                    Uitkomst = "ERROR";
                    break;
            }
        }
    }
}
