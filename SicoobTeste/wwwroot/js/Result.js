//Função para as opções de servidor publico
$(document).ready(function () {
    $("#servidor-publico").change(function () {
        if ($(this).val() == "sim") {
            $("#aposentado-container").show();
            $("#tipo-container").show();
            $("#profissao-container").hide();
            $("#empresa-container").hide();
            $("#periodo-container").hide();
        } else if ($(this).val() == "nao") {
            $("#aposentado-container").hide();
            $("#tipo-container").hide();
            $("#profissao-container").show();
            $("#empresa-container").show();
            $("#periodo-container").show();
        } else {
            $("#aposentado-container").hide();
            $("#tipo-container").hide();
            $("#profissao-container").hide();
            $("#empresa-container").hide();
            $("#periodo-container").hide();
        }
    });
});

//Função para garantias pessoal/real
$(document).ready(function () {
    $('#garantia').on('change', function () {
        var selected = $(this).val();
        if (selected == 'real') {
            $('#garantia-real').show();
            $('#garantia-pessoal').hide();
        } else if (selected == 'pessoal') {
            $('#garantia-real').hide();
            $('#garantia-pessoal').show();
        } else {
            $('#garantia-real').hide();
            $('#garantia-pessoal').hide();
        }
    });
});


// Tornar campos como ReadOnly quando ja trazidos do banco.
$(document).ready(function () {
    $("input[type='text'], input[type='number']").each(function (index, item) {
        if ($(item).val() != "") {
            $(item).attr('readonly', true);
        }
    });
});


//Calcular capacidade de pagamento
$(document).ready(function () {
    // event listeners to the input fields
    $("#ValorParcelas").on('input', calculateCapacidadePagamento);
});
function calculateCapacidadePagamento() {

    var valorParcelas = parseFloat($("#ValorParcelas").val()) || 0;
    var rendaBrutaMensal = parseFloat($("#rendaBrutaMensal").val());
    var valorVencerAte360Dias = parseFloat($('[name$="valorVencerAte360Dias"]').val());
    // Perform the AJAX request
    $.ajax({
        url: "/AnaliseCredito/CalcularCapacidadePagamento",
        method: "POST",
        data: {
            valorParcelas: valorParcelas,
            rendaBrutaMensal: rendaBrutaMensal,
            valorVencerAte360Dias: valorVencerAte360Dias
        },
        success: function (data) {
            // Update the value of the field on the page
            console.log("Data received from server:", data)
            $("#capacidade-pagamento").val(data.toFixed(2));
        }
    });
    callbackFunction();
}
function callbackFunction() {
    // Call the calculateSeguroPrestamista function
    calculateSeguroPrestamista();
}
function calculateSeguroPrestamista() {
    var valorTotalEmprestimo = parseFloat(document.getElementById("valor-total-emprestimo").value);
    var saldoTotalDevedor = parseFloat(document.getElementById("saldoTotalDevedor").value);
    var idade = document.getElementById("idade").value;

    console.log("valorTotalEmprestimo:", valorTotalEmprestimo);
    console.log("saldoTotalDevedor:", saldoTotalDevedor);
    console.log("idade:", idade);

    $.ajax({
        url: "/AnaliseCredito/CalcularSeguroPrestamista",
        method: "POST",
        data: {
            valorTotalEmprestimo: valorTotalEmprestimo,
            saldoTotalDevedor: saldoTotalDevedor,
            idade: idade
        },
        success: function (data) {
            // Update the value of the field on the page
            console.log("Data received from server:", data);
            $("#seguro_prestamista").val(data);
        }
    });
}

//Esconder campos para calculo
$("#hiddenFieldsContainer").hide();