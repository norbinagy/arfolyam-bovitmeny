using System.Collections.Generic;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class MNBCurrencyUnits
{

    private List<MNBCurrencyUnitsUnit> unitsField;

    [System.Xml.Serialization.XmlArrayItemAttribute("Unit", IsNullable = false)]
    public List<MNBCurrencyUnitsUnit> Units
    {
        get
        {
            return this.unitsField;
        }
        set
        {
            this.unitsField = value;
        }
    }

    /// <summary>
    /// A valuta nevekből és valutaegységekből 2 dimenziós tömböt készít.
    /// </summary>
    /// <returns>A 2 dimenziós tömb, első sor valuta név, második sor valutaegység.</returns>
    public object[,] ToArray()
    {
        object[,] array = new object[2, Units.Count];
        for (int i = 0; i < Units.Count; i++)
        {
            array[0, i] = Units[i].curr;
            array[1, i] = Units[i].Value;
        }
        return array;
    }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MNBCurrencyUnitsUnit
{

    private string currField;

    private int valueField;

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
    public int Value
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

