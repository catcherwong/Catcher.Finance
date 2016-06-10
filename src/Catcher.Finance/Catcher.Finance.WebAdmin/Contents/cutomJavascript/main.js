$(function () {
    $("#dv_userRefresh").click(function () {
        $.ajax({
            url: "/main/usercount",
            type: "post",           
            dataType: "json",
            success: function (data) {
                if (data.Code == '0000') {
                    $("#sp_userCount").text(data.Count);
                } else {
                    $("#sp_userCount").text('0');
                }
            }
        });        
    });

    $("#dv_recordCountRefresh").click(function () {
        $.ajax({
            url: "/main/recordcount",
            type: "post",
            dataType: "json",
            success: function (data) {
                if (data.Code == '0000') {
                    $("#sp_recordCount").text(data.Count);
                } else {
                    $("#sp_recordCount").text('0');
                }
            }
        });
    });

    $("#dv_payRefresh").click(function () {
        $.ajax({
            url: "/main/payinfo",
            type: "post",
            dataType: "json",
            success: function (data) {
                if (data.Code == '0000') {
                    $("#sp_payMoney").text(data.Money);
                    $("#sp_payCount").text(data.Count);
                } else {                    
                }
            }
        });
    });

    $("#dv_incomeRefresh").click(function () {
        $.ajax({
            url: "/main/incomeinfo",
            type: "post",
            dataType: "json",
            success: function (data) {
                if (data.Code == '0000') {
                    $("#sp_incomeMoney").text(data.Money);
                    $("#sp_incomeCount").text(data.Count);
                } else {                 
                }
            }
        });
    });

})