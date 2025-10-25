function Spinner() {
    // Exibir o spinner
    document.getElementById("spinner").style.display = "block";

    // Desativar o botão enquanto o spinner está ativo
    document.getElementById("btnLogin").disabled = true;

    // Simular um tempo de carregamento (remova esta parte no código final)
    setTimeout(() => {
        // Enviar o formulário após o spinner ser exibido
        document.getElementById("frmPost").submit();
    }, 3000); // Envia o formulário após 3 segundos (ajuste conforme necessário)
}
