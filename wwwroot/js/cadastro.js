document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector(".form-cadastro");
    const nome = document.getElementById("nome");
    const email = document.getElementById("email");
    const telefone = document.getElementById("telefone");
    const endereco = document.getElementById("endereco");
    const usuario = document.getElementById("usuario");
    const senha = document.getElementById("senha");
    const confirmarSenha = document.getElementById("confirmar-senha");
    const termos = document.getElementById("termos");

    function exibirMensagemErro(input, mensagem) {
        const erroElement = document.createElement("p");
        erroElement.classList.add("mensagem-erro");
        erroElement.innerText = mensagem;
        input.parentElement.appendChild(erroElement);
        input.classList.add("input-erro");
    }

    function limparMensagensErro() {
        const mensagensErro = document.querySelectorAll(".mensagem-erro");
        mensagensErro.forEach(mensagem => mensagem.remove());

        const inputsComErro = document.querySelectorAll(".input-erro");
        inputsComErro.forEach(input => input.classList.remove("input-erro"));
    }

    form.addEventListener("submit", function (event) {
        event.preventDefault(); // Impede o envio padrão do formulário
        limparMensagensErro();

        let formValido = true;

        if (nome.value.trim() === "") {
            exibirMensagemErro(nome, "Nome completo é obrigatório.");
            formValido = false;
        }

        if (email.value.trim() === "") {
            exibirMensagemErro(email, "E-mail é obrigatório.");
            formValido = false;
        } else if (!validateEmail(email.value)) {
            exibirMensagemErro(email, "Formato de e-mail inválido.");
            formValido = false;
        }

        if (telefone.value.trim() === "") {
            exibirMensagemErro(telefone, "Número de telefone é obrigatório.");
            formValido = false;
        } else if (telefone.value.trim().length < 10 || telefone.value.trim().length > 15) {
            exibirMensagemErro(telefone, "Número de telefone deve ter entre 10 e 15 caracteres.");
            formValido = false;
        }

        if (endereco.value.trim() === "") {
            exibirMensagemErro(endereco, "Endereço é obrigatório.");
            formValido = false;
        }

        if (usuario.value.trim() === "") {
            exibirMensagemErro(usuario, "Nome de usuário é obrigatório.");
            formValido = false;
        }

        if (senha.value.trim() === "") {
            exibirMensagemErro(senha, "Senha é obrigatória.");
            formValido = false;
        } else if (senha.value.trim().length < 8) {
            exibirMensagemErro(senha, "A senha deve ter pelo menos 8 caracteres.");
            formValido = false;
        }

        if (confirmarSenha.value.trim() === "") {
            exibirMensagemErro(confirmarSenha, "Confirmação de senha é obrigatória.");
            formValido = false;
        } else if (confirmarSenha.value !== senha.value) {
            exibirMensagemErro(confirmarSenha, "As senhas não coincidem.");
            formValido = false;
        }

        if (!termos.checked) {
            exibirMensagemErro(termos.parentElement, "Você deve aceitar os termos de serviço.");
            formValido = false;
        }

        if (formValido) {
            const formData = {
                Nome: nome.value,
                Email: email.value,
                Telefone: telefone.value,
                Endereco: endereco.value,
                nome_usuario: usuario.value,
                senha: senha.value,
                Status_cliente: "ativo" // Adicionando o Status_cliente
            };

            fetch("/Cadastro/Cadastrar", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(formData)
            })
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw new Error("Erro ao tentar cadastrar.");
                }
            })
            .then(data => {
                if (data.sucesso) {
                    alert(data.mensagem);
                    window.location.href = "/Home/Index"; // Redireciona para a página inicial
                } else {
                    alert(data.mensagem);
                    if (data.erros) {
                        data.erros.forEach(function(erro) {
                            alert(erro);
                        });
                    }
                }
            })
            .catch(error => {
                console.error("Erro:", error);
                alert("Ocorreu um erro no cadastro. Tente novamente mais tarde.");
            });
        }
    });

    function validateEmail(email) {
        const re = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        return re.test(String(email).toLowerCase());
    }
});
