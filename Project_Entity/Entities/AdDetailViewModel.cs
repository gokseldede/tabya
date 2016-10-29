using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class AdDetailViewModel
    {
        //this list has all movies available for dropdown
        public List<Tag> AvailableTags { get; set; }
        //this list has our default values 
        public List<Tag> DefaultTags { get; set; }
        //this will retrieve the ids of movies selected in list when submitted
        public List<string> SubmittedTags { get; set; }

    }
}
