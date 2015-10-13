namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Report
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }
    }
}
