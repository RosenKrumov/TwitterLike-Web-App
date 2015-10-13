namespace Twitter.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface ITwitterContext
    {
        IDbSet<Tweet> Tweets { get; }
        IDbSet<Notification> Notifications { get; }
        IDbSet<Message> Messages { get; }
    }
}
