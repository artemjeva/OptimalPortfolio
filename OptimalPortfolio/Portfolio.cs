using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalPortfolio
{
    public class Portfolio
    {
        private double[] array;
        private double profit, risk, standDev = 0;
        private double cost;

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Portfolio(double[] array)
        {
            if(array.Length >= 3)
            {
                this.array = new double[array.Length - 2];
                for (int i = 0; i < this.array.Length; i++)
                    this.array[i] = array[i];
                profit = array[array.Length - 2];
                risk = array[array.Length - 1];
            }
        }
        public Portfolio(double[] array, double profit, double risk)
        {
            this.array = array;
            this.profit = profit;
            this.risk = risk;
        }

        public double Profit 
        {
            get { return profit; }
            set { profit = value; }
        }

        public double Risk
        {
            get { return risk; }
            set { risk = value; }
        }
        
        public double StandDev
        {
            get { return standDev; }
            set { standDev = value; }
        }

        public double[] ConvertPortfolio() { return array; }

        public double GetSum
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < array.Length; i++)
                    sum += array[i];
                return sum;
            }
        }

    }
}
