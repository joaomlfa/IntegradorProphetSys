﻿// <auto-generated />
using System;
using IntegradorSV.DataBase.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegradorSV.Migrations
{
    [DbContext(typeof(IntegradorSuasVendasContext))]
    [Migration("20210806160227_Atualicao Salt")]
    partial class AtualicaoSalt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("IntegradorSV.Models.Usuario.UsuarioModel", b =>
                {
                    b.Property<int>("usr_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("usr_email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("usr_nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("usr_salt")
                        .HasColumnType("text");

                    b.Property<string>("usr_senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("usr_telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("usr_token_pedido_eletronico")
                        .HasColumnType("text");

                    b.Property<string>("usr_token_suasvendas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("usr_ultima_atualizacao_pedidoeletronico")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("usr_ultima_atualizacao_suasvendas")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("usr_id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}