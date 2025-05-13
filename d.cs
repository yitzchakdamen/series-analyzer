namespace SeriesAnalyzer
{
    class Program
    {

        static void Main(string[] args)
        {

            List<int> seriesList = new List<int>();
            if (validationInput(args))
            {
                seriesList = convertFromStringToilsInt(args);
            }
            else
            {
                seriesList = inputSeries();
            }


            void showMenu()
            {
                Console.WriteLine("\nSeries Analyzer");
                Console.WriteLine("a. Input series");
                Console.WriteLine("b. Display series");
                Console.WriteLine("c. Display series in reverse");
                Console.WriteLine("d. Display series sorted");
                Console.WriteLine("e. Display max number");
                Console.WriteLine("f. Display min number");
                Console.WriteLine("g. Display average");
                Console.WriteLine("h. Display number of elements");
                Console.WriteLine("i. Display sum");
                Console.WriteLine("j. Exit");
                Console.Write("Enter your choice: ");
            }

            List<int> convertFromStringToilsInt(string[] inputNumbers)
            {
                List<int> seriesList = new List<int>();
                foreach (string number in inputNumbers)
                {
                    int num = int.Parse(number);
                    seriesList.Add(num);
                }
                return seriesList;
            }

            bool validationInput(string [] inputNumbers)
            {
                if (inputNumbers.Length < 3)
                {
                    Console.WriteLine("Please enter at least 3 numbers.");
                    return false;
                }
                foreach (string number in inputNumbers)
                {
                    if (!int.TryParse(number, out int numberInt) )
                    {
                        Console.WriteLine($"Invalid input: {number} is not a number.");
                        return false;
                    } 
                    else if (numberInt < 0)
                    {
                        Console.WriteLine($"Invalid input: {number} is a negative number.");
                        return false;
                    }
                }
                return true;
            }


            List<int> inputSeries()
            {
                Console.Write("Enter at least 3 numbers: ");
                string inputNumbers = Console.ReadLine()!;
                string[] inputNumbersArras = inputNumbers.Split();


                if (validationInput(inputNumbersArras))
                {
                    return convertFromStringToilsInt(inputNumbersArras);
                }
                Console.WriteLine("Enter a valid number: ");
                return inputSeries();
            }


            void displaySeriesList(List<int> seriesList)
            {
                foreach (int num in seriesList)
                {
                    Console.Write(num + " ");
                }
            }


            List<int> convertListToReverse(List<int> seriesList)
            {
                List<int> seriesListRevers = new List<int>();
                int lengthList = SeriesNumberElements(seriesList);
                for (int i = lengthList - 1; i >= 0; i--)
                {
                    seriesListRevers.Add(seriesList[i]);
                }
                return seriesListRevers;
            }


            List<int> SeriesSorted(List<int> seriesList)
            {
                List<int> seriesListSorted = new List<int>(seriesList);
                seriesListSorted.Sort();
                return seriesListSorted;
            }


            int SeriesMax(List<int> seriesList)
            {
                int max = 0;
                foreach (int num in seriesList)
                {
                    if (num > max)
                    {
                        max = num;
                    }
                }
                return max;
            }


            int SeriesMin(List<int> seriesList)
            {
                int min = seriesList[0];
                foreach (int num in seriesList)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }
                return min;
            }


            float SeriesAverage(List<int> seriesList)
            {
                int NumElements = SeriesNumberElements(seriesList);
                int sum = calculateSumSeries(seriesList);
                float average = sum / NumElements;
                return average;
            }


            int SeriesNumberElements(List<int> seriesList)
            {
                int numElements = 0;
                foreach (int num in seriesList)
                {
                    numElements += 1;
                }
                return numElements;
            }


            int calculateSumSeries(List<int> seriesList)
            {
                int sum = 0;
                foreach (int num in seriesList)
                {
                    sum += num;
                }
                return sum;
            }


            bool Menu()
            {
                showMenu();
                string choice = Console.ReadLine()!.ToLower();
                switch (choice)
                {
                    case "a":
                        seriesList = inputSeries();
                        break;
                    case "b":
                        displaySeriesList(seriesList);
                        break;
                    case "c":
                        List<int> reversList = convertListToReverse(seriesList);
                        displaySeriesList(reversList);
                        break;
                    case "d":
                        List<int> seriesListSOrt = SeriesSorted(seriesList);
                        displaySeriesList(seriesListSOrt);
                        break;
                    case "e":
                        SeriesMax(seriesList);
                        Console.WriteLine($"Max number: {SeriesMax(seriesList)}");
                        break;
                    case "f":
                        SeriesMin(seriesList);
                        Console.WriteLine($"Min number: {SeriesMin(seriesList)}");
                        break;
                    case "g":
                        SeriesAverage(seriesList);
                        Console.WriteLine($"Average number: {SeriesAverage(seriesList)}");
                        break;
                    case "h":
                        Console.WriteLine($"Number of elements: {SeriesNumberElements(seriesList)}");
                        break;
                    case "i":
                        Console.WriteLine($"Sum of series: {calculateSumSeries(seriesList)}");
                        break;
                    case "j":
                        Console.WriteLine("Exiting...");
                        return true;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                return false;
            }


            void displayLoopMenu()
            {
                bool exit;
                do
                {
                    exit = Menu();
                }
                while (!exit);
            }

            displayLoopMenu();
        }
    }
}