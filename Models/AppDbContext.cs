using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerce_Frutas.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrinho> Carrinho { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Frutas> Frutas { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrinho>(entity =>
            {
                entity.HasKey(e => e.CodCarrinho)
                    .HasName("PK__Carrinho__B17DEBF8E9F19931");

                entity.Property(e => e.CodCarrinho).ValueGeneratedNever();

                entity.Property(e => e.CarrinhoId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Frutas)
                    .WithMany(p => p.Carrinho)
                    .HasForeignKey(d => d.FrutasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carrinho__Frutas__46136164");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EstoqueId).ValueGeneratedOnAdd();

                entity.Property(e => e.QtdeAtual)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Frutas)
                    .WithMany()
                    .HasForeignKey(d => d.FrutasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estoque__FrutasI__1758727B");
            });

            modelBuilder.Entity<Frutas>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Valor).HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.CodPedido)
                    .HasName("PK__Pedido__D1AFD9978A61A293");

                entity.Property(e => e.CodPedido).ValueGeneratedNever();

                entity.Property(e => e.DataPedido).HasColumnType("date");

                entity.Property(e => e.PedidoId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CodCarrinhoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.CodCarrinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pedido__CodCarri__4BCC3ABA");

                entity.HasOne(d => d.CodStatusNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.CodStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pedido__CodStatu__4AD81681");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.CodStatus)
                    .HasName("PK__Status__C6B65D00BD2D65F6");

                entity.Property(e => e.CodStatus).ValueGeneratedNever();

                entity.Property(e => e.DescStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StatusId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
