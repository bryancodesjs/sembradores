


$(document).ready(function () {

    $('#DetallesCompra').hide();
    //document.getElementById("DetallesCompra").style.display = "none";

    $('#Comprar').click(function (e) {
        e.preventDefault();

        var _monto = $('#monto').val();

        Comprar(_monto);

    });

    function RealizarCompra(_monto) {

        $.ajax({
            url: '/Home/Api',
            type: 'POST',
            data: { Monto: _monto },
            success: function (resp) {
                console.log(resp);

                $('#DetallesCompra').show();

                $.each(resp, function (key, item) {
                    console.log(item.address);

                    document.getElementById("imgQr").src = item.qrcode_url; 
                    $('#Direccion').html(item.address);
                    //document.getElementById("Direccion").src = item.address;
                    $('#BTCComprados').html(item.amount);
                    //document.getElementById("BTCComprados").src = item.amount;

                });

            },
            error: function (err) {
                console.error(err.responseText);
            }

        });
    }



    function Comprar(_monto) {

        Swal.fire({
            title: 'Vas a realizar un deposito por un monto total de '+ _monto +'',
            showDenyButton: true,
            showCancelButton: false,
            denyButtonText: `Cancelar`,
            confirmButtonText: `Depositar`,
            
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                RealizarCompra(_monto);
            } else if (result.isDenied) {
                Swal.fire('Solicitud cancelada!', '', 'info')
            }
        })

    };

});