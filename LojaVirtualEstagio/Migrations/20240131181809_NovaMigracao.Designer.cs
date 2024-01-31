﻿// <auto-generated />
using System;
using LojaVirtualEstagio.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaVirtualEstagio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240131181809_NovaMigracao")]
    partial class NovaMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Excluido = false,
                            Nome = "Sapato",
                            Url = "url_sapato"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Excluido = false,
                            Nome = "Sandalia",
                            Url = "url_sandalia"
                        });
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("UsuarioId1")
                        .IsUnique()
                        .HasFilter("[UsuarioId1] IS NOT NULL");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataPedido = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            DataPedido = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UsuarioId = 2
                        });
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.PedidoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoItems");
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            CategoriaId = 2,
                            Excluido = false,
                            Nome = "Sandalia1",
                            Quantidade = 100,
                            Url = "url_sandalia"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            CategoriaId = 2,
                            Excluido = false,
                            Nome = "Sandalia2",
                            Quantidade = 80,
                            Url = "url_sandalia"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            CategoriaId = 2,
                            Excluido = false,
                            Nome = "Sandalia3",
                            Quantidade = 50,
                            Url = "url_sandalia"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = false,
                            CategoriaId = 2,
                            Excluido = true,
                            Nome = "Sandalia4",
                            Quantidade = 50,
                            Url = "url_sandalia"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            CategoriaId = 1,
                            Excluido = false,
                            Nome = "Sapato1",
                            Quantidade = 45,
                            Url = "url_sapato"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            CategoriaId = 1,
                            Excluido = false,
                            Nome = "Sapato2",
                            Quantidade = 10,
                            Url = "url_sapato"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            CategoriaId = 1,
                            Excluido = false,
                            Nome = "Sapato3",
                            Quantidade = 30,
                            Url = "url_sapato"
                        },
                        new
                        {
                            Id = 8,
                            Ativo = false,
                            CategoriaId = 1,
                            Excluido = true,
                            Nome = "Sapato4",
                            Quantidade = 10,
                            Url = "url_sapato"
                        });
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("ChaveVerificacao")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerificado")
                        .HasColumnType("bit");

                    b.Property<string>("LastToken")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            ChaveVerificacao = "chave-unico-para-verificacao",
                            Email = "Gustavo@example.com",
                            Excluido = false,
                            IsDeleted = false,
                            IsVerificado = true,
                            LastToken = "token-unico",
                            Login = "Guga123",
                            Nome = "Gustavo",
                            Senha = "senha123"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            ChaveVerificacao = "outra-chave-unico",
                            Email = "Henrique@example.com",
                            Excluido = false,
                            IsDeleted = false,
                            IsVerificado = true,
                            LastToken = "outro-token-unico",
                            Login = "Henrique123",
                            Nome = "Henrique",
                            Senha = "senha12345"
                        });
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Pedido", b =>
                {
                    b.HasOne("LojaVirtualEstagio.Api.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LojaVirtualEstagio.Api.Entities.Usuario", null)
                        .WithOne("Pedido")
                        .HasForeignKey("LojaVirtualEstagio.Api.Entities.Pedido", "UsuarioId1");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.PedidoItem", b =>
                {
                    b.HasOne("LojaVirtualEstagio.Api.Entities.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaVirtualEstagio.Api.Entities.Produto", "Produto")
                        .WithMany("Itens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Produto", b =>
                {
                    b.HasOne("LojaVirtualEstagio.Api.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Pedido", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Produto", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("LojaVirtualEstagio.Api.Entities.Usuario", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}