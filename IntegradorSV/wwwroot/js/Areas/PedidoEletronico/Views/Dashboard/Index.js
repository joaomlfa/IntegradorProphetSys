$(document).ready(function () {
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
                    data = JSON.parse(data);
                    
                }
        });
    });
}
