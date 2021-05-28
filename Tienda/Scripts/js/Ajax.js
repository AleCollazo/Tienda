
var anadirMarca = function () {
        var codigoMarca = $('#codigoMarca').val();
        var descripcionMarca = $('#descripcionMarca').val();
        $.ajax({
            url: 'Insert/AddMarca',
            type: 'POST',
            dataType: 'json',
            data: {
                'codigo': codigoMarca,
                'descripcion': descripcionMarca
            },
            success: function (data) {
                var $el = $('#modalInsert');
                var $lblErrorCodigo = $('#codigoMarca-error');
                var $lblErrorDescripcion = $('#codigoDescripcion-error');
                var $inputCodigoMarca = $('#codigoMarca');
                var $inputDescripcionMarca = $('#descripcionMarca');

                if (!data.inputCodigo.Valido) {
                    $inputCodigoMarca.addClass('is-invalid');
                    $lblErrorCodigo[0].innerText = data.inputCodigo.MensajeError;
                    $lblErrorCodigo.show();
                }
                else {
                    $lblErrorCodigo.hide();
                    $inputCodigoMarca.removeClass('is-invalid');
                }

                if (!data.inputDescripcion.Valido) {
                    $inputDescripcionMarca.addClass('is-invalid');
                    $lblErrorDescripcion[0].innerText = data.inputDescripcion.MensajeError;
                    $lblErrorDescripcion.show();
                }
                else {
                    $lblErrorDescripcion.hide();
                    $inputDescripcionMarca.removeClass('is-invalid');
                }

                if (data.Show) {
                    $el.find('#modal-mensaje').html(data.Mensaje);
                    $el.show();
                }
                if (!data.Error) {
                    $inputCodigoMarca.val('');
                    $inputDescripcionMarca.val('');
                }
            },
            error: function () {

            }
        })
}

/*var enterPressMarca = function (event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        anadirMarca();
    }
}


$('#btn-anadir').click(anadirMarca);
$('#codigoMarca').keypress(enterPressMarca);
$('#descripcionMarca').keypress(enterPressMarca);*/