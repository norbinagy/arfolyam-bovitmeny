namespace MnbArfolyam.Classes
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class MNBStoredInterval
    {
        private MNBStoredIntervalDateInterval dateIntervalField;
        public MNBStoredIntervalDateInterval DateInterval
        {
            get
            {
                return this.dateIntervalField;
            }
            set
            {
                this.dateIntervalField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MNBStoredIntervalDateInterval
    {
        private System.DateTime startdateField;
        private System.DateTime enddateField;

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime startdate
        {
            get
            {
                return this.startdateField;
            }
            set
            {
                this.startdateField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime enddate
        {
            get
            {
                return this.enddateField;
            }
            set
            {
                this.enddateField = value;
            }
        }
    }
}
