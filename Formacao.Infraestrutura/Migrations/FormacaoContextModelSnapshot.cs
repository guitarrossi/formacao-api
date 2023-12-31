﻿// <auto-generated />
using System;
using Formacao.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Formacao.Infraestrutura.Migrations
{
    [DbContext(typeof(FormacaoContext))]
    partial class FormacaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Formacao.Dominio.Entidades.Formacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CriadoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ExcluidoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("UltimaAlteracaoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UltimaAlteracaoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Formacao", "formacao");
                });

            modelBuilder.Entity("Formacao.Dominio.Entidades.FormacaoPessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CriadoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ExcluidoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdFormacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UltimaAlteracaoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UltimaAlteracaoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdFormacao");

                    b.HasIndex("IdPessoa");

                    b.ToTable("FormacaoPessoa", "formacao");
                });

            modelBuilder.Entity("Formacao.Dominio.Entidades.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CriadoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ExcluidoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UltimaAlteracaoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UltimaAlteracaoPorIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", "formacao");
                });

            modelBuilder.Entity("Formacao.Dominio.Entidades.FormacaoPessoa", b =>
                {
                    b.HasOne("Formacao.Dominio.Entidades.Formacao", "Formacao")
                        .WithMany("FormacaoPessoas")
                        .HasForeignKey("IdFormacao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Formacao.Dominio.Entidades.Pessoa", "Pessoa")
                        .WithMany("FormacaoPessoas")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Formacao");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Formacao.Dominio.Entidades.Formacao", b =>
                {
                    b.Navigation("FormacaoPessoas");
                });

            modelBuilder.Entity("Formacao.Dominio.Entidades.Pessoa", b =>
                {
                    b.Navigation("FormacaoPessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
