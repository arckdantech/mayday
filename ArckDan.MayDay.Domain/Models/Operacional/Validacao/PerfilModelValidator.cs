using FluentValidation;

namespace ArckDan.MayDay.Domain.Models.Operacional.Validacao
{
    public class PerfilModelValidator : AbstractValidator<PerfilModel>
    {
        #region validações

        /// <summary>
        /// construtor da classe PerfilModelValidator
        /// </summary>
        public PerfilModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty();
        }

        #endregion
    }
}
