function nextPage(currentPage) {
    if (currentPage < 3) {
        currentPage++;
        showPage(currentPage);
    }
}

function prevPage(currentPage) {
    if (currentPage > 1) {
        currentPage--;
        showPage(currentPage);
    }
}

function showPage(pageNumber) {
    const pages = document.querySelectorAll('.page');

    pages.forEach(page => {
        page.style.display = 'none';
    });

    const currentPage = document.getElementById(`page${pageNumber}`);
    if (currentPage) {
        currentPage.style.display = 'block';
    } else {
        console.warn(`Elemento page${pageNumber} não encontrado`);
    }
}


document.addEventListener("submit", async function (e) {

    const form = e.target;

    if (form.id !== "formNovaEmpresa")
        return;

    e.preventDefault();

    const response = await fetch(form.action, {
        method: "POST",
        body: new FormData(form)
    });

    const data = await response.json();

    Impacto.ModalMensagem.abrir(data);

});



