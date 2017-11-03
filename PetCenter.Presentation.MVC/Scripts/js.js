var setAno = function (ano) {
    $("#ano1").val(ano);
};

var setMes = function (mes) {
    $("#mes1").val(mes);
};

var setErrorPro = function (setErrorPro) {
    if (setErrorPro === "True") {
        getGrowl("Error", "Planilla ya se encuentra procesada", "danger");
    }
};

var setErrorPro = function (setErrorPro) {
    if (setErrorPro === "True") {
        getGrowl("Error", "Planilla ya se encuentra procesada", "danger");
    }
};

var setProcesado = function (procesado) {
    if (procesado === "True") {
        getGrowl("Sistema", "Planilla Procesada", "success");
    }
};


var setErrorExiste = function (errorExiste) {
    if (errorExiste === "True") {
        getGrowl("Error", "Planilla no existe", "danger");
    }
};

var setErrorAprobado = function (errorAprobado) {
    if (errorAprobado === "True") {
        getGrowl("Error", "Planilla ya se encuentra aprobado", "danger");
    }
};

var setBorrado = function (borrado) {
    if (borrado === "True") {
        getGrowl("Sistema", "Planilla borrada con existo", "success");
    }
};

 



var getGrowl = function (titulo, mensaje, tipo) {
    $.growl({
        title: titulo,
        icon: 'glyphicon glyphicon-info-sign',
        message: mensaje
    },
    {
        type: tipo,
        z_index: 3031,
        position: {
            align: "center"
        },
        template: {
            title_divider: '<hr class="separator" />',
            container: '<div class="col-xs-10 col-md-4 alert">'
        }
    });
};



var setFecha = function (id) {
    $("#" + id).attr("readonly", "readonly");
    $("#" + id).attr("placeholder", "dd/mm/aaaa");
    var html = '<div class="input-group date" id="' + id + 'Div" data-date-format="DD/MM/YYYY">';
    html += $("#" + id)[0].outerHTML;
    html += '<span class="input-group-addon btn-sm"><span class="glyphicon-calendar glyphicon"></span></span></div>';
    $("#" + id).replaceWith(html);

    $('#' + id+ "Div").datetimepicker({
        language: 'es'
    });
};