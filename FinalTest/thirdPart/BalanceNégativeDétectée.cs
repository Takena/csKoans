using System;

namespace FinalTest.thirdPart
{
    public struct BalanceNégativeDétectée : IEvenementMetier
    {
        public Montant _montant;
        public DateTime _dateRetrait;
        public String _numeroCompte;

        public BalanceNégativeDétectée(string numeroCompte, Montant montant, DateTime dateRetrait)
        {
            this._montant = montant;
            this._dateRetrait = dateRetrait;
            this._numeroCompte = numeroCompte;
        }
    }
}