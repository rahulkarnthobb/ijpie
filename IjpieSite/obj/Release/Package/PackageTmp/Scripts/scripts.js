var opt = {
    apiUr1l: "http://webapi20160424110903.azurewebsites.net/api",
    apiUrl2: "http://ijpieapi.azurewebsites.net/api"
}
var lst = "";
var lstSize = "";
window.getVMImgLst = function (data) {
    var osNum = data.length;
   
    for (var i = 0; i < osNum; i++) {
        lst += "<option value='" + data[i].Value + "'>" + data[i].Text + "</option>";
    }
    $("#imgListSelectBox").html(lst);
    $("#imgListLoader").hide();
}
var size;
window.getSize = function (data) {
    var osNum = data.length;

    for (var i = 0; i < osNum; i++) {
        lstSize += "<option value='" + data[i].Value + "'>" + data[i].Text + "</option>";
    }
    $("#macListSize").html(lstSize);
    
   
}
function getImageList() {
    $("#imgListLoader").show();
    var imgLstReq = $.ajax({
        url: opt.apiUrl2 + "/vmprovision",
        method: "GET",
        data: { format: "jsonp", callback: "getVMImgLst" },
        jsonp: 'callback',
        dataType: "jsonp",
        jsonpCallback: "getVMImgLst"
    })
}

function getVMSize() {
    $("#imgListLoader").show();
    var imgLstReq = $.ajax({
        url: opt.apiUrl2 + "/Vmsize",
        method: "GET",
        data: { format: "jsonp", callback: "getSize" },
        jsonp: 'callback',
        dataType: "jsonp",
        jsonpCallback: "getSize"
    })
}
getImageList();
getVMSize();
var i=-1;
$("#increaseVMSize").on("click", function (e) {
    $("#selectedMachineLabel").html(size[i++].Text);
    e.preventDefault();

    return false;
});
$("#decreaseVMSize").on("click", function (e) {
    if (i > 0) {
        $("#selectedMachineLabel").html(size[i--].Text);
    }
    e.preventDefault();

    return false;
});
$("#createMachineBtn").on("click", function (e) {
    var el = document.getElementById('macListSize');
    var size = el.options[el.selectedIndex].innerHTML;
    var OS = document.getElementById('imgListSelectBox');
    var textOS = OS.options[OS.selectedIndex].innerHTML;
    var OSname = OS.options[OS.selectedIndex].value;
    var emailadd = document.getElementById('EmailAddress').value;
    var add = emailadd.innerHTML;
    var usrName = userName;
    var vm = { Size: size, OS: textOS, user: usrName, email: emailadd, OSName: OSname };
    $.ajax({
        url: opt.apiUrl2 + "/VmCreate",
        type: "get",
        crossDomain: true,
        data: vm,
        dataType:'jsonp',
        contentType: "application/json;charset=utf-8",
        success: function () {
            
                window.location.href = '/Success/Index' // redirect to another page
            }
        
    });
    alert(vm);
    e.preventDefault();
    return false;
});