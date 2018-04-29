


var tinhTien = function () {
    $.ajax({
        url: '/ChiTietHDs/ThanhToan',
        type: 'post',
        data: { sohd: $('#sohd').val() },
        dataType:'json',
        success: function (response) {
            alert(response);
        }
    });
};

$(document).ready(function () {
    
    $("#valueA").change(function () {
       // alert("Handler for .change() called.");
        var kq = $("#valueA").val() - $("#valueB").val();
        $("#result").val(kq);
    });

});