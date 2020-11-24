var count = $("#orderPositions").eq(0).children("tbody").children("tr").length - 1;
console.log(count);
var i = count + 1;
var orderId = parseInt($("#orderId").eq(0).val());
var n = parseInt($("#countPositions").eq(0).val());
var numbersForPrice = Array();
if (n != -1)
    fillArray(n);


function fillArray(index) {
    var index1 = 0;
    $("#orderPositions").eq(0).children("tbody").eq(0).children("tr").each(function () {
        var current = $(this).eq(0);
        if (current.children("th").length == 0) {
            numbersForPrice[index1] = new Array(3);
            var window = current.children("td").eq(0).children("select").eq(0).children("option:selected").eq(0).text();
            var length = current.children("td").eq(1).children("input").eq(0).val();
            var width = current.children("td").eq(2).children("input").eq(0).val();
            var indexS = window.indexOf(':');
            var price = parseFloat(window.slice(indexS + 1, window.Length));
            length = parseFloat(length);
            if (length == NaN)
                length = 0;
            var width = parseFloat(width);
            if (width == NaN)
                width = 0;
            numbersForPrice[index1][0] = price;
            numbersForPrice[index1][1] = length;
            numbersForPrice[index1][2] = width;
            index1++;

        }
    });

}

function changeWindow(input, id) {
    var str = input.outerText;
    var index = str.indexOf(':')
    if (index != -1) {
        var price = parseFloat(str.slice(index + 1, str.Length));
        if (price == NaN)
            price = 0;
        numbersForPrice[id][0] = price;
        CalculatePrice();
    }
}

function changeLength(input, id) {
    var str = input.value;
    var length = parseFloat(str);
    if (length == NaN)
        length = 0;
    numbersForPrice[id][1] = length;
    CalculatePrice();
}

function changeWidth(input, id) {
    var str = input.value;
    var width = parseFloat(str);
    if (width == NaN)
        width = 0;
    numbersForPrice[id][2] = width;
    CalculatePrice();
}


function CalculatePrice() {
    var sum = 0;
    for (var index = 0; index < numbersForPrice.length; index++) {
        if (numbersForPrice[index] != undefined) {
            var p = numbersForPrice[index][0];
            var s = numbersForPrice[index][1] * numbersForPrice[index][2];
            sum += p * s;
        }

    }
    $("#Price").val(sum);
}


function deleteOrderPosition(id) {
    var rowIndex = 0;
    var table = $("#orderPositions").eq(0);
    var rows = table.children("tbody").eq(0).children("tr");
    table.children("tbody").eq(0).children("tr").each(function () {
        var tr = $(this).eq(0);
        if (tr.children(":hidden").length != 0 && tr.children(":hidden")[0].value == id) {
            rowIndex = parseInt(tr.prop("id"));
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

    numbersForPrice[rowIndex][0] = 0;
    numbersForPrice[rowIndex][1] = 0;
    numbersForPrice[rowIndex][2] = 0;

    CalculatePrice();

}




function addPositionOrder() {
    console.log(i);
    numbersForPrice[i] = new Array(3);
    for (var index = 0; index < 3; index++) {
        numbersForPrice[i][index] = 0;
    }
    var table = $("#orderPositions");
    table.append('<tr id=' + '"' + i + '"' + '> <td> </td> <td> <input class="form-control" type="text" onchange="changeLength(this,' + i + ')" /> </td> <td>  <input class="form-control" type="text" onchange="changeWidth(this,' + i + ')" /></td> <td> <button class="form-control" type="button" onclick="deleteRow(' + i + ');"' + ' >Удалить  </button> </td> </tr>');
    var row = table.children("tbody").eq(0).children("tr").eq(i);
    var index = i;
    $("#windowsSelect").eq(0).clone()
        .removeAttr("hidden")
        .change(function () {
            var str = $(this).children("option:selected").eq(0).text();
            var i = str.indexOf(':')
            if (i != -1) {
                var price = parseFloat(str.slice(i + 1, str.Length));
                if (price == NaN)
                    price = 0;
                numbersForPrice[index][0] = price;
                CalculatePrice();
            }
        })
        .appendTo(row.children("td").eq(0))
        ;
    i++;
}


function deleteRow(rowId) {
    $('#' + rowId).remove();
    numbersForPrice[rowId] = undefined;
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
                var windowId = row.children("td").eq(0).children("select").eq(0).val();
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
                var windowId = row.children("td").eq(0).children("select").eq(0).val();
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
    var buyer = $("#buyerId").eq(0).val();
    order.BuyerId = buyer;


    var seller = $("#sellerId").eq(0).val();
    order.SellerId = seller;
    order.Id = orderId;
    order.OrderDate = $("#OrderDate")[0].value;
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