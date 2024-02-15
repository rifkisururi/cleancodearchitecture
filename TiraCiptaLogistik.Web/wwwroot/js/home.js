$(document).ready(function () {
    $('#cutomerList select').select2();
});

$('#addProduk').click(function (e) {
    var id = "tr_" + Math.floor(Math.random() * 100000000);
    var optionProduct = "";
    dtProduct.forEach(function (dt) {
        optionProduct += `<option value="${dt.productCode}">${dt.productName}</option>`
    });

    html = `
        <tr id="${id}">
            <td>
                <select onchange="getPrice('select_${id}')" id="select_${id}">
                    ${optionProduct}
                </select>
            </td>
            <td class="price" id="price_${id}"></td>
            <td><input type="number" min="0" value=0></td>
        </tr>`;
    $("#detailProduk tbody").append(html);
    $(`#${id} select`).select2();
    getPrice(`select_${id}`)
})

function getPrice(id) {
    valSelect2 = $(`#${id}`).val();
    dtProduct.forEach(function (dt) {
        if (dt.productCode == valSelect2) {
            var idPrice = id.replace('select_', 'price_');
            $(`#${idPrice}`).html(dt.priceValue);
        }
    });
}

$('#saveData').click(function (e) {
    console.log("saveData");
    var object = new Object();
    object.CustCode = $("#cutomerList select").val();
    object.OrderDetail = [];
    $(`#detailProduk tbody tr`).each(function () {
        var dtProductDetail = new Object();
        id = $(this).attr("id");
        dtProductDetail.ProductCode = $("#" + id + " select").val();
        dtProductDetail.Price = $("#" + id + " .price").html().trim();
        dtProductDetail.Qty = $("#" + id + " input").val();
        object.OrderDetail.push(dtProductDetail);
    });

    console.log(object);
    var oForm = $('form')[0];
    var oData = new FormData(oForm);

    oData.append("postData", JSON.stringify(object));
    $.ajax({
        type: "POST",
        contentType: false,
        processData: false,
        dataType: "json",
        url: "save",
        data: oData,
        success: function (response) {
            console.log(response);

            alert('Data has been insert successfully, Sales order no : ' + response.salesOrderNo);
            location.reload();
        },
        error: function (event) {
            console.log('error submit data');
            alert('error submit data');
        }
    });
})