function deleteOrder(id) {
    $("#" + id).eq(0).remove();
    $.ajax({
        type: "POST",
        url: "/Order/Delete",
        data: JSON.stringify({ orderId: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

}

function deleteManufactor(id) {
    $("#" + id).eq(0).remove();
    $.ajax({
        type: "POST",
        url: "/Manufactor/Delete",
        data: JSON.stringify({ manufactorId: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

}


function deleteSeller(id) {
    $("#" + id).eq(0).remove();
    $.ajax({
        type: "POST",
        url: "/Seller/Delete",
        data: JSON.stringify({ sellerId: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

}

function deleteBuyer(id) {
    $("#" + id).eq(0).remove();
    $.ajax({
        type: "POST",
        url: "/Buyer/Delete",
        data: JSON.stringify({ buyerId: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

}

function deleteWindow(id) {
    $("#" + id).eq(0).remove();
    $.ajax({
        type: "POST",
        url: "/Window/Delete",
        data: JSON.stringify({ windowId: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

}