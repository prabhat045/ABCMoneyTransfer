using ABCMoneyTransfer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ABCMoneyTransfer.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("tblUsers");
            builder.Entity<Transaction>().ToTable("tblTransactions");
            builder.Entity<Transaction>(entity =>
            {
                entity.OwnsOne(t => t.Sender);
                entity.OwnsOne(t => t.Receiver);
                entity.OwnsOne(t => t.PaymentDetail, pd =>
                {
                    pd.Property(p => p.TransferAmount)
                      .HasColumnName("PaymentDetail_TransferAmount")
                      .HasPrecision(20, 2);
                    pd.Property(p => p.ExchangeRate)
                      .HasColumnName("PaymentDetail_ExchangeRate")
                      .HasPrecision(20, 2);
                });

                entity.Property(t => t.PayoutAmount)
                      .HasComputedColumnSql("([PaymentDetail_TransferAmount] * [PaymentDetail_ExchangeRate])", stored: true)
                      .HasPrecision(20, 2);
            });
        }
    }
}
