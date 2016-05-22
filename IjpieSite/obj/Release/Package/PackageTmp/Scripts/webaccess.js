var opt = {
    apiUr1l: "http://webapi20160424110903.azurewebsites.net/api",
    apiUrl2: "http://ijpieapi.azurewebsites.net/api"
}

var machineName = "";

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
window.getVMName = function (data) {
    machineName = data;
    var mac = document.getElementById('server');
    mac.value = machineName
    
}

//function getvmaccess() {
//    var webaccess = getParameterByName('accessToken');
//    $.ajax({
//        url: opt.apiUrl2 + "/VmAccess",
//        type: "get",
//        crossDomain: true,
//        data: {data:webaccess, format:"jsonp", callback:"getVMName"},
//        jsonp: 'callback',
//        dataType: 'jsonp',
//        jsonpCallback: "getVMName"
//    })
//}

function getvmaccess() {
    var webaccess = getParameterByName('accessToken');
    var vmname = $.ajax({
        url: opt.apiUrl2 + "/VmAccess",
        method: "GET",
        data: {data:webaccess, format:"jsonp", callback:"getVMName"},
        jsonp: 'callback',
        dataType: "jsonp",
        jsonpCallback: "getVMName",

    })
}

getvmaccess();


