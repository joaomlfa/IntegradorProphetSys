$(document).ready(function () {
    VerificarProdutosNovosAtualizados();
    $('.counter').each(function () {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 4000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });


    $(function () {

        $(".progress").each(function () {

            var value = $(this).attr('data-value');
            var left = $(this).find('.progress-left .progress-bar');
            var right = $(this).find('.progress-right .progress-bar');

            if (value > 0) {
                if (value <= 50) { right.css('transform', 'rotate(' + percentageToDegrees(value) + 'deg)') } else { right.css('transform', 'rotate(180deg)'); left.css('transform', 'rotate(' + percentageToDegrees(value - 50) + 'deg)') }
            }
        }); function percentageToDegrees(percentage) { return percentage / 100 * 360 }
    });
});

function VerificarPedidosNovosAtualizados() {
    $("#spin-pedido").removeAttr("hidden");
}

function VerificarProdutosNovosAtualizados() {
    $("#spin-produto").removeAttr("hidden");
    $(function () {
        $.ajax({
            contentType: "application/json",
            type: "GET",
            url: "/PedidoEletronico/Dashboard/VerificarProdutosNovosAtualizados",
            success:
                function (data) {
                    if (data != "") {                       
                        data = JSON.parse(data);
                        if (data.ListagemRetorno.length > 0) {
                            AlterarCorProgress("produto", true);
                            $("#qtde-produto").html(data.ListagemRetorno.length);
                            $("#spin-produto").attr("hidden", "true");
                            $("#btn-produto").attr("hidden", "true");
                            $("#btn-produto-sincronizar").removeAttr("hidden");

                        } else {
                            AlterarCorProgress("produto", false);
                            $("#qtde-produto").html(0);
                            $("#spin-produto").attr("hidden", "true");
                            $("#btn-produto-sincronizar").attr("hidden", "true");
                        }
                    } else {
                        Swal.fire({
                            icon: "error",
                            title: "Erro de comunicação",
                            text: "Houve um erro ao tentar solicitar os dados, tente novamente mais tarde caso o problema persista entre em contato conosco.",

                        });
                    }
                    
                    
                }
        });
    });
}


function AlterarCorProgress(modulo, possuiAltualizacao) {
    if (possuiAltualizacao) {
        $(".progress-" + modulo).removeAttr("style");
        $(".progress-" + modulo).attr("style", "transform: rotate(180deg);border-color: #ff00009c !important;");
    } else {
        $(".progress-" + modulo).removeAttr("style");
        $(".progress-" + modulo).attr("style", "transform: rotate(180deg);border-color: #007bff !important;");
    }
}
