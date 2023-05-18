class Program
{
    static void Main(string[] args)
    {
        int letterCount = int.Parse(Console.ReadLine());
        int digitCount = int.Parse(Console.ReadLine());

        string lastCode = FirstCode(letterCount, digitCount);
        var products = new Dictionary<string, string>();

        string product = Console.ReadLine();

        while (product != "Stop")
        {
            products.Add(lastCode, product);
            lastCode = GenerateNextCode(lastCode);
            product = Console.ReadLine();
        }

        string searchCode = Console.ReadLine();
        Search(searchCode, products);
    }
    
    static void Search(string searchCode, Dictionary<string, string> products)
    {
        foreach (KeyValuePair<string, string> p in products)
        {
            if (p.Key == searchCode)
            {
                Console.WriteLine(p.Value);
                return;
            }
        }
        Console.WriteLine("Not found!");
    }

    static string FirstCode(int letterCount, int digitCount)
    {
        string letters = new string('A', letterCount);
        string digits = new string('0', digitCount);
        return letters + digits;
    }

    static string GenerateNextCode(string lastCode)
    {
        char[] codeArray = lastCode.ToCharArray();
        int index = codeArray.Length - 1;

        while (index >= 0 && codeArray[index] == '9')
        {
            codeArray[index] = '0';
            index--;
        }

        if (index >= 0)
        {
            codeArray[index]++;
        }
        else
        {
            Array.Resize(ref codeArray, codeArray.Length + 1);
            codeArray[0] = 'A';
        }
        return new string(codeArray);
    }
}