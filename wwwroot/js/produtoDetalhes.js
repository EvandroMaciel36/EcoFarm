document.addEventListener("DOMContentLoaded", function () {
    const quantidadeInput = document.getElementById("quantidade");
    const totalSpan = document.getElementById("total");
    const precoUnitario = parseFloat(document.getElementById("adicionarCarrinho").getAttribute("data-preco"));

    // Atualiza o total ao alterar a quantidade
    quantidadeInput.addEventListener("input", function () {
        const quantidade = parseInt(this.value, 10); // Quantidade inserida pelo usuário

        if (!isNaN(quantidade) && quantidade > 0) {
            const total = precoUnitario * quantidade; // Calcula o total
            totalSpan.textContent = total.toFixed(2).replace(".", ","); // Atualiza o total no HTML
        } else {
            totalSpan.textContent = precoUnitario.toFixed(2).replace(".", ","); // Preço unitário como padrão
        }
    });

    // Evento de adicionar ao carrinho
    const adicionarCarrinhoBtn = document.getElementById("adicionarCarrinho");
    adicionarCarrinhoBtn.addEventListener("click", function () {
        const id = this.getAttribute("data-id");
        const nome = this.getAttribute("data-nome");
        const quantidade = parseInt(quantidadeInput.value, 10);

        if (isNaN(quantidade) || quantidade <= 0) {
            alert("Por favor, insira uma quantidade válida maior que zero.");
            return;
        }

        fetch("/Carrinho/AdicionarAoCarrinho", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                Id_produto: id,
                nome: nome,
                preco: precoUnitario,
                quantidade: quantidade,
            }),
        })
            .then(response => response.json())
            .then(data => {
                if (data.sucesso) {
                    alert(data.mensagem);
                } else {
                    alert(data.mensagem || "Erro ao adicionar ao carrinho.");
                }
            })
            .catch(error => {
                console.error("Erro:", error);
                alert("Erro ao processar a solicitação.");
            });
    });
});
