using Encapsulamiento;
using System.Collections.Generic;

bool generalContinue = true;
List <Customers> customersList = new List<Customers>();
List<CreditCard> creditCardsList = new List<CreditCard>();

while (generalContinue)
{
	try
	{
        SwitchFirstMenu();
	}
	catch (FormatException)
	{
        Console.WriteLine("ERROR!, Datos Inválidos");
		Console.ReadKey();
	}
}
int FirstMenu()
{
    Console.Clear();
    Console.WriteLine("--- Sistema de Banco ---");
    Console.WriteLine("1. Crear Cliente");
    Console.WriteLine("2. Asignar Tarjeta de Crédito");
    Console.WriteLine("3. Buscar Información");
    Console.WriteLine("4. Mostrar Información");
    Console.WriteLine("5. Salir");
    Console.Write("\nIngrese una Opción del Menú: ");
    int optionFirstMenu = int.Parse(Console.ReadLine());
    return optionFirstMenu;
}
bool GoOut()
{
    Console.Clear();
    Console.WriteLine("Usted está Saliendo del Programa");
    generalContinue = false;
    return generalContinue;
}
void SwitchFirstMenu()
{
    switch (FirstMenu())
    {
        case 1:
            Customers.AddCustomer(ref customersList);
            break;
        case 2:
            Customers.AssignCreditCard(ref customersList, ref creditCardsList);
            break;
        case 3:
            Customers.ShowInfoCustomer(ref customersList, ref creditCardsList);
            break;
        case 4:
            Customers.ShowInfoCustomers(ref customersList, ref creditCardsList);
            break;
        case 5:
            GoOut();
            break;
        default:
            Console.WriteLine("Ingrese una Opción Válida (1 - 5)");
            Console.ReadKey();
            break;
    }
}
