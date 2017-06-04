using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalPortfolio
{
    public class Asset
    {
        private string name, code;
        private int number;
        private double volatility = 0, capitalization = 0, cor = 0, liquidity = 0;
        private double dividend = 0, averageProfit = 0;

        public double AverageProfit
        {
            get { return averageProfit; }
            set { averageProfit = value; }
        }

        public double Dividend
        {
            get { return dividend; }
            set { dividend = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Ticker
        {
            get { return code; }
            set { code = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
       
        public double Volatility
        {
            get { return volatility; }
            set { volatility = value; }
        }

        public double Capitalization
        {
            get { return capitalization; }
            set { capitalization = value; }
        }

        public double Correlation
        {
            get { return cor; }
            set { cor = value; }
        }

        public double Liquidity
        {
            get { return liquidity; }
            set { liquidity = value; }
        }
        public Asset(string name, string code, int number)
        {
            this.name = name;
            this.code = code;
            this.number = number;
            this.volatility = 0;
            this.capitalization = 0;
            this.cor = 0;
            this.liquidity = 0;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
