﻿
function popMsg(txt) {
    var msg = $('<div class="msg hide">' + txt + '</div>');
    msg.css('left', '50%');
    $('body').append(msg);
    msg.css('margin-left', '-' + parseInt(msg.outerWidth() / 2) + 'px');
    msg.removeClass('hide');
    setTimeout(function () {
        msg.addClass('hide');
        setTimeout(function () {
            msg.remove();
        }, 400);
    }, 2600);
}

function closeDialog() {
    $('.dialog').removeClass('active');
    setTimeout(function () {
        $('.dialog').remove();
    }, 200);
}

function postDelete(url, id) {
    $.post(url, function (data) {
        $('#' + id).remove();
        if (data == 'ok' || data == 'OK')
            popMsg('删除成功');
        else
            popMsg(data);
        closeDialog();
    });
}


function deleteDialog(url, id) {
    var html = '<div class="dialog">' +
        '<h3 class="dialog-title">提示</h3>' +
        '<p>您确认要删除这条记录吗？</p>' +
        '<div class="dialog-buttons"><a href="javascript:postDelete(\'' + url + '\', \'' + id + '\')" class="button red">删除</a> <a href="javascript:closeDialog()" class="button blue">取消</a></div>' +
        '</div>';
    var dom = $(html);
    dom.css('margin-left', -(dom.outerWidth() / 2));
    $('body').append(dom);
    setTimeout(function () { dom.addClass('active'); }, 10);
}


//执行公司处理
function postDeal(id, real) {
    var url = "/Company/CompanyDeal/" + id + "?result=" + $("#sldeal").val();
    $.post(url, function (data) {
        if (data == 'ok' || data == 'OK')
            popMsg('处理成功');
        else
            popMsg(data);
        closeDialog();
    });
}

//公司处理
function dealDialog(id, name) {
    var html = '<div class="dialog">' +
        '<h3 class="dialog-title">提示</h3>' +
        '<p>公司处理</p>' +
        '<select name="sldeal" id="sldeal" class="textbox"><option value="1">通过</option><option value="2">拒绝</option>' +
        '</select><div class="dialog-buttons"><a href="javascript:postDeal(\'' + id + '\')" class="button blue">处理</a> <a href="javascript:closeDialog()" class="button blue">取消</a></div>' +
        '</div>';
    var dom = $(html);
    dom.css('margin-left', -(dom.outerWidth() / 2));
    $('body').append(dom);
    setTimeout(function () { dom.addClass('active'); }, 10);
}

function SetDate() {
    $('.date').datetimepicker({
        format: 'Y/m/d',
        timepicker: false,
    });
};

$(document).ready(function () {

});