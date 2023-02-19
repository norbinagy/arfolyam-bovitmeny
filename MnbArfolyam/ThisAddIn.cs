using Microsoft.Office.Interop.Excel;
using MnbArfolyam.Classes;

namespace MnbArfolyam
{
    public partial class ThisAddIn
    {
        static MNBCurrencies currencies;
        static MNBStoredInterval interval;

        public static MNBCurrencies MNBCurrencies { get => currencies; set => currencies = value; }
        public static MNBStoredInterval MNBInterval { get => interval; set => interval = value; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            MNBCurrencies = MNBClient.GetCurrencies();
            MNBInterval = MNBClient.GetDateInterval();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// A jelenlegi munkalapot kérdezi le.
        /// </summary>
        /// <returns>Jelenlegi munkalap</returns>
        public Worksheet GetActiveWorksheet()
        {
            return (Worksheet)Application.ActiveSheet;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
