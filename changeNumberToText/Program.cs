using System;

class Program
{

    static void Main()
    {
        // min skaicius 
        const int FROM_NUMBER = -999;
        // max skaicius 
        const int TO_NUMBER = 999;

        string inputString = "";
        int inputNumber = 0;

        Console.Write("Sveiki!");
        while (inputString != " ")
        {
            Console.Write("\n(Enter SPACE to exit.)\nIveskite skaiciu:");
            inputString = Console.ReadLine();
            if (checkIfGoodNumber(inputString))
            {
                Console.WriteLine("Skaicius teisingas!");
                inputNumber = Convert.ToInt32(inputString);
                if (checkIfNumberInRange(FROM_NUMBER, TO_NUMBER, inputNumber))
                {
                    Console.WriteLine("Skaicius {0} zodziais: {1}", inputNumber, changeNumberToText(inputNumber));
                }
                else
                {
                    Console.WriteLine("Blogas skaicius {0}, prasau ivesti skaiciu reziuose: {1}..{2}", inputString, FROM_NUMBER, TO_NUMBER);
                }
            }
            else
            {
                Console.WriteLine("Ivesti duomenys:{0} nera skaicius!", inputString);
            }
        }

        Console.WriteLine("\nAciu uz demesi, viso gero.");
        Console.ReadKey();
    }

    // bendra funkcija apjungti visom funkcijom kurias jus sukursit.
    static string changeNumberToText(int number)
    {
        return changeOnesToText(number);
    }

    // funkcija gauna string skaiciu, patikrina ar skaicius teisingu formatu. Pvz: "123", "-123" grazina true. "12a3", "1-23" grazina false.
    static bool checkIfGoodNumber(string dataToCheck)
    {
        int stringToInt;
        if (int.TryParse(dataToCheck, out stringToInt))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // funkcija gauna true jei skaicius checkNumber yar tarp fromNumber ir toNumber (imtinai)
    private static bool checkIfNumberInRange(int fromNumber, int toNumber, int checkNumber)
    {
        if (checkNumber >= fromNumber && checkNumber <= toNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // funkcija gauna int skaiciu, pakeicia ji i string teksta kuri zodziais nusako skaiciu. PVZ: -1684542 turi grazint - "minus vienas milijonas sesi simtai astuoniasdesimt keturi tukstanciai penki simtai keturiasdiasimt du"
    static string changeOnesToText(int number)
    {
        string result = "";
        if (number < 0)
        {
            result = "minus";
            number = number * (-1);
        }
        int simtai = number / 100;
        int desimtys = number / 10;
        int vienetai = number%10;

        //Console.WriteLine($"sim {simtai}, des {desimtys}, vien {vienetai}");
        if (simtai != 0)
        {
            desimtys = (number - (((number / 100) % 10) * 100))/10;
            //Console.WriteLine($"sim {simtai}, des {desimtys}, vien {vienetai}");
            result = change1_9ToText(simtai, result);
            result = changeHundredsToText(simtai, result);
            result = changeTensToText(desimtys, result);
            if (desimtys == 1 && vienetai != 0 && simtai == 0)
            {
                result = changeTeensToText(vienetai, result);
            }
            result = change1_9ToText(vienetai, result);
            
        }

        if (simtai == 0)
        {
            if ((desimtys == 1 && vienetai == 0) || desimtys != 1)
            {
                result = changeTensToText(desimtys, result);
            }

            if (desimtys == 1 && vienetai != 0)
            {
                result = changeTeensToText(vienetai, result);
            }
            else
            {
                result = change1_9ToText(vienetai, result);
            }
        }

        return result;
    }

    static string changeTensToText(int desimtys, string result)
    {
        switch (desimtys)
        {
            case 1: result += " desimt"; break;
            case 2: result += " dvidesimt"; break;
            case 3: result += " trisdesimt"; break;
            case 4: result += " keturiasdesimt"; break;
            case 5: result += " penkiasdesimt"; break;
            case 6: result += " sesiasdesimt"; break;
            case 7: result += " septyniasdesimt"; break;
            case 8: result += " astuoniasdesimt"; break;
            case 9: result += " devyniasdesimt"; break;
        }
        return result;
    }

    static string changeTeensToText(int vienetai, string result)
    {
        switch (vienetai)
        {
            case 1: result += " vienuolika"; break;
            case 2: result += " dvylika"; break;
            case 3: result += " trylika"; break;
            case 4: result += " keturiolika"; break;
            case 5: result += " penkiolika"; break;
            case 6: result += " sesiolika"; break;
            case 7: result += " septyniolika"; break;
            case 8: result += " astuoniolika"; break;
            case 9: result += " devyniolika"; break;
        }
        return result;
    }

    static string change1_9ToText(int vienetai, string result)
    {
        switch (vienetai)
        {
            case 1: result += " vienas"; break;
            case 2: result += " du"; break;
            case 3: result += " trys"; break;
            case 4: result += " keturi"; break;
            case 5: result += " penki"; break;
            case 6: result += " sesi"; break;
            case 7: result += " septyni"; break;
            case 8: result += " astuoni"; break;
            case 9: result += " devyni"; break;
        }
        return result;
    }

    static string changeHundredsToText(int vienetai, string result)
    {
        switch (vienetai)
        {
            case 1: result += " simtas"; break;
            default: result += " simtai"; break;
        }
        return result;
    }




    // TODO : sukurti funkcija kuri grazina skaiciu -9999...9999 zodziais - changeThousandsToText

    // TODO : sukurti funkcija kuri grazina skaiciu -9999999...9999999 zodziais - changeMillionsToText

    // TODO : sukurti funkcija kuri grazina skaiciu -9999999999...9999999999 zodziais - changeBilllionsToText

    //  "tukstantis", "milijonas", "milijardas"; 
    //  "tukstanciai", "milijonai", "milijardai"; 
    // "simtu", "tukstanciu", "milijonu", "milijardu"; 
}