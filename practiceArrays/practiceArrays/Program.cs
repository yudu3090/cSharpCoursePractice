using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //142857
        string arTinka = "";
        string arTinka6 = "";
        int skaicius= 100000;
        int arTinkax6;
        int[] skaiciai = new int[6];
        int[] skaiciaix2 = new int[6];
        int[] skaiciaix3 = new int[6];
        int[] skaiciaix4 = new int[6];
        int[] skaiciaix5 = new int[6];
        int[] skaiciaix6 = new int[6];
        bool areUnique;
        bool magicNumber = false;
        do
        {
            arTinka = Convert.ToString(skaicius);
            arTinkax6 = skaicius * 6;
            arTinka6 = Convert.ToString(arTinkax6);
            Console.WriteLine(skaicius);

            skaiciai = ConvertToArray(arTinka, skaiciai);
            skaiciaix2 = ConvertToArray(Convert.ToString(skaicius * 2), skaiciaix2);
            skaiciaix3 = ConvertToArray(Convert.ToString(skaicius * 3), skaiciaix3);
            skaiciaix4 = ConvertToArray(Convert.ToString(skaicius * 4), skaiciaix4);
            skaiciaix5 = ConvertToArray(Convert.ToString(skaicius * 5), skaiciaix5);
            skaiciaix6 = ConvertToArray(Convert.ToString(skaicius * 6), skaiciaix6);
            areUnique = CheckIfNumbersAreUnique(skaiciai);

            if (areUnique)
            {
                if (CheckIfNumbersAreEqual(skaiciai, skaiciaix2) && CheckIfNumbersAreEqual(skaiciai, skaiciaix3) && 
                CheckIfNumbersAreEqual(skaiciai, skaiciaix4) && CheckIfNumbersAreEqual(skaiciai, skaiciaix5) && CheckIfNumbersAreEqual(skaiciai, skaiciaix6))
                {
                    magicNumber = true;
                    Console.WriteLine("Magiskas skaicius: " + skaicius);
                }
                else
                {
                    Console.WriteLine("Tai ne magiskas skaicius!");
                }
            }
            else
            {
                Console.WriteLine("Yra vienodi skaitmenys");
            }
            skaicius++;
            PrintOut(skaiciaix2);
            PrintOut(skaiciaix3);
            PrintOut(skaiciaix4);
            PrintOut(skaiciaix5);
        } while (magicNumber!=true);
        Console.WriteLine();
        Console.ReadKey();
    }






    private static void PrintOut(int[] skaiciai)
    {
        foreach (int item in skaiciai)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n");
    }

    private static int[] ConvertToArray(string arTinka, int[] skaiciai)
    {
        for (int i = 0; i < 6; i++)
        {
            skaiciai[i] = Convert.ToInt32(arTinka[i].ToString());
        }
        return skaiciai;
    }

    private static bool CheckIfNumbersAreUnique(int[] skaiciai)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 1 + i; j < 6; j++)
            {
                if (skaiciai[i] == skaiciai[j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static bool CheckIfNumbersAreEqual(int[] skaiciai, int[] skaiciaiPoPakeitimu)
    {
        int count = 0;
        for (int i = 0; i < 6; i++) 
        {
            int check = skaiciai[i];
            if (skaiciaiPoPakeitimu.Contains(check)) 
            {
                count++;
                if (count==6)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

