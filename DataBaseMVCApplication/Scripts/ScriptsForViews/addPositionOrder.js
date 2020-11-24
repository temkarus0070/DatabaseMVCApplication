
var i = 1;

var numbersForPrice = Array();




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
    for (var index = 1; index < numbersForPrice.length; index++) {
        if (numbersForPrice[index] != undefined) {
            var p = numbersForPrice[index][0];
            var s = numbersForPrice[index][1] * numbersForPrice[index][2];
            sum += p * s;
        }

    }
    $("#Price").val(sum);
}



function addPositionOrder() {
    numbersForPrice[i] = new Array(3);
    for (var index = 0; index < 3; index++) {
        numbersForPrice[i][index] = 0;
    }
    var table = $("#orderPositions");
    table.append('<tr id=' + '"' + i + '"' + '> <td>  </td> <td> <input class="form-control" type="text" onchange="changeLength(this,' + i + ')" /> </td> <td>  <input class="form-control" type="text" onchange="changeWidth(this,' + i + ')" /></td> <td> <button class="btn-primary" type="button" onclick="deleteRow(' + i + ');"' + ' >Удалить  </button> </td> </tr>');
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
    i--;
    CalculatePrice();
}

function send() {
    var orderPositions = new Array();
    $("#orderPositions TBODY TR").each(function () {
        var row = $(this);
        if (row.children("th").length == 0) {
            var orderPosition = {};
            orderPosition.WindowId = row.find("td").eq(0).children("select").eq(0).val();
            orderPosition.Length = row.find("TD").eq(1).children("input").eq(0).val();
            orderPosition.Width = row.find("TD").eq(2).children("input").eq(0).val();
            orderPositions.push(orderPosition);
        }
    }
    );


    var order = {};
    var buyer = $("#buyerId")[0].value;
    order.BuyerId = buyer;



    var seller = $("#sellerId")[0].value;
    order.SellerId = seller;
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