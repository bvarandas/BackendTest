using System;
using DDDSample.Domain.Validations;

namespace DDDSample.Domain.Commands
{
    public class RemoveClienteCommand : ClienteCommand
    {
        public RemoveClienteCommand(Guid id)
        {
            ID = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
