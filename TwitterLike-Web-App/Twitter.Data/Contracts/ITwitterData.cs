namespace Twitter.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface ITwitterData
    {
        IRepository<Tweet> Tweets { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<Message> Messages { get; }
        IRepository<ApplicationUser> Users { get; }
        int SaveChanges();
    }
}
