using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MovieLibraryWithAbstractClasses.Models;

namespace MovieLibraryWithAbstractClasses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Which media type do you want to display (1/2/3) ?");
            var choice = Console.ReadLine();

            Media media = null;

            switch (choice)
            {
                case "1":

                    media = new Movie();
                    media.ReadData();
                    break;

                case "2":
                    media = new Show();
                    media.ReadData();
                    break;

                case "3":
                    media = new Video();
                    media.ReadData();
                    break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 3.");
                    break;
            }

            media?.Display();
        }
    }
}
