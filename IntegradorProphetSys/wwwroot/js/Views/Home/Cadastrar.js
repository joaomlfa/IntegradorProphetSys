$(document).ready(function () {
    $("#nav-logout").hide();
    $("#spin-carregando").attr("hidden", "true");
    $("#check-image").attr("hidden", "true");
    $("#cross-image").attr("hidden", "true");
    $("#Email").change(function () {
        if (isEmail($(this).val())) {
            var email = $(this).val();
            $(function () {                
                $.ajax({
                    contentType: "application/json",
                    type: "GET",
                    url: "/Home/ExisteEmail",
                    data: { "email": email},
                    success:
                        function (data) {                           
                            if (data == true) {
                                Swal.fire({
                                    icon: "error",
                                    title: "Oops...",
                                    text: "Email já existe, por favor escolha outro.",

                                });
                                $(this).val("");
                            }
                        }
                });
            });
        } else {
            
            alert("Email inválido, favor verifique!");
            $(this).val("");
            $(this).focus();
           
        }
    });

    $("#Token").change(function () {
        $("#CadastrarButton").attr('disabled', true);
        $("#ValidarTokenSuasVendas").show();
        $("#spin-carregando").attr("hidden", "true");
        $("#check-image").attr("hidden", "true");
        $("#cross-image").attr("hidden", "true");

    })
});

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function ValidarTokenSuasVendas() {
    if ($("#Token").val() != "") {
        $("#spin-carregando").removeAttr("hidden");
        $("#ValidarTokenSuasVendas").hide();
        $(function () {
            var token = $("#Token").val();
            $.ajax({
                contentType: "application/json",
                method: "GET",
                data: { "token": token },
                url: "/Home/VerificarToken",              
                success:
                    function (data) {
                        if (data == true) {
                            $("#spin-carregando").attr("hidden", "true");
                            $("#cross-image").attr("hidden", "true");
                            $("#check-image").removeAttr("hidden");
                            $("#CadastrarButton").removeAttr("disabled");
                        } else {
                            $("#spin-carregando").attr("hidden", "true");
                            $("#check-image").attr("hidden", "true");
                            $("#cross-image").removeAttr("hidden");
                            $("#ValidarTokenSuasVendas").show();
                            Swal.fire({
                                icon: "error",
                                title: "Oops...",
                                text: "Token inválido, favor verifique.",

                            });
                        }
                    }

            });
        });
    }
}
