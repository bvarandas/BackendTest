using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDSample.Domain.Models
{
    [Table("tb_Cliente")]
    public class Cliente : Entity
    {
        
        public Cliente(Guid id, string nome, int idade)
        {
            ID = id;
            Nome = nome;
            Idade = idade;
        }

        public Cliente(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        // Entity framework
        protected Cliente() { }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid  ID { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }
        
    }
}
