using System.Collections.Generic;
using System.Globalization;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class MNBExchangeRates
{

    private List<MNBExchangeRatesDay> dayField;

    [System.Xml.Serialization.XmlElementAttribute("Day")]
    public List<MNBExchangeRatesDay> Day
    {
        get
        {
            return this.dayField;
        }
        set
        {
            this.dayField = value;
        }
    }

    /// <summary>
    /// A dátumokból 2 dimenziós tömböt készít.
    /// </summary>
    /// <returns>A 2 dimenziós tömb, első oszlopban a dátumok.</returns>
    public object[,] DayToArray()
    {
        object[,] array = new object[Day.Count, 1];
        for (int i = 0; i < Day.Count; i++)
        {
            array[i, 0] = Day[i].date;
        }
        return array;
    }

    /// <summary>
    /// 2 dimenziós tömböt készít a valuta értékekkel.
    /// </summary>
    /// <param name="currencies">A valuták.</param>
    /// <returns>A 2 dimenziós tömb a valuták értékeivel.</returns>
    public object[,] RateToArray(MNBCurrencies currencies)
    {
        int index = 0;
        object[,] array = new object[Day.Count, currencies.Currencies.Count];
        for (int i = 0; i < Day.Count; i++)
        {
            for (int j = 0; j < currencies.Currencies.Count; j++)
            {
                index = Day[i].Rate.FindIndex(x => x.curr.Equals(currencies.Currencies[j]));
                array[i, j] = index > -1 ? float.Parse(Day[i].Rate[index].Value, new NumberFormatInfo() { NumberDecimalSeparator = "," }) : (float?)null;
            }
        }
        return array;
    }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MNBExchangeRatesDay
{

    private List<MNBExchangeRatesDayRate> rateField;

    private System.DateTime dateField;

    [System.Xml.Serialization.XmlElementAttribute("Rate")]
    public List<MNBExchangeRatesDayRate> Rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MNBExchangeRatesDayRate
{

    private string unitField;

    private string currField;

    private string valueField;

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unit
    {
        get
        {
            return this.unitField;
        }
        set
        {
            this.unitField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string curr
    {
        get
        {
            return this.currField;
        }
        set
        {
            this.currField = value;
        }
    }

    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

