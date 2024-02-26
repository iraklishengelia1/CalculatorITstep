

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("-----------------------------");
Console.WriteLine("Welcome to the C# Calculator!");
Console.WriteLine("-----------------------------");
Console.Write("Enter an operator (+, -, *, /, ^, s) or type 'exit' to quit: ");

while (true)
{
    string operatorInput;
    do
    {
        operatorInput = Console.ReadLine();
        if (operatorInput.ToLower() == "exit")
        {
            Console.WriteLine("Exiting the calculator.");
            return;
        }

        switch (operatorInput)
        {
            case "+":
            case "-":
            case "*":
            case "/":
            case "^":
            case "s":
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nInvalid operator. Please enter a valid operator (+, -, *, /, ^, s).");
                Console.Write("\nPlease try again enter operator: ");
                break;
        }
    } while (operatorInput != "+" && operatorInput != "-" && operatorInput != "*" && operatorInput != "/" && operatorInput != "^" && operatorInput != "s");

    double num1, num2 = 0;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Enter number 1: ");
    string num1Input = Console.ReadLine();
    if (!double.TryParse(num1Input, out num1))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid input. Please enter a valid number.");
        Console.WriteLine("\nPlease enter operator again, and valid number.");
        Console.ResetColor();
        continue;
    }

    switch (operatorInput)
    {
        case "+":
        case "-":
        case "*":
        case "^":
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter number 2: ");
            string num2Input = Console.ReadLine();
            if (!double.TryParse(num2Input, out num2))
            {
                Console.WriteLine("\nInvalid input. Please enter a valid number.");
                Console.Write("\nplease try again enter operator: ");
                Console.ResetColor();
                continue;
            }
            break;
        case "/":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter number 2: ");
            string num2InputDiv = Console.ReadLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            if (!double.TryParse(num2InputDiv, out num2))
            {
                Console.WriteLine("\nInvalid input. Please enter a valid number.");
                Console.Write("\nplease try again enter operator: ");
                continue;
            }
            if (num1 == 0 || num2 == 0)
            {
                Console.WriteLine("\nCannot divide by zero. Please enter a non-zero divisor.");
                Console.ResetColor();
                Console.Write("\nplease try again enter operator: ");
                continue;
            }
            break;
        case "s":
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter the root: ");
            string rootInput = Console.ReadLine();
            if (!double.TryParse(rootInput, out num2))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.WriteLine("please try again enter operator: ");
                Console.ResetColor();
                continue;
            }
            if (num2 <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for the root.");
                Console.WriteLine("please try again enter operator: ");
                Console.ResetColor();
                continue;
            }
            break;
    }

    double result = CalculateResult(operatorInput, num1, num2);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"\nYour result: {num1} {operatorInput} {num2} = " + result);
    Console.ResetColor ();
   Console.ForegroundColor= ConsoleColor.Cyan;
    Console.Write("\nPlease enter an operator for the following calculation: ");
    Console.ResetColor();
}
        

        static double CalculateResult(string operatorInput, double num1, double num2)
{
    double result = 0;
    switch (operatorInput)
    {
        case "+":
            result = num1 + num2;
            break;
        case "-":
            result = num1 - num2;
            break;
        case "*":
            result = num1 * num2;
            break;
        case "/":
            result = num1 / num2;
            break;
        case "^":
            result = Math.Pow(num1, num2);
            break;
        case "s":
            result = Math.Pow(num1, 1 / num2);
            break;
    }
    return result;
}
    