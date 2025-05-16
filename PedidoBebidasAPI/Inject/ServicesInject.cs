using PedidoBebidas.Aplicacao.Interfaces;
using PedidoBebidas.Aplicacao.Services;
using PedidoBebidas.Infraestrutura.Interfaces;
using PedidoBebidas.Infraestrutura.Repositorios;

namespace PedidoBebidasAPI
{
    public static class ServicesInject
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddScoped<IRevendaRepository, RevendaRepository>();
            services.AddScoped<IRevendaService, RevendaService>();

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddScoped<IEmissaoRepository, EmissaoRepository>();
            services.AddScoped<IEmissaoService, EmissaoService>();

            services.AddScoped<IEmissaoTentativaEnvioRepository, EmissaoTentativaEnvioRepository>();
        }
    }
}
