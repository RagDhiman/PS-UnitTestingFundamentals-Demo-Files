namespace SmartScalesApp.ConsoleUI
{
    public static class ConsoleInput
    {
        public static int ReadInt(ConsoleColor color, string prompt, int min, int max)
        {
            Console.ForegroundColor = color;
            ConsoleOutput.DisplayPrompt(prompt);
            Console.ResetColor();
            return ReadInt(min, max);
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            ConsoleOutput.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                ConsoleOutput.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public static decimal ReadDec(string prompt)
        {
            ConsoleOutput.DisplayPrompt(prompt);
            return ReadDec();
        }

        public static decimal ReadDec()
        {
            string? input = Console.ReadLine();
            decimal value;

            while (!decimal.TryParse(input, out value))
            {
                ConsoleOutput.DisplayPrompt("Please enter a valid value!");
                input = Console.ReadLine();
            }

            return value;
        }

        public static int ReadInt()
        {
            string? input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                ConsoleOutput.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static string? ReadString(string prompt)
        {
            ConsoleOutput.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static string? ReadString(ConsoleColor color, string prompt)
        {
            Console.ForegroundColor = color;
            ConsoleOutput.DisplayPrompt(prompt);
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            ConsoleOutput.WriteLine(prompt);
            //Menu menu = new Menu();

            TEnum choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                Console.WriteLine($"{(int)value}. {Enum.GetName(type, value)}");

            Console.Write("Please select an option:");

            var enteredChoice = Console.ReadLine();
            Enum.TryParse<TEnum>(enteredChoice, out choice);

            return choice;
        }
    }
}