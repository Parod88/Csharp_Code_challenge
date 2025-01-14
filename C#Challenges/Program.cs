namespace CsharpChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Prime numbers calculator");
            Console.WriteLine("2. Password validation");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Insert a number:");
                    int number = int.Parse(Console.ReadLine()!);
                    var primes = PrimeCalculator.GetPrimes(number);
                    Console.WriteLine("Prime numbers: " + string.Join(", ", primes));
                    break;

                case "2":
                    Console.WriteLine("Insert a password:");
                    string password = Console.ReadLine()!;
                    string result= PasswordValidator.Validate(password);
                    Console.WriteLine(result);
                    break;

                default:
                    Console.WriteLine("Not a valid option.");
                    break;
            }
        }
    }
}
