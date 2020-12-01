using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample.Domain.Models;

namespace DDDSample.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.ID)
                //.HasColumnType("SqlGuid")
                .HasColumnName("ID").
                ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(45)
                .IsRequired();

            //builder.Property(c => c.Modelo)
            //    .HasColumnType("varchar(45)")
            //    .HasMaxLength(45)
            //    .IsRequired();

            //builder.Property(c => c.Versao)
            //    .HasColumnType("varchar(45)")
            //    .HasMaxLength(45)
            //    .IsRequired();

            builder.Property(c => c.Idade)
                .HasColumnType("int")
                .IsRequired();

            //builder.Property(c => c.Quilometragem)
            //    .HasColumnType("int")
            //    .IsRequired();

            //builder.Property(c => c.Observacao)
            //    .HasColumnType("text")
            //    .HasMaxLength(450)
            //    .IsRequired();
                
        }
    }
}
