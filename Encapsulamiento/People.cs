using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamiento
{
    public class People
    {
        private string name;
        private string address;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public People(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        public virtual void ShowInformation()
        {
            Console.WriteLine($"Nombre: {name}");
            Console.WriteLine($"Dirección: {address}");
        }
    }
}