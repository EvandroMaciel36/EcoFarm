document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("search");
    const mainContent = document.getElementById("main-content");
    const resultadosContainer = document.getElementById("resultados");

    // Torna a função global
    window.buscarPorCategoria = function (categoria) {
        fetch(`/Produto/BuscarPorCategoria?categoria=${encodeURIComponent(categoria)}`)
            .then(response => response.json())
            .then(data => {
                resultadosContainer.innerHTML = ""; // Limpa os resultados anteriores

                if (data.length > 0) {
                    mainContent.classList.add("hidden"); // Esconde o conteúdo principal
                    data.forEach(produto => {
                        const card = document.createElement("div");
                        card.classList.add("produto-card");
                        card.innerHTML = `
                            <img src="/img/${produto.caminhoImagem}" alt="${produto.nome}" class="produto-img" />
                            <h3>${produto.nome}</h3>
                            <p>${produto.descricao}</p>
                            <p>Preço: R$ ${produto.preco.toFixed(2).replace(".", ",")}</p>
                            <button onclick="window.location.href='/Produto/Detalhes?id=${produto.id}'" class="btn btn-success">
                                Comprar
                            </button>
                        `;
                        resultadosContainer.appendChild(card);
                    });
                } else {
                    resultadosContainer.innerHTML = "<p>Nenhum produto encontrado nesta categoria.</p>";
                    mainContent.classList.remove("hidden"); // Mostra o conteúdo principal
                }
            })
            .catch(error => {
                console.error("Erro ao buscar produtos:", error);
                mainContent.classList.remove("hidden"); // Mostra o conteúdo principal em caso de erro
            });
    };

    // Código para busca por termo
    searchInput.addEventListener("input", function () {
        const query = this.value.trim();

        if (query.length > 0) {
            fetch(`/Produto/Buscar?termo=${encodeURIComponent(query)}`)
                .then(response => response.json())
                .then(data => {
                    resultadosContainer.innerHTML = ""; // Limpa os resultados anteriores

                    if (data.length > 0) {
                        mainContent.style.display = "none"; // Esconde o conteúdo principal
                        data.forEach(produto => {
                            const card = document.createElement("div");
                            card.classList.add("produto-card");
                            card.innerHTML = `
                                <img src="/img/${produto.caminhoImagem}" alt="${produto.nome}" class="produto-img" />
                                <h3>${produto.nome}</h3>
                                <p>${produto.descricao}</p>
                                <p>Preço: R$ ${produto.preco.toFixed(2).replace(".", ",")}</p>
                                <button onclick="window.location.href='/Produto/Detalhes?id=${produto.id}'" class="btn btn-success">
                                    Comprar
                                </button>
                            `;
                            resultadosContainer.appendChild(card);
                        });
                    } else {
                        resultadosContainer.innerHTML = "<p>Nenhum produto encontrado.</p>";
                        mainContent.style.display = "block"; // Mostra o conteúdo principal
                    }
                })
                .catch(error => {
                    console.error("Erro ao buscar produtos:", error);
                    mainContent.style.display = "block"; // Mostra o conteúdo principal em caso de erro
                });
        } else {
            resultadosContainer.innerHTML = ""; // Limpa os resultados se o campo estiver vazio
            mainContent.style.display = "block"; // Mostra o conteúdo principal
        }
    });
});
