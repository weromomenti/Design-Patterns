public delegate bool ContextDelegate(int number);

class Context
{
    public Func<int, int, int> Strategy { get; set; }
    public int ExecuteStrategy(int num1, int num2)
    {
        return Strategy(num1, num2);
    }

}

class Strategy
{
    public static void Main(string[] args)
    {
        var context = new Context();

        context.Strategy = (int num1, int num2) =>
        {
            num1++;
            num2++;
            return num1 * num2;
        };
        Console.WriteLine(context.ExecuteStrategy(2, 3));

        context.Strategy = (int num1, int num2) => num1 + num2;
        Console.WriteLine(context.ExecuteStrategy(2, 3));
    }
}

