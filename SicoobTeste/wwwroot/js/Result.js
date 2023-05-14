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

