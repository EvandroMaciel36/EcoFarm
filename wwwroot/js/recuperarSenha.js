document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector(".form-cadastro");

    console.log("DOM carregado, formulário localizado:", form);

    form.addEventListener("submit", function (event) {
        event.preventDefault();

        const nomeUsuario = document.getElementById("nomeUsuario").value.trim();
        const email = document.getElementById("email").value.trim();
        const novaSenha = document.getElementById("novaSenha").value.trim();

        console.log("Dados capturados do formulário:", { nomeUsuario, email, novaSenha });

        if (!nomeUsuario || !email || !novaSenha || novaSenha.length < 8) {
            console.log("Erro: Validação do formulário falhou.");
            alert("Preencha todos os campos corretamente.");
            return;
        }

        console.log("Iniciando requisição para recuperar senha com os dados:", {
            NomeUsuario: nomeUsuario,
            Email: email,
            NovaSenha: novaSenha
        });

        fetch("/RecuperarSenha/RecuperarSenha", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                NomeUsuario: nomeUsuario,
                Email: email,
                NovaSenha: novaSenha
            })
        })
            .then(response => response.json())
            .then(data => {
                console.log("Resposta recebida do servidor:", data);
                if (data.sucesso) {
                    alert(data.mensagem);
                    window.location.href = "/Home/Index";
                } else {
                    alert(data.mensagem);
                }
            })
            .catch(error => {
                console.error("Erro na requisição:", error);
                alert("Erro ao processar a solicitação.");
            });
    });
});
