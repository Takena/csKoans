using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FinalTest.thirdPart
{
    public class CompteBancaire : IEvenementMetier
    {
        private readonly String _numeroDeCompte;
        private int _autorisationDeCredit;
        private Montant _montantStandard;

        public CompteBancaire(CompteCr�� nouveauCompte)
        {
            this._montantStandard = new Montant(0);
            this._numeroDeCompte = nouveauCompte.NumeroDeCompte;

        }

        public CompteBancaire(CompteCr�� compteCree, D�potR�alis� d�potR�alis�)
        {
            this._numeroDeCompte = compteCree.NumeroDeCompte;
            this._montantStandard = new Montant(0);
            this._montantStandard.Montant1 += d�potR�alis�.Depot.Montant1;

        }

        public static IEnumerable<IEvenementMetier> Ouvrir(string num�roDeCompte, int autorisationDeCr�dit)
        {
            var nouveauCompte = new CompteCr��(num�roDeCompte, autorisationDeCr�dit);
            yield return nouveauCompte;
        }

        public IEnumerable<IEvenementMetier> FaireUnDepot(Montant montantDepot, DateTime dateDepot)
        {
            var depot = new D�potR�alis�(_numeroDeCompte, montantDepot, dateDepot);
            _montantStandard.Montant1 += montantDepot.Montant1;
            yield return depot;
        }


        public IEnumerable<IEvenementMetier> FaireUnRetrait(Montant montantRetrait, DateTime dateRetrait)
        {
            if ((_montantStandard.Montant1 - montantRetrait.Montant1) * -1 > _autorisationDeCredit)
            {
                throw new RetraitNonAutoris�();
            }
            else
            {
                _montantStandard.Montant1 -= montantRetrait.Montant1;
                yield return new RetraitR�alis�(_numeroDeCompte, montantRetrait, dateRetrait);
                if (_montantStandard.Montant1 < 0)
                {
                    yield return new BalanceN�gativeD�tect�e(_numeroDeCompte, new Montant(_montantStandard.Montant1 * -1), dateRetrait);
                }
            }

        }
    }
}