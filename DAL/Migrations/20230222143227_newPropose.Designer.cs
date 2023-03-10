// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230222143227_newPropose")]
    partial class newPropose
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("EntityBaseSequence");

            modelBuilder.Entity("DAL.Domain.EntityBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [EntityBaseSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DAL.Domain.Models.Animal", b =>
                {
                    b.HasBaseType("DAL.Domain.EntityBase");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasIndex("TypeId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("DAL.Domain.Models.Trophy", b =>
                {
                    b.HasBaseType("DAL.Domain.EntityBase");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfMurder")
                        .HasColumnType("datetime2");

                    b.HasIndex("AnimalId");

                    b.ToTable("Trophes");
                });

            modelBuilder.Entity("DAL.Domain.Models.TypeAnimal", b =>
                {
                    b.HasBaseType("DAL.Domain.EntityBase");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TypeAnimals");
                });

            modelBuilder.Entity("DAL.Domain.Models.User", b =>
                {
                    b.HasBaseType("DAL.Domain.EntityBase");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrophyId")
                        .HasColumnType("int");

                    b.HasIndex("TrophyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Domain.Models.Animal", b =>
                {
                    b.HasOne("DAL.Domain.Models.TypeAnimal", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DAL.Domain.Models.Trophy", b =>
                {
                    b.HasOne("DAL.Domain.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("DAL.Domain.Models.User", b =>
                {
                    b.HasOne("DAL.Domain.Models.Trophy", "Trophy")
                        .WithMany()
                        .HasForeignKey("TrophyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trophy");
                });
#pragma warning restore 612, 618
        }
    }
}
