document.addEventListener("DOMContentLoaded", function () {

    const form = document.querySelector("form");
    const usuario = document.getElementById("nomeUsuario");
    const senha = document.getElementById("novaSenha");
    const email = document.getElementById("email");

    const mensagemErroUsuario = document.getElementById("mensagemErroUsuario");
    const mensagemErroSenha = document.getElementById("mensagemErroNovaSenha");
    const mensagemErroEmail = document.getElementById("mensagemErroEmail");


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
        let formValido = true;

        mensagemErroUsuario.style.visibility = "hidden";
        mensagemErroSenha.style.visibility = "hidden";
        mensagemErroEmail.style.visibility = "hidden";


        // Validação do campo "Usuário"
        if (usuario.value.trim() === "") {
            exibirMensagemErro(mensagemErroUsuario, "este campo não pode estar vazio.");
            formValido = false;
        } else if (usuario.value.trim().length < 3) {
            exibirMensagemErro(mensagemErroUsuario, "O nome de usuário tem pelo menos 3 caracteres.");
            formValido = false;
        }

        // Validação do campo "Nova Senha"
        if (senha.value.trim() === "") {
            exibirMensagemErro(mensagemErroSenha, "este campo não pode estar vazio.");
            formValido = false;
        } else if (senha.value.trim().length < 8) {
            exibirMensagemErro(mensagemErroSenha, "A nova senha deve ter pelo menos 8 caracteres.");
            formValido = false;
        }

        if (email.value.trim() === "") {
            exibirMensagemErro(mensagemErroEmail, "este campo não pode estar vazio.");
            formValido = false;
        }

        if (!formValido) {
            event.preventDefault();
        }
    });
});
