using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    struct ValuePair
    {
        public int Value1;
        public int Value2;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int NoOfDays = Convert.ToInt32(Console.ReadLine());
            string[] _arr = Console.ReadLine().Split(' ');
            int[] profit = Array.ConvertAll(_arr, Int32.Parse);
            int NoOfQuery = Convert.ToInt32(Console.ReadLine());
            List<ValuePair> queries = new List<ValuePair>();
            profit = profit.OrderBy(x => x).ToArray<int>();


            for (int i = 0; i < NoOfQuery; i++)
            {
                string[] queryValue = Console.ReadLine().Split(' ');
                int[] value = Array.ConvertAll(queryValue, Int32.Parse);

                queries.Add(new ValuePair { Value1 = value[0], Value2 = value[1] });
            }

            for (int i = 0; i < NoOfQuery; i++)
            {
                //var output = profit.Count(x => x >= queries[i].Item1 && x <= queries[i].Item2);
                int count = 0;

                for (int j = 0; j < NoOfDays; j++)
                {
                    if (profit[j] >= queries[i].Value1 && profit[j] <= queries[i].Value2)
                        count++;
                }

                Console.WriteLine(count);
            }
        }

        static void BalancedString()
        {
            string line1 = System.Console.ReadLine().Trim();
            char[] allCharacter = line1.ToCharArray();

            bool balanced = true;
            int firstCharCount = 1;

            for (int j = 1; j < allCharacter.Length; j++)
            {
                if (allCharacter[0] == allCharacter[j])
                {
                    firstCharCount++;
                }
            }

            for (int i = 0; i < allCharacter.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < allCharacter.Length; j++)
                {
                    if (allCharacter[i] == allCharacter[j])
                    {
                        count++;
                    }
                }

                if (count != firstCharCount)
                    balanced = false;
            }

            if (balanced)
            {
                System.Console.WriteLine("Yes");
            }
            else
            {
                System.Console.WriteLine("No");
            }
        }

    }
}
