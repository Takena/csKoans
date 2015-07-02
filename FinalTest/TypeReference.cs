namespace FinalTest
{
    public class TypeReference
    {
        protected bool Equals(TypeReference other)
        {
            return _valeur == other._valeur;
        }

        public override int GetHashCode()
        {
            return _valeur;
        }

        private readonly int _valeur; 

        public TypeReference(int i)
        {
            _valeur = i;
        }

        public override bool Equals(object obj)
        {
            //On cast l'objet et on compare la valeur 
            return _valeur == ((TypeReference) obj)._valeur;
        }
    }
}