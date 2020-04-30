using System;
using GestionImmoBDD;

namespace GestionImmoBDDConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BDDSingleton BDD = BDDSingleton.Instance;
            Console.WriteLine("Ok tu géres");
            Console.ReadKey();
        }
    }
}
