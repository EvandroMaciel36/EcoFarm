document.addEventListener("DOMContentLoaded", function () {
    // Atualiza a quantidade de um item no carrinho
    document.querySelectorAll(".quantidade-input").forEach(input => {
        input.addEventListener("change", function () {
            const id = this.getAttribute("data-id");
            const quantidade = parseInt(this.value, 10);

            // Validação de entrada
            if (isNaN(quantidade) || quantidade <= 0) {
                alert("Por favor, insira uma quantidade válida maior que zero.");
                this.value = 1; // Restaura o valor para 1 em caso de erro
                return;
            }

            // Atualiza a quantidade no backend
            fetch("/Carrinho/AtualizarQuantidade", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ id, quantidade })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.sucesso) {
                        // Atualiza o total do item na tabela
                        const totalItem = this.closest("tr").querySelector(".total-item");
                        totalItem.textContent = `R$ ${data.totalItem.toFixed(2).replace(".", ",")}`;

                        // Atualiza o total geral do carrinho
                        atualizarTotalGeral();
                    } else {
                        alert(data.mensagem || "Erro ao atualizar a quantidade.");
                    }
                })
                .catch(error => {
                    console.error("Erro:", error);
                    alert("Erro ao atualizar a quantidade do item.");
                });
        });
    });

    // Remove um item do carrinho
    document.querySelectorAll(".remover-item").forEach(button => {
        button.addEventListener("click", function () {
            const id = this.getAttribute("data-id");

            fetch("/Carrinho/RemoverItem", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ id })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.sucesso) {
                        // Remove a linha do item
                        this.closest("tr").remove();

                        // Atualiza o total geral do carrinho
                        atualizarTotalGeral();
                    } else {
                        alert(data.mensagem || "Erro ao remover item.");
                    }
                })
                .catch(error => {
                    console.error("Erro:", error);
                    alert("Erro ao remover o item do carrinho.");
                });
        });
    });

    // Função para atualizar o total geral do carrinho
    function atualizarTotalGeral() {
        const totalGeral = Array.from(document.querySelectorAll(".total-item"))
            .reduce((acc, item) => acc + parseFloat(item.textContent.replace(",", ".")), 0);

        document.getElementById("total-geral").textContent = `R$ ${totalGeral.toFixed(2).replace(".", ",")}`;
    }
});
