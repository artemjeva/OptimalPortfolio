using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalPortfolio
{
    public static class CalculationClass
    {
        //Доходность
        public static double[,] Profitability(double[,] array)
        {
            try
            {
                double[,] new_array = new double[array.GetLength(0), array.GetLength(1) - 1];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1) - 1; j++)
                    {
                        new_array[i, j] = (array[i, j + 1] - array[i, j]) / array[i, j];
                    }
                }
                return new_array;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
        }

        //Средняя доходность
        public static double[] AverageProfitability(double[,] array) //profit
        {
            double[] new_array = new double[array.GetLength(0)];
            double sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
                new_array[i] = sum / (array.GetLength(1));
                sum = 0;
            }

            return new_array;
        }

        //Доходность единичного портфеля (ЕП)
        public static double[] ProfitabilitySP(double[,] array) //profit
        {
            double[] new_array = new double[array.GetLength(1)];
            double sum = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    sum += array[j, i];
                }
                new_array[i] = sum / (array.GetLength(0));
                sum = 0;
            }

            return new_array;
        }

        //Средняя доходность ЕП
        public static double AverageProfitabilitySP(double[] array) //profitSP
        {
            return array.Average();
        }

        //Бета-коэффициент
        public static double[] Beta(double[,] profit, double[] averageProfit, double[] profitSP, double averageProfitSP, out double sum_d)
        {
            double[] denominator = new double[profit.GetLength(1)];
            double[,] numerator = new double[profit.GetLength(0), profit.GetLength(1)];
            double[] beta = new double[profit.GetLength(0)];
            double[] sum_num = new double[profit.GetLength(0)];
            double sum = 0;
            sum_d = 0;

            for (int i = 0; i < denominator.Length; i++)
            {
                denominator[i] = (profitSP[i] - averageProfitSP)*(profitSP[i] - averageProfitSP);
                sum_d += denominator[i];
            }

            for (int i = 0; i < numerator.GetLength(0); i++)
            {
                for (int j = 0; j < numerator.GetLength(1); j++)
                {
                    numerator[i,j] = (profit[i,j]-averageProfit[i])*(profitSP[j]-averageProfitSP);
                    sum += numerator[i, j];
                }
                sum_num[i] = sum;
                sum = 0;
            }
            for (int i = 0; i < beta.Length; i++ )
            {
                beta[i] = sum_num[i]/sum_d;
            }
            return beta;
        }
        //Остаточный риск
        public static double[] ResidualRisk(double[,] profit, double[] averageProfit, double[] profitSP, double averageProfitSP, double[] beta)
        {
            double[,] risk = new double[profit.GetLength(0), profit.GetLength(1)];
            double[] averageRisk = new double[profit.GetLength(0)];
            double sum = 0;

            for (int i = 0; i < risk.GetLength(0); i++)
            {
                for (int j = 0; j < risk.GetLength(1); j++)
                {
                    risk[i, j] = Math.Pow(profit[i, j] - averageProfit[i] - beta[i] * (profitSP[j] - averageProfitSP), 2);
                }
            }

            for (int i = 0; i < risk.GetLength(0); i++)
            {
                for (int j = 0; j < risk.GetLength(1); j++)
                {
                    sum += risk[i, j];
                }
                averageRisk[i] = sum / (risk.GetLength(1));
                sum = 0;
            }
            return averageRisk;
        }
        //R_sp
        public static double R_sp(double[] profitSP, double averageProfitSP)
        {
            return profitSP[profitSP.Length - 1] - averageProfitSP;
        }
        //Риск единичного портфеля
        public static double RiskSP(double sum_d, int n)
        {
            return Math.Sqrt(sum_d/n);
        }
        //Ковариация
        //prof[4, 12]
        private static double Cov(double[,] profit, double[] averageProfit, int i, int j)
        {
            double res = 0;

            for (int k = 0; k < profit.GetLength(1); k++ )
            {
                res += (profit[i, k] - averageProfit[i]) * (profit[j, k] - averageProfit[j]);
            }

            return res/profit.GetLength(1);
        }
        //Корреляция
        public static double Cor(double[,] profit, double[] averageProfit, int i, int j)
        {
            double si = 0, sj = 0;
            double cov = Cov(profit, averageProfit, i, j);

            for (int k = 0; k < profit.GetLength(1); k++)
            {
                si += (profit[i, k] - averageProfit[i]) * (profit[i, k] - averageProfit[i]);
                sj += (profit[j, k] - averageProfit[j]) * (profit[j, k] - averageProfit[j]);
            }
            si /= profit.GetLength(1);
            sj /= profit.GetLength(1);

            return cov / (Math.Sqrt(si) * Math.Sqrt(sj));
        }
        //Волатильность по периодам
        public static double[] Vol_t(double[] asset)
        {
            double[] result = new double[asset.Length - 1];
            for (int i = 0; i < result.Length;i++ )
            {
                result[i] = asset[i + 1] / asset[i];// Math.Log(asset[i + 1] / asset[i]);
            }

            return result;
        }
        //Средняя волатильность
        public static double AverageVol(double[] vol_t)
        {
            double result = 0;
            foreach(var t in vol_t)
            {
                result += t;
            }
            return result / vol_t.Length;
        }
        //Волатильность ЦБ
        public static double Volatility(double[] vol_t, double averageVol)
        {
            double result = 0;
            for (int i = 0; i < vol_t.Length; i++)
            {
                result += Math.Pow(vol_t[i] - averageVol, 2);
            }
            return Math.Sqrt(result / vol_t.Length);
        }

        public static double StandardDeviation(double[,] profit, Portfolio portfolio) //массив доходностей [4, 12]
        {
            double stdev = 0;
            double[] portf = portfolio.ConvertPortfolio();
            double[] result = new double[profit.GetLength(1)];

            for (int i = 0; i < profit.GetLength(1); i++)
            {
                for (int j = 0 ; j < profit.GetLength(0); j++)
                {
                    result[i] += (portf[j]/100) * profit[j, i];
                }
            }
            double average = result.Average();
            double sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                sum += (result[i] - average) * (result[i] - average);
            }
            stdev = sum / result.Length;

            return Math.Sqrt(stdev);
        }
        public static double PortfolioCost(double[,] finalArray, Portfolio p)
        {
            double cost = 0;
            double[] portfolio = p.ConvertPortfolio();

            for (int i = 0; i < finalArray.GetLength(0); i++)
            {
                cost += finalArray[i, finalArray.GetLength(1) - 1] * portfolio[i]*100;
            }

            while (cost < 100000)
                cost *= 10;

            return cost;
        }
    }
}
