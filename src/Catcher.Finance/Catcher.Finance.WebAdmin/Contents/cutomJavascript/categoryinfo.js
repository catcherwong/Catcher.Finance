$(function () {
    initCategoryList();

    $("#btn_AddCategory").click(function () {        
        $.ajax({
            url: "/main/category/add",
            type: "post",
            data: { "name": $("#addCategoryName").val() },
            dataType: "json",
            success: function (data) {
                if (data.Code == '0000') {                    
                    initCategoryList();
                    $("#addCategoryModal").modal("hide");
                } else {
                    alert("添加失败");
                }
            }
        });
    });

})

function initCategoryList() {
    $.ajax({
        url: "/main/category/getall",
        type: "post",
        dataType: "json",
        success: function (data) {
            if (data.Code == '0000') {                
                var row = data.Row;
                $("#tb_category").empty();
                var sb = "";
                for (var i = 0; i < row.length; i++) {

                    sb += '<tr>';

                    sb += '<td style="width:20px"><div class="vd_checkbox">';
                    sb += '<input type="checkbox" id="checkbox-' + row[i].Id + '" class="checkbox-group">';
                    sb += '<label for="checkbox-' + row[i].Id + '"></label></div></td>';
                    sb += '<td>' + row[i].Id + '</td>';
                    sb += '<td>' + row[i].CategoryName + '</td>';
                    sb += '<td><a href="javascript:void(0)" data-toggle="modal" data-target="#myModal"  data-original-title="edit" onclick="edit(\'' + row[i].Id + '\',\'' + row[i].CategoryName + '\')">编辑</a>&nbsp;&nbsp;&nbsp;<a href="javascript:void(0)" onclick="del(\'' + row[i].Id + '\')">删除</a></td>';
                    //sb += '<td>' + getOpreation(row[i].Id, row[i].CategoryName) + '</td>';
                    sb += "</tr>";
                }
                $(sb).appendTo($("#tb_category"));
            }
        }
    });
}

function edit(id, name) {
    $("#myModalLabel").text("修改分类信息");
    $("#categoryName").val(name);
    $("#btn_EditCategory").click(function () {
        $.ajax({
            url: "/main/category/edit",
            type: "post",
            data: { "Id": id, "CategoryName": $("#categoryName").val() },
            dataType: "json",
            success: function (data) {
                if (data.code == '0000') {
                    initCategoryList();
                    $("#myModal").modal("hide");
                } else {
                    alert("update faile");
                }
            }
        });
    });
}

function del(id) {
    $.ajax({
        url: "/main/category/delete",
        type: "post",
        data: { "id": id },
        dataType: "json",
        success: function (data) {
            if (data.Code == '0000') {
                initCategoryList();                
            } else {
                alert("删除失败");
            }
        }
    });
}

function addOrEdit(type) {    
    $("#saveCategory").click(function () {
        if (type == 1) {
            alert("add");
        } else {
            alert("edit");
        }
    });
}