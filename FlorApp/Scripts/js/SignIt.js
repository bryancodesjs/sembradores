

$(document).ready(function() {

    $('#SignItbtn').click(function (e) {
        e.preventDefault();

        var _User = $('#Usuario').val();
        var _Pass = $('#Clave').val();

        $.ajax({
            url: 'Login/Acceder',
            type: 'POST',
            data: { Email: _User, Clave: _Pass },
            success: function (resp) {
               // console.log(resp);

                if (resp == "False") {

                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Usuario/Clave incorrecta!'
                    })

                } else if (resp == "Ok") {
                    window.location = "/Home/Index";
                } 



            },
            error: function (err) {
                console.error(err.responseText);
            }
            
        });


    });






});