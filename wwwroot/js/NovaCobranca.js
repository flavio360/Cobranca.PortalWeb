// ============================================================
// NovaCobranca.js
// Controle de exibição e habilitação do formulário de nova cobrança
// ============================================================

document.addEventListener("DOMContentLoaded", function () {

    // Elementos principais
    const btnNova = document.querySelector("#btnCriarNovaCobranca");
    const btnCancelar = document.querySelector("#btnCancelarNova");
    const btnSalvar = document.querySelector("#btnSalvarCobranca");
    const formContainer = document.querySelector("#novaCobrancaContainer");
    const formNova = document.querySelector("#formNovaCobranca");
    const btnImportar = document.querySelector("#btnImportarCobrancas");
    const fileImport = document.querySelector("#fileImportCobrancas");

    // ============================================================
    // Função: habilitarCampos
    // ============================================================
    function habilitarCampos(enable = true) {
        const campos = formNova.querySelectorAll("input, select, textarea, button");
        campos.forEach(el => {
            if (el.id === "btnCancelarNova" || el.dataset.action === "cancelar-nova") return;
            el.disabled = !enable;
        });
        btnSalvar.disabled = !enable;
    }

    // ============================================================
    // Função: mostrar formulário
    // ============================================================
    function mostrarFormulario() {
        formContainer.classList.remove("is-hidden");
        habilitarCampos(true);
        btnNova.disabled = true;
        window.scrollTo({ top: formContainer.offsetTop, behavior: "smooth" });
    }

    // ============================================================
    // Função: ocultar formulário
    // ============================================================
    function ocultarFormulario() {
        formContainer.classList.add("is-hidden");
        habilitarCampos(false);
        btnNova.disabled = false;
        formNova.reset();
    }

    // ============================================================
    // Função: selecionar arquivo Excel (Importar)
    // ============================================================
    function acionarImportacao() {
        if (!fileImport) return;
        fileImport.click();
    }

    // ============================================================
    // Função: enviar arquivo Excel para o endpoint MVC
    // ============================================================
    async function enviarArquivoExcel(endpoint, arquivo) {
        const formData = new FormData();
        formData.append("file", arquivo);

        // adiciona o antiforgery token
        const tokenInput = document.querySelector('input[name="__RequestVerificationToken"]');
        if (tokenInput) {
            formData.append("__RequestVerificationToken", tokenInput.value);
        }

        try {
            const response = await fetch(endpoint, {
                method: "POST",
                body: formData
            });

            if (!response.ok) {
                const erro = await response.text();
                throw new Error(`Erro ${response.status}: ${erro}`);
            }

            const contentType = response.headers.get("content-type");
            if (contentType && contentType.includes("text/html")) {
                const html = await response.text();
                document.open();
                document.write(html);
                document.close();
                return;
            }

            const resultado = await response.text();
            alert(resultado || "Importação concluída!");
        } catch (erro) {
            console.error("Erro ao importar arquivo:", erro);
            alert("Falha ao enviar o arquivo para o servidor.");
        }
    }



    // ============================================================
    // Função: manipular upload e enviar
    // ============================================================
    function aoSelecionarArquivo(e) {
        const arquivo = e.target.files[0];
        if (!arquivo) return;

        console.log("Arquivo selecionado:", arquivo.name);

        const endpoint = fileImport.dataset.uploadEndpoint || "/Cobranca/ImportarArquivo";
        enviarArquivoExcel(endpoint, arquivo);
    }

    // ============================================================
    // Listeners
    // ============================================================
    if (btnNova) btnNova.addEventListener("click", mostrarFormulario);
    if (btnCancelar) btnCancelar.addEventListener("click", ocultarFormulario);
    if (btnImportar) btnImportar.addEventListener("click", acionarImportacao);
    if (fileImport) fileImport.addEventListener("change", aoSelecionarArquivo);

    // Ao iniciar, deixa tudo desabilitado
    habilitarCampos(false);
});



