using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SolverFoundation.Common;
using Microsoft.SolverFoundation.Services;
using Microsoft.SolverFoundation.Solvers;

namespace OptimalPortfolio
{
    static class SolverClass
    {
        // возвращает массив, где предпоследний элемент - доходность, последний - риск, в начале - доли активов
        private static Portfolio SolverOptimalPortfolio(double[] profit, double[] beta, double[] residualRisk, double prof, double riskSP, double R_sp, double[] constraints)
        {
            int n = profit.Length;

            var solver = SolverContext.GetContext();
            solver.ClearModel();
            var model = solver.CreateModel();

            string[] name = new string[n];
            for (int i = 0; i < n; i++)
            {
                name[i] = "name" + i;
            }

            Decision[] decisions = new Decision[n];
            for (int i = 0; i < n; i++)
            {
                decisions[i] = new Decision(Domain.RealNonnegative, name[i]);
                model.AddDecision(decisions[i]);
            }

            string constr = "";
            for (int i = 0; i < n; i++)
            {
                constr += name[i] + "*" + profit[i] + "+";
            }
            constr += R_sp + "*(";
            for (int i = 0; i < n; i++)
            {
                constr += name[i] + "*" + beta[i] + "+";
            }
            constr = constr.Remove(constr.Length - 1, 1);
            constr += ") >= " + prof;


            string goal = "(";//"Sqrt[(";
            for (int i = 0; i < n; i++)
            {
                goal += name[i] + "*" + beta[i] + "*" + name[i] + "*" + beta[i] + "+";
            }
            goal = goal.Remove(goal.Length - 1, 1);
            goal += ")*" + riskSP + "*" + riskSP + "+(";
            for (int i = 0; i < n; i++)
            {
                goal += name[i] + "*" + name[i] + "*" + residualRisk[i] + "*" + residualRisk[i] + "+";
            }
            goal = goal.Remove(goal.Length - 1, 1);
            goal += ")";

            // contr1 = name[0]+ "*" + profit[0].ToString() + " + " + name[1] + "*" + profit[1].ToString() + " + " + name[2] + "*" + profit[2].ToString() + " + " + R_sp + "*(" + name[0]+ "*" + beta[0] + " + " + name[1]+ "*" + beta[1] + " + " + name[2] + "*" + beta[2] + ") >= " + prof;
            //
            // string goal = "(" + name[0] + "*" + beta[0] + "*" + name[0] + "*" + beta[0] + " + " + name[1] + "*" + beta[1] + "*" + name[1] + "*" + beta[1] + " + " + name[2] + "*" + beta[2] + "*" + name[2] + "*" + beta[2] + ")*" + riskSP + "*" + riskSP +
            //                                " +(" + name[0] + "*" + name[0] + "*" + residualRisk[0] + "*" + residualRisk[0] + " + " + name[1] + "*" + name[1] + "*" + residualRisk[1] + "*" + residualRisk[1] + " + " + name[2] + "*" + name[2] + "*" + residualRisk[2] + "*" + residualRisk[2] + ")";

            constr = constr.Replace(",", ".");
            goal = goal.Replace(",", ".");
            model.AddGoal("Goal", GoalKind.Minimize, goal);//SumOfFactors(profit, decisions) + R_sp*SumOfFactors(beta, decisions));


            //    string contr1 = "(" + name[0] + "*" + beta[0] + "*" + name[0] + "*" + beta[0] + " + " + name[1]+ "*" + beta[1] + "*" + name[1] + "*" + beta[1] + " + " + name[2] + "*" + beta[2] + "*" + name[2] + "*" + beta[2] + ")*" + riskSP + "*" + riskSP +
            //                                    " +(" + name[0] + "*" + name[0]+ "*" + residualRisk[0] + "*" + residualRisk[0] + " + " + name[1]+ "*" + name[1]+ "*" + residualRisk[1] + "*" + residualRisk[1] + " + " + name[2] + "*" + name[2] + "*" + residualRisk[2] + "*" + residualRisk[2] + ") >= " + risk*risk;
            string constrEq = "";
            for(int i =0; i < n; i++)
            {
                constrEq += name[i] + "+";
            }
            constrEq = constrEq.Remove(constrEq.Length - 1);
            constrEq += "== 1";

            string[] c = new string[constraints.Length];
            for (int i = 0; i < c.Length;i++ )
            {
                c[i] = name[i] + " <= " + (constraints[i]/100);
                c[i] = c[i].Replace(",", ".");
            }


            model.AddConstraint("ConstraintMain", constr);
            model.AddConstraint("ConstraintEq", constrEq);
            int j =0;
            foreach(var t in c)
            {
                model.AddConstraint("c" + j, c[j]);
                j++;
            }

            for (int i = 0; i < n; i++)
            {
                model.AddConstraint("Constraint" + i, name[i] + ">= 0");
            }

            Solution solution = solver.Solve();

            double[] stat = new double[n + 2];

            for (int i = 0; i < n; i++)
            {
                stat[i] = decisions[i].GetDouble();
            }

            stat[stat.Length - 2] = GetProfit(decisions, profit, beta, R_sp); //(decisions[0].GetDouble() * profit[0] + decisions[1].GetDouble() * profit[1] + decisions[2].GetDouble() * profit[2] + R_sp *(decisions[0].GetDouble() * beta[0] + decisions[1].GetDouble() * beta[1] + decisions[2].GetDouble() * beta[2]));
            stat[stat.Length - 1] = GetRisk(decisions, beta, residualRisk, riskSP); // Math.Sqrt((decisions[0].GetDouble() * beta[0] * decisions[0].GetDouble() * beta[0] + decisions[1].GetDouble() * beta[1] * decisions[1].GetDouble() * beta[1] + decisions[2].GetDouble() * beta[2] * decisions[2].GetDouble() * beta[2]) * riskSP * riskSP +
            //(decisions[0].GetDouble()*decisions[0].GetDouble() * residualRisk[0] * residualRisk[0] + decisions[1].GetDouble()*decisions[1].GetDouble()* residualRisk[1] * residualRisk[1] + decisions[2].GetDouble()*decisions[2].GetDouble()* residualRisk[2] * residualRisk[2]));

            return new Portfolio(stat);

        }
        private static double GetProfit(Decision[] decisions, double[] profit, double[] beta, double R_sp)
        {
            double a = 0, b = 0;
            for (int i = 0; i < decisions.Length; i++)
            {
                a += decisions[i].GetDouble() * profit[i];
                b += decisions[i].GetDouble() * beta[i];
            }
            return a + R_sp * b;
        }
        public static double GetProfitSP(double[] profit, double[] beta, double R_sp)
        {
            double a = 0, b = 0;
            double w = (1.0 / profit.Length);
            for (int i = 0; i < profit.Length; i++)
            {
                a += w * profit[i];
                b += w * beta[i];
            }
            return a + R_sp * b;
        }
        private static double GetRisk(Decision[] decisions, double[] beta, double[] residualRisk, double riskSP)
        {
            double a = 0, b = 0;
            for (int i = 0; i < decisions.Length; i++)
            {
                a += decisions[i].GetDouble() * beta[i] *decisions[i].GetDouble() * beta[i];
                b += decisions[i].GetDouble() * decisions[i].GetDouble() * residualRisk[i] * residualRisk[i];
            }
            return Math.Sqrt(a * riskSP * riskSP + b);
        }

        public static Portfolio DoOpt(double[] profit, double[] beta, double[] residualRisk, double prof, double riskSP, double R_sp, double[] constraints)//, out Portfolio portfolio)
        {
            Portfolio p = SolverOptimalPortfolio(profit, beta, residualRisk, prof, riskSP, R_sp, constraints);
            if (p.Profit == 0 && p.Risk == 0)
            {
                if (prof > -0.1)
                    return DoOpt(profit, beta, residualRisk, prof - 0.001, riskSP, R_sp, constraints);//, out portfolio);
                else return p;
            }
            else
            {
                return p;
            }
        }

    }
}
