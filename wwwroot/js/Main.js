//$(document).ready(function () {
//    GetSupplier(); // Corrected function name
//});

//function GetSupplier() {
//    $.ajax({
//        url: '/LicenseMSupplier/GetLicenseSuppliers',
//        type: 'get',
//        datatype: 'json',
//        contentType: 'application/json;charset=utf-8',
//        success: function (response) {
//            if (response == null || response == undefined || response.length == 0) {
//                var object = ' ';
//                object += '<tr>';
//                object += '<td colspan="5">' + "License Supplier not available" + '</td> ';
//                object += '</tr>';
//                $('#LicenseSupply').html(object);
//            } else {
//                var object = ' ';
//                $.each(response, function (index, item) {
//                    object += '<tr>';
//                    object += '<td>' + item.SupplierId + '</td>';
//                    object += '<td>' + item.UserId + '</td>';
//                    object += '<td>' + item.Supplier + '</td>';
//                    object += '<td>' + item.Contact + '</td>';
//                    object += '<td>' + item.EmailAddress + '</td>';
//                    object += '<td>' + item.Status + '</td>';
//                    object += '<td>  <a href="#"  class="btn btn-primary btn-sm" onclick="Edit(' + item.SupplierId + ')"> Edit </a> ';
//                    object += '</tr>';
//                });
//                $('#LicenseSupply').html(object);
//            }
//        },
//        error: function () {
//            alert('Unable to read the data.');
//        }
//    });

//}
