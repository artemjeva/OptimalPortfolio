using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace OptimalPortfolio
{
    class WorkWithExcel
    {

        public static void WriteColumn(Worksheet workSheet, string name, Array array, int col)
        {
            workSheet.Cells[1, col] = name;
            for (int i = 2; i <= array.Length + 1; i++)
            {
                workSheet.Cells[i, col] = array.GetValue(i - 2);
            }
        }
        public static void WriteFile(Asset[] company, double[] averageProfit, double[] beta, double[] risk, int periods, double riskSP, double R_sp, double givenRisk)
        {
            int count = company.Length;
            Application Excel = new Application();
            Workbook workBook;
            Worksheet workSheet;
            workBook = Excel.Workbooks.Open(System.Windows.Forms.Application.StartupPath + "\\test2.xlsm");//@"D:\assets\test2.xlsm");
            workSheet = (Worksheet)workBook.Sheets[1];
            Excel.Visible = true;
            Excel.UserControl = true;

           // workSheet.Cells.get_Range("B").AutoFit();

            workSheet.Cells[1, 1] = "Название";
            for (int i = 2; i <= company.Length + 1; i++)
            {
                workSheet.Cells[i, 1] = company[i - 2].Ticker;
            }

            WriteColumn(workSheet, "Доходность", averageProfit, 2);
            WriteColumn(workSheet, "Бета", beta, 3);
            WriteColumn(workSheet, "Остаточный риск", risk, 4);

            workSheet.Cells[count + 3, 1] = "Риск ЕП";
            workSheet.Cells[count + 3, 2] = riskSP;
            workSheet.Cells[count + 4, 1] = "R_sp";
            workSheet.Cells[count + 4, 2] = R_sp;

            workSheet.Cells[count + 2, 5] = "Сумма";

            workSheet.Cells[1, 6] = "Доли (W)";
            workSheet.Cells[1, 7] = "R*W";
            workSheet.Cells[1, 8] = "Бета*W";
            workSheet.Cells[1, 9] = "(Бета*W)^2";
            workSheet.Cells[1, 10] = "ОР^2*W^2";

            for (int i = 2; i <= count + 1; i++)
            {
                workSheet.Cells.get_Range("G" + i).FormulaLocal = "=B" + i + "*F" + i;
                workSheet.Cells.get_Range("H" + i).FormulaLocal = "=C" + i + "*F" + i;
                workSheet.Cells.get_Range("I" + i).FormulaLocal = "=H" + i + "*H" + i;
                workSheet.Cells.get_Range("J" + i).FormulaLocal = "=D" + i + "*D" + i + "*F" + i + "*F" + i;
            }
            workSheet.Cells.get_Range("F" + (count + 2)).FormulaLocal = "=СУММ(F2:F" + (count + 1) + ")";
            workSheet.Cells.get_Range("G" + (count + 2)).FormulaLocal = "=СУММ(G2:G" + (count + 1) + ")";
            workSheet.Cells.get_Range("H" + (count + 2)).FormulaLocal = "=СУММ(H2:H" + (count + 1) + ")";
            workSheet.Cells.get_Range("I" + (count + 2)).FormulaLocal = "=СУММ(I2:I" + (count + 1) + ")";
            workSheet.Cells.get_Range("J" + (count + 2)).FormulaLocal = "=СУММ(J2:J" + (count + 1) + ")";

            workSheet.Cells[count + 6, 1] = "Доходность";
            workSheet.Cells[count + 7, 1] = "Риск";
            workSheet.Cells[count + 8, 1] = "Заданный риск";
            workSheet.Cells[count + 8, 3] = givenRisk/100;


            workSheet.Cells.get_Range("C" + (count + 6)).NumberFormat = "0.00%";
            workSheet.Cells.get_Range("C" + (count + 7)).NumberFormat = "0.00%";
            workSheet.Cells.get_Range("C" + (count + 8)).NumberFormat = "0.00%";

            workSheet.Cells.get_Range("C" + (count + 6)).FormulaLocal = "=СУММ(G2:G" + (count + 1) + ")+B" + (count + 4) + "*СУММ(H2:H" + (count + 1) + ")";
            workSheet.Cells.get_Range("C" + (count + 7)).FormulaLocal = "=КОРЕНЬ(I" + (count + 2) + "*B" + (count + 3) + "*B" + (count + 3) + "+J" + (count + 2) + ")";

            RunMacro(Excel, new Object[] { "SolverAll", count });

            workSheet.Cells[1, 12] = "Доли (в %)";

            for (int i = 2; i <= count + 2;i++)
            {
                workSheet.Cells.get_Range("L" + i).NumberFormat = "0.00%";
                workSheet.Cells.get_Range("L" + i).Interior.Color = System.Drawing.Color.PeachPuff;
                workSheet.Cells[i, 12] = workSheet.Cells[i, 6];
            }

            for (int i = 1; i < 13; i++)
            {
                Range exRange = (Range)workSheet.Columns[i];
                exRange.AutoFit();
            }
            //workBook.SaveAs(@"D:\0project\test.xlsx");
        }
        private static void RunMacro(object oApp, object[] oRunArgs)
        {
            oApp.GetType().InvokeMember("Run",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, oApp, oRunArgs);
        }
        
    }
}
