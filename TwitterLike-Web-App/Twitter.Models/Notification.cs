namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public NotificationType NotificationType { get; set; }

        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
    }
}