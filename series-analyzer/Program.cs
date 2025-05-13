
class Program
{
    static void Main(string[] args)
    {
        List<double> series = new List<double> {};
        bool exit = false;
        bool inputIsProper;
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

        void MainProgram()
        {
            // Getting a list of numbers
            SeriesManagement(); 
            while (!exit)
            {
                // Menu activation
                MenuManagement(); 
            }
        }

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

        void MenuManagement()
        {
            DisplayMenu(); // Printing the menu
            string choice = ReceiveSelection(); // Accept the choice.
            PerformOperation(choice); // Performing the selected action
        }

        string ReceiveSeries()
        {
            // Clears the list before inserting a new value.
            series.Clear();
            // Getting a list - string
            Console.WriteLine("\nEnter a series of numbers.\nSeparated by a single space.\nAt least three positive numbers required!\n");
            var input = Console.ReadLine();
            return (input != null) ? input:"";
        }

        void InputProcessing(string input)
        {   
            bool erro = false;
            int sumPusetivNum = 0;
            if (input.Length >= 1)
            {
                foreach (string character in input.Split(" "))
                {
                    double digit;
                    bool IsDigit = double.TryParse(character, out digit);
                    if (IsDigit)
                    {
                        // עיבוד הפלט לרשימת מספרים
                        series.Add(digit); 
                        sumPusetivNum += (digit > 0) ? 1:0;
                    }
                    else
                    {
                        erro = true;
                    }
                }
            }
            if (LenSeries() >= 3 && sumPusetivNum >= 3 && !erro)
            {
                inputIsProper = true;
            }
            else
            {
                Console.WriteLine("Non-standard list of numbers!!");
            }
        }

        void DisplayMenu()
        {
            Console.WriteLine("_________________________________________________");
            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine($"{i + 1}: --> {menu[i]} \n");
            }
            Console.WriteLine("_________________________________________________");
        }

        string ReceiveSelection()
        {
            Console.WriteLine("\n Dear User,\n please enter your selection\n (menu number) \n");
            var input = Console.ReadLine();
            return (input != null) ? input:"";
        };

        void PerformOperation(string choice)
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
                    Thread.Sleep(2000);
                    break;

                case "3":
                    ActionMessage(choice);
                    List<double> reversed = ReversedOrder();
                    Display(reversed);
                    Thread.Sleep(2000);
                    break;

                case "4":
                    ActionMessage(choice);
                    List<double> sort = sortLest();
                    Display(sort);
                    Thread.Sleep(2000);
                    break;

                case "5":
                    ActionMessage(choice);
                    double max = MaxValue();
                    Console.WriteLine($" --->     max: -- {max} -- ");
                    Thread.Sleep(2000);
                    break;

                case "6":
                    ActionMessage(choice);
                    double min = MinValue();
                    Console.WriteLine($" --->     min: -- {min} -- ");
                    Thread.Sleep(2000);
                    break;

                case "7":
                    ActionMessage(choice);
                    double average = Average();
                    Console.WriteLine($" --->     average: -- {average} -- ");
                    Thread.Sleep(2000);
                    break;

                case "8":
                    ActionMessage(choice);
                    int len = LenSeries();
                    Console.WriteLine($" --->     len: -- {len} -- ");
                    Thread.Sleep(2000);
                    break;

                case "9":
                    ActionMessage(choice);
                    double sum = SumSeries();
                    Console.WriteLine($" --->     sum: -- {sum} -- ");
                    Thread.Sleep(2000);
                    break;

                case "10":
                    ActionMessage(choice);
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Wrong choice!!");
                    Thread.Sleep(2000);
                    break;
            }
        };

        void PrintProgress()
        {
            int steps = 20;
            Console.Write("\n");
            for (int i = 0; i <= steps; i++)
            {
                double percent = (double)i / steps;
                Console.Write($"\rProgress:  {(int)(percent * 100)}%   ");
                Thread.Sleep(100);
            }
            Console.WriteLine("\n");
        }

        void Display(List<double> series)
        {
            Console.WriteLine("");
            foreach(double num in series)
            {
                Console.Write($" --  {num}  --  ");
            }
            Console.WriteLine("");
        }

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

        List<double> sortLest()
        {   
            List<double> list = new List<double>(series);
            for (int i = 0; i < LenSeries(); i++)
            {
                int min = i;
                for (int j = i + 1; j < LenSeries(); j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    double temporary = list[i];
                    list[i] = list[min];
                    list[min] = temporary;
                }
            }
            return list;
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
            foreach (int num in series)
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
