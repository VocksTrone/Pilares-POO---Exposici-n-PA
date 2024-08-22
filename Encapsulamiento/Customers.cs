using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamiento
{
    public class Customers : People
    {
        private int id;
        private CreditCard card;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public Customers(string name, string address, int id) : base(name, address)
        {
            {
                this.id = id;
            }
        }
        public static void AddCustomer(ref List<Customers> customersList)
        {
            Console.Clear();
            Console.Write("Nombre del Cliente: ");
            string name = Console.ReadLine();
            Console.Write("Dirección del Cliente: ");
            string address = Console.ReadLine();
            Console.Write("ID del Cliente: ");
            int id = int.Parse(Console.ReadLine());
            Customers customer = customersList.Find(x => x.ID == id);
            if (customer == null)
            {
                customersList.Add(new Customers(name, address, id));
                Console.WriteLine("\nCliente Creado Correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nEl ID Ya se Encuentra en Uso");
                Console.ReadKey();
            }
        }
        public static void AssingCreditCard(ref List<Customers> customersList, ref List<CreditCard> creditCardsList)
        {
            if (customersList.Count == 0)
            {
                Console.WriteLine("No Existen Clientes Registrados");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.Write("ID del Cliente: ");
                int id = int.Parse(Console.ReadLine());
                Customers customer = customersList.Find(x => x.ID == id);
                if (customer != null)
                {
                    Console.Write("Número de Tarjeta: ");
                    string cardNumber = Console.ReadLine();
                    CreditCard creditCard = creditCardsList.Find(x => x.CardNumber == cardNumber);
                    if (creditCard == null)
                    {
                        Console.Write("Límite de Crédito: ");
                        double creditLimit = double.Parse(Console.ReadLine());
                        Console.Write("Saldo Inicial: ");
                        double amount = double.Parse(Console.ReadLine());
                        creditCardsList.Add(new CreditCard(cardNumber, creditLimit, amount));
                        Console.WriteLine("\nTarjeta de Crédito Asignada Correctamente");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Número de Tarjeta en Uso");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nCliente No Encontrado");
                    Console.ReadKey();
                }
            }
        }
        public void AddCreditCard(ref List<CreditCard> creditCardsList, CreditCard creditCard)
        {
            creditCardsList.Add(creditCard);
        }
        public void ShowCreditCards(ref List<CreditCard> creditCardsList)
        {
            if (creditCardsList.Count == 0)
            {
                Console.WriteLine("No Existen Tarjetas Asociadas");
            }
            else
            {
                Console.WriteLine("\nTarjetas de Crédito");
                foreach (var creditCard in creditCardsList)
                {
                    creditCard.ShowCardInfo();
                    Console.WriteLine("");
                }
                Console.ReadKey();
            }
        }
        public static void ShowInfoCustomer(ref List<Customers> customersList, ref List<CreditCard> creditCardsList)
        {
            if (customersList.Count == 0)
            {
                Console.WriteLine("No Existen Clientes Registrados");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.Write("ID del Cliente: ");
                int id = int.Parse(Console.ReadLine());
                Customers customer = customersList.Find(x => x.ID == id);
                if (customer != null)
                {
                    Console.WriteLine("");
                    customer.ShowInformation();
                    customer.ShowCreditCards(ref creditCardsList);
                }
                else
                {
                    Console.WriteLine("\nCliente No Encontrado");
                    Console.ReadKey();
                }
            }
        }
        public static void ShowInfoCustomers(ref List<Customers> customersList, ref List<CreditCard> creditCardsList)
        {
            if (customersList.Count == 0)
            {
                Console.WriteLine("No Existen Clientes Registrados");
                Console.ReadKey();
            }
            else
            {
                foreach (var customer in customersList)
                {
                    customer.ShowInformation();
                    customer.ShowCreditCards(ref creditCardsList);
                    Console.WriteLine("--------------------------");
                }
                Console.ReadKey();
            }
        }
        public override void ShowInformation()
        {
            base.ShowInformation();
            Console.WriteLine($"ID del Cliente: {id}");
        }
    }
}
