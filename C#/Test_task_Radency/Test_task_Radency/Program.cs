using System;

namespace Test_task_Radency
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightString weightString = new WeightString();
            string inputString = Console.ReadLine();
            Console.WriteLine(weightString.Order(inputString));
        }

    class WeightString
    {
            public string Order(string input)
            {
                int startIndex = 0;
                if (input.Length == 0)
                {
                    return "";
                }
                else
                {
                    string orderedString = "";
                    var array = Array.ConvertAll(input.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries), s => ulong.TryParse(s, out var i) ? i : 0);
                    for (int i = startIndex; i < array.Length; i++)
                    {
                        int minIndex = i;
                        ulong min = Convert(array[minIndex]);
                        for (int j = i + 1; j < array.Length; j++)
                        {
                            if (min > Convert(array[j]) || (min == Convert(array[j]) && String.Compare(array[j].ToString(), array[minIndex].ToString()) < 0))
                            {
                                min = Convert(array[j]);
                                minIndex = j;
                            }
                        }
                        if (minIndex != i)
                        {
                            ulong tmp = array[i];
                            array[i] = array[minIndex];
                            array[minIndex] = tmp;
                        }
                    }
                    orderedString = String.Join(" ", array);
                    return orderedString;
                }
            }

            ulong Convert(ulong num)
            {
                ulong weight = 0;
                while (num > 0)
                {
                    weight += num % 10;
                    num = num / 10;
                }
                return weight;
            }
        }
    }
}
