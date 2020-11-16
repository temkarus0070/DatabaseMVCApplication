var i = 1;
var orderId = parseInt($("#orderId").eq(0).val());




function deleteOrderPosition (id){
    var table = $("#orderPositions").eq(0);
    var rows = table.children("tbody").eq(0).children("tr");
    table.children("tbody").eq(0).children("tr").each(function () {
        var tr = $(this).eq(0);
        if (tr.children(":hidden").length != 0 && tr.children(":hidden")[0].value == id) {
            $.ajax({
                type: "POST",
                url: "/OrderPosition/Delete",
                data: JSON.stringify({ orderPositionId: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            });
            tr.remove();
        }
    });
}




function addPositionOrder() {
    var table = $("#orderPositions");
    table.append('<tr id=' + '"' + i + '"' + '> <td> <input type="text" list="windows" /> </td> <td> <input type="text" /> </td> <td>  <input type="text" /></td> <td> <button class="btn" type="button" onclick="deleteRow(' + i + ');"' + ' >Удалить  </button> </td> </tr>');
    i++;
}


function deleteRow(rowId) {
    $('#' + rowId).remove();
}

function updateOrderPositions() {

    var orderPositions = [];
    var table = $("#orderPositions").eq(0);
    table.children("tbody").eq(0).children("tr").each(function () {
        var row = $(this).eq(0);
        if (row.children("th").length == 0) {
            if (row.children(":hidden").length == 0) {
                var id = parseInt(row.children(":hidden").eq(0).val());
                var str = row.children("td").eq(0).children("input").eq(0).val();
                var windowId;
                 $("#windowsList").eq(0).children("li").each(function () {
                    var el = $(this).eq(0);
                    var value = el.eq(0).prop("textContent");
                    if (value === str)
                        windowId = el.eq(0).prop("id");
                });
                var length = row.children("td").eq(1).children("input").eq(0).val();
                var width = row.children("td").eq(2).children("input").eq(0).val();
                var orderPosition = { Length: length, Width: width, WindowId: windowId, OrderId: orderId };
                addOrderPosition(orderPosition);




            }
            else {
                var id = parseInt(row.children(":hidden").eq(0).val());
                var str = row.children("td").eq(0).children("input").eq(0).val();
                var windowId;
                $("#windowsList").eq(0).children("li").each(function () {
                    var el = $(this).eq(0);
                    var value = el.eq(0).prop("textContent");
                    if (value === str)
                        windowId = el.eq(0).prop("id");
                });
                var length = row.children("td").eq(1).children("input").eq(0).val();
                var width = row.children("td").eq(2).children("input").eq(0).val();

                var orderPosition = { id: id, Length: length, Width: width, WindowId: windowId, OrderId: orderId };
                updateOrderPosition(orderPosition);
               
            }
        }

    });
}

function updateOrderPosition(orderPosition) {
    $.ajax({
        type: "POST",
        url: "/OrderPosition/Update",
        data: JSON.stringify(orderPosition),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
}

function addOrderPosition(orderPosition) {
    $.ajax({
        type: "POST",
        url: "/OrderPosition/Add",
        data: JSON.stringify(orderPosition),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
}

function sendData() {
    var order = {};
    var buyer = $("#buyerId")[0].value;
    $("#buyersList").eq(0).children("li").each(function () {
        var el = $(this).eq(0);
        var text = el.prop("textContent");
        if (text == buyer)
            order.BuyerId = el.eq(0).prop("id");
    });


    var seller = $("#sellerId")[0].value;
    $("#sellersList").eq(0).children("li").each(function () {
        var el = $(this).eq(0);
        var text = el.prop("textContent");
        if (text == seller)
            order.SellerId = el.eq(0).prop("id");
    });
    order.Id = orderId;
    order.IsDeliver = $("#IsDeliver")[0].checked;
    order.IsSetup = $("#IsSetup")[0].checked;
    order.DeliverDate = $("#DeliverDate")[0].value;
    order.SetupDate = $("#SetupDate")[0].value;
    order.Price = $("#Price")[0].value;
    console.log(order);

    $.ajax({
        type: "POST",
        url: "/Order/Edit",
        data: JSON.stringify({ order: order, Price: order.Price }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

    document.location.href = "../Order/Index";
}