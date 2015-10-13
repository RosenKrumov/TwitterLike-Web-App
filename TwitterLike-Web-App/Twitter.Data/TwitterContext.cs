namespace Twitter.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class TwitterContext : IdentityDbContext<ApplicationUser>, ITwitterContext
    {
        public TwitterContext()
            : base("name=TwitterContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>());
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.SentMessages)
                .WithRequired(m => m.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReceivedMessages)
                .WithRequired(m => m.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Following)
                .Map(
                m =>
                {
                    m.MapLeftKey("FollowerId");
                    m.MapRightKey("FollowingId");
                    m.ToTable("FollowerFollowing");
                });

            modelBuilder.Entity<Tweet>()
                .HasMany(u => u.ReplyTweets)
                .WithMany()
                .Map(
                    m =>
                    {
                        m.MapLeftKey("TweetId");
                        m.MapRightKey("ReplyTweetId");
                        m.ToTable("ReplyTweets");
                    }
                );

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.FavoritedBy)
                .WithMany(u => u.FavouriteTweets)
                .Map(
                    m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("TweetId");
                        m.ToTable("UsersFavouriteTweets");
                    }
                );

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.RetweetedBy)
                .WithMany()
                .Map(
                    m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("TweetId");
                        m.ToTable("UsersRetweets");
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}