using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;

namespace ObserwatorzyGwiazd
{
    public class OdczytywanieXml           // Odczytywanie danych z pliku w formacie xml
    {
        public XmlDocument XmlDoc;
        public OdczytywanieXml(string sciezkaPliku)
        {
            XmlDoc = new XmlDocument();
            if(sciezkaPliku!=null) {
                  XmlDoc.Load(sciezkaPliku);
            } 
        }
        
        // Uzupełnianie danych w aplikacji na postawie pliku
        public string[] uzupelnijWydarzenia(string indeksMies)
        {                                                         
            string[] tekst = new string[3];
            tekst[0] = "";
            tekst[1] = "";
            tekst[2] = "";

            foreach (string w in znajdzMiastaDanegoMiesiaca(indeksMies))
            {
                tekst[0] += w + "\n";
            }
            foreach (string w in znajdzNazwyWydarzenia(indeksMies))
            {
                tekst[1] += w + "\n";
            }
            foreach (string w in znajdzDaty(indeksMies))
            {
                tekst[2] += w + "\n";
            }

            return tekst;
        }


        public string[] znajdzMiastaDanegoMiesiaca(string indeksMies)
        {
            List<string> ListaMiast = new List<string>();
            XmlNodeList Miasta = XmlDoc.SelectNodes("//miesiac[@indeks= '" + indeksMies + "']//w");
            foreach (XmlNode xn in Miasta)
            {
                if (xn.HasChildNodes)
                {
                    ListaMiast.Add(xn.Attributes["miasto"].InnerText);
                }
            }
            return ListaMiast.ToArray();
        }

        public string[] znajdzNazwyWydarzenia(string indeksMies)
        {
            List<string> ListaWydarzen = new List<string>();
            XmlNodeList Wydarzenia = XmlDoc.SelectNodes("//miesiac[@indeks = '" + indeksMies + "']//w");
            foreach (XmlNode xn in Wydarzenia)
            {
                if (xn.HasChildNodes)
                {
                    foreach (XmlNode item in xn.ChildNodes)
                        ListaWydarzen.Add(item.InnerText);
                }
            }
            return ListaWydarzen.ToArray();
        }

        public string[] znajdzDaty(string indeksMies)
        {
            List<string> ListaDat = new List<string>();
            XmlNodeList Daty = XmlDoc.SelectNodes("//miesiac[@indeks= '" + indeksMies + "']//w");
            foreach (XmlNode xn in Daty)
            {
                if (xn.HasChildNodes)
                {
                    ListaDat.Add(xn.Attributes["data"].InnerText);
                }
            }
            return ListaDat.ToArray();
        }

        // uzupełnianie opisów faz Księżyca z pliku "fazy.xml" 
        public string dopasujOpisFazy(String nazwaFazy)
        {
            string wynik="";
            XmlNodeList Faza;

            if (nazwaFazy == "Nów")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 1 + "']");
            else if (nazwaFazy == "Sierp Przybywający")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 2 + "']");
            else if (nazwaFazy == "Pierwsza Kwadra")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 3 + "']");
            else if (nazwaFazy == "Księżyc Garbaty Przybywający")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 4 + "']");
            else if (nazwaFazy == "Pełnia")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 5 + "']");
            else if (nazwaFazy == "Księżyc Garbaty Ubywający")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 6 + "']");
            else if (nazwaFazy == "Ostatnia Kwadra")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 7 + "']");
            else if (nazwaFazy == "Sierp Ubywający")
                Faza = XmlDoc.SelectNodes("//faza[@indeks = '" + 8 + "']");
            else
                Faza = null;

              foreach (XmlNode xn in Faza)
              {
                if (xn.HasChildNodes)
                {
                    foreach (XmlNode item in xn.ChildNodes)
                        wynik = item.InnerText;
                }
              }
            return wynik;
        }

    }
}
