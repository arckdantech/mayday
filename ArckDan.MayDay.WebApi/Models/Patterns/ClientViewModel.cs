using ArckDan.MayDay.WebApi.Models.Operacional;
using ArckDan.MayDay.WebApi.Models.PatternObjectFactory.Factory.Abstract;
using ArckDan.MayDay.WebApi.Models.PatternObjectFactory.Product.Abstract;
using ArckDan.MayDay.WebApi.Models.PatternObjectFactory.Product.Concrete;
using ArckDan.MayDay.WebApi.Utils.Enums;
using System.Collections.Generic;

namespace ArckDan.MayDay.WebApi.Models.PatternObjectFactory
{
    public class ClientViewModel
    {
        #region atributos

        IProdutoViewModel<UsuarioViewModel> _produtoUsuario;

        #endregion

        #region construtores

        public ClientViewModel() { }

        #endregion
    }
}
