using Banks.Entities;
using Banks.Entities.Entities;
using Banks.Entities.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Banks.DataAccess
{
    /// <summary>       
    /// Determines the content and configures the data context.        
    /// </summary>
    public class ApplicationContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Defines a collection of clients in the context.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Defines a collection of accounts in the context.
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Defines a collection of banks in the context.
        /// </summary>
        public DbSet<Bank> Banks { get; set; }

        /// <summary>
        /// Creates an instance of ApplicationContext.
        /// </summary>
        /// <param name="options">Data context configuration options.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {            
            Database.EnsureCreated();
        }

        ///<inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
               .HasOne(x => x.Bank);

            modelBuilder.Entity<Bank>()
                .HasMany(x => x.Clients)
                 .WithOne(x => x.Bank)
               .HasForeignKey(x => x.BankId);

            modelBuilder.Entity<Account>()
                .HasOne(x => x.Client)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.ClientId);

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(x => x.Id);
                u.HasMany(x => x.Clients)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
                u.ToTable("AspNetUsers");               
            });

            modelBuilder.Entity<User>().HasData(
               new User[]
               {
                    new User{Id="1", UserName="PetrLogin", Year=1970, PasswordHash="123", Email="Petr@mail.ru"},
                    new User{Id="2", UserName="PavelLogin", Year=2005, PasswordHash="123", Email="Pavel@mail.ru"},
                    new User{Id="3", UserName="PetyaLogin", Year=2012, PasswordHash="123", Email="Petya@mail.ru"},
               });

            modelBuilder.Entity<Client>().HasData(
                new Client[]
                {
                    new Client{Id=1, FirstName="Petr", LastName="Petrov", Code="1234567890", UserId="1", BankId=1},
                    new Client{Id=2, FirstName="Pavel", LastName="Pavlov", Code="9087654321", UserId="2", BankId=1},
                    new Client{Id=3, UserId="3", BankId=2, FirstName="Petya", LastName="Petin", Code="1472583690"}
                });

            modelBuilder.Entity<Account>().HasData(
                new Account[]
                {
                    new Account{Id=1, ClientId=1, Currency=Currencies.Uah, Number="123456"},
                    new Account{Id=2, ClientId=1, Currency=Currencies.Usd, Number="234567"},
                    new Account{Id=3, ClientId=2, Currency=Currencies.Uah, Number="789456"},
                    new Account{Id=4, ClientId=2, Currency=Currencies.Rub, Number="741852"},
                    new Account{Id=5, ClientId=3, Currency=Currencies.Uah, Number="789456"}
                });

            modelBuilder.Entity<Bank>().HasData(
                new Bank[]
                {
                    new Bank{Id=1, BankName="MEGABANK"},
                    new Bank{Id=2, BankName="MonoBank"}
                });
        }
    }
}
