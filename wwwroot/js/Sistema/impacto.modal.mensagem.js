window.Impacto = window.Impacto || {};

Impacto.ModalMensagem = (function () {

    let redirectRoute = null;

    function abrir(data) {

        const modal = document.getElementById("modalMensagemOverlay");
        const texto = document.getElementById("modalMensagemTexto");
        const icone = document.getElementById("modalMensagemIcone");

        if (!modal) return;

        texto.textContent = data.mensagem || "";

        if (data.sucesso) {
            icone.src = "/assets/icones/CirculoOK.svg";
        } else {
            icone.src = "/assets/icones/CirculoAtencao.svg";
        }

        redirectRoute = data.route || null;

        modal.classList.add("ativo");
    }

    function fechar() {

        const modal = document.getElementById("modalMensagemOverlay");

        if (!modal) return;

        modal.classList.remove("ativo");

        if (redirectRoute) {
            window.location.href = redirectRoute;
        }
    }

    function bind() {

        const btn = document.getElementById("modalMensagemBtnOk");

        if (!btn) return;

        btn.addEventListener("click", fechar);
    }

    document.addEventListener("DOMContentLoaded", bind);

    return {
        abrir
    };

})();



// ===============================
// FORM AJAX GLOBAL
// ===============================

document.addEventListener("submit", async function (e) {

    const form = e.target;

    if (!form.classList.contains("impacto-form-ajax"))
        return;

    e.preventDefault();

    try {

        const response = await fetch(form.action, {
            method: form.method || "POST",
            body: new FormData(form),
            headers: {
                "X-Requested-With": "XMLHttpRequest"
            }
        });

        // Verifica erro HTTP
        if (!response.ok) {
            throw new Error("Erro na requisição");
        }

        const data = await response.json();

        Impacto.ModalMensagem.abrir(data);

    }
    catch (error) {

        Impacto.ModalMensagem.abrir({
            sucesso: false,
            mensagem: "Erro inesperado ao processar requisição."
        });

    }

});