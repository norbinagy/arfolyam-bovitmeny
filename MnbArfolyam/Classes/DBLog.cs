using System;
using System.Collections.Generic;

namespace MnbArfolyam.Classes
{
    public class DBLog
    {
        int id;
        string felhasznaloNev;
        DateTime idopont;
        string indoklas;

        public int Id { get => id; set => id = value; }
        public string FelhasznaloNev { get => felhasznaloNev; set => felhasznaloNev = value; }
        public DateTime Idopont { get => idopont; set => idopont = value; }
        public string Indoklas { get => indoklas; set => indoklas = value; }

        public DBLog(int id, string felhasznaloNev, DateTime idopont, string indoklas)
        {
            Id = id;
            FelhasznaloNev = felhasznaloNev;
            Idopont = idopont;
            Indoklas = indoklas;
        }

        /// <summary>
        /// A megadott DBLog típusú Listát 2 dimenziós tömbbé alakítja.
        /// </summary>
        /// <param name="list">Az átalakítandó DBLog Lista.</param>
        /// <returns>A Lista elemei 2 dimenziós tömbben.</returns>
        public static object[,] GetArray(List<DBLog> list)
        {
            object[,] array = new object[list.Count, 4];
            for (int i = 0; i < list.Count; i++)
            {
                array[i, 0] = list[i].Id;
                array[i, 1] = list[i].FelhasznaloNev;
                array[i, 2] = list[i].Idopont;
                array[i, 3] = list[i].Indoklas;
            }
            return array;
        }
    }
}
