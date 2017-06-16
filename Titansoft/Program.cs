using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titansoft
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthLimit = 1100;
            int weightLimit = 1000;

            string line;

            List<string> input = new List<string>();

            while ((line = Console.ReadLine().Trim()) != null && line != "")
            {
                input.Add(line);
            }
            List<Items> items = new List<Items>();

            foreach (string value in input)
            {
                int[] temp = Array.ConvertAll(value.Split(' '), Int32.Parse);
                Items item = new Items();
                item.Id = temp[0];
                item.Width = temp[1];
                item.Weight = temp[2];
                items.Add(item);
            }

            List<Items> output = new List<Items>();

            output = items.OrderByDescending(x => x.Width).ThenByDescending(x => x.Width).ThenByDescending(x => x.Id).ToList();

            int weight = 0;
            int width = 0;

            List<string> test = new List<string>() { "A:", "B:", "C:" };

            int counter = 0;

            for (int i = 0; i < output.Count; i++)
            {
                weight += output[i].Weight;
                width += output[i].Width;

                if (weight <= weightLimit && width <= widthLimit)
                    test[counter] += output[i].Id + ",";
                else
                {
                    counter += 1;
                    i--;

                    weight = 0;
                    width = 0;
                }
            }


            if (test[0].Contains(','))
                test[0] = test[0].Remove(test[0].LastIndexOf(','), 1);

            if (test[1].Contains(','))
                test[1] = test[1].Remove(test[1].LastIndexOf(','), 1);

            if (test[2].Contains(','))
                test[2] = test[2].Remove(test[2].LastIndexOf(','), 1);

            // print out the answer
            System.Console.WriteLine(test[0]);
            System.Console.WriteLine(test[1]);
            System.Console.WriteLine(test[2]);
        }
    }

    class Items
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Width { get; set; }
    }
}
