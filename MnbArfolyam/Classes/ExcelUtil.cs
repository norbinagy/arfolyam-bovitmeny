using Microsoft.Office.Interop.Excel;

namespace MnbArfolyam.Classes
{
    public static class ExcelUtil
    {
        static Worksheet sheet;
        static Range range;

        static ExcelUtil()
        {
            sheet = Globals.ThisAddIn.GetActiveWorksheet();
        }

        /// <summary>
        /// Törli a jelenlegi munkalap celláinak a tartalmát és formázását.
        /// </summary>
        public static void Clear()
        {
            sheet.Cells.ClearContents();
            sheet.Cells.ClearFormats();
        }

        /// <summary>
        /// Beilleszt egy elemet a munkalap adott cellájába.
        /// </summary>
        /// <param name="data">A beillesztendő elem.</param>
        /// <param name="cell">A cella neve A1 formátumban.</param>
        public static void InsertSingle(object data, string cell)
        {
            range = sheet.Range[cell];
            range.Value2 = data;
        }


        /// <summary>
        /// Beilleszti egy 2 dimenziós tömb elemeit a munkalapra az adott kezdő cellától.
        /// </summary>
        /// <param name="data">A 2 dimenziós tömb.</param>
        /// <param name="startRow">A kezdő cella sor indexe.</param>
        /// <param name="startColumn">A kezdő cella oszlop indexe.</param>
        public static void InsertRange(object[,] data, int startRow, int startColumn)
        {
            range = sheet.Range[sheet.Cells[startRow, startColumn], sheet.Cells[data.GetLength(0) + startRow - 1, data.GetLength(1) + startColumn - 1]];
            range.Value2 = data;
        }

        /// <summary>
        /// Beilleszti egy 2 dimenziós tömb elemeit a munkalapra az adott kezdő cellától a megadott formátumkóddal.
        /// </summary>
        /// <param name="data">A 2 dimenziós tömb.</param>
        /// <param name="startRow">A kezdő cella sor indexe.</param>
        /// <param name="startColumn">A kezdő cella oszlop indexe.</param>
        /// <param name="numberFormat">A formátumkód.</param>
        public static void InsertRange(object[,] data, int startRow, int startColumn, string numberFormat)
        {
            range = sheet.Range[sheet.Cells[startRow, startColumn], sheet.Cells[data.GetLength(0) + startRow - 1, data.GetLength(1) + startColumn - 1]];
            range.Value2 = data;
            range.NumberFormat = numberFormat;
        }

        /// <summary>
        /// Az adott cella tartományt formázza a megadott formátumkóddal.
        /// </summary>
        /// <param name="numberFormat">A formátumkód.</param>
        /// <param name="startRow">A kezdő cella sor indexe.</param>
        /// <param name="startColumn">A kezdő cella oszlop indexe.</param>
        /// <param name="endRow">Az utolsó cella sor indexe.</param>
        /// <param name="endColumn">Az utolsó cella oszlop indexe.</param>
        public static void FormatRange(string numberFormat, int startRow, int startColumn, int endRow, int endColumn)
        {
            range = sheet.Range[sheet.Cells[startRow, startColumn], sheet.Cells[endRow, endColumn]];
            range.NumberFormat = numberFormat;
        }
    }
}
