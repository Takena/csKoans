namespace FinalTest.firstPart
{
    public class Somme : IOperation
    {
        public bool PeutCalculer(string p0)
        {
            return p0.Contains("+");
        }

        public int Calculer(string s)
        {
            var firstValue = int.Parse(s.Split('+')[0]);
            var secondValue = int.Parse(s.Split('+')[1]);
            return firstValue + secondValue;
        }
    }
}