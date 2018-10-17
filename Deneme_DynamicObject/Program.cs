namespace Deneme_DynamicObject
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic myObj = new Wrapper(new Ops());
            myObj.Add(3, 4);
        }
    }
}
