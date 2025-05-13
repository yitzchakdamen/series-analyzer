
class Program
{
    static void Main(string[] args)
    {
        List<int> series = new List<int> {};
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
            Console.WriteLine("Enter a series of numbers separated by spaces.");
            var input = Console.ReadLine();
            return (input != null) ? input:"";
        }

        void InputProcessing(string input)
        {   
            bool erro = false;
            int sumPusetivNum = 0;
            if (input.Length >= 1)
            {
                foreach (string num in input.Split(" "))
                {
                    int NumToInt;
                    bool IsNum = int.TryParse(num, out NumToInt);
                    if (IsNum)
                    {
                        // עיבוד הפלט לרשימת מספרים
                        series.Add(NumToInt); 
                        sumPusetivNum += (NumToInt > 0) ? 1:0;
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
            Console.WriteLine("Dear User, please enter your selection (menu number)");
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
                    break;

                case "3":
                    ActionMessage(choice);
                    List<int> reversed = ReversedOrder();
                    Display(reversed);
                    break;

                case "4":
                    ActionMessage(choice);
                    List<int> sort = sortLest();
                    Display(sort);
                    break;

                case "5":
                    ActionMessage(choice);
                    int max = MaxValue();
                    Console.WriteLine($"max: -- {max} -- ");
                    break;

                case "6":
                    ActionMessage(choice);
                    int min = MinValue();
                    Console.WriteLine($"min: -- {min} -- ");
                    break;

                case "7":
                    ActionMessage(choice);
                    double average = Average();
                    Console.WriteLine($"average: -- {average} -- ");
                    break;

                case "8":
                    ActionMessage(choice);
                    int len = LenSeries();
                    Console.WriteLine($" -- {len} -- ");
                    break;

                case "9":
                    ActionMessage(choice);
                    int sum = SumSeries();
                    Console.WriteLine($" -- {sum} -- ");
                    break;

                case "10":
                    ActionMessage(choice);
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Wrong choice!!");
                    break;
            }
        };

        void Display(List<int> series)
        {
            Console.WriteLine("");
            foreach(int num in series)
            {
                Console.Write($" --  {num}  --  ");
            }
            Console.WriteLine("");
        }

        void ActionMessage(string choice)
        {
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
        }

        List<int> ReversedOrder()
        {   
            List<int> NewList = new List<int> {};
            for (int i = LenSeries() - 1; i >= 0; i--)
            {
                NewList.Add(series[i]);
            }
            return NewList;
        };

        List<int> sortLest()
        {   
            List<int> copy = new List<int>([..series]);
            for (int i = 0; i < LenSeries(); i++)
            {
                int min = i;
                for (int j = i + 1; j < LenSeries(); j++)
                {
                    if (copy[j] < copy[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int temporary = copy[i];
                    copy[i] = copy[min];
                    copy[min] = temporary;
                }
            }
            return copy;
        }

        int MaxValue()
        {
            int max = series[0];
            foreach (int num in series)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        };  

        int MinValue()
        {
            int min = series[0];
            foreach (int num in series)
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

        int SumSeries()
        {
            int sum = 0;
            foreach (int num in series)
            {
                sum += num;
            }
            return sum;
        };

        double Average()
        {
            return SumSeries() / Convert.ToDouble(LenSeries());
        };
    }
}
