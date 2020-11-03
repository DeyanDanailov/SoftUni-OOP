

namespace Restaurant
{
    public static class StartUp
    {
        static void Main(string[] args)
        {
            var mascarpone = new Cake("mascarpone");
            System.Console.WriteLine(mascarpone.Price);
        }
    }
}
