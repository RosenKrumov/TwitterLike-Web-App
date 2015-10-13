namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Tweet> ownTweets;

        private ICollection<Tweet> favouriteTweets;

        private ICollection<Report> tweetReports; 

        private ICollection<ApplicationUser> followers;

        private ICollection<ApplicationUser> following;

        private ICollection<Notification> notifications;

        private ICollection<Message> sentMessages; 

        private ICollection<Message> receivedMessages; 

        public ApplicationUser()
        {
            this.followers = new HashSet<ApplicationUser>();
            this.following = new HashSet<ApplicationUser>();
            this.notifications = new HashSet<Notification>();
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.ownTweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<Tweet>();
            this.tweetReports = new HashSet<Report>();
        }

        public virtual ICollection<ApplicationUser> Followers
        {
            get { return this.followers; }

            set { this.followers = value; }
        }

        public virtual ICollection<ApplicationUser> Following
        {
            get { return this.following; }

            set { this.following = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }

            set { this.notifications = value; }
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }

            set { this.sentMessages = value; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        public virtual ICollection<Tweet> OwnTweets
        {
            get { return this.ownTweets; }
            set { this.ownTweets = value; }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }

        public virtual ICollection<Report> TweetReports
        {
            get { return this.tweetReports; }
            set { this.tweetReports = value; }
        } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
