#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

#endregion

namespace ParvoICUStatsAnalyser
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            /*string[] nums =
                {
                    "A15930325.htm",
                    "A15930345.htm",
                    "A15930350.htm",
                    "A16567107.htm",
                    "A16766863.htm",
                    "A18782506.htm"
                };*/
            //PullRecords("2013.txt");
            List<AnimalRecord> records =
                ParseRecords(Application.StartupPath + @"\Data");

            StreamWriter writer = new StreamWriter("2013_9-6-2013.json");
            writer.Write(JsonConvert.SerializeObject(records, Formatting.Indented));
            writer.Close();

            Console.WriteLine("Done Processing. Press any key to quit.");
            Console.ReadLine();
        }

        public static void PullRecords(string filename)
        {
            /* Test Data
             * string[] anums =
                {
                    "A19555674", "A15140487", "A19556171", "A19564879", "A19564880", "A19572987", "A19581751",
                    "A19589716", "A19589821"
                };
             */

            StreamReader aNumsReader = new StreamReader(filename);
            string aNumsReaderFileString = aNumsReader.ReadToEnd();
            aNumsReader.Close();
            string[] anums = aNumsReaderFileString.Split(new[] {"\r\n"}, StringSplitOptions.None);

            string[] urls = new string[anums.Length];
            Console.WriteLine("Creating " + anums.Length + " urls...");
            for (int i = 0; i < anums.Length; i++)
                urls[i] = @"http://sms.petpoint.com/sms3/embeddedreports/animalviewreport.aspx?AnimalID=" +
                          anums[i].Substring(1);

            PageRipper p = new PageRipper(urls);
            Console.WriteLine("Loading and saving " + urls.Length + " urls...");
            p.ShowDialog();

            while (!p.Done)
            {
            }
            Console.WriteLine("Done pulling!");

            Console.WriteLine("Saving url text to anum files...");
            for (int i = 0; i < p.ResultDocumentTexts.Length; i++)
            {
                StreamWriter w = new StreamWriter(Application.StartupPath + "\\Data\\" + anums[i] + ".htm");
                w.Write(p.ResultDocumentTexts[i]);
                w.Close();
            }

            Console.WriteLine("Completed " + anums.Length + " page pull attempts and saves. \nPress any key to close.");
        }

        public static List<AnimalRecord> ParseRecords(string dataPath)
        {
            string[] files = Directory.GetFiles(dataPath);

            List<AnimalRecord> records = new List<AnimalRecord>();
            foreach (string f in files)
            {
                StreamReader reader = new StreamReader(f);
                string html = reader.ReadToEnd();
                reader.Close();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                AnimalRecord r = AnimalRecord.HtmlDocumentToAnimalRecord(doc);
                if (r != null)
                    records.Add(r);
            }
            return records;
        }

        public static List<AnimalRecord> ParseRecords(string dataPath, string[] filenames)
        {
            string[] files = new string[filenames.Length];
            for (int i = 0; i < filenames.Length; i++)
                files[i] = dataPath +"\\"+ filenames[i];
            List<AnimalRecord> records = new List<AnimalRecord>();
            foreach (string f in files)
            {
                StreamReader reader = new StreamReader(f);
                string html = reader.ReadToEnd();
                reader.Close();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                AnimalRecord r = AnimalRecord.HtmlDocumentToAnimalRecord(doc);
                if (r != null)
                    records.Add(r);
            }
            return records;
        }
    }
}