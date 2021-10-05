using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            //CONSTRUCTOR
            public OptionsBuild()
            {
                //AppConfiguration class with our connection string.
                Settings = new AppConfiguration();
                //Inits a class which allows us to configure the database connection for a db context.
                //In our case allocate the connection string that our DatabaseContext(Db Sessions) will use.
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                //Allocates the connection string to be used when connecting to a Microsoft Sql Database
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                //Allocates the set options to be used by the DbContext [Eg our connection string it must use when DatabaseContext it is initiated]
                DatabaseOptions = OptionsBuilder.Options;//used for options class for our database context as we specify that online 26 - ref to 32
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }
        // We want the DatabaseContext to expect to have an DbContextOptions object available when it is created:
        // So We have set a static OptionsBuild Constructor:
        // SO IN  OTHER WORDS: 
        // A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced
        public static OptionsBuild Options = new OptionsBuild();

        //DatabaseContext CONSTRUCTOR:
        // Initializes a new instance of DbContext (DatabaseContext) but with specified OPTIONS.
        // But we will always simply just use the static OptionsBuild Options, as they are static and ready to go.
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //Our DbSets [Entities].
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reply> Replies { get; set; }
        //public DbSet<Applicant> Applicants { get; set; }
        //public DbSet<Application> Applications { get; set; }
        //public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        //public DbSet<Grade> Grades { get; set; }
        //public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SET CUSTOM DEFAULT VALUE ON CREATION
            DateTime modifiedDate = new DateTime(1900, 1, 1);
            DateTime sentDate = new DateTime(2000, 1, 1);

            #region User
            modelBuilder.Entity<User>().ToTable("user");
            //Primary Key & Identity Column
            modelBuilder.Entity<User>().HasKey(ap => ap.User_ID);
            modelBuilder.Entity<User>().Property(ap => ap.User_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("user_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<User>().Property(ap => ap.Username).IsRequired(true).IsUnicode().HasMaxLength(100).HasColumnName("username");
            modelBuilder.Entity<User>().Property(ap => ap.User_Password).IsRequired(true).HasMaxLength(100).HasColumnName("user_password");
            modelBuilder.Entity<User>().Property(ap => ap.User_Profile_Name).IsRequired(true).IsUnicode().HasMaxLength(100).HasColumnName("user_profile_name");
            modelBuilder.Entity<User>().Property(ap => ap.User_Email).IsRequired(true).IsUnicode().HasMaxLength(250).HasColumnName("user_email");
            modelBuilder.Entity<User>().Property(ap => ap.User_Point).IsRequired(true).HasColumnName("user_point");
            modelBuilder.Entity<User>().Property(ap => ap.User_Creation_Date).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("user_creation_date");
            //RelationShips
            modelBuilder.Entity<User>()
                   .HasMany<Message>(app => app.Messages)
                   .WithOne(ap => ap.User)
                   .HasForeignKey(app => app.User_ID)
                   .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                   .HasMany<Reply>(app => app.Replies)
                   .WithOne(ap => ap.User)
                   .HasForeignKey(app => app.User_ID)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Message
            modelBuilder.Entity<Message>().ToTable("message");
            //Primary Key & Identity Column
            modelBuilder.Entity<Message>().HasKey(ap => ap.Message_ID);
            modelBuilder.Entity<Message>().Property(ap => ap.Message_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("message_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Message>().Property(ap => ap.Message_Content).IsRequired(true).HasMaxLength(100).HasColumnName("message_content");
            modelBuilder.Entity<Message>().Property(ap => ap.Message_Status).IsRequired(true).HasMaxLength(100).HasColumnName("message_status");
            modelBuilder.Entity<Message>().Property(apps => apps.Message_Creation_Date).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("message_creation_date");
            modelBuilder.Entity<Message>().Property(ap => ap.Message_Modified_Date).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("message_modified_date");
            modelBuilder.Entity<Message>().Property(ap => ap.Message_Sent_Date).IsRequired(true).HasDefaultValue(sentDate).HasColumnName("message_sent_date");

            //User link
            modelBuilder.Entity<Message>()
                 .HasOne<User>(app => app.User)
                 .WithMany(ap => ap.Messages)//CAN HAVE MANY APPLICATIONS
                 .HasForeignKey(app => app.User_ID)
                 .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

            //RelationShips
            modelBuilder.Entity<Message>()
                   .HasMany<Reply>(app => app.Replies)
                   .WithOne(ap => ap.Message)
                   .HasForeignKey(app => app.Message_ID)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete an applicants info Ever, We can update it though.


            #endregion

            #region Reply
            modelBuilder.Entity<Reply>().ToTable("reply");
            //Primary Key & Identity Column
            modelBuilder.Entity<Reply>().HasKey(ap => ap.Reply_ID);
            modelBuilder.Entity<Reply>().Property(ap => ap.Reply_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("reply_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Reply>().Property(ap => ap.Reply_Content).IsRequired(true).HasMaxLength(100).HasColumnName("reply_content");
            modelBuilder.Entity<Reply>().Property(ap => ap.Reply_Status).IsRequired(true).HasMaxLength(100).HasColumnName("reply_status");
            modelBuilder.Entity<Reply>().Property(apps => apps.Reply_Creation_Date).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("reply_creation_date");
            modelBuilder.Entity<Reply>().Property(ap => ap.Reply_Modified_Date).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("reply_modified_date");
            modelBuilder.Entity<Reply>().Property(ap => ap.Reply_Sent_Date).IsRequired(true).HasDefaultValue(sentDate).HasColumnName("reply_sent_date");

            //Applicant link
            modelBuilder.Entity<Reply>()
                 .HasOne<User>(app => app.User)
                 .WithMany(ap => ap.Replies)//CAN HAVE MANY replies
                 .HasForeignKey(app => app.User_ID)
                 .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

            //Grade link
            modelBuilder.Entity<Reply>()
                 .HasOne<Message>(app => app.Message)
                 .WithMany(ap => ap.Replies)//Grade is linked to many applications
                 .HasForeignKey(app => app.Message_ID)
                 .OnDelete(DeleteBehavior.NoAction);//Can delete an application.
            #endregion 
        }
    }
}