using System;

namespace FinalTest.thirdPart
{
    public struct RetraitR�alis� : IEvenementMetier
    {
        private Montant _montantRetrait;
        private DateTime _dateRetrait;
        private String _numeroCompte;

        public RetraitR�alis�(String numeroCompte, Montant montantRetrait, DateTime dateRetrait)
        {
            this._montantRetrait = montantRetrait;
            this._dateRetrait = dateRetrait;
            this._numeroCompte = numeroCompte;
        }
    }
}