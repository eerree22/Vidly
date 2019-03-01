using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "影片名稱")]
        public string Name { get; set; }

        [Display(Name = "上映日期")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "存量")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "影片類型")]
        public int GenreId { get; set; }
    }
}