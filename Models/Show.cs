using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryWithAbstractClasses.Models
{
    public class Show : Media
    {
        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public List<Show> showList;

        public override void ReadData()
        {
            string filePath = $"{AppContext.BaseDirectory}/Data/shows.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: {File}", filePath);
                return;
            }

            try
            {
                showList = new List<Show>();
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var show = new Show();

                    string[] showDetails = line.Split(',');

                    show.Id = Convert.ToInt32((showDetails[0]));
                    show.Title = showDetails[1];
                    show.Season = Convert.ToInt32((showDetails[2]));
                    show.Episode = Convert.ToInt32((showDetails[3]));
                    string[] writer = showDetails[4].Split("|");
                    show.Writers = writer;

                    showList.Add(show);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Display()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var show in showList)
            {
                var writers = String.Join(",", show.Writers);
                sb.AppendLine($"ShowId: {show.Id} Title: {show.Title} Season: {show.Season} Episode: {show.Episode} Writers: {writers}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
