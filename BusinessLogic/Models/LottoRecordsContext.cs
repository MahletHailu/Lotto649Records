using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusinessLogic.Models
{
    public partial class LottoRecordsContext : DbContext
    {
        public LottoRecordsContext()
        {
        }

        public LottoRecordsContext(DbContextOptions<LottoRecordsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HistoricalDraws> HistoricalDraws { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(" Server=tcp:boattrackerserver.database.windows.net,1433;Initial Catalog=LottoRecords;Persist Security Info=False;User ID=boattrackeradmin;Password=Stmary12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricalDraws>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BonusNumber).HasColumnName("BONUS_NUMBER");

                entity.Property(e => e.DrawDate)
                    .HasColumnName("DRAW_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.DrawNumber).HasColumnName("DRAW_NUMBER");

                entity.Property(e => e.NumberDrawn1).HasColumnName("NUMBER_DRAWN_1");

                entity.Property(e => e.NumberDrawn2).HasColumnName("NUMBER_DRAWN_2");

                entity.Property(e => e.NumberDrawn3).HasColumnName("NUMBER_DRAWN_3");

                entity.Property(e => e.NumberDrawn4).HasColumnName("NUMBER_DRAWN_4");

                entity.Property(e => e.NumberDrawn5).HasColumnName("NUMBER_DRAWN_5");

                entity.Property(e => e.NumberDrawn6).HasColumnName("NUMBER_DRAWN_6");

                entity.Property(e => e.SequenceNumber).HasColumnName("SEQUENCE_NUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
