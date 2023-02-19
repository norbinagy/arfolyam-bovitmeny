using Microsoft.Office.Tools.Ribbon;
using MnbArfolyam.Classes;
using System;

namespace MnbArfolyam
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            ExcelHandler.CreateExchangeRateTable("2015-01-01", "2020-04-01");
            DBHandler.InsertUser(Environment.UserName);
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            ExcelHandler.CreateLogTable(1, 1);
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            ExcelHandler.UpdateLogTable(1, 1);
        }
    }
}
