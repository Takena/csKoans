using System;
using System.Collections;

namespace FinalTest.thirdPart
{
    public struct CompteCréé : IEvenementMetier
    {
        private readonly String _numeroDeCompte;
        private readonly int _autorisationDeCredit;

        public CompteCréé(string numéroDeCompte, int autorisationDeCrédit)
        {
            this._numeroDeCompte = numéroDeCompte;
            this._autorisationDeCredit = autorisationDeCrédit;
        }


        public string NumeroDeCompte
        {
            get { return _numeroDeCompte; }
        }

        public int AutorisationDeCredit
        {
            get { return _autorisationDeCredit; }
        }
    }
}