filter('');

function filter(tipo) {
    // Alterando a visibilidade dos cards
    document.querySelectorAll('.jogo').forEach(card => {
        card.style.display = "flex";
        if (!card.classList.contains(tipo) && tipo !== '')
            card.style.display = "none";
    })

    // Verificando se existem cards
    let cardCount = 0;
    document.querySelectorAll('.jogo').forEach(card => {
        cardCount += card.style.display == "flex" ? 1 : 0;
    });
    let zeroJogo = document.querySelector('#zeroJogo');
    if (zeroJogo != null) {
        if (cardCount == 0)
            zeroJogo.classList.remove('d-none');
        else
            zeroJogo.classList.add('d-none');
    }

    // Alterando a visibilidade dos botões de filtro
    document.querySelectorAll('.btn-filter').forEach(button => {
        button.classList.add('btn-sm');
        button.classList.remove('btn-md');
        if (button.id == `btn-${tipo}`) {
            button.classList.remove('btn-sm');
            button.classList.add('btn-md');

        }
    })
}