using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTest
{
    public class Calculatrice
    {
        private readonly IReadOnlyList<IOperation> _operations;
       

        public Calculatrice(IReadOnlyList<IOperation> operations)
        {
            _operations = operations;
         
        }

        public int Calculer(string p0)
        {
            var resultat = 0;
            foreach (var operation in _operations.Where(operation => operation.PeutCalculer(p0)))
            {
                resultat = operation.Calculer(p0);
            }
            return resultat;
        }
    }
}