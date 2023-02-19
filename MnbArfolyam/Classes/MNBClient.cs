using MnbArfolyam.MNBArfolyamService;

namespace MnbArfolyam.Classes
{
    public static class MNBClient
    {

        static MNBArfolyamServiceSoapClient client;

        /// <summary>
        /// Lekérdezi a valuták neveit.
        /// </summary>
        /// <returns>MNBCurrencies amely tartalmazza a valuták neveit.</returns>
        public static MNBCurrencies GetCurrencies()
        {
            client = new MNBArfolyamServiceSoapClient();
            string xml = client.GetCurrencies(new GetCurrenciesRequestBody()).GetCurrenciesResult;
            client.Close();
            return XmlUtil.Deserialize<MNBCurrencies>(xml);
        }

        /// <summary>
        /// Lekérdezi az időintervallumot.
        /// </summary>
        /// <returns>MNBStoredInterval amely tartalmazza az első és utolsó lekérdezhető dátumot.</returns>
        public static MNBStoredInterval GetDateInterval()
        {
            client = new MNBArfolyamServiceSoapClient();
            string xml = client.GetDateInterval(new GetDateIntervalRequestBody()).GetDateIntervalResult;
            client.Close();
            return XmlUtil.Deserialize<MNBStoredInterval>(xml);
        }

        /// <summary>
        /// Lekérdezi az árfolyamokat a megadott időintervallumon a megadott valutákról.
        /// </summary>
        /// <param name="startDate">Az intervallum kezdete YYYY-MM-DD formában.</param>
        /// <param name="endDate">Az intervallum vége YYYY-MM-DD formában.</param>
        /// <param name="currencyNames">A valuták nevei HUF,EUR formában.</param>
        /// <returns>MNBExchangeRates amely tartalmazza a valuták értékeit az időintervallumon.</returns>
        public static MNBExchangeRates GetExchangeRates(string startDate, string endDate, string currencyNames)
        {
            client = new MNBArfolyamServiceSoapClient();
            string xml = client.GetExchangeRates(new GetExchangeRatesRequestBody { startDate = startDate, endDate = endDate, currencyNames = currencyNames }).GetExchangeRatesResult;
            client.Close();
            return XmlUtil.Deserialize<MNBExchangeRates>(xml);
        }

        /// <summary>
        /// Lekérdezi az adott valuták valutaegységét.
        /// </summary>
        /// <param name="currencyNames">A valuták nevei HUF,EUR formában.</param>
        /// <returns>MNBCurrencyUnits amely tartalmazza a valuták valutaegységeit.</returns>
        public static MNBCurrencyUnits GetCurrencyUnits(string currencyNames)
        {
            client = new MNBArfolyamServiceSoapClient();
            string xml = client.GetCurrencyUnits(new GetCurrencyUnitsRequestBody { currencyNames = currencyNames }).GetCurrencyUnitsResult;
            client.Close();
            return XmlUtil.Deserialize<MNBCurrencyUnits>(xml);
        }
    }
}
