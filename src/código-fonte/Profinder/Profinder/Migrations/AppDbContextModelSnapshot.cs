﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Profinder.Models;

#nullable disable

namespace Profinder.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Profinder.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContratacaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContratacaoId")
                        .IsUnique();

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("Profinder.Models.Contratacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetalhesPaciente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("HoraFim")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Contratacoes");
                });

            modelBuilder.Entity("Profinder.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experiencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Formacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Habilidades")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NecessidadesEspecificas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroResidencia")
                        .HasColumnType("int");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<bool>("ProcurandoCuidadorDeficiencia")
                        .HasColumnType("bit");

                    b.Property<bool>("ProcurandoCuidadorIdosos")
                        .HasColumnType("bit");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreMim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Profinder.Models.Cliente", b =>
                {
                    b.HasBaseType("Profinder.Models.Usuario");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Profinder.Models.Profissional", b =>
                {
                    b.HasBaseType("Profinder.Models.Usuario");

                    b.HasDiscriminator().HasValue("Profissional");
                });

            modelBuilder.Entity("Profinder.Models.Avaliacao", b =>
                {
                    b.HasOne("Profinder.Models.Contratacao", "Contratacao")
                        .WithOne("Avaliacao")
                        .HasForeignKey("Profinder.Models.Avaliacao", "ContratacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Profinder.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contratacao");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Profinder.Models.Contratacao", b =>
                {
                    b.HasOne("Profinder.Models.Usuario", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Profinder.Models.Usuario", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Profinder.Models.Contratacao", b =>
                {
                    b.Navigation("Avaliacao");
                });
#pragma warning restore 612, 618
        }
    }
}
