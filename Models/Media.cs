using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryWithAbstractClasses.Models
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public abstract void Display();

        public abstract void ReadData();

    }
}
