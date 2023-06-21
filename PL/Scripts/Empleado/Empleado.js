$(document).ready(function () { //click
    GetAll();
    EstadoGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:19691/api/Empleado/GetAll',
        success: function (result) { //200 OK
            $('#SubCategorias tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas = '<tr>' +
                    '<td class="text-center"> <button class="btn btn-warning" onclick="GetById(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-edit" style="color:#FFFFFF"></span></button>' + '</td>'
                    + "<td  id='id' class='hidden'>" + empleado.IdEmpleado + "</td>" + "<td class='text-center'>" + empleado.NumeroNomina + "</td>" + "<td class='text-center'>" + empleado.Nombre + "</td>" + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>" + "<td class='text-center'>" + empleado.ApellidoMaterno + "</td>" + "<td class='text-center'>" + empleado.Estado.Nombre + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SubCategorias tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Add(empleado) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:19691/api/Empleado/Add',
            dataType: 'json',
            data: empleado,
            success: function (result) {
                $('#myModal').modal();
                $('#ModalUpdate').modal('hide');
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:19691/api/Empleado/GetById/' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoP').val(result.Object.ApellidoPaterno);
            $('#txtApellidoM').val(result.Object.ApellidoMaterno);
            $('#ddlEstado').val(result.Object.Estado.IdEstado);

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:19691/api/Estado/GetAll',
        success: function (result) {
            $("#ddlEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstado").append('<option value="'
                    + estado.IdEstado + '">'
                    + estado.Nombre + '</option>');
            });
        }
    });
}

function Update(empleadoUD) {
    
    $.ajax({
        type: 'POST',
        url: 'http://localhost:19691/api/Empleado/Update',
        datatype: 'json',
        data: empleadoUD,
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    IniciarEmpleado();

}

function Actualizar() {
    var empleado1 = {
        IdEmpleado: $('#txtIdEmpleado').val()
    }

    if (empleado1.IdEmpleado == '') {
        var empleado = {
            IdEmpleado: 0,
            NumeroNomina: $('#txtNumeroNomina').val(),
            Nombre: $('#txtNombre').val(),
            ApellidoPaterno: $('#txtApellidoP').val(),
            ApellidoMaterno: $('#txtApellidoM').val(),
            Estado: {
                IdEstado: $('#ddlEstado').val()
            }
        }
        Add(empleado);

    }
    else {
        var empleadoUD = {
            IdEmpleado: $('#txtIdEmpleado').val(),
            NumeroNomina: $('#txtNumeroNomina').val(),
            Nombre: $('#txtNombre').val(),
            ApellidoPaterno: $('#txtApellidoP').val(),
            ApellidoMaterno: $('#txtApellidoM').val(),
            Estado: {
                IdEstado: $('#ddlEstado').val()
            }
        }
        Update(empleadoUD);
    }
}

function Eliminar(IdEmpleado) {
    if (confirm("¿Estas seguro de eliminar el empleado ?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:19691/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta' + result.responseJSON.ErrorMessage);
            }
        });

    };
};


function IniciarEmpleado() {

    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(''),
        NumeroNomina: $('#txtNumeroNomina').val(''),
        Nombre: $('#txtNombre').val(''),
        ApellidoPaterno: $('#txtApellidoP').val(''),
        ApellidoMaterno: $('#txtApellidoM').val(''),
        Estado: {
            IdEstado: $('#ddlEstado').val(0)
        }
    }
}