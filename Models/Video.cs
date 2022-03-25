using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryWithAbstractClasses.Models
{
    public class Video : Media
    {
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public List<Video> videoList;
        public override void ReadData()
        {
            string filePath = $"{AppContext.BaseDirectory}/Data/videos.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: {File}", filePath);
                return;
            }

            try
            {
                videoList = new List<Video>();
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] videoDetails = line.Split(",");

                    var video = new Video();
                    video.Id = Int32.Parse(videoDetails[0]);
                    video.Title = videoDetails[1];
                    video.Format = videoDetails[2];
                    video.Length = Int32.Parse(videoDetails[3]);
                    var regionDetails = videoDetails[4].Split("|");
                    int[] region = Array.ConvertAll(regionDetails, s => int.Parse(s));
                    video.Regions = region;

                    videoList.Add(video);
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
            foreach (var video in videoList)
            {
                var regions = String.Join(",", video.Regions);
                sb.AppendLine($"VideoID: {video.Id} Title: {video.Title} Format: {video.Format} Length: {video.Length} Regions: {regions}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
