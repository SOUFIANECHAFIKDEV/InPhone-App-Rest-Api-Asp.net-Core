// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inphone_API.Infrastructure;

namespace inphone_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210417214856_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("inphone_API.Model.Button", b =>
                {
                    b.Property<int>("IdButton")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModificationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("IdButton");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("Type");

                    b.ToTable("Button");
                });

            modelBuilder.Entity("inphone_API.Model.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModificationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Logo1")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Logo2")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Logo3")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("IdCustomer");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("inphone_API.Model.TypeButton", b =>
                {
                    b.Property<int>("IdTypeButton")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("IdTypeButton");

                    b.ToTable("TypeButton");

                    b.HasData(
                        new
                        {
                            IdTypeButton = 1,
                            Description = "(Should open the default text app of the user's phone) - and default use phone number in the setup",
                            Label = "Text"
                        },
                        new
                        {
                            IdTypeButton = 2,
                            Description = "(Should open default email function from users phone)",
                            Label = "Send email"
                        },
                        new
                        {
                            IdTypeButton = 3,
                            Description = "",
                            Label = "Call"
                        },
                        new
                        {
                            IdTypeButton = 4,
                            Description = "",
                            Label = "Video"
                        },
                        new
                        {
                            IdTypeButton = 5,
                            Description = "",
                            Label = "Web link"
                        });
                });

            modelBuilder.Entity("inphone_API.Model.Button", b =>
                {
                    b.HasOne("inphone_API.Model.Customer", "Customer")
                        .WithMany("Buttons")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("inphone_API.Model.TypeButton", "TypeButton")
                        .WithMany("Buttons")
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
