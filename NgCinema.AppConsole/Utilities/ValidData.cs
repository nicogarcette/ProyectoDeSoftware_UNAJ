namespace NgCinema.ConsoleApp.Utilities
{
    public static class ValidData
    {
        public static int AskForNumber(string name, int max = int.MaxValue, int min = 0)
        {
            int number = 0;
            bool valid = false;

            while(!valid)
            {
                Console.Write($"{name}:");
                valid = int.TryParse(Console.ReadLine(), out number);
                
                if(!valid || number < min || number > max)
                {
                    if(max != int.MaxValue || min != 0)
                        Console.WriteLine($"Por favor, ingrese un número válido entre {min} y {max}.");
                    else
                        Console.WriteLine("Por favor, ingrese un número válido.");
                    
                    valid = false;
                }
            }
            
            return number;
        }

        public static string AskForString(string name)
        {
            string data = Console.ReadLine();

            while(string.IsNullOrEmpty(data))
            {
                Console.Write($"Campo vacio. Ingrese {name}: ");
                data = Console.ReadLine();
            }

            return data;
        }
    }
}
