using FluentValidation;

namespace ArckDan.MayDay.Domain.Models.Acesso.Validacao
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        #region validação

        /// <summary>
        /// construtor da classe LoginModelValidator
        /// </summary>
        public LoginModelValidator()
        {
            // definição das validações
            RuleFor(x => x.ChaveUsuario)
                .NotEmpty();

            RuleFor(x => x.Senha)
                .NotEmpty();
        }

        #endregion
    }
}
