﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelBlog.Models;

namespace TravelBlog.Migrations
{
    [DbContext(typeof(TravelBlogDbContext))]
    [Migration("20160907175827_AddPeopleExperiencesModel")]
    partial class AddPeopleExperiencesModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("LocationId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TravelBlog.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TravelBlog.Models.PeopleExperiences", b =>
                {
                    b.Property<int>("PeopleExperiencesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExperienceId");

                    b.Property<int>("PersonId");

                    b.HasKey("PeopleExperiencesId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("PersonId");

                    b.ToTable("PeopleExperiences");
                });

            modelBuilder.Entity("TravelBlog.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.HasOne("TravelBlog.Models.Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelBlog.Models.PeopleExperiences", b =>
                {
                    b.HasOne("TravelBlog.Models.Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelBlog.Models.Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}