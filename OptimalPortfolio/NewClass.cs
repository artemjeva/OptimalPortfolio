using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace OptimalPortfolio
{
    class NewClass
    {
        static string path = @"D:\assets";
        public static Asset[] DoAssetsArray()
        {
            Asset[] assets = new Asset[15];

            assets[0] = new Asset("Аэрофлот", "AFLT", 29);
            assets[1] = new Asset("ВТБ", "VTBR", 19043);
            assets[2] = new Asset("ГАЗПРОМ", "GAZP", 16842);
            assets[3] = new Asset("ГМКНорНик", "GMKN", 795);
            assets[4] = new Asset("ЛУКОЙЛ", "LKOH", 8);

            assets[5] = new Asset("МТС", "MTSS", 15523);
            assets[6] = new Asset("Магнит", "MGNT", 17086);
            assets[7] = new Asset("МосБиржа", "MOEX", 152798);
            assets[8] = new Asset("НЛМК", "NLMK", 17046);
            assets[9] = new Asset("Роснефть", "ROSN", 17273);

            assets[10] = new Asset("Ростел", "RTKM", 7);
            assets[11] = new Asset("РусГидро", "HYDR", 20266);
            assets[12] = new Asset("Сбербанк", "SBER", 3);
            assets[13] = new Asset("СевСт", "CHMF", 16136);
            assets[14] = new Asset("Сургнфгз", "SNGS", 4);

            return assets;
        }

        public static void DownloadAsset(string name, int number, int year, int month)
        {
            DateTime dt = new DateTime(year, month, 1);
            DateTime dt_now = dt.AddMonths(1);

            int period = 8;

            string link = @"http://export.finam.ru/" + name + ".txt?market=1&em=" + number + "&code=" + name +
                            "&apply=0&df=" + dt.Day + "&mf=" + (dt.Month - 1) + "&yf=" + dt.Year + "&from=" + dt.ToString("dd.mm.yyyy") +
                            "&dt=" + dt_now.Day + "&mt=" + (dt_now.Month - 1) + "&yt=" + dt_now.Year + "&to=" + dt_now.ToString("dd.mm.yyyy") +
                            "&p=" + period + "&f=" + name + "&e=.txt&cn=" + name + "&dtf=3&tmf=1&MSOR=1&mstime=on&mstimever=1&sep=1&sep2=1&datf=4&at=0";
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri(link), path + name + month + ".txt");
            webClient.Dispose();
        }

        public static void ReadWriteData(Asset a)
        {
            double[] array = new double[12];
            double sum = 0;
            DateTime dt = DateTime.Now;
            int y = dt.Year;
            dt.AddMonths(-13);
            for (int i = 0; i < 12; i++)
            {
              //  Console.WriteLine("Month №" + (i + 1) + "...");
                DownloadAsset(a.Ticker, a.Number, dt.Year, dt.Month);
                try
                {
                    using (StreamReader sr = new StreamReader(path + a.Ticker + ".txt"))
                    {
                        string[] text = sr.ReadToEnd().Split('\n');
                        int period = text.Length;

                        for (int j = 0; j < period - 1; j++)
                        {
                            string[] line = text[j].Split(',');
                            sum += Convert.ToDouble(line[line.Length - 1].Replace('.', ','));
                        }
                        array[i] = sum / (period - 1);
                        sum = 0;
                    }
                    dt.AddMonths(1);
                    // string[] text = File.ReadAllLines(path + a.code + ".txt");
                    
                }
                catch (FormatException) { }
            }
            using (StreamWriter sw = new StreamWriter(path + a.Ticker + ".txt"))
            {
                foreach (var t in array)
                {
                    sw.Write(t.ToString() + " \n");
                }
            }

        }

    }
}
