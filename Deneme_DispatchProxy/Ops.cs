namespace Deneme_DispatchProxy
{
    public class Ops: IOps
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public virtual int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
