﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestionSee.DB;

namespace QuestionSee.Migrations
{
    [DbContext(typeof(DBConnection))]
    [Migration("20190516161427_Update-Databse")]
    partial class UpdateDatabse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuestionSee.DB.Answer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerText");

                    b.Property<bool>("BestAnswer");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<int>("Dislike");

                    b.Property<int>("Like");

                    b.Property<string>("Picture");

                    b.Property<int>("QuestionId");

                    b.Property<int>("Rating");

                    b.Property<int>("UserId");

                    b.HasKey("id");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuestionSee.DB.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Answered");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<int>("Dislike");

                    b.Property<string>("Header");

                    b.Property<int>("Like");

                    b.Property<int>("Rating");

                    b.Property<string>("Tag");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuestionSee.DB.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Admin");

                    b.Property<int>("Answered");

                    b.Property<int>("Asked");

                    b.Property<bool>("Banned");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Nickname");

                    b.Property<string>("Password");

                    b.Property<string>("ProfilePicture");

                    b.Property<int>("Rating");

                    b.Property<string>("SecondName");

                    b.Property<bool>("Status");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
