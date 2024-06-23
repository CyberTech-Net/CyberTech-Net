﻿// <auto-generated />
using System;
using CyberTech.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CyberTech.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CyberTech.Domain.Entities.CountryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("MongoCountryPic")
                        .HasColumnType("int");

                    b.Property<string>("TitleCountry")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.GameTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("MongoGameTypePic")
                        .HasColumnType("int");

                    b.Property<string>("TitleGame")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.InfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInfo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<int?>("MongoInfoPic")
                        .HasColumnType("int");

                    b.Property<int?>("MongoInfoVideo")
                        .HasColumnType("int");

                    b.Property<string>("TextInfo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TitleInfo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("InfoList");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.PlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MongoPlayerPic")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TitleRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Founded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<string>("TitleTeam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TeamPlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year1")
                        .HasColumnType("int");

                    b.Property<int?>("Year2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataTournamentEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataTournamentInit")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EarndTournament")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasDefaultValue(0m);

                    b.Property<Guid>("GameTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("MongoChat")
                        .HasColumnType("int");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TitleTournament")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TypeTournament")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("GameTypeId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentMeetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataTournamentMeet")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentMeets");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentMeetTeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("EarndTeam")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("RatingTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ScoreTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TournamentMeetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Win")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentMeetId");

                    b.ToTable("TournamentMeetTeams");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.UserEntity", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Login");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.PlayerEntity", b =>
                {
                    b.HasOne("CyberTech.Domain.Entities.CountryEntity", "Country")
                        .WithMany("Players")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TeamPlayerEntity", b =>
                {
                    b.HasOne("CyberTech.Domain.Entities.PlayerEntity", "Player")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CyberTech.Domain.Entities.TeamEntity", "Team")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentEntity", b =>
                {
                    b.HasOne("CyberTech.Domain.Entities.GameTypeEntity", "GameType")
                        .WithMany("Tournaments")
                        .HasForeignKey("GameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameType");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentMeetEntity", b =>
                {
                    b.HasOne("CyberTech.Domain.Entities.TournamentEntity", "Tournament")
                        .WithMany("TournamentMeets")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentMeetTeamEntity", b =>
                {
                    b.HasOne("CyberTech.Domain.Entities.TeamEntity", "Team")
                        .WithMany("TournamentMeetTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CyberTech.Domain.Entities.TournamentMeetEntity", "TournamentMeet")
                        .WithMany("TournamentMeetTeams")
                        .HasForeignKey("TournamentMeetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("TournamentMeet");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("CyberTech.Domain.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.CountryEntity", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.GameTypeEntity", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.PlayerEntity", b =>
                {
                    b.Navigation("TeamPlayers");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TeamEntity", b =>
                {
                    b.Navigation("TeamPlayers");

                    b.Navigation("TournamentMeetTeams");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentEntity", b =>
                {
                    b.Navigation("TournamentMeets");
                });

            modelBuilder.Entity("CyberTech.Domain.Entities.TournamentMeetEntity", b =>
                {
                    b.Navigation("TournamentMeetTeams");
                });
#pragma warning restore 612, 618
        }
    }
}
