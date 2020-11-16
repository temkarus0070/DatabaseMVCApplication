
var i = 1;
function addPositionOrder() {
    var table = $("#orderPositions");
    table.append('<tr id=' + '"' + i + '"' + '> <td> <input type="text" list="windows" /> </td> <td> <input type="text" /> </td> <td>  <input type="text" /></td> <td> <button class="btn" type="button" onclick="deleteRow(' + i + ');"' + ' >Удалить  </button> </td> </tr>');
    i++;
}


function deleteRow(rowId) {
    $('#' + rowId).remove();
}

function send() {
    var orderPositions = new Array();
    $("#orderPositions TBODY TR").each(function () {
        var row = $(this);
        var orderPosition = {};
        if (row.find("TD").eq(0).children("input")[0] != null) {
            var str = row.find("TD").eq(0).children("input")[0].value;
            var id = $("#windowsList").eq(0).children("li").each(function () {
                var el = $(this).eq(0);
                var value = el.eq(0).prop("textContent");
                if (value === str)
                    orderPosition.WindowId = el.eq(0).prop("id");
            });
         
            orderPosition.Length = row.find("TD").eq(1).children("input")[0].value;
            orderPosition.Width = row.find("TD").eq(2).children("input")[0].value;
            orderPositions.push(orderPosition);
        }
    }
    );


    var order = {};
    var buyer = $("#buyerId")[0].value;
    $("#buyersList").eq(0).children("li").each(function () {
        var el = $(this).eq(0);
        var text = el.prop("textContent");
        if (text === buyer)
            order.BuyerId = el.eq(0).prop("id");
    });


    var seller = $("#sellerId")[0].value;
    $("#sellersList").eq(0).children("li").each(function () {
        var el = $(this).eq(0);
        var text = el.prop("textContent");
        if (text === seller)
            order.SellerId = el.eq(0).prop("id");
    });

    order.IsDeliver = $("#IsDeliver")[0].checked;
    order.IsSetup = $("#IsSetup")[0].checked;
    order.DeliverDate = $("#DeliverDate")[0].value;
    order.SetupDate = $("#SetupDate")[0].value;
    order.Price = $("#Price")[0].value;

    $.ajax({
        type: "POST",
        url: "/Order/Add",
        data: JSON.stringify({ orderViewModel: order, orderPositions: orderPositions, Price: order.Price }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

    document.location.href = "../Order/Index";
}