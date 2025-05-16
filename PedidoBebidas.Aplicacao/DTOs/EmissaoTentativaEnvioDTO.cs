namespace PedidoBebidas.Aplicacao.DTOs
{
    public class EmissaoTentativaEnvioDTO_Out : BaseDTO
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}