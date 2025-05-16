using AutoMapper;
using PedidoBebidas.Aplicacao.DTOs;
using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Aplicacao.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Revenda, RevendaDTO_In>().ReverseMap();
            CreateMap<Revenda, RevendaDTO_Out>().ReverseMap();
            CreateMap<Revenda, Revenda>().ReverseMap();

            CreateMap<Telefone, TelefoneDTO_In>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO_Out>().ReverseMap();
            CreateMap<Telefone, Telefone>().ReverseMap();

            CreateMap<Contato, ContatoDTO_In>().ReverseMap();
            CreateMap<Contato, ContatoDTO_Out>().ReverseMap();
            CreateMap<Contato, Contato>().ReverseMap();

            CreateMap<EnderecoEntrega, EnderecoEntregaDTO_In>().ReverseMap();
            CreateMap<EnderecoEntrega, EnderecoEntregaDTO_Out>().ReverseMap();
            CreateMap<EnderecoEntrega, EnderecoEntrega>().ReverseMap();

            CreateMap<Pedido, PedidoDTO_In>().ReverseMap();
            CreateMap<Pedido, PedidoDTO_Out>().ReverseMap();
            CreateMap<Pedido, Pedido>().ForMember(dest => dest.Identificador, opt => opt.Ignore());

            CreateMap<PedidoProduto, PedidoProdutoDTO_In>().ReverseMap();
            CreateMap<PedidoProduto, PedidoProdutoDTO_Out>().ReverseMap();
            CreateMap<PedidoProduto, PedidoProduto>().ReverseMap();

            CreateMap<Emissao, EmissaoDTO_In>().ReverseMap();
            CreateMap<Emissao, EmissaoDTO_Out>().ReverseMap();
            CreateMap<Emissao, Emissao>().ReverseMap();

            CreateMap<Emissao, EmissaoDTO_In>().ReverseMap();
            CreateMap<Emissao, EmissaoDTO_Out>().ReverseMap();
            CreateMap<Emissao, Emissao>().ReverseMap();

            CreateMap<EmissaoPedido, EmissaoPedidoDTO_In>().ReverseMap();
            CreateMap<EmissaoPedido, EmissaoPedidoDTO_Out>().ReverseMap();
            CreateMap<EmissaoPedido, EmissaoPedido>().ReverseMap();

            CreateMap<EmissaoTentativaEnvio, EmissaoTentativaEnvioDTO_Out>().ReverseMap();
            CreateMap<EmissaoTentativaEnvio, EmissaoTentativaEnvio>().ReverseMap();
        }
    }
}