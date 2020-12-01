using System;
using DDDSample.Domain.Validations;

namespace DDDSample.Domain.Commands
{
    public class UpdateClienteCommand : ClienteCommand
    {
        public UpdateClienteCommand(Guid id, string nome, int idade)
        {
            ID = id;
            Nome = nome;
            Idade = idade;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
