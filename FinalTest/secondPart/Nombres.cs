using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTest.secondPart
{
    public class Nombres
    {
        private readonly IEnumerable<KeyValuePair<string, int>> _keyValuePairs;

        public Nombres(IEnumerable<KeyValuePair<string, int>> keyValuePairs)
        {           _keyValuePairs = keyValuePairs;        }

        public IEnumerable<int> NombresPairs
        {
            get
            {
                return this._keyValuePairs.Where(x => x.Value % 2 == 0).Select(x => x.Value);
            }
        }

        public string TexteNombresImpairs
        {
            get
            {
                return this._keyValuePairs.Where(x => x.Value%2 != 0)
                    .OrderBy(x => x.Value)
                    .Select(x => x.Key).Aggregate((k, l) => k + ", " + l);
            }
        }

        public string PremierNombreDontLeTexteContientPlusDe5Caractères
        {
            get
            {
                return this._keyValuePairs.Where(x => x.Key.Length > 5)
                    .Select(x=> x.Key).First();
            }
        }

        public IEnumerable<int> QuatreNombresSupérieursSuivant3
        {
            // retourne un IEnumerable<int> en utilisant Linq (i.e sans utiliser de boucles) -> OrderBy + Skip (optionnel) + Take
            get
            {
                return this._keyValuePairs.Where(x => x.Value > 3).OrderBy(x => x.Value)
                    .Select(x => x.Value).Take(4);
            }
        }
    }
}