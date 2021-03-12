using System;
using System.Globalization;

namespace Task1
{
    class Program
    {
        static void SetCulture(string culture)
        {
            System.Globalization.CultureInfo cc;
            switch (culture)
            {
                case "Belarusian":
                    cc = new System.Globalization.CultureInfo("be");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc; //  sets the culture for the current thread
                    break;
                case "Ukrainian":
                    cc = new System.Globalization.CultureInfo("uk");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Chinese":
                    cc = new System.Globalization.CultureInfo("zh");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Czech":
                    cc = new System.Globalization.CultureInfo("cz");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Danish":
                    cc = new System.Globalization.CultureInfo("da");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "English":
                    cc = new System.Globalization.CultureInfo("en");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "French":
                    cc = new System.Globalization.CultureInfo("fr");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Finnish":
                    cc = new System.Globalization.CultureInfo("fi");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "German":
                    cc = new System.Globalization.CultureInfo("de");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Italian":
                    cc = new System.Globalization.CultureInfo("it");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Japanese":
                    cc = new System.Globalization.CultureInfo("jv");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Latvian":
                    cc = new System.Globalization.CultureInfo("lv");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Lithuanian":
                    cc = new System.Globalization.CultureInfo("lt");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Polish":
                    cc = new System.Globalization.CultureInfo("pl");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Russian":
                    cc = new System.Globalization.CultureInfo("ru");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
                case "Spanish":
                    cc = new System.Globalization.CultureInfo("es");
                    System.Threading.Thread.CurrentThread.CurrentCulture = cc;
                    break;
            }
        }
        static void Main(string[] args)
        {
            string culture;
            Console.Write("Available cultures:\n" +
                "Belarusian\n" + 
                "Ukrainian\n" + 
                "Chinese\n" + 
                "Czech\n" + 
                "Danish\n" + 
                "English\n" + 
                "French\n" + 
                "Finnish\n" + 
                "German\n" + 
                "Italian\n" + 
                "Japanese\n" + 
                "Latvian\n" + 
                "Lithuanian\n" + 
                "Polish\n" + 
                "Russian\n" + 
                "Spanish\n" +  
                "Enter culture : ");
            culture = Console.ReadLine();
            Console.Clear();
            SetCulture(culture);
            DateTime dt = new DateTime(2000, 1, 1);
            for(int i = 0; i < 12; ++i)
            {
                Console.WriteLine(dt.ToString("MMMM"));
                dt = dt.AddMonths(1);
            }
        }
    }
}
