using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(String[] args)
        {
            int output;
            int ip1;
            ip1 = Convert.ToInt32(Console.ReadLine());
            int ip2;
            ip2 = Convert.ToInt32(Console.ReadLine());
            string ip3;
            ip3 = Console.ReadLine();
            string ip4;
            ip4 = Console.ReadLine();
            output = appearanceCount(ip1, ip2, ip3, ip4);
            Console.WriteLine(output);
        }
        static int appearanceCount(int input1, int input2, string input3, string input4)
        {
            int count = 0;

            List<string> wString = new List<string>();
            string value = string.Empty;

            for (int i = 0; i < input4.Length; i++)
            {
                if (i + input1 <= input4.Length)
                {
                    for (int j = i; j < input1 + i; j++)
                    {
                        value = string.Concat(value, input4[j]);
                    }

                    wString.Add(value);
                    value = string.Empty;
                }
            }

            List<string> sString = new List<string>();

            Permutation("", input3,ref sString);

            foreach (string var in sString)
            {
                if (wString.Contains(var))
                {
                    count++;
                }
            }

            return count;
        }
        static void Permutation(string soFar, string input,ref List<string> value)
        {
            if (!string.IsNullOrEmpty(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string remaining = input.Substring(0, i) + input.Substring(i + 1);
                    Permutation(soFar + input[i], remaining, ref value);
                }
            }
            else
            {
                value.Add(soFar);
            }
        }

        //static void Permutation(string soFar, string input)
        //{
        //    if (string.IsNullOrEmpty(input))
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < input.Length; i++)
        //        {
        //            string remaining = input.Substring(0, i) + input.Substring(i + 1);
        //            Permutation(soFar + input[i], remaining);
        //        }
        //    }
        //}

        static void GetJumpCount(int input1, int input2, int[] input3)
        {
            //int ip1;
            //ip1 = Convert.ToInt32(Console.ReadLine());
            //int ip2;
            //ip2 = Convert.ToInt32(Console.ReadLine());
            //int ip3_size = 0;
            //ip3_size = Convert.ToInt32(Console.ReadLine());
            //int[] ip3 = new int[ip3_size];
            //int ip3_item;

            //for (int ip3_i = 0; ip3_i < ip3_size; ip3_i++)
            //{
            //    ip3_item = Convert.ToInt32(Console.ReadLine());
            //    ip3[ip3_i] = ip3_item;
            //}

            int totalJump = 0;

            for (int i = 0; i < input3.Length; i++)
            {
                int reach = 0;
                do
                {
                    totalJump++;
                    reach = reach + input1;

                    if (reach < input3[i])
                        reach = reach - input2;

                } while (reach < input3[i]);
            }
        }

        static void Maximum()
        {
            int[][] arr = new int[6][];

            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            int? maximum = null;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 0; j < arr.Length - 2; j++)
                {
                    int row1 = arr[i][j] + arr[i][j + 1] + arr[i][j + 2];
                    int row2 = arr[i + 1][j + 1];
                    int row3 = arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    int sum = row1 + row2 + row3;

                    if (maximum == null)
                        maximum = sum;
                    else if (maximum < sum)
                        maximum = sum;
                }
            }
            Console.Write(maximum);
        }

        static void ReverseArray()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            int[] output = new int[arr.Length];
            int j = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[j] = arr[i];
                j++;
            }

            for (int i = 0; i < output.Length; i++)
            {
                Console.Write("{0} ", output[i]);
            }
            Console.Read();
        }
        static void DigitCout()
        {
            int row = Convert.ToInt32(Console.ReadLine());
            int column = Convert.ToInt32(Console.ReadLine());
            int[][] _arr = new int[row][];
            for (int _arr_i = 0; _arr_i < row; _arr_i++)
            {
                string[] _arr_temp = Console.ReadLine().Split(' ');
                _arr[_arr_i] = Array.ConvertAll(_arr_temp, Int32.Parse);
            }

            List<int> digitCount = new List<int>();

            for (int i = 0; i < _arr.GetLength(0); i++)
            {
                int count = 0;
                int startNumber = _arr[i][0];
                int endNumber = _arr[i][1];

                for (int j = startNumber; j <= endNumber; j++)
                {
                    string rev = j.ToString();
                    bool repeat = true;

                    if (rev.Length == 1)
                    {
                        count++;
                    }
                    else
                    {
                        for (int k = 0; k < rev.Length - 1; k++)
                        {
                            if (rev[k] != rev[k + 1])
                                repeat = false;
                        }

                        if (!repeat)
                            count++;
                    }
                }

                digitCount.Add(count);
            }

            foreach (var value in digitCount)
                Console.WriteLine(value);
        }
        static void temp()
        {
            String[] reviews = Console.ReadLine().ToLower().Split(' ');
            int m = Convert.ToInt32(Console.ReadLine());

            List<Tuple<int, string>> review = new List<Tuple<int, string>>();

            for (int i = 0; i < m; i++)
            {
                int hotelId = Convert.ToInt32(Console.ReadLine());
                string rev = Console.ReadLine().Replace('.', ' ').Replace(',', ' ').ToLower();

                Tuple<int, string> tuple = new Tuple<int, string>(hotelId, rev);
                review.Add(tuple);
            }

            Dictionary<int, string> finalReviews = new Dictionary<int, string>();

            foreach (var val in review)
            {
                if (!finalReviews.ContainsKey(val.Item1))
                    finalReviews.Add(val.Item1, val.Item2);
                else
                {
                    finalReviews[val.Item1] = finalReviews[val.Item1] + " " + val.Item2;
                }
            }

            Dictionary<int, int> hotel = new Dictionary<int, int>();

            foreach (var val in finalReviews.Keys)
            {
                int count = 0;

                foreach (var word in reviews)
                {
                    if (finalReviews[val].Contains(word))
                    {
                        string[] input = finalReviews[val].Split(' ');

                        foreach (var temp in input)
                        {
                            if (temp == word)
                            {
                                count++;
                            }
                        }
                    }
                }

                hotel.Add(val, count);
            }

            hotel = hotel.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var val in hotel.Keys)
            {
                Console.Write(val + " ");
            }
        }
        static void PairInpput()
        {
            int res;

            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);
        }
        static int pairs(int[] a, int k)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    int diff = Math.Abs(a[i] - a[j]);
                    if (diff == k)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        static void MealPrice()
        {
            double mealCost = Convert.ToDouble(Console.ReadLine());
            double tipPercent = Convert.ToDouble(Console.ReadLine());
            double taxPercent = Convert.ToDouble(Console.ReadLine());


            double tip = (mealCost * tipPercent) / 100;
            double tax = (mealCost * taxPercent) / 100;

            int finalCost = Convert.ToInt32(mealCost + tip + tax);

            Console.WriteLine("The total meal cost is {0} dollars.", mealCost);
        }
    }
}
