
List<int> SeriesOfNumbers = new List<int> {};
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


void MainManagement()
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
    
    while (!inputIsProper)
    {   
        // Receiving input
        string input = ReceiveSeries();
        // Convert to a list of numbers
        InputProcessing(input);
    };
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
    SeriesOfNumbers.Clear();
    // Getting a list - string
    Console.WriteLine("Enter a series of numbers separated by spaces.");
    return Console.ReadLine();
}

void InputProcessing(string input)
{   
    if (input.Length >= 1)
    {
        foreach (string num in input.Split(" "))
        {
            // עיבוד הפלט לרשימת מספרים
            SeriesOfNumbers.Add(int.Parse(num)); 
        }
        inputIsProper = true;
    }
    else
    {
        Console.WriteLine("Non-standard list of numbers!!");
    }
}

void DisplayMenu()
{
    Console.WriteLine("");
    for (int i = 0; i <= 9; i++)
    {
        Console.WriteLine($"{i + 1}: {menu[i]}");
    }
    Console.WriteLine("");
}

string ReceiveSelection()
{
    Console.WriteLine("Dear User, please enter your selection (menu number)");
    return Console.ReadLine();
};

void PerformOperation(string choice)
{
    switch (choice)
    {
        case "1":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            SeriesManagement();
            break;

        case "2":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            DisplayInOrder();
            break;

        case "3":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            DisplayInReversedOrder();
            break;

        case "4":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            DisplaySortedSeries(sortLest());
            break;

        case "5":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            DisplayMaxValue();
            break;

        case "6":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            DisplayMinValue();
            break;

        case "7":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            DisplayAverage();
            break;

        case "8":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            Console.WriteLine(NumberElements());
            break;

        case "9":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            Console.WriteLine(SumSeries());
            break;

        case "10":
            Console.WriteLine($"Brings out the {menu[int.Parse(choice) - 1] }:");
            exit = true;
            break;

        default:
            Console.WriteLine("Wrong choice!!");
            break;
    }
};


void DisplayInOrder()
{
    Console.WriteLine("");
    foreach(int num in SeriesOfNumbers)
    {
        Console.Write($"{num} - ");
    }
};

void DisplayInReversedOrder()
{   
    for (int i = NumberElements() - 1; i >= 0; i--)
    {
        Console.Write($"{SeriesOfNumbers[i]} - ");
    }
    Console.WriteLine("");
};

void DisplaySortedSeries(List<int> list)
{
    foreach (int num in list)
        Console.Write($"{num} - ");
};

List<int> sortLest()
{   
    List<int> copy = new List<int>([..SeriesOfNumbers]);
    for (int i = 0; i < NumberElements(); i++)
    {
        int min = copy[i];
        for (int j = i + 1; j < NumberElements(); j++)
        {
            if (copy[j] < min)
            {
                int temporary = copy[i];
                copy[i] = copy[j];
                copy[j] = temporary;
            }
        }
    }
    return copy;
}

void DisplayMaxValue()
{
    int max = SeriesOfNumbers[0];
    foreach (int num in SeriesOfNumbers)
    {
        if (num > max)
        {
            max = num;
        }
    }
    Console.WriteLine($"max: -- {max} -- ");
};  

void DisplayMinValue()
{
    int min = SeriesOfNumbers[0];
    foreach (int num in SeriesOfNumbers)
    {
        if (num < min)
        {
            min = num;
        }
    }
    Console.WriteLine($"min: -- {min} -- ");
};  


int NumberElements()
{
    int len = 0;
    foreach (int num in SeriesOfNumbers)
    {
        len += 1;
    }
    return len;
};

int SumSeries()
{
    int sum = 0;
    foreach (int num in SeriesOfNumbers)
    {
        sum += num;
    }
    return sum;
};

void DisplayAverage()
{
    Console.WriteLine(SumSeries() / Convert.ToDouble(NumberElements()));
};








MainManagement();