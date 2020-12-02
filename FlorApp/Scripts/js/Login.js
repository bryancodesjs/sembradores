

$(document).ready(function () {   
   

    $('#Registrar').click(function (e) {
        e.preventDefault();

        Login();
    });

    $('#ProcesarCodigo').click(function (e) {
        //e.preventDefault();

        verificarCodigo();
    });

    function verificarCodigo() {

        var _usuario = $('#NombreUsuario').html();

        var _codigoVerificacion = $('#CodigoVerificacion').val();        

        $.ajax({
            url: '/Login/VerificarCodigo',
            type: 'POST',
            data: { Usuario: _usuario, Codigo: _codigoVerificacion},
            success: function (resp) {

                //console.log(resp);

                if (resp == "False") {

                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Su codigo no es correcto!'
                    })

                } else if (resp == "Ok") {
                    window.location = "/Home/";
                } 

            },
            error: function (err) {
                console.error(err.responseText);
            }


        });

    }


    function Login() {

        var _Usuario = $('#Usuario').val();
        var _email = $('#Email').val();
        var _pass = $('#Password').val();
        var _direccion_btc = $('#Direccion_btc').val();


        $.ajax({
            url: '/Login/Registro',
            type: 'POST',
            data: { User: _Usuario, Pass: _pass, Email: _email,  Direccion_btc: _direccion_btc },
            success: function (resp) {

                //console.log(resp);

                if (resp == "Ok")
                {
                    $('#NombreUsuario').html(_Usuario);
                    $('#ModalVerificacion').modal();                    

                } else
                {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Algo salio mal!'
                    })
                }

            },
            error: function (err) {
                console.error(err.responseText);
            }


        });
    }

});