using FluentValidation;

namespace ArckDan.MayDay.Domain.Models.Acesso.Validacao
{
    public class SenhaModelValidator : AbstractValidator<SenhaModel>
    {
        #region validação

        /// <summary>
        /// construtor da classe SenhaModelValidator
        /// </summary>
        public SenhaModelValidator()
        {
            // definição das validações
            RuleFor(x => x.IdLogin)
                .NotEmpty();

            RuleFor(x => x.Chave)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(10);
        }

        #endregion
    }
}
