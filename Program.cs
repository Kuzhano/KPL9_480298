using System;

namespace TP_MODUL9_103022400098
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();

            //covidConfig.UbahSatuan();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}: ");
            double inputSuhu = double.Parse(Console.ReadLine());

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
            int inputHariDeman = int.Parse(Console.ReadLine());

            bool suhuValid = false;

            if (covidConfig.config.satuan_suhu == "celcius")
            {
                // Range 36.5 - 37.5
                if (inputSuhu >= 36.5 && inputSuhu <= 37.5) suhuValid = true;
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                // Range 97.7 - 99.5
                if (inputSuhu >= 97.7 && inputSuhu <= 99.5) suhuValid = true;
            }

            bool hariValid = inputHariDeman < covidConfig.config.batas_hari_deman;

            if (suhuValid && hariValid)
            {
                Console.WriteLine("\n" + covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine("\n" + covidConfig.config.pesan_ditolak);
            }
        }
    }
}