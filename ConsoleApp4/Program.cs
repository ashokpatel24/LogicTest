using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            int totalInput = Convert.ToInt32(Console.ReadLine());

            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] value = Array.ConvertAll(arr_temp, Int32.Parse);

            int operationCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < operationCount; i++)
            {
                int d = Convert.ToInt32(Console.ReadLine());
                if (d != 1)
                {
                    for (int j = 0; j < totalInput; j++)
                    {
                        value[j] /= d;
                    }
                }
            }

            for (int i = 0; i < totalInput; i++)
            {
                Console.Write($"{value[i]} ");
            }

        }

        static string ValidInput(string[] value)
        {
            string outputError = string.Empty;

            //validate pair
            foreach (var pair in value)
            {
                if (!(pair.Length == 5 && pair[0] == '(' && pair[2] == ',' && pair[4] == ')'))
                {
                    outputError = "E1";
                    break;
                }
            }

            //duplicate check
            for (int i = 0; i < value.Length - 1; i++)
            {
                int parentCount = 0;

                string[] node = value[i].Split(',');
                string parent = node[0];
                string child = node[1];

                if (outputError == string.Empty)
                {
                    for (int j = i + 1; j < value.Length; j++)
                    {
                        if (string.Compare(value[i], value[j]) == 0)
                        {
                            outputError = "E2";
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }



            return outputError;
        }
    }

}
