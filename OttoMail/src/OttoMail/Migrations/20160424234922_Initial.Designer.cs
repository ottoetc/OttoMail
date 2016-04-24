using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using OttoMail.Models;

namespace OttoMail.Migrations
{
    [DbContext(typeof(OttoMailDbContext))]
    [Migration("20160424234922_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OttoMail.Models.Email", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<bool>("Checked");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Read");

                    b.Property<string>("Sender");

                    b.Property<string>("Subject");

                    b.Property<int>("UserId");

                    b.HasKey("EmailId");

                    b.HasAnnotation("Relational:TableName", "Emails");
                });

            modelBuilder.Entity("OttoMail.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasAnnotation("Relational:TableName", "Users");
                });

            modelBuilder.Entity("OttoMail.Models.Email", b =>
                {
                    b.HasOne("OttoMail.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
