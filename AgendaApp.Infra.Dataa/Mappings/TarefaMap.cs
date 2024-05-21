using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Mappings
{
    internal class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.DataHora)
                .HasColumnName("DATAHORA")
                .IsRequired();

            builder.Property(t => t.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .IsRequired();

            builder.Property(t => t.DataHoraUltimaAtualizacao)
                .HasColumnName("DATAHORAULTIMAATUALIZACAO")
                .IsRequired();


            builder.Property(t => t.Prioridade)
                .HasColumnName("PRIORIDADE")
                .IsRequired()
                .HasConversion<int>();


        }
    }
}
