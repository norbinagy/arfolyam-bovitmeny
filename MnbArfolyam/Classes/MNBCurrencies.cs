using System.Collections.Generic;
using System.Text;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class MNBCurrencies
{

    private List<string> currenciesField;

    [System.Xml.Serialization.XmlArrayItemAttribute("Curr", IsNullable = false)]
    public List<string> Currencies
    {
        get
        {
            return this.currenciesField;
        }
        set
        {
            this.currenciesField = value;
        }
    }

    /// <summary>
    /// A lista elemeket HUF,EUR formátumú string-é alakítja.
    /// </summary>
    /// <returns>A lista elemek string-ként.</returns>
    public override string ToString()
    {
        var allCurrencies = new StringBuilder();
        foreach (string item in currenciesField)
        {
            allCurrencies.Append(item);
            allCurrencies.Append(",");
        }
        allCurrencies.Length--;
        return allCurrencies.ToString();
    }
}