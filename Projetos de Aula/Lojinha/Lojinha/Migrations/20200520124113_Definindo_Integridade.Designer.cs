﻿// <auto-generated />
using System;
using Lojinha.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lojinha.Migrations
{
    [DbContext(typeof(LojinhaContext))]
    [Migration("20200520124113_Definindo_Integridade")]
    partial class Definindo_Integridade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lojinha.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Lojinha.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Altura");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Lojinha.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.Property<double>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Lojinha.Models.Produto", b =>
                {
                    b.HasOne("Lojinha.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}