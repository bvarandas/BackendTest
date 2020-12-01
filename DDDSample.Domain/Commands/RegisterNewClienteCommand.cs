using System;
using DDDSample.Domain.Validations;


namespace DDDSample.Domain.Commands
{
    public class RegisterNewClienteCommand : ClienteCommand
    {
        public RegisterNewClienteCommand(string nome, int idade)
        {
            //ID = id;
            Nome = nome;
            Idade = idade;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
