using System;

namespace FinalTest.thirdPart
{
    public struct DépotRéalisé : IEvenementMetier
    {
        public string NumCompte { get; private set; }
        public Montant Depot { get; private set; }
        public DateTime Date { get; private set; }

        public DépotRéalisé(string numCompte, Montant depot, DateTime date) : this()
        {
            this.Date = date;
            this.NumCompte = numCompte;
            this.Depot = depot;           
        }

    }
}