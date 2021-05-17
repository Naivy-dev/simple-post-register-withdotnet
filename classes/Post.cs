using System;
using System.Globalization;

namespace firstDotNetProj
{
    public class Post : BaseEntity
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private DateTime Date { get; set; }
        public Genre[] Genre { get; set; }
        private bool deleted;

        public Post(int id, string title, string description, DateTime date, Genre[] genre)
        {
            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.Genre = genre;
            this.deleted = false;
        }

        public override string ToString()
        {
            string _return = "";

            _return += "Title: " + this.Title + Environment.NewLine;
            _return += "Description: " + this.Description + Environment.NewLine;
            _return += "Date: " + this.Date + Environment.NewLine;
            _return += "Genre: ";
            for (int gen = 0; gen < this.Genre.Length; gen++)
            {
                if (this.Genre[gen] != (Genre)0)
                {
                    _return += this.Genre[gen] + " ";
                }
            }
            _return += Environment.NewLine;
            _return += "Deleted: " + this.deleted;
            return _return;
        }

        public string returnTitle()
        {
            return this.Title;
        }
        public bool returnDeleted()
        {
            return this.deleted;
        }
        public DateTime returnDate()
        {
            return this.Date;
        }

        public int returnId()
        {
            return this.Id;
        }

        public void delete()
        {
            this.deleted = true;
        }

    }
}