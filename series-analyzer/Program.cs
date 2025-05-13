
class Program
{
    static void Main(string[] args)
    {
        // Defining global variables
        List<double> series = new List<double>(); // The series of numbers for the program
        bool exit = false;  // The series of numbers for the program
        bool inputIsProper;  // Checking the correctness of the series
        string[] menu = new string[10] { 
            "Input a Series. (Replace the current series)",
            "Display the series in the order it was entered.",
            "Display the series in the reversed order it was entered.",
            "Display the series in sorted order (from low to high).",
            "Display the Max value of the series.",
            "Display the Min value of the series.",
            "Display the Average of the series.",
            "Display the Number of elements in the series.",
            "Display the Sum of the series.",
            "Exit."
            }; 
        
        MainProgram();
        
        // Entry point of the main program logic.
        // Initializes the series and runs the menu loop until the user chooses to exit.
        void MainProgram() 
        {
            SeriesManagement(); 
            while (!exit)
            {
                MenuManagement(); 
            }
        }

        // Manages the input of the number series.
        // Validates input from command-line arguments or user input.
        // Ensures at least three positive numbers are entered.
        void SeriesManagement()
        {
            inputIsProper = false;

            if (args.Length >= 3 && LenSeries() == 0)
            {
                string argInput = string.Join(" ", args);
                InputProcessing(argInput);
            }
            
            while (!inputIsProper)
            {   
                // Receiving input
                string input = ReceiveSeries();
                // Convert to a list of numbers
                InputProcessing(input);
            }
        }

        // Displays the menu and handles user selection to perform operations on the series.
        void MenuManagement()
        {
            DisplayMenu(); 
            string choice = ReceiveSelection(); 
            HandleMenuChoice(choice); 
        }

        // Prompts the user to enter a new series of numbers.
        // Clears the existing series and returns the raw input string.
        string ReceiveSeries()
        {
            series.Clear(); 
            Console.WriteLine("\nEnter a series of numbers.\nSeparated by a single space or comma .\nAt least three positive numbers required!\n");
            var input = Console.ReadLine();
            return (input != null) ? input:"";
        }

        // Processes a string of numbers separated by spaces or commas.
        // Validates that all entries are positive numbers and adds them to the series.   
        void InputProcessing(string input)
        {   
            bool erro = false;

            foreach (string character in input.Split(' ', ','))
            {
                bool IsDigit = double.TryParse(character, out double digit);
                if (IsDigit && digit > 0)
                {
                    series.Add(digit); 
                }
                else
                {
                    Console.WriteLine("A letter was inserted instead of a number.");
                    erro = true;
                    break;
                }
            }

            if (LenSeries() >= 3 && !erro)
            {
                inputIsProper = true;
            }
            else
            {
                Console.WriteLine("The word list does not meet the standards!!");
            }
        }

        // Displays the menu
        void DisplayMenu()
        {
            Console.WriteLine("_________________________________________________");
            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine($"{i + 1}: --> {menu[i]} \n");
            }
            Console.WriteLine("_________________________________________________");
        }

        // Prompts the user to enter a menu choice.
        string ReceiveSelection()
        {
            Console.WriteLine("\n Dear User,\n please enter your selection\n (menu number) \n");
            var input = Console.ReadLine();
            return (input != null) ? input:"";
        };

        // Executes the selected operation based on the user's menu choice.
        void HandleMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    ActionMessage(choice);
                    SeriesManagement(); 
                    break;

                case "2":
                    ActionMessage(choice);
                    Display(series);
                    Wait();
                    break;

                case "3":
                    ActionMessage(choice);
                    List<double> reversed = ReversedOrder();
                    Display(reversed);
                    Wait();
                    break;

                case "4":
                    ActionMessage(choice);
                    List<double> sort = SortLest();
                    Display(sort);
                    Wait();
                    break;

                case "5":
                    ActionMessage(choice);
                    double max = MaxValue();
                    Console.WriteLine($" --->     max: -- {max} -- ");
                    Wait();
                    break;

                case "6":
                    ActionMessage(choice);
                    double min = MinValue();
                    Console.WriteLine($" --->     min: -- {min} -- ");
                    Wait();
                    break;

                case "7":
                    ActionMessage(choice);
                    double average = Average();
                    Console.WriteLine($" --->     average: -- {average} -- ");
                    Wait();
                    break;

                case "8":
                    ActionMessage(choice);
                    int len = LenSeries();
                    Console.WriteLine($" --->     len: -- {len} -- ");
                    Wait();
                    break;

                case "9":
                    ActionMessage(choice);
                    double sum = SumSeries();
                    Console.WriteLine($" --->     sum: -- {sum} -- ");
                    Wait();
                    break;

                case "10":
                    ActionMessage(choice);
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Wrong choice!!");
                    
                    break;
            }
        }

        void Wait()
        {
            Thread.Sleep(1000);
            Console.WriteLine("--- Press any key to continue. ---");
            Console.ReadKey();
            Console.Clear();
        }

        // Simulates a progress bar for user feedback when an action is performed.
        void PrintProgress()
        {
            int steps = 9;
            Console.Write("\n");
            for (int i = 0; i <= steps; i++)
            {
                double percent = (double)i / steps;
                Console.Write($"\rProgress:  {(int)(percent * 100)}%   ");
                Thread.Sleep(100);
            }
            Console.WriteLine("\n");
        }

        // Displays the elements of a given number list to the console.
        void Display(List<double> series)
        {
            // List print function
            Console.WriteLine("");
            foreach(double num in series)
            {
                Console.Write($" --  {num}  --  ");
            }
            Console.WriteLine("");
        }

        // Displays a message indicating which action is being performed based on the user's choice.
        void ActionMessage(string choice)
        {
            Console.Write($"Brings out the {menu[int.Parse(choice) - 1] }:");
            PrintProgress(); // הדפסת התקדמות
        }

        List<double> ReversedOrder()
        {   
            List<double> ReverseList = new List<double> {};
            for (int i = LenSeries() - 1; i >= 0; i--)
            {
                ReverseList.Add(series[i]);
            }
            return ReverseList;
        };
        

        List<double> SortLest()
        {   
            List<double> sortLest = new List<double>(series);
            for (int i = 0; i < LenSeries(); i++)
            {
                int min = i;
                for (int j = i + 1; j < LenSeries(); j++)
                {
                    if (sortLest[j] < sortLest[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    double temporary = sortLest[i];
                    sortLest[i] = sortLest[min];
                    sortLest[min] = temporary;
                }
            }
            return sortLest;
        }

        double MaxValue()
        {
            double max = series[0];
            foreach (double num in series)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        };  

        double MinValue()
        {
            double min = series[0];
            foreach (double num in series)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        };  


        int LenSeries()
        {
            int len = 0;
            foreach (double num in series)
            {
                len += 1;
            }
            return len;
        };

        double SumSeries()
        {
            double sum = 0;
            foreach (double num in series)
            {
                sum += num;
            }
            return sum;
        };

        double Average()
        {
            return SumSeries() / LenSeries();
        };
    }
}
