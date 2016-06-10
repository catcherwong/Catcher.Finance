$(function () {
    $.ajax({
        url: "/main/user/getall",
        type: "post",
        dataType: "json",
        success: function (data) {
            if (data.Code == '0000') {
                var row = data.Row;
                $("#tb_user").empty();
                var sb = "";
                for (var i = 0; i < row.length; i++) {

                    sb += '<tr>';

                    sb += '<td style="width:20px"><div class="vd_checkbox">';
                    sb += '<input type="checkbox" id="checkbox-' + row[i].UserID + '" class="checkbox-group">';
                    sb += '<label for="checkbox-' + row[i].UserID + '"></label></div></td>';
                    sb += '<td>' + row[i].UserName + '</td>';
                    sb += '<td>' + row[i].UserGender + '</td>';
                    sb += '<td>' + row[i].UserEmail + '</td>';
                    sb += '<td>' + (row[i].UserState == '1' ? '<span class="label vd_bg-green append-icon">激活</span>' : '<span class="label vd_bg-red append-icon">扯淡</span>') + '</td>';
                    sb += '<td>' + getOpreation(row[i].UserState, row[i].UserID) + '</td>';
                    sb += "</tr>";
                }
                $(sb).appendTo($("#tb_user"));
            }
        }
    });
})

function getOpreation(state,id) {
    if (state == "1") {
        return '<a href="javascript:void(0)" data-toggle="modal" data-target="#lookUserDetialModal" onClick=lookUser(\'' + id + '\');>查看</a>'
    }else {
        return '<a href="javascript:void(0)" data-toggle="modal" data-target="#lookUserDetialModal" onClick=lookUser(\'' + id + '\');>查看</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:void(0)">激活</a>'
    }
}

function lookUser(id)
{

    $.ajax({
        url: "/main/user/getone",
        dataType: "json",
        data: { "id": id },
        type: "post",
        success: function (data) {
            if (data.code == '0000') {

                var row = data.row;
                $("#lbl_uName").text(row.userName);
                $("#lbl_gender").text(row.userGender);
                $("#lbl_email").text(row.userEmail);
                $("#lbl_state").text(row.userState);
            }
        }
    });
}
