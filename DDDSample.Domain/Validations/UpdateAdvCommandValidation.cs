using DDDSample.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Validations
{
    public class UpdateClienteCommandValidation : ClienteValidation<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidation()
        {
            ValidateIdade();
            ValidateId();
            ValidateNome();
        }
    }
}
