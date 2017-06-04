using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace OptimalPortfolio
{
    static class ClassAssistant
    {
        static int count = 0;
        public static Asset[] DoAssetsArray(string filename)
        {
            Asset[] assets;
            using(StreamReader sr = new StreamReader(filename, Encoding.GetEncoding(1251)))
            {
                string[] text = sr.ReadToEnd().Split('\n');
                if(text[text.Length-1] != "")
                    assets = new Asset[text.Length];
                else assets = new Asset[text.Length - 1];
                for (int i = 0; i < assets.Length; i++)
                {
                    string[] asset = text[i].Split(';');
                    Asset a = new Asset(asset[0], asset[1], Convert.ToInt32(asset[2]));
                    if (asset.Length > 3)
                    {
                        try
                        {
                            a.AverageProfit = Convert.ToDouble(asset[3]);
                            a.Volatility = Convert.ToDouble(asset[4]);
                            a.Capitalization = Convert.ToDouble(asset[5]);
                            a.Liquidity = Convert.ToDouble(asset[6]);
                            a.Dividend = Convert.ToDouble(asset[7].Replace('\r', ' '));
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                    assets[i] = a;
                }
            }
            return assets;
            
//          Asset[] assets = new Asset[100];
/*
            assets[0] = new Asset("Polymetal", "POLY", 175924);
            assets[1] = new Asset("RUSAL plc", "RUAL", 414279);
            assets[2] = new Asset("Yandex clA", "YNDX", 388383);
            assets[3] = new Asset("iАвиастК", "UNAC", 22843);
            assets[4] = new Asset("iНПОНаука", "NAUK", 81992);
            assets[5] = new Asset("АВТОВАЗ","AVAZ", 39);
            assets[6] = new Asset("АЛРОСА", "ALRS", 81820);
            assets[7] = new Asset("АбрауДюрсо", "ABRD", 82460);
            assets[8] = new Asset("Авангард", "AVAN", 82843);
            assets[9] = new Asset("Акрон", "AKRN", 17564);
            assets[10] = new Asset("Аптеки36и6", "APTK", 13855);

            assets[11] = new Asset("Аэрофлот", "AFLT", 29);//
            assets[12] = new Asset("БСП", "BSPB", 20066);
            assets[13] = new Asset("БУДУЩЕЕ", "FTRE", 462599);
            assets[14] = new Asset("Башнефт", "BANE", 81757);
            assets[15] = new Asset("ВСМПО-АВСМ", "VSMO", 15965);
            assets[16] = new Asset("ВТБ", "VTBR", 19043);//
            assets[17] = new Asset("Варьеган", "VJGZ", 81954);
            assets[18] = new Asset("Возрожд", "VZRZ", 17068);
            assets[19] = new Asset("ГАЗПРОМ", "GAZP", 16842);//
            assets[20] = new Asset("ГМКНорНик", "GMKN", 795);//

            assets[21] = new Asset("Газпрнефть", "SIBN", 2);
            assets[22] = new Asset("Галс-Девел", "HALS", 17698);
            assets[23] = new Asset("Дорогбж", "DGBZ", 17919);
            assets[24] = new Asset("ДетскийМир", "DSKY", 473181);
            assets[25] = new Asset("Дикси", "DIXY", 18564);
            assets[26] = new Asset("Европлан", "EPLN", 451471);
            assets[27] = new Asset("ИнтерРАО", "IRAO", 20516);
            assets[28] = new Asset("ИркЭнерго", "IRGZ", 9);
            assets[29] = new Asset("КАМАЗ", "KMAZ", 15544);
            assets[30] = new Asset("КоршГОК", "KOGK", 20710);

            assets[31] = new Asset("Кубанэнр", "KUBE", 522);
            assets[32] = new Asset("Куйбазот", "KAZT", 81941);
            assets[33] = new Asset("ЛСР", "LSRG", 19736);
            assets[34] = new Asset("ЛУКОЙЛ", "LKOH", 8);//
            assets[35] = new Asset("Лензолото", "LNZL", 21004);
            assets[36] = new Asset("Ленэнерго", "LSNG", 31);
            assets[37] = new Asset("М.видео", "MVID", 19737);
            assets[38] = new Asset("МГТС", "MGTS", 12984);
            assets[39] = new Asset("МКБ", "CBOM", 420694);
            assets[40] = new Asset("ММК", "MAGN", 16782);

            assets[41] = new Asset("МОЭСК", "MSRS", 16917);
            assets[42] = new Asset("МРСК Центр", "MRKC", 20235);
            assets[43] = new Asset("МТС",  "MTSS", 15523);//
            assets[44] = new Asset("Магнит", "MGNT", 17086);//
            assets[45] = new Asset("МегаФон", "MFON", 152516);
            assets[46] = new Asset("Мегион", "MFGS", 30);
            assets[47] = new Asset("Мечел", "MTLR", 21018);
            assets[48] = new Asset("МосБиржа", "MOEX", 152798);//
            assets[49] = new Asset("МосОблБанк", "MOBB", 82890);
            assets[50] = new Asset("МосЭнерго", "MSNG", 6);

            assets[51] = new Asset("Мостотрест", "MSTT", 74549);
            assets[52] = new Asset("НКНХ", "NKNC", 20100);
            assets[53] = new Asset("НКХП", "NKHP", 450432);
            assets[54] = new Asset("НЛМК", "NLMK", 17046);//
            assets[55] = new Asset("НМТП", "NMTP", 19629);
            assets[56] = new Asset("Новатэк", "NVTK", 17370);
            assets[57] = new Asset("ОВК", "UWGN", 414560);
            assets[58] = new Asset("ОГК-2", "OGKB", 18684);
            assets[59] = new Asset("ОКС", "UCSS", 175781);
            assets[60] = new Asset("ОргСинт", "KZOS", 81856);

            assets[61] = new Asset("Отисифарм", "OTCP", 407627);
            assets[62] = new Asset("ОткрФКБ", "OFCB", 80728);
            assets[63] = new Asset("ПИК", "PIKK", 18654);
            assets[64] = new Asset("ПРОТЕК", "PRTK", 35247);
            assets[65] = new Asset("Полюс", "PLZL", 17123);
            assets[66] = new Asset("Промсвб", "PSBR", 152320);
            assets[67] = new Asset("РБК", "RBCM", 74779);
            assets[68] = new Asset("РГС СК", "RGSS", 181934);
            assets[69] = new Asset("Распадская", "RASP", 17713);
            assets[70] = new Asset("Росбанк", "ROSB", 16866);

            assets[71] = new Asset("Роснефть", "ROSN", 17273);//
            assets[72] = new Asset("Россети", "RSTI", 20971);
            assets[73] = new Asset("Ростел", "RTKM", 7);//
            assets[74] = new Asset("РусГидро", "HYDR", 20266);//
            assets[75] = new Asset("Русполимет", "RUSP", 20712);
            assets[76] = new Asset("РуссНфт", "RNFT", 465236);
            assets[77] = new Asset("СОЛЛЕРС", "SVAV", 16080);
            assets[78] = new Asset("Сбербанк", "SBER", 3);//
            assets[79] = new Asset("СевСт", "CHMF", 16136);//

            assets[80] = new Asset("Система", "AFKS", 19715);
            assets[81] = new Asset("Славн-ЯНОС", "JNOS", 15722);
            assets[82] = new Asset("Сургнфгз", "SNGS", 4);//
            assets[83] = new Asset("ТГК-1", "TGKA", 18382);
            assets[84] = new Asset("ТМК", "TRMK", 18441);
            assets[85] = new Asset("ТНСэнрг", "TNSE", 420644);
            assets[86] = new Asset("Татнфт", "TATN", 825);
            assets[87] = new Asset("ТрансК", "TRCN", 74561);
            assets[88] = new Asset("Транснф (ап)", "TRNFP", 1012);
            assets[89] = new Asset("Уркалий", "URKA", 19623);

            assets[90] = new Asset("ФСК ЕЭС", "FEES", 20509);
            assets[91] = new Asset("ФосАгро", "PHOR", 81114);
            assets[92] = new Asset("ЭнелРос", "ENRU", 16440);
            assets[93] = new Asset("ЧМК", "CHMK", 21001);
            assets[94] = new Asset("ЧТПЗ", "CHEP", 20999);
            assets[95] = new Asset("ЧЦЗ", "CHZN", 19960);
            assets[96] = new Asset("ЧеркизГ", "GCHE", 20125);
            assets[97] = new Asset("ЮТэйр", "UTAR", 15522);
            assets[98] = new Asset("ЮжКузб", "UKUZ", 20717);
            assets[99] = new Asset("Юнипро", "UPRO", 18584);
 */           
            /*

            Asset[] assets = new Asset[20];

            assets[0] = new Asset("Аэрофлот", "AFLT", 29);
            assets[1] = new Asset("ВТБ", "VTBR", 19043);
            assets[2] = new Asset("ГАЗПРОМ", "GAZP", 16842);
            assets[3] = new Asset("ГМКНорНик", "GMKN", 795);
            assets[4] = new Asset("ИнтерРАО", "IRAO", 20516);

            assets[5] = new Asset("ЛУКОЙЛ", "LKOH", 8);
            assets[6] = new Asset("ММК", "MAGN", 16782);
            assets[7] = new Asset("МТС",  "MTSS", 15523);
            assets[8] = new Asset("Магнит", "MGNT", 17086);
            assets[9] = new Asset("НЛМК", "NLMK", 17046);
           
            assets[10] = new Asset("Новатэк", "NVTK", 17370);
            assets[11] = new Asset("Роснефть", "ROSN", 17273);
            assets[12] = new Asset("Ростел", "RTKM", 7);
            assets[13] = new Asset("РусГидро", "HYDR", 20266);
            assets[14] = new Asset("Сбербанк", "SBER", 3);

            assets[15] = new Asset("СевСт", "CHMF", 16136);
            assets[16] = new Asset("Система", "AFKS", 19715);
            assets[17] = new Asset("Сургнфгз", "SNGS", 4);
            assets[18] = new Asset("Татнфт З", "TATN", 825);
            assets[19] = new Asset("ФСК ЕЭС", "FEES", 20509);
            */
        }

        public static void SaveData(string filename, Asset[] assets)
        {
            using (StreamWriter sr = new StreamWriter(filename, false,  Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < assets.Length; i++)
                {
                    Asset a = assets[i];
                    sr.WriteLine(a.Name + ";" + a.Ticker + ";" + a.Number + ";" + a.AverageProfit + ";" + a.Volatility+";" + a.Capitalization + ";" + a.Liquidity + ";" + a.Dividend);
                }
            }
        }
        public static void DownloadAsset(string code, int number, DateTime dt_now, DateTime dt, string fileName, bool days)
        {
            int period;
            if (days)
                period = 8;
            else period = 9;

            string link = @"http://export.finam.ru/" + code + ".txt?market=1&em=" + number + "&code=" + code +
                            "&apply=0&df=" + dt.Day + "&mf=" + (dt.Month - 1) + "&yf=" + dt.Year + "&from=" + dt.ToString("dd.mm.yyyy") +
                            "&dt=" + dt_now.Day + "&mt=" + (dt_now.Month - 1) + "&yt=" + dt_now.Year + "&to=" + dt_now.ToString("dd.mm.yyyy") +
                            "&p=" + period + "&f=" + code + "&e=.txt&cn=" + code + "&dtf=4&tmf=1&MSOR=1&mstime=on&mstimever=1&sep=1&sep2=1&datf=4&at=0";
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri(link), fileName);
            webClient.Dispose();
        }
        
        public static double[] ReadAssets(string fileName)
        { 
            try
            {
                string[] text = File.ReadAllLines(fileName);
                int period = text.Length;
                double[] array = new double[period];
                for (int i = 0; i < period; i++)
                {
                    string[] line = text[i].Split(',');
                    array[i] = Convert.ToDouble(line[line.Length - 1].Replace('.', ','));
                }
                return array;
            }
            catch (FormatException) { throw new FormatException(); }
            catch (IOException ex) { throw ex; }
        }

        public static double[] ReadAssets(string fileName, DateTime[] weeks)
        {
            try
            {
                string[] text = File.ReadAllLines(fileName);
                if (text.Length <= 1) throw new IOException("Нет данных для " + Path.GetFileNameWithoutExtension(fileName));
                int period = weeks.Length;
                double[] array = new double[period];
                int j = 0;
                for (int i = 0; i < period; i++)
                {
                    string[] line = text[j].Split(',');
                    DateTime date = Convert.ToDateTime(line[2]);
                    if (i == 0 || weeks[i] == date)
                    {
                        array[i] = Convert.ToDouble(line[line.Length - 1].Replace('.', ','));
                        if (weeks[i] == date && j != text.Length - 1)
                            j++;
                    }
                    else if (weeks[i] > date && j != text.Length - 1)
                    {
                        j++;
                        i--;
                    }
                    else array[i] = array[i - 1];
                }
                return array;
            }
            catch (FormatException) { return null; }
            catch (IOException ex) { throw ex; }
        }

        
        // assets для Excel
        private static Portfolio DoCalculations(double[,] array, Asset[] assets, double valueRiskOrProf, bool forExcel, double[] constraints)
        {
            try
            {
                double[,] profit = CalculationClass.Profitability(array);

                double[] averageProfit = CalculationClass.AverageProfitability(profit);

                double[] profitSP = CalculationClass.ProfitabilitySP(profit);

                double averageProfitSP = profitSP.Average();

                double sum_d = 0;
                double[] beta = CalculationClass.Beta(profit, averageProfit, profitSP, averageProfitSP, out sum_d);

                double[] risk = CalculationClass.ResidualRisk(profit, averageProfit, profitSP, averageProfitSP, beta);

                double riskSP = CalculationClass.RiskSP(sum_d, array.GetLength(1));
                double R_sp = CalculationClass.R_sp(profitSP, averageProfitSP);

                if (forExcel)
                {
                    WorkWithExcel.WriteFile(assets, averageProfit, beta, risk, 12, riskSP, R_sp, valueRiskOrProf);
                    return null;
                }
                else
                {
                    return SolverClass.DoOpt(averageProfit, beta, risk, valueRiskOrProf, riskSP, R_sp, constraints);//, out p);
                    //return p;
                }
            }
            catch (NullReferenceException) { return null; }
        }

        public static Portfolio SinglePortfolio(double[,] array)
        {
            double[,] profit = CalculationClass.Profitability(array);

            double[] averageProfit = CalculationClass.AverageProfitability(profit);

            double[] profitSP = CalculationClass.ProfitabilitySP(profit);

            double averageProfitSP = profitSP.Average();

            double sum_d = 0;
            double[] beta = CalculationClass.Beta(profit, averageProfit, profitSP, averageProfitSP, out sum_d);

            double[] risk = CalculationClass.ResidualRisk(profit, averageProfit, profitSP, averageProfitSP, beta);

            double riskSP = CalculationClass.RiskSP(sum_d, array.GetLength(1));
            double R_sp = CalculationClass.R_sp(profitSP, averageProfitSP);

            double[] w = new double[beta.Length];
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = Math.Round(1.0 / w.Length, 4) * 100;
            }
            double profitSP_model = Math.Round(SolverClass.GetProfitSP(averageProfit, beta, R_sp), 4)*100;
            double riskSP_model = Math.Round(riskSP, 4) * 100;// Math.Round(SolverClass.GetRiskSP(beta, risk, riskSP), 4) * 100;

            Portfolio p = new Portfolio(w, profitSP_model, riskSP_model);
            p.StandDev = Math.Round(riskSP, 4) * 100;
         //   p.Cost = Math.Round(CalculationClass.PortfolioCost(array, p), 2);
            return p;
        }

        public static double[,] ReadData(Asset[] selectedAssets, string path)
        {
            int i = 0;
            
            DateTime[] weeks;
            try
            {
                weeks = DateTimeArray(selectedAssets, path);
                int period = weeks.Length;
                double[,] finalArray = new double[selectedAssets.Length, period];
                for (i = 0; i < finalArray.GetLength(0); i++)
                {
                    double[] test = ReadAssets(path + selectedAssets[i].Ticker + ".txt", weeks);
                    if (test == null || test.Length != period) throw new IOException("Ошибка в " + selectedAssets[i].Name);
                    else
                    {
                        for (int j = 0; j < finalArray.GetLength(1); j++)
                        {
                            finalArray[i, j] = test[j];
                        }
                    }
                }
                return finalArray;
            }
            catch (IOException ex) { throw ex; }//throw new IOException("Exception in "+selectedAssets[i].name); }
        }
        public static DateTime[] DateTimeArray(Asset[] selectedAssets, string path)
        {
            DateTime[] weeks;
            string nameMax = "";
            double size = 0;
            foreach (var a in selectedAssets)
            {
                string name = a.Ticker;
                double size_ = new FileInfo(path + name + ".txt").Length;
                if (size_ > size)
                {
                    size = size_;
                    nameMax = name;
                }
            }

            using (StreamReader sr = new StreamReader(path + nameMax + ".txt"))
            {
                string text = sr.ReadToEnd();
                string[] lines = text.Split('\n');
                weeks = new DateTime[lines.Length - 1];
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string[] one = lines[i].Split(',');
                    weeks[i] = Convert.ToDateTime(one[2]);
                }
            }
            return weeks;
        }
        
        public static void DownloadAllAssets(Asset[] selectedAssets, string path, int period, bool days)
        {
            DateTime dt, dt_now;
            if(period > 2000)
            {
                dt = new DateTime(period, 1, 1);
                dt_now = new DateTime(period, 12, 30);
            }
            else
            {
                dt_now = DateTime.Now.AddDays(-1);
                dt = dt_now.AddMonths(-period);
            }
            int i = 0;
            //загрузка котировок
            foreach (var c in selectedAssets)
            {
                DownloadAsset(c.Ticker, c.Number, dt_now, dt, path + c.Ticker + ".txt", days);
                System.Threading.Thread.Sleep(200);
            }
            System.Threading.Thread.Sleep(1000);
        }
        public static double[] ReadNewData(string filename, Asset a, int p)
        {
            List<double> list = new List<double>();
            using (StreamReader sr = new StreamReader(filename))
            {
                DateTime dt = DateTime.Now.AddDays(-1).AddMonths(-p);

                string[] text = sr.ReadToEnd().Split('\n');
                for (int i = 0; i < text.Length - 1; i++)
                {
                    string[] line = text[i].Split(';');
                    if (dt > Convert.ToDateTime(line[1])) continue;
                    else
                    {
                        if (line[0] == a.Ticker)
                        {
                            if (line[5] != "")
                                list.Add(Convert.ToDouble(line[5].Replace('.', ',')));
                        }
                    }
                }
            }
            double[] vol = list.ToArray();
            return vol;
        }

        public static void VolatilityResult(Asset a, double[] data)
        {
            double[] vol = data;

            double[] vol_t = CalculationClass.Vol_t(vol);
            double avVol = CalculationClass.AverageVol(vol_t);
            a.Volatility = Math.Round(CalculationClass.Volatility(vol_t, avVol), 5) * 100;
        }

        public static void ReadCapitalization(List<Asset> assets, int year, string p)
        {
            try
            {
                using (StreamReader sr = new StreamReader(p + "\\"+year + ".txt"))
                {
                    string[] text = sr.ReadToEnd().Split('\n');
                    for (int j = 0; j < assets.Count; j++)
                    {
                        for (int i = 0; i < text.Length; i++)
                        {
                            string[] line = text[i].Split('\t');
                            if (line[0] == assets[j].Ticker)
                            {
                                line[line.Length - 1] = line[line.Length - 1].Replace('.', ',');
                                double c = Convert.ToDouble(line[line.Length - 1]);
                                assets[j].Capitalization = c;
                                break;
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException) { throw new FileNotFoundException(); }
        }
/*
        public static void ReadLiquidity(Asset a)
        {
            try
            {
                string path = Program.path + "liq\\";

                DownloadAssetForLiq(a.Ticker, a.Number, path + a.Ticker + "liq.txt");
                System.Threading.Thread.Sleep(1000);
                double sum = 0;
                using (StreamReader sr = new StreamReader(path + a.Ticker + "liq.txt"))
                {
                    string text = sr.ReadToEnd();
                    string[] lines = text.Split('\n');
                    if (lines.Length > 1)
                    {
                        string[] oneline = lines[lines.Length - 2].Split(',');//;
                        sum = Convert.ToDouble(oneline[oneline.Length - 1].Replace('.', ','));
                    }
                    else
                    {
                        sr.Close();
                        if (lines.Length == 1 && lines[0] != "") ReadLiquidity(a);
                    }
                }
                a.Liquidity = sum;
            }
            catch (IOException ex) { ReadLiquidity(a); }
        }
        */

        public static void ReadLiquidity(Asset[] assets, DateTime dt_now)
        {
            string url = @"http://export.rbc.ru/free/micex.0/free.fcgi?period=DAILY&tickers=NULL&d1=" + dt_now.Day + "&m1=" + dt_now.Month + "&y1=" + dt_now.Year + "&d2=" + dt_now.Day + "&m2=" + dt_now.Month + "&y2=" + dt_now.Year + "&lastdays=0&separator=;&data_format=BROWSER&header=0";
            HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create(url);
            proxy_request.Method = "GET";
            proxy_request.KeepAlive = true;
            HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
            string html = "";
            using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                html = sr.ReadToEnd();

            if (html == "") ReadLiquidity(assets, dt_now.AddDays(-1));
            else
            {
                string[] text = html.Split('\n');
                for (int i = 0; i < assets.Length; i++)
                {
                    for (int j = 0; j < text.Length;j++ )
                    {
                        string[] line = text[j].Split(';');
                        if(assets[i].Ticker == line[0])
                        {
                            if (line[6] != "") assets[i].Liquidity = Convert.ToDouble(line[6].Replace('.', ','));
                            else assets[i].Liquidity = 0;
                            break;
                        }
                    }
                }
            }

        }

        public static List<Asset>[] FillQueue(Asset[] allassets)
        {
            List<Asset>[] queues = new List<Asset>[4];
            for (int i = 0; i < queues.Length;i++ )
                queues[i] = new List<Asset>();

            for (int i = 0; i < allassets.Length;i++ )
            {
                queues[i % 4].Add(allassets[i]);
            }
            return queues;
        }
        public static List<Portfolio> DoListPortfolio(double[,] finalArray, Asset[] selectedAssets, double start, double finish, double step, double[] constraints)
        {
            List<Portfolio> results = new List<Portfolio>();
            double r = 0, p = 0;
            bool isCycle = false;
            while (start <= finish && !isCycle)
            {
                Portfolio result = ClassAssistant.DoCalculations(finalArray, selectedAssets, start, false, constraints);

                if (result.Profit == p && result.Risk == r)
                    break;
                else
                {
                    if (start > result.Profit)
                    {
                        break;
                    }
                    else
                    {
                        double t = Math.Truncate(result.Profit / step);
                        start = step * t + step;
                    }

                    p = result.Profit;
                    r = result.Risk;
                    double sum = 0;
                    for (int k = 0; k < result.ConvertPortfolio().Length; k++)
                    {
                        result.ConvertPortfolio()[k] = Math.Round(result.ConvertPortfolio()[k], 4) * 100;
                    }
                    result.Profit = Math.Round(result.Profit, 5) * 100;
                    result.Risk = Math.Round(result.Risk, 4) * 100;
                    sum = result.GetSum;
                    foreach (var res in results)
                    {
                        if (res.Profit == result.Profit && res.Risk == result.Risk) isCycle = true;
                    }
                    if (Math.Abs(sum - 100) <= 0.1 && !isCycle)
                    {
                        double[,] profit = CalculationClass.Profitability(finalArray);
                        result.StandDev = Math.Round(CalculationClass.StandardDeviation(profit, result), 4) * 100;

                      //  result.Cost = Math.Round(CalculationClass.PortfolioCost(finalArray, result), 2);

                        results.Add(result);
                    }
                }
            }
            return results;
        }      
        public static void DownloadDividend(Asset[] list)
        {
            try
            {
                HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create(@"http://smart-lab.ru/q/shares_fundamental/div_yield/");
                proxy_request.Method = "GET";
                proxy_request.KeepAlive = true;
                HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
                string html = "";
                using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    html = sr.ReadToEnd();

                Regex rgx = new Regex(@"((<td><a href.*</td>)|(<strong>\n.*\n.*\n.*\n.*\n.*</strong>))");//(<td><a href.*\n*(?'text'.*?)\n*</td>)|(<td.*\n.*%.*</td>)
                //  List<string> reg = new List<string>();
                string[] reg = new string[rgx.Matches(html).Count];
                int i = 0;
                foreach (Match match in rgx.Matches(html))
                {
                    reg[i] = match.Value;
                    i++;
                } 
                
                Dictionary<string, double> dic = new Dictionary<string, double>();
                for (i = 0; i < reg.Length; i++)
                {
                    if (Regex.IsMatch(reg[i], @"<td><a href.*</td>"))
                    {
                        string[] s = reg[i].Split('>');
                        string name = s[2].Split('<')[0];

                        s = reg[i + 1].Split('\n');
                        string d = s[2].Replace('\t', '0');
                        double div = Convert.ToDouble(d.Replace('.', ','));
                        if (!dic.ContainsKey(name))
                            dic.Add(name, div);
                    }
                }
                for (i = 0; i < list.Length; i++)
                {
                    foreach (var d in dic)
                    {
                        string d_ = d.Key.ToLower();
                        string l_ = list[i].Name.ToLower();
                        if (l_ == d_)
                        {
                            list[i].Dividend = d.Value;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        public static void AverageProfit(Asset a, double[] data)
        {
            try
            {
                double[] asset = data;
                double[] profit = new double[asset.Length - 1];
                for (int j = 0; j < profit.Length; j++)
                {
                    profit[j] = (asset[j + 1] - asset[j]) / asset[j];
                }
                double average = profit.Average();
                a.AverageProfit = Math.Round(average, 4) * 100;
            }
            catch (Exception ex) { throw ex; }
        }

        public static void DownloadData(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (!File.Exists(filename)) File.Create(filename);
            if (File.GetLastWriteTime(filename).Date != DateTime.Now.Date || fi.Length == 0)
            {
                try
                {
                    DateTime dt_now = DateTime.Now.AddDays(-1);
                    DateTime dt = dt_now.AddYears(-1);

                    string url = @"http://export.rbc.ru/free/micex.0/free.fcgi?period=DAILY&tickers=NULL&d1=" + dt.Day + "&m1=" + dt.Month + "&y1=" + dt.Year + "&d2=" + dt_now.Day + "&m2=" + dt_now.Month + "&y2=" + dt_now.Year + "&lastdays=0&separator=;&data_format=BROWSER&header=0";
                    HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create(url);
                    proxy_request.Method = "GET";
                    proxy_request.KeepAlive = true;
                    HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
                    string html = "";
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                        html = sr.ReadToEnd();
                    string s = html;
                    File.WriteAllText(filename, s);
                }
                catch (Exception ex) { DownloadData(filename); }
            }
        }

        public static double[,] ReadDataForCorrelation(Asset[] allAssets, string filename, int p)
        {
            double[,] array = null;
            using (StreamReader sr = new StreamReader(filename))
            {
                DateTime dt = DateTime.Now.AddDays(-1).AddMonths(-p);
                string[] text = sr.ReadToEnd().Split('\n');
                    
                for (int j = 0; j < allAssets.Length; j++)
                {
                    List<double> list = new List<double>();
            
                    for (int i = 0; i < text.Length - 1; i++)
                    {
                        string[] line = text[i].Split(';');
                        if (dt > Convert.ToDateTime(line[1])) continue;
                        else
                        {
                            if (line[0] == allAssets[j].Ticker)
                            {
                                if (line[5] != "")
                                    list.Add(Convert.ToDouble(line[5].Replace('.', ',')));
                                else list.Add(0);
                            }
                        }
                    }
                    int k = 0;
                    if (j == 0) array = new double[allAssets.Length, list.Count];
                    foreach (var l in list)
                    {
                        if (l != 0)
                            array[j, k] = l;
                        else if (k != 0) array[j, k] = array[j, k - 1];
                        k++;
                    }
                    for(k = list.Count-2; k >= 0; k--)
                    {
                        if (array[j, k] == 0) array[j, k] = array[j, k + 1];
                    }
                }
            }
            return array;
        }
    }
}