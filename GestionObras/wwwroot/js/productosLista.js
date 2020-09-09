// separador en la tabla &nbsp; "width": "30%" "width": "10%"
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_loadProductos').DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": "/inventarios/getallproductos/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "descripcion", },
            { "data": "precio", },
            { "data": "observacion",},
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                        <!--Editar-->
                        <a href="/inventarios/UpsertProductos?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            <i class="far fa-edit"></i>                         
                        </a>
                        <!--Eliminar-->
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/inventarios/Delete_Productos?id='+${data})>
                            <i class="fas fa-trash-alt"></i>
                        </a>
                        </div>`;
                }, // width
            }
        ],
        "language": {
            "emptyTable": "No hay datos",
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta Seguro?",
        text: "Una vez eliminado, no sera capaz de recuperarlo",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}