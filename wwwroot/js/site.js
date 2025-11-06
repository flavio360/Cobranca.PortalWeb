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


document.addEventListener('click', function (e) {
    const clicouEmIcone = e.target.closest('[data-sidebar-target]');
    const clicouNoDrawer = e.target.closest('.re_sidebar-drawer');
    if (!clicouEmIcone && !clicouNoDrawer) { fecharSidebars(); }

