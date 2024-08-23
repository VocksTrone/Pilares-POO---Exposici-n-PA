using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamiento
{
    public class CreditCard
    {
        private string cardnumber;
        private double credilLimit;
        private double amount;
        public int CustomerID { get; set; }
        public string CardNumber
        {
            get { return cardnumber; }
            set { cardnumber = value; }
        }
        public double CreditLimit
        {
            get { return credilLimit;}
            set { credilLimit = value; }
        }
        public double Amount
        {
            get{ return amount;}
            set { amount = value; }
        }
        public CreditCard(string cardnumber, double creditlimit, double amount, int customerID)
        {
            this.cardnumber = cardnumber;
            this.credilLimit = creditlimit;
            this.amount = amount;
            CustomerID = customerID;
        }
        public void ShowCardInfo()
        {
            Console.WriteLine($"Número de Tarjeta: {cardnumber}");
            Console.WriteLine($"Límite de Crédito: Q.{Math.Round(credilLimit, 2)}.00");
            Console.WriteLine($"Saldo: Q.{Math.Round(amount, 2)}.00");
        }
    }
}
