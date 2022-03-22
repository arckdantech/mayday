using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Command.Acesso;
using ArckDan.MayDay.Repositorio.Command.Operacional;
using ArckDan.MayDay.Repositorio.Command.Relacional;
using ArckDan.MayDay.Repositorio.Context;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Repositorio.Query.Acesso;
using ArckDan.MayDay.Repositorio.Query.Cadastro;
using ArckDan.MayDay.Repositorio.Query.Operacional;
using ArckDan.MayDay.Repositorio.Query.Relacional;
using ArckDan.MayDay.Servico.Command.Acesso;
using ArckDan.MayDay.Servico.Command.Operacional;
using ArckDan.MayDay.Servico.Command.Relacional;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models.Acesso;
using ArckDan.MayDay.WebApi.Models.Operacional;
using ArckDan.MayDay.WebApi.Models.Relacional;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace ArckDan.MayDay.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication
                 (JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,

                         ValidIssuer = _configuration["Jwt:Issuer"],
                         ValidAudience = _configuration["Jwt:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey
                         (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                     };
                 });

            services.AddControllers();
            services.AddSingleton<IConfiguration>(_configuration);
            services.AddSingleton<MayDayContext, MayDayContext>();

            // --> Fluent Validation            

            //--> Acesso

            // Json Web Token
            services.AddTransient<ICommandHandler<TokenModel>, TokenServico>();
            services.AddTransient<ICommand<TokenModel>, TokenCommand>();
            services.AddTransient<IQuery<TokenModel>, TokenQuery>();

            // login
            services.AddTransient<ICommandHandler<LoginModel>, LoginServico>();
            services.AddTransient<ICommand<LoginModel>, LoginCommand>();
            services.AddTransient<IQuery<LoginModel>, LoginQuery>();

            // senhas
            services.AddTransient<ICommandHandler<SenhaModel>, SenhaServico>();
            services.AddTransient<ICommand<SenhaModel>, SenhaCommand>();
            services.AddTransient<IQuery<SenhaModel>, SenhaQuery>();
            
            //--> Operacional

            // perfil
            services.AddTransient<ICommandHandler<PerfilModel>, PerfilServico>();
            services.AddTransient<ICommand<PerfilModel>, PerfilCommand>();
            services.AddTransient<IQuery<PerfilModel>, PerfilQuery>();

            // campo
            services.AddTransient<ICommandHandler<CampoModel>, CampoServico>();
            services.AddTransient<ICommand<CampoModel>, CampoCommand>();
            services.AddTransient<IQuery<CampoModel>, CampoQuery>();

            // usuários
            services.AddTransient<ICommandHandler<UsuarioModel>, UsuarioServico>();
            services.AddTransient<ICommand<UsuarioModel>, UsuarioCommand>();
            services.AddTransient<IQuery<UsuarioModel>, UsuarioQuery>();

            // endereço
            services.AddTransient<ICommandHandler<EnderecoModel>, EnderecoServico>();
            services.AddTransient<ICommand<EnderecoModel>, EnderecoCommand>();
            services.AddTransient<IQuery<EnderecoModel>, EnderecoQuery>();

            // cadastros
            services.AddTransient<ICommandHandler<CadastroSistemaModel>, CadastroSistemaServico>();
            services.AddTransient<ICommand<CadastroSistemaModel>, CadastroSistemaCommand>();
            services.AddTransient<IQuery<CadastroSistemaModel>, CadastroSistemaQuery>();

            // formulários
            services.AddTransient<ICommandHandler<FormularioModel>, FormularioServico>();
            services.AddTransient<ICommand<FormularioModel>, FormularioCommand>();
            services.AddTransient<IQuery<FormularioModel>, FormularioQuery>();

            //--> Operacional

            // formulário campo
            services.AddTransient<ICommandHandler<FormularioCampoModel>, FormularioCampoServico>();
            services.AddTransient<ICommand<FormularioCampoModel>, FormularioCampoCommand>();
            services.AddTransient<IQuery<FormularioCampoModel>, FormularioCampoQuery>();

            // automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PerfilViewModel, PerfilModel>().ReverseMap();
                cfg.CreateMap<LoginViewModel, LoginModel>().ReverseMap();
                cfg.CreateMap<SenhaViewModel, SenhaModel>().ReverseMap();
                cfg.CreateMap<CampoViewModel, CampoModel>().ReverseMap();
                cfg.CreateMap<FormularioViewModel, FormularioModel>().ReverseMap();
                cfg.CreateMap<FormularioCampoViewModel, FormularioCampoModel>().ReverseMap();
                cfg.CreateMap<CadastroSistemaViewModel, CadastroSistemaModel>().ReverseMap();
                cfg.CreateMap<UsuarioViewModel, UsuarioModel>().ReverseMap();
                cfg.CreateMap<EnderecoViewModel, EnderecoModel>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // configuração do swagger
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // configuração do swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MayDay");
            });
        }
    }
}