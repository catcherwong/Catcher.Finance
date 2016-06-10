$(function () {
    initMoneyList();
})
function initMoneyList() {
    $.ajax({
        url: "/main/money/getall",
        type: "post",
        dataType: "json",
        success: function (data) {
            if (data.Code == '0000') {
                var row = data.Row;
                $("#tb_money").empty();
                var sb = "";
                for (var i = 0; i < row.length; i++) {
                    sb += '<tr>';
                    sb += '<td style="width:20px"><div class="vd_checkbox">';
                    sb += '<input type="checkbox" id="checkbox-' + row[i].MoneyId + '" class="checkbox-group">';
                    sb += '<label for="checkbox-' + row[i].MoneyId + '"></label></div></td>';
                    sb += '<td>' + row[i].UserName + '</td>';
                    sb += '<td>' + row[i].MoneyType + '</td>';
                    sb += '<td>' + row[i].CategoryName + '</td>';
                    sb += '<td>' + row[i].MoneyValue + '</td>';
                    sb += '<td>' + new Date(row[i].MoneyDate).Format("yyyy-MM-dd") + '</td>';
                    sb += '<td>' + row[i].MoneyAbout + '</td>';
                    sb += '<td><a href="javascript:void(0)" data-toggle="modal" data-target="#lookMoneyDetialModal" onclick=showDetial(\'' + row[i].MoneyId + '\');>查看</a></td>';
                    sb += "</tr>";
                }
                $(sb).appendTo($("#tb_money"));
            }
        }
    });
}
function showDetial(mid) {
    $.ajax({
        url: "/main/money/getmoneyrecord",
        dataType: "json",
        data: { "mid": mid },
        type: "post",
        success: function (data) {
            if (data.Code == '0000') {
                var row = data.Row;
                $("#lbl_uName").text(row.UserName);
                $("#lbl_type").text(row.MoneyType);
                $("#lbl_category").text(row.CategoryName);
                $("#lbl_money").text(row.MoneyValue);
                $("#lbl_date").text(new Date(row.MoneyDate).Format("yyyy-MM-dd"));
                $("#lbl_about").text(row.MoneyAbout);
            }
        }
    });
}

