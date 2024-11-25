document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");
    const usuario = document.getElementById("usuario");
    const senha = document.getElementById("senha");
    const mensagemErroUsuario = document.getElementById("mensagemErroUsuario");
    const mensagemErroSenha = document.getElementById("mensagemErroSenha");

    if (!form || !usuario || !senha || !mensagemErroUsuario || !mensagemErroSenha) {
        console.error("Elementos não encontrados na página.");
        return;
    }

    // Função para exibir uma mensagem de erro
    function exibirMensagemErro(mensagemErro, mensagem) {
        mensagemErro.innerText = mensagem;
        mensagemErro.style.visibility = "visible"; // Mostra o erro
        mensagemErro.style.opacity = "1"; // Garante a visibilidade
        setTimeout(() => {
            mensagemErro.style.visibility = "hidden"; // Oculta o erro
            mensagemErro.style.opacity = "0";
            mensagemErro.innerText = ""; // Limpa o texto
        }, 3000); // Remove após 3 segundos
    }

    form.addEventListener("submit", function (event) {
        event.preventDefault(); // Impede o envio padrão do formulário
        let formValido = true;

        mensagemErroUsuario.style.visibility = "hidden";
        mensagemErroSenha.style.visibility = "hidden";

        // Validação do campo "Usuário"
        if (usuario.value.trim() === "") {
            exibirMensagemErro(mensagemErroUsuario, "Este campo não pode estar vazio.");
            formValido = false;
        } else if (usuario.value.trim().length < 3) {
            exibirMensagemErro(mensagemErroUsuario, "O nome de usuário deve ter pelo menos 3 caracteres.");
            formValido = false;
        }

        // Validação do campo "Senha"
        if (senha.value.trim() === "") {
            exibirMensagemErro(mensagemErroSenha, "Este campo não pode estar vazio.");
            formValido = false;
        } else if (senha.value.trim().length < 8) {
            exibirMensagemErro(mensagemErroSenha, "A senha deve ter pelo menos 8 caracteres.");
            formValido = false;
        }

        if (formValido) {
            const loginData = {
                usuario: usuario.value,
                senha: senha.value
            };

            fetch("/Home/Autenticar", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(loginData)
            })
            .then(response => response.json())
            .then(data => {
                if (data.sucesso) {
                    alert(data.mensagem);
                    window.location.href = "/PaginaInicial"; // Redireciona para a página inicial
                } else {
                    alert(data.mensagem);
                }
            })
            .catch(error => {
                console.error("Erro:", error);
                alert("Ocorreu um erro no login. Tente novamente mais tarde.");
            });
        }
    });
});
