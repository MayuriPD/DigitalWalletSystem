// <auto-generated />
using DigitalWalletSystem.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitalWalletSystem.Migrations
{
    [DbContext(typeof(DigitalWalletDbContext))]
    partial class DigitalWalletDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DigitalWalletSystem.Models.Account", b =>
                {
                    b.Property<int>("Accountid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Registerid")
                        .HasColumnType("int");

                    b.Property<double>("TotalBalance")
                        .HasColumnType("float");

                    b.HasKey("Accountid");

                    b.HasIndex("Registerid");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("DigitalWalletSystem.Models.LoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegisterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.ToTable("LoginHistory");
                });

            modelBuilder.Entity("DigitalWalletSystem.Models.Register", b =>
                {
                    b.Property<int>("RegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegisterId");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("DigitalWalletSystem.Models.Account", b =>
                {
                    b.HasOne("DigitalWalletSystem.Models.Register", "Register")
                        .WithMany("Account")
                        .HasForeignKey("Registerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Register");
                });

            modelBuilder.Entity("DigitalWalletSystem.Models.LoginHistory", b =>
                {
                    b.HasOne("DigitalWalletSystem.Models.Register", "Register")
                        .WithMany("LoginHistory")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Register");
                });

            modelBuilder.Entity("DigitalWalletSystem.Models.Register", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("LoginHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
