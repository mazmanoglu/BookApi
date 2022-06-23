﻿using System;

namespace BookApi.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public DateTime DateAdded { get; set; }


        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

    }
}
