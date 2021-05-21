$(document).ready(function () {
    $("#insert-marca-form").validate({
        codigoMarca: {
            required: true,
            digits:true
        },
        descripcionMarca: {
            required: true
        }
    });

    $('#insert-tipo-producto-form').validate({
        codigoTipoProducto: {
            required: true,
            digits: true
        },
        nombreTipoProducto: {
            required: true
        }
    });

    $('#insert-producto-form').validate({
        descripcionProducto: {
            required: true
        },
        precio: {
            required: true,
            number: true
        },
        stock: {
            required: true,
            digits: true
        }
    })
});