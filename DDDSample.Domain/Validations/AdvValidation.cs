using System;
using DDDSample.Domain.Commands;
using FluentValidation;

namespace DDDSample.Domain.Validations
{
    public abstract class ClienteValidation<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.ID.ToString())
                .NotEmpty().WithMessage("É necessário enviar o ID com uma Guid!")
                .Length(10, 50).WithMessage("É necessário inserir ao menos 10 caracteres no guid");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("É necessário inserir o nome do cliente!")
                .Length(3, 150).WithMessage("É necessário inserir ao menos 3 caracteres no nome do cliente!"); 
        }

        protected void ValidateIdade()
        {
            RuleFor(c => c.Idade)
                .NotEqual(0)
                .WithMessage("É necessário inserir a Idade de cliente!");
        }
    }
}
