using System.Collections.Generic;
using System.Windows.Forms;

namespace MnbArfolyam.Classes
{
    public static class ExcelHandler
    {

        /// <summary>
        /// Létrehoz egy árfolyam táblát a megadott időintervallumon.
        /// </summary>
        /// <param name="startDate">Az időszak első időpontja YYYY-MM-DD formában.</param>
        /// <param name="endDate">Az időszak utolsó időpontja YYYY-MM-DD formában.</param>
        public static void CreateExchangeRateTable(string startDate, string endDate)
        {
            ExcelUtil.Clear();
            Globals.ThisAddIn.Application.ScreenUpdating = false;

            ExcelUtil.InsertSingle("Dátum/ISO", "A1");
            ExcelUtil.InsertSingle("Egység", "A2");

            ExcelUtil.InsertRange(MNBClient.GetCurrencyUnits(ThisAddIn.MNBCurrencies.ToString()).ToArray(), 1, 2);
            ExcelUtil.FormatRange("0", 2, 2, 2, ThisAddIn.MNBCurrencies.Currencies.Count + 1);

            MNBExchangeRates exchangeRates = MNBClient.GetExchangeRates(startDate, endDate, ThisAddIn.MNBCurrencies.ToString());
            ExcelUtil.InsertRange(exchangeRates.DayToArray(), 3, 1, "yyyy.mm.dd.");
            ExcelUtil.InsertRange(exchangeRates.RateToArray(ThisAddIn.MNBCurrencies), 3, 2, "0.00");

            Globals.ThisAddIn.Application.ScreenUpdating = true;
        }

        /// <summary>
        /// Létrehoz egy táblát az adatbázis Logs táblájának rekordjaiból, a munkalap adott helyén.
        /// </summary>
        /// <param name="rowIndex">A tábla bal felső elemének sor indexe.</param>
        /// <param name="columnIndex">A tábla bal felső elemének oszlop indexe.</param>
        public static void CreateLogTable(int rowIndex, int columnIndex)
        {
            ExcelUtil.Clear();

            ExcelUtil.InsertRange(new object[,] { { "ID", "Felhasználó", "Időpont", "Indoklás" } }, rowIndex, columnIndex, "General");

            List<DBLog> users = DBHandler.GetUsers();
            object[,] array = DBLog.GetArray(users);

            ExcelUtil.InsertRange(array, rowIndex + 1, columnIndex);

            ExcelUtil.FormatRange("0", rowIndex + 1, columnIndex, rowIndex + users.Count, columnIndex);
            ExcelUtil.FormatRange("General", rowIndex + 1, columnIndex + 1, rowIndex + users.Count, columnIndex + 1);
            ExcelUtil.FormatRange("yyyy.mm.dd. hh:mm:ss", rowIndex + 1, columnIndex + 2, rowIndex + users.Count, columnIndex + 2);
            ExcelUtil.FormatRange("General", rowIndex + 1, columnIndex + 3, rowIndex + users.Count, columnIndex + 3);
        }


        /// <summary>
        /// Frissíti az adatbázis Logs tábláját a munkalapon létrehozott táblával.
        /// </summary>
        /// <param name="rowIndex">A tábla bal felső elemének sor indexe.</param>
        /// <param name="columnIndex">A tábla bal felső elemének oszlop indexe.</param>
        public static void UpdateLogTable(int rowIndex, int columnIndex)
        {
            List<DBLog> users = DBHandler.GetUsers();
            int index = -1;

            try
            {
                for (int i = rowIndex + 1; i < users.Count + rowIndex + 1; i++)
                {
                    index = users.FindIndex(x => x.Id == Globals.ThisAddIn.GetActiveWorksheet().Cells[i, columnIndex].Value);

                    if (index != -1)
                    {
                        if ((Globals.ThisAddIn.GetActiveWorksheet().Cells[i, columnIndex + 3].Value ?? "") != users[index].Indoklas)
                        {
                            DBHandler.InsertReason(index + 1, (string)Globals.ThisAddIn.GetActiveWorksheet().Cells[i, columnIndex + 3].Value);
                        }
                    }
                    else
                    {
                        MessageBox.Show("A bejegyzés módosítása sikertelen.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("A bejegyzés módosítása sikertelen.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
