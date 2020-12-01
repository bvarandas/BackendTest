using DDDSample.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Validations
{
    public class RegisterNewClienteCommandValidation: ClienteValidation<RegisterNewClienteCommand>
    {
        public RegisterNewClienteCommandValidation()
        {
            ValidateIdade();
            ValidateNome();
            ValidateId();
        }
    }
}
