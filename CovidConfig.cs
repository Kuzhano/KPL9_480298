using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400098
{
    public class Config
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public Config() { }

        public Config(string s, int b, string p1, string p2)
        {
            satuan_suhu = s;
            batas_hari_deman = b;
            pesan_ditolak = p1;
            pesan_diterima = p2;
        }
    }

    public class CovidConfig
    {
        public Config config;
        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            ReadConfig();
        }

        private void ReadConfig()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                config = JsonSerializer.Deserialize<Config>(jsonString);
            }
            else
            {
                config = new Config(
                    "celcius",
                    14,
                    "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                );
                WriteConfig();
            }
        }

        public void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu == "celcius")
                config.satuan_suhu = "fahrenheit";
            else
                config.satuan_suhu = "celcius";

            WriteConfig();
        }
    }
}
