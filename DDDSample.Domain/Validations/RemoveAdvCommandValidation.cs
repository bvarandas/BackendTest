using DDDSample.Domain.Commands;

namespace DDDSample.Domain.Validations
{
    public class RemoveClienteCommandValidation : ClienteValidation<RemoveClienteCommand>
    {
        public RemoveClienteCommandValidation()
        {
            ValidateId();
        }
    }
}
