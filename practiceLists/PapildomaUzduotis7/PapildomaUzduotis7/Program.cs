using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapildomaUzduotis7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> textList = new List<string>();

            string text = "At any time of day or night, a group of older residents can be seen patrolling the Duranguito neighborhood in downtown El Paso, Texas, " +
                "located across the river from downtown Juárez, Mexico. Historian David Dorado Romo is one of several “Paso Del Sur” figureheads who have been " +
                "fighting the City of El Paso, for over a decade, to preserve the spaces Romo has long been writing about. In his 2005 book, Ringside Seat to a Revolution, " +
                "Romo tracked the footsteps of Mexican Revolutionary folk hero, Francisco “Pancho” Villa and other historical figures of the period throughout Duranguito and " +
                "greater downtown El Paso. I visited Romo this summer in Duranguito where I interviewed him about their battle with the City and the El Paso Del Norte Group, " +
                "a bi-national consortium of developers who disobeyed a court order and illegally paid people to demolish their own property. At the time of our interview " +
                "the neighborhood was in a state of limbo with a section punched out of each of five buildings by orders issued by the City; giving the distinct anthropomorphic " +
                "appearance of a body disemboweled and left for dead.";
           
            text = text.Replace(Environment.NewLine, String.Empty).Replace(".", String.Empty).Replace(". ", " ").Replace(", ", " ").Replace("; ", " ").Replace("? ", " ").Replace(" “", " ").Replace("” ", " ");
            textList = text.Split(' ').ToList();
            Console.WriteLine(text);
          

            if (textList.Contains("split") || textList.Contains("Split"))
            {
                Console.WriteLine("Liste yra zodis SPLIT");
            }

            string x = FindMaxWord(textList);
            Console.WriteLine("\n\n Ilgiausias zodis yra "+ x);
            Console.WriteLine("\n Kiti ilgesni nei 7 simboliai zodziai:");
            Find(textList);
            Console.WriteLine("\n\n Naujas tekstas: \n ");
            Random rnd = new Random();
            int nr;
            for (int i = 1; i < textList.Count; i++)
            {
                nr = rnd.Next(1, textList.Count);
                Console.Write(textList[nr] + " ");
                if (i % 6 == 0) { textList[nr] += ".";}
            }

            Console.ReadKey();
        }

        static string FindMaxWord(List<string> list)
        {
            int maxLength = int.MinValue;
            string maxText = "";
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].Length > maxLength)
                {
                    maxLength = list[i].Length;
                    maxText = list[i];
                }
            }
            return maxText;
        }

        static void Find(List<string> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].Length > 7)
                {
                    Console.Write(", " + list[i]);
                }
            }
           
        }
    }
}
