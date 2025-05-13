using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = GetValidNumbers(args);

        Console.WriteLine("הסדרה התקבלה בהצלחה:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
    }

    static int[] GetValidNumbers(string[] args)
    {
        int[] result = ParsePositiveNumbers(args);

        while (result.Length < 3)
        {
            Console.WriteLine("נא להזין לפחות 3 מספרים חיוביים מופרדים ברווח:");
            string input = Console.ReadLine();
            string[] inputParts = input.Split(' ');
            result = ParsePositiveNumbers(inputParts);
        }

        return result;
    }

    static int[] ParsePositiveNumbers(string[] input)
    {
        var list = new System.Collections.Generic.List<int>();

        foreach (string item in input)
        {
            if (int.TryParse(item, out int number) && number > 0)
            {
                list.Add(number);
            }
        }

        return list.ToArray();
    }
}
