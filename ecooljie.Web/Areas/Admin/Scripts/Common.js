jQuery.alert = function (message, type) {
    /// <summary>提示信息</summary>     
    /// <param name="message" type="String">需要提示的信息</param>        
    /// <param name="type" type="String">【info】【error】【question】【warning】</param>   
    if (type == null || type == undefined || type == "") {
        $.messager.alert('提示信息:', message, 'info');
    }
    else if (type == "info") {
        $.messager.alert('提示信息:', message, 'info');
    }
    else if (type == "error") {
        $.messager.alert('错误信息:', message, 'error');
    }
    else if (type == "question") {
        $.messager.alert('提示信息:', message, 'question');
    }
    else if (type == "warning") {
        $.messager.alert('警告信息:', message, 'warning');
    }

}