﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rockaway.WebApp.Data;

#nullable disable

namespace Rockaway.WebApp.Migrations
{
    [DbContext(typeof(RockawayDbContext))]
    partial class RockawayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("IdentityRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityRoleClaim<string>", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("IdentityUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f0b13a58-0c1f-4466-b423-e58d7ca23bfd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "13c3a901-b3ef-4087-99bd-4838697f012d",
                            Email = "admin@rockaway.dev",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ROCKAWAY.DEV",
                            NormalizedUserName = "ADMIN@ROCKAWAY.DEV",
                            PasswordHash = "AQAAAAIAAYagAAAAECGG+Toa0zUk4MKymWLqGexZpAVx/jjWNP4hqqnNPCUKUhYUgo1Wpe0NlxJ26MiBgA==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "fe4ba7a6-7089-497d-a684-80bb5f8e19d1",
                            TwoFactorEnabled = false,
                            UserName = "admin@rockaway.dev"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserClaim<string>", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserLogin<string>", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityUserRole<string>", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("IdentityUserToken<string>", (string)null);
                });

            modelBuilder.Entity("Rockaway.WebApp.Data.Entities.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Artist", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
                            Description = "Alter Column are South Africa's hottest math rock export. Founded in Cape Town in 2021, their debut album \"Drop Table Mountain\" was nominated for four Grammy awards.",
                            Name = "Alter Column",
                            Slug = "alter-column"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),
                            Description = "Speed metal pioneers from San Francisco, <Body>Bag helped define the “web rock” sound in the early 2020s.",
                            Name = "<Body>Bag",
                            Slug = "body-bag"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"),
                            Description = "Hailing from a distant future, Coda is a time-traveling rock band known for their mind-bending melodies that transport audiences through different eras, merging past and future into a harmonious blend of sound.",
                            Name = "Coda",
                            Slug = "coda"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
                            Description = "Rising from the ashes of adversity, Dev Leppard is a fiercely talented rock band that overcame obstacles with sheer determination, captivating fans worldwide with their electrifying performances and showcasing a bond that empowers their music.",
                            Name = "Dev Leppard",
                            Slug = "dev-leppard"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"),
                            Description = "Merging the realms of art and emotion, Электроника is an introspective rock group, infusing their hauntingly beautiful lyrics with mesmerizing melodies that delve into the depths of human existence, leaving listeners immersed in profound reflections.",
                            Name = "Электроника",
                            Slug = "elektronika"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa6"),
                            Description = "With an otherworldly allure, For Ear Transform is an ethereal rock ensemble, their music transcends reality, leading listeners on a dreamlike journey where celestial harmonies and ethereal instrumentation create a captivating and transformative experience.",
                            Name = "For Ear Transform",
                            Slug = "for-ear-transform"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa7"),
                            Description = "Rebel rockers with a cause, Garbage Collectors are raw, raucous and unapologetic, fearlessly tackling social issues and societal norms in their music, energizing crowds with their powerful anthems and unyielding spirit.",
                            Name = "Garbage Collectors",
                            Slug = "garbage-collectors"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa8"),
                            Description = "Virtuosos of rhythm and harmony, Haskell’s Angels radiate a divine aura, blending complex melodies and celestial harmonies that resonate deep within the soul.",
                            Name = "Haskell’s Angels",
                            Slug = "haskells-angels"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9"),
                            Description = "A force to be reckoned with, Iron Median are known for their thunderous beats and adrenaline-pumping anthems, electrifying audiences with their commanding stage presence and unstoppable energy.",
                            Name = "Iron Median",
                            Slug = "iron-median"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"),
                            Description = "Enigmatic and mysterious, Java’s Crypt are shrouded in secrecy, their enigmatic melodies and cryptic lyrics take listeners on a thrilling journey through the unknown realms of music.",
                            Name = "Java’s Crypt",
                            Slug = "javas-crypt"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa11"),
                            Description = "An electrifying whirlwind, Killer Bite unleash a torrent of energy through their performances, captivating audiences with their explosive riffs and heart-pounding rhythms.",
                            Name = "Killer Bite",
                            Slug = "killer-bite"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa12"),
                            Description = "Pioneers of progressive rock, Lambda of God is an innovative band that pushes the boundaries of musical expression, combining intricate compositions and thought-provoking lyrics that resonate deeply with their dedicated fanbase.",
                            Name = "Lambda of God",
                            Slug = "lambda-of-god"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa14"),
                            Description = "A charismatic ensemble, Mott the Tuple blends vintage charm with a modern edge, creating a unique sound that captivates audiences and takes them on a nostalgic journey through time.",
                            Name = "Mott the Tuple",
                            Slug = "mott-the-tuple"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa13"),
                            Description = "Quirky and witty, the Null Terminated String Band is a rock group that weaves clever humor and geeky references into their catchy tunes, bringing a smile to the faces of both tech enthusiasts and music lovers alike.",
                            Name = "Null Terminated String Band",
                            Slug = "null-terminated-string-band"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa15"),
                            Description = "Overflowing with passion and intensity, Överflow is a rock band that immerses listeners in a tsunami of sound, exploring emotions through powerful melodies and soul-stirring performances.",
                            Name = "Överflow",
                            Slug = "overflow"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa16"),
                            Description = "Philosophers of rock, Pascal’s Wager delves into existential themes with their intellectually charged songs, prompting listeners to ponder the profound questions of life and purpose.",
                            Name = "Pascal’s Wager",
                            Slug = "pascals-wager"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa17"),
                            Description = "Futuristic and avant-garde, Qüantum Gäte defy conventions, using experimental sounds and innovative compositions to transport listeners to other dimensions of music.",
                            Name = "Qüantum Gäte",
                            Slug = "quantum-gate"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa18"),
                            Description = "High-energy and rebellious, Run CMD is a rock band that merges technology themes with headbanging-worthy tunes, igniting the stage with their electrifying presence and infectious enthusiasm.",
                            Name = "Run CMD",
                            Slug = "run-cmd"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa19"),
                            Description = "Mischievous and bold, <Script>Kiddies subvert expectations with clever musical pranks, weaving clever wordplay and tongue-in-cheek humor into their audacious performances.",
                            Name = "<Script>Kiddies",
                            Slug = "script-kiddies"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa20"),
                            Description = "Masters of atmosphere, Terrorform’s dark and atmospheric rock ensembles conjure hauntingly beautiful soundscapes that captivate the senses and evoke a deep emotional response.",
                            Name = "Terrorform",
                            Slug = "terrorform"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa21"),
                            Description = "ᵾnɨȼøđɇɍ harmonize complex equations and melodies, weaving a symphony of logic and emotion in their unique and captivating music.",
                            Name = "ᵾnɨȼøđɇɍ",
                            Slug = "unicoder"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa22"),
                            Description = "Bridging reality and virtuality, Virtual Machine is a surreal rock group that blurs the lines between the tangible and the digital, creating mind-bending performances that leave audiences questioning the nature of existence.",
                            Name = "Virtual Machine",
                            Slug = "virtual-machine"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa23"),
                            Description = "Technologically savvy and creatively ambitious, Webmaster of Puppets is a web-inspired rock band, crafting narratives of digital dominance and manipulation with their inventive music.",
                            Name = "Webmaster of Puppets",
                            Slug = "webmaster-of-puppets"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa24"),
                            Description = "Mesmerizing and genre-defying, XSLTE is an enchanting rock ensemble that fuses electronic and rock elements, creating a spellbinding sound that enthralls listeners and transports them to MakeArtist sonic landscapes.",
                            Name = "XSLTE",
                            Slug = "xslte"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa25"),
                            Description = "Youthful and exuberant, YAMB spreads positivity and infectious energy through their music, connecting with fans through their youthful spirit and heartwarming performances.",
                            Name = "YAMB",
                            Slug = "yamb"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa26"),
                            Description = "Innovative and exploratory, Zero Based Index starts from scratch, building powerful narratives through their dynamic sound, leaving audiences inspired and moved by their expressive and daring music.",
                            Name = "Zero Based Index",
                            Slug = "zero-based-index"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa27"),
                            Description = "Inspired by their Australian namesakes, Ærbårn are Scandinavia's #1 party rock band. Thundering drums, huge guitar riffs and enough energy to light up the Arctic Circle, their shows have had amazing reviews all over the world",
                            Name = "Ærbårn",
                            Slug = "aerbaarn"
                        });
                });

            modelBuilder.Entity("Rockaway.WebApp.Data.Entities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Venue", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
                            Address = "Town Hall Parade",
                            City = "London",
                            CountryCode = "GB",
                            Name = "Electric Brixton",
                            PostalCode = "SW2 1RJ",
                            Slug = "electric-brixton",
                            Telephone = "020 7274 2290",
                            WebsiteUrl = "https://www.electricbrixton.uk.com/"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"),
                            Address = "50 Boulevard Voltaire",
                            City = "Paris",
                            CountryCode = "FR",
                            Name = "Bataclan",
                            PostalCode = "75011",
                            Slug = "bataclan-paris",
                            Telephone = "+33 1 43 14 00 30",
                            WebsiteUrl = "https://www.bataclan.fr/"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"),
                            Address = "Columbiadamm 9 - 11",
                            City = "Berlin",
                            CountryCode = "DE",
                            Name = "Columbia Theatre",
                            PostalCode = "10965",
                            Slug = "columbia-berlin",
                            Telephone = "+49 30 69817584",
                            WebsiteUrl = "https://columbia-theater.de/"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"),
                            Address = "Liosion 205",
                            City = "Athens",
                            CountryCode = "GR",
                            Name = "Gagarin 205",
                            PostalCode = "104 45",
                            Slug = "gagarin-athens",
                            Telephone = "+45 35 35 50 69",
                            WebsiteUrl = ""
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"),
                            Address = "Torggata 16",
                            City = "Oslo",
                            CountryCode = "NO",
                            Name = "John Dee Live Club & Pub",
                            PostalCode = "0181",
                            Slug = "john-dee-oslo",
                            Telephone = "+47 22 20 32 32",
                            WebsiteUrl = "https://www.rockefeller.no/"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"),
                            Address = "stengade-copenhagen",
                            City = "Copenhagen",
                            CountryCode = "DK",
                            Name = "Stengade",
                            PostalCode = "2200",
                            Slug = "Stengade 18",
                            Telephone = "+45 35355069",
                            WebsiteUrl = "https://www.stengade.dk"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"),
                            Address = "R da Madeira 186",
                            City = "Porto",
                            CountryCode = "PT",
                            Name = "Barracuda",
                            PostalCode = "4000-433",
                            Slug = "barracuda-porto"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"),
                            Address = "Sveavägen 90",
                            City = "Stockholm",
                            CountryCode = "SE",
                            Name = "Pub Anchor",
                            PostalCode = "113 59",
                            Slug = "pub-anchor-stockholm",
                            Telephone = "+46 8 15 20 00",
                            WebsiteUrl = "https://www.instagram.com/pubanchor/?hl=en"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"),
                            Address = "323 New Cross Road",
                            City = "London",
                            CountryCode = "GB",
                            Name = "New Cross Inn",
                            PostalCode = "SE14 6AS",
                            Slug = "new-cross-inn-london",
                            Telephone = "+44 20 8469 4382",
                            WebsiteUrl = "https://www.newcrossinn.com/"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
