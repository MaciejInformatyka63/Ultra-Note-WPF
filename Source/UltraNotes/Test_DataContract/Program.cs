using System;
using Modele;

namespace Test_DataContract
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new Bouquin(new Data.Stub()));
            manager.Bouquin.ChargeDonnees();
            manager.Bouquin.Persistance = new DataContractPersistance.DataContractPers();
            manager.Bouquin.SauvegardeDonnees();
        }
    }
}
