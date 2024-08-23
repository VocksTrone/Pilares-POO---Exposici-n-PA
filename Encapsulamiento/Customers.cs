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
        public static void AssignCreditCard(ref List<Customers> customersList, ref List<CreditCard> creditCardList)
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
                    CreditCard creditCard = creditCardList.Find(x => x.CardNumber == cardNumber);
                    if (creditCard == null)
                    {
                        Console.Write("Límite de Crédito: ");
                        double creditLimit = double.Parse(Console.ReadLine());
                        Console.Write("Saldo Inicial: ");
                        double amount = double.Parse(Console.ReadLine());
                        creditCardList.Add(new CreditCard(cardNumber, creditLimit, amount, id));
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
        public static void ShowInfoCustomer(ref List<Customers> customersList, ref List<CreditCard> creditCardsList)
        {
            if (customersList.Count == 0)
            {
                Console.WriteLine("\nNo Existen Clientes Registrados");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.Write("ID del CLiente: ");
                int id = int.Parse(Console.ReadLine());
                Customers customer = customersList.Find(x => x.ID == id);
                if (customer != null)
                {
                    Console.Clear();
                    Console.WriteLine("Datos Generales");
                    Console.WriteLine("");
                    customer.ShowInformation();
                    Console.WriteLine("\nDatos Crediticios");
                    CreditCard card = creditCardsList.Find(x => x.CustomerID == id);
                    if (card != null)
                    {
                        Console.WriteLine("");
                        card.ShowCardInfo();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nNo Existen Tarjetas Asociadas al Cliente");
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
        public static void ShowInfoCustomers(ref List<Customers> customersList, ref List<CreditCard> creditCardsList)
        {
            if (customersList.Count == 0)
            {
                Console.WriteLine("\nNo Existen Clientes Registrados");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Clientes Registrados");
                foreach (Customers customer in customersList)
                {
                    Console.WriteLine("");
                    customer.ShowInformation();
                    bool hasCreditCard = false;
                    foreach (CreditCard creditCard in creditCardsList)
                    {
                        if (creditCard.CustomerID == customer.ID)
                        {
                            if (!hasCreditCard)
                            {
                                Console.WriteLine("\nDatos Crediticios:");
                                hasCreditCard = true;
                            }
                            Console.WriteLine("");
                            creditCard.ShowCardInfo();
                        }
                    }
                    if (!hasCreditCard)
                    {
                        Console.WriteLine("\nDatos Crediticios");
                        Console.WriteLine("\nNo Existen Tarjetas de Crédito Asociadas");
                    }
                    Console.WriteLine("\n-------------------------");
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
