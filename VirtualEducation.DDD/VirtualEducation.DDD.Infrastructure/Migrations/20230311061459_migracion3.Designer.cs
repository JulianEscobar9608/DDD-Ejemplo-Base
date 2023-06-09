﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualEducation.DDD.Infrastructure;

#nullable disable

namespace VirtualEducation.DDD.Infrastructure.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230311061459_migracion3")]
    partial class migracion3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VirtualEducation.DDD.Infrastructure.Generics.StoredEvent", b =>
                {
                    b.Property<string>("StoredId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoredName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoredId");

                    b.ToTable("storedEvent", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
