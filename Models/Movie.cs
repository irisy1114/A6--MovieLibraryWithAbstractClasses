using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryWithAbstractClasses.Models
{
    public class Movie : Media
    {
        public string Genres { get; set; }

        public List<Movie> movieList;
        public override void ReadData()
        {
            string filePath = $"{AppContext.BaseDirectory}/Data/movies.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: {File}", filePath);
                return;
            }

            try
            {
                movieList = new List<Movie>();
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    var movie = new Movie();
                    // check quote(") first, it contains a comma in movie title
                    int index = line.IndexOf('"');
                    if (index == -1)
                    {
                        string[] movieDetails = line.Split(',');

                        // first array contains movie id
                        movie.Id = Convert.ToInt32((movieDetails[0]));

                        // second array contains movie title
                        movie.Title = movieDetails[1];

                        // third array contains movie genres, replace'|' with ','
                        movie.Genres = movieDetails[2].Replace("|", ", ");
                    }
                    else
                    {
                        // quote means comma in movie title,locate the index of quote
                        // add number to movie id 
                        movie.Id = Convert.ToInt32(line.Substring(0, index - 1));
                        // remove movie id and first quote from line
                        line = line.Substring(index + 1);
                        // locate the next quote
                        index = line.IndexOf('"');
                        // extract the movie title
                        movie.Title = line.Substring(0, index);
                        // remove title and last comma from the line
                        line = line.Substring(index + 2);

                        // replace '|' with ','
                        movie.Genres = line.Replace("|", ", ");

                    }

                    movieList.Add(movie);

                }
                // close file when finished
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                movieList = null; //reset movie list
            }

        }
        public override void Display()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var movie in movieList)
            {
                sb.AppendLine($"MovieId:{movie.Id} Title:{movie.Title} Genre:{movie.Genres}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
