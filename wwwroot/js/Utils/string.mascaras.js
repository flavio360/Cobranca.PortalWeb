(function () {

    function apenasNumeros(valor) {
        return valor.replace(/\D/g, '');
    }

    function mascaraCNPJ(valor) {
        valor = apenasNumeros(valor);

        valor = valor.replace(/^(\d{2})(\d)/, "$1.$2");
        valor = valor.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");
        valor = valor.replace(/\.(\d{3})(\d)/, ".$1/$2");
        valor = valor.replace(/(\d{4})(\d)/, "$1-$2");

        return valor.substring(0, 18);
    }

    function mascaraCEP(valor) {
        valor = apenasNumeros(valor);

        valor = valor.replace(/^(\d{5})(\d)/, "$1-$2");

        return valor.substring(0, 9);
    }

    function mascaraTelefone(valor) {
        valor = apenasNumeros(valor);

        if (valor.length <= 10) {
            valor = valor.replace(/^(\d{2})(\d)/g, "($1) $2");
            valor = valor.replace(/(\d{4})(\d)/, "$1-$2");
        }
        else {
            valor = valor.replace(/^(\d{2})(\d)/g, "($1) $2");
            valor = valor.replace(/(\d{5})(\d)/, "$1-$2");
        }

        return valor.substring(0, 15);
    }

    function aplicarMascaras() {

        document.querySelectorAll('[data-mask]').forEach(function (input) {

            input.addEventListener('input', function () {

                const tipo = input.getAttribute('data-mask');

                switch (tipo) {

                    case 'cnpj':
                        input.value = mascaraCNPJ(input.value);
                        break;

                    case 'cep':
                        input.value = mascaraCEP(input.value);
                        break;

                    case 'telefone':
                        input.value = mascaraTelefone(input.value);
                        break;

                    case 'numbers':
                        input.value = apenasNumeros(input.value);
                        break;
                }
            });

        });
    }

    document.addEventListener('DOMContentLoaded', aplicarMascaras);

})();