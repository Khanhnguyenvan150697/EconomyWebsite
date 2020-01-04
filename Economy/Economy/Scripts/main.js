$(document).ready(function () {
    loadData();
});

function loadData() {
    //Load product
    $.ajax({
        url: '/HomeAdmin/ShowData',
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (res) {
            var html = '';
            $.each(res, function (key, item) {
                html += '<tr>';
                html += '<td class="idProd">' + item.ID + '</td>';
                html += '<td><img src="' + item.Image + '" alt="' + item.Name + '" width="100px" /></td>';
                html += '<td><a href="#" class="ProdName" data-id="' + item.ID + '" data-toggle="modal" data-target="#myModal" onclick="Detail(this);">' + item.Name + '</a></td>';
                html += '<td>' + item.BrandName + '</td>';
                html += '<td>' + item.CategoryName + '</td>';
                html += '<td class="text-primary">' + item.Price + ' VNĐ</td>';
                if (item.Quantity > 0) {
                    html += '<td><a id="editProd" class="btn btn-info" style="padding: 12px 20px;">Còn hàng (' + item.Quantity + ')</a > ';
                } else {
                    html += '<td><a id="editProd" class="btn btn-warning" style="padding: 12px 20px;">Hết hàng (' + item.Quantity + ')</a > ';
                }
                html += '<td><a style = "padding:12px 20px" href="/HomeAdmin/Edit/' + item.ID + '" class="btn btn-success">Sửa</a> <a href="#" data-id="' + item.ID + '" style = "padding:12px 20px" class="btn btn-danger" id="deleteProd" onclick="Delete(this);">Xóa</a></td>';
                html += '<tr>';
            });
            $('#tblProducts').html(html);
        }
    });
}

// Delete Product
function Delete(elem) {
    var getId = $(elem).data('id'); 
    if (confirm('Bạn muốn xóa sản phẩm này. Nếu muốn xóa click vào OK.') == true) {
        $.ajax({
            type: 'POST',
            url: '/HomeAdmin/Delete/' + getId + '',
            success: function (result) {
                loadData();
            }
        });
    } else {
        alert('Bạn đã hủy hành động xóa sản phẩm này.');
    }
    
}


//Product detail
function Detail(elem) {
    var getId = $(elem).data('id');
    $.ajax({
        type: 'GET',
        url: '/HomeAdmin/Detail/' + getId + '',
        success: function (result) {
            
        }
    });
}

//Search dynamicallys
$('#txtSearch').on('keyup', function () {
    var txtEnter = $(this).val();
    $('table tr').each(function (result) {
        if (result !== 0) {
            var id = $(this).find('td:nth-child(3)').text();
            if (id.indexOf(txtEnter) !== 0 && id.toLowerCase().indexOf(txtEnter.toLowerCase()) < 0) {
                $(this).hide();
            } else {
                $(this).show();
            }
        }
    });
});