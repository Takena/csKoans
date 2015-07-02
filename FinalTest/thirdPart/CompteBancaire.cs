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

        public CompteBancaire(CompteCréé nouveauCompte)
        {
            this._montantStandard = new Montant(0);
            this._numeroDeCompte = nouveauCompte.NumeroDeCompte;

        }

        public CompteBancaire(CompteCréé compteCree, DépotRéalisé dépotRéalisé)
        {
            this._numeroDeCompte = compteCree.NumeroDeCompte;
            this._montantStandard = new Montant(0);
            this._montantStandard.Montant1 += dépotRéalisé.Depot.Montant1;

        }

        public static IEnumerable<IEvenementMetier> Ouvrir(string numéroDeCompte, int autorisationDeCrédit)
        {
            var nouveauCompte = new CompteCréé(numéroDeCompte, autorisationDeCrédit);
            yield return nouveauCompte;
        }

        public IEnumerable<IEvenementMetier> FaireUnDepot(Montant montantDepot, DateTime dateDepot)
        {
            var depot = new DépotRéalisé(_numeroDeCompte, montantDepot, dateDepot);
            _montantStandard.Montant1 += montantDepot.Montant1;
            yield return depot;
        }


        public IEnumerable<IEvenementMetier> FaireUnRetrait(Montant montantRetrait, DateTime dateRetrait)
        {
            if ((_montantStandard.Montant1 - montantRetrait.Montant1) * -1 > _autorisationDeCredit)
            {
                throw new RetraitNonAutorisé();
            }
            else
            {
                _montantStandard.Montant1 -= montantRetrait.Montant1;
                yield return new RetraitRéalisé(_numeroDeCompte, montantRetrait, dateRetrait);
                if (_montantStandard.Montant1 < 0)
                {
                    yield return new BalanceNégativeDétectée(_numeroDeCompte, new Montant(_montantStandard.Montant1 * -1), dateRetrait);
                }
            }

        }
    }
}