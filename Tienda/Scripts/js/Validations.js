$(document).ready(function () {
    $("#insert-marca-form").validate({
        codigoMarca: {
            required: true,
            digits:true
        },
        descripcionMarca: {
            required: true
        },
        errorClass: "is-invalid error"
    });

    $('#insert-tipo-producto-form').validate({
        codigoTipoProducto: {
            required: true,
            digits: true
        },
        nombreTipoProducto: {
            required: true
        },
        errorClass: "is-invalid error"
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
        },
        errorClass: "is-invalid error"
    });

    $('#form-register').validate({
        user: {
            required: true
        },
        password: {
            required: true
        },
        confirmPassword: {
            required: true
        },
        errorClass: "is-invalid error"
    });

    $('#form-login').validate({
        user: {
            required: true
        },
        password: {
            required: true
        },
        errorClass: "is-invalid error"
    });

    $('#form-register').submit(function () {
        var pass = $('#password');
        var confirmpass = $('#confirm-password');
        if (pass.val() == confirmpass.val()) {
            return true;
        }
        confirmpass.addClass('is-invalid');
        pass.addClass('is-invalid');
        $(this).find('label.error').remove();
        $(this).find('.card-body').append('<label class="error form-label user-select-none">La confirmación de contraseña no coincide</label>');
        return false;
    });
});