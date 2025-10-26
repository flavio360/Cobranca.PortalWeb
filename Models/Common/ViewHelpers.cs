namespace Cobranca.PortalWeb.Models.Common
{
    public static  class ViewHelpers
    {
        /// <summary>
        /// Retorna o caminho da imagem correspondente ao status da cobrança.
        /// </summary>
        public static string GetStatusImage(StatusEnvioCobranca status)
        {
            return status switch
            {
                StatusEnvioCobranca.PENDENTE => "/assets/icones/icon-atencao-amarelo.png",
                StatusEnvioCobranca.ENVIADO => "/assets/icones/enviado.png",
                StatusEnvioCobranca.FALHA => "/assets/icones/icon-x-vermelho.svg",
                StatusEnvioCobranca.FINALIZADO_SUCESSO => "/assets/icones/icon-tic-verde.svg",
                StatusEnvioCobranca.RESPONDIDO_DEVEDOR => "/assets/icones/icon-back-azul.png",
                StatusEnvioCobranca.FINALIZADO_DEVEDOR => "/assets/icones/icon-prioridade-vermelho.png",
                StatusEnvioCobranca.FINALIZADO_INTERNO => "/assets/icones/icon-prioridade-vermelho.png",
                _ => "/assets/icones/default.png"
            };
        }

        /// <summary>
        /// Retorna uma descrição legível do status.
        /// </summary>
        public static string GetStatusDescricao(StatusEnvioCobranca status)
        {
            return status switch
            {
                StatusEnvioCobranca.PENDENTE => "Pendente",
                StatusEnvioCobranca.ENVIADO => "Enviado",
                StatusEnvioCobranca.FALHA => "Falha no envio",
                StatusEnvioCobranca.FINALIZADO => "Finalizado",
                StatusEnvioCobranca.RESPONDIDO_DEVEDOR => "Respondido pelo devedor",
                StatusEnvioCobranca.FINALIZADO_DEVEDOR => "Finalizado pelo devedor",
                _ => "Desconhecido"
            };
        }

        /// <summary>
        /// Retorna uma cor representativa (ex.: Bootstrap) para o status.
        /// </summary>
        public static string GetStatusCor(StatusEnvioCobranca status)
        {
            return status switch
            {
                StatusEnvioCobranca.PENDENTE => "#ffcc00", // amarelo
                StatusEnvioCobranca.ENVIADO => "#007bff", // azul
                StatusEnvioCobranca.FALHA => "#dc3545", // vermelho
                StatusEnvioCobranca.FINALIZADO => "#28a745", // verde
                StatusEnvioCobranca.RESPONDIDO_DEVEDOR => "#6f42c1", // roxo
                StatusEnvioCobranca.FINALIZADO_DEVEDOR => "#17a2b8", // ciano
                _ => "#6c757d"  // cinza
            };
        }
    }
}
