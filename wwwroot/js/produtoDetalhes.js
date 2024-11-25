document.addEventListener("DOMContentLoaded", function () {
    const adicionarCarrinhoBtn = document.getElementById("adicionarCarrinho");

    adicionarCarrinhoBtn.addEventListener("click", function () {
        const id = this.getAttribute("data-id");
        const nome = this.getAttribute("data-nome");
        const preco = parseFloat(this.getAttribute("data-preco"));
        const quantidadeInput = document.getElementById("quantidade");
        const quantidade = parseInt(quantidadeInput.value, 10);

        // Valida a quantidade antes de enviar
        if (isNaN(quantidade) || quantidade <= 0) {
            alert("Por favor, insira uma quantidade válida maior que zero.");
            return;
        }

        // Envia os dados para o backend
        fetch("/Carrinho/AdicionarAoCarrinho", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                id: id,
                nome: nome,
                preco: preco,
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
