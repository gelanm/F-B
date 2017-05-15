//var baseUrl = "http://192.168.6.231:9000/api.ashx/json/";
//var baseUrl = "http://localhost/ServiceAPI/api.ashx/json/";
//var baseUrl = "http://192.168.6.235/ServiceAPI/api.ashx/json/";
//var baseUrl = "http://m.shcmsc.com/iServiceAPI/api.ashx/json/";
//var baseUrl = "http://testserviceapi.shcmsc.com:8000/ServiceApi/api.ashx/";
//var baseUrl = "http://m.shcmsc.com/ServiceApi/api.ashx/";
var baseUrl = "http://localhost:10038/json/reply/";
function api(name, param) {
    var result;
    var url = baseUrl + name;
    var htmlobj = $.ajax({
        type: 'post',
        url: url,
        dataType: 'json',
        async: false, 
        data: JSON.stringify(param),
        contentType: 'application/json',
        success: function (data) {
            result = data;
        },
        error: function (xhr, testStatus, error) {
            //var d = JSON.parse(xhr.responseText);
            //var data = { Status: { IsSuccess: 'false', ErrorMessage: d.ResponseStatus.Errors[0].Message} };
            //result = data;
            result = error;
        }
    });
    return result;
}


function MessageAdd(parm)
{
    var data = api("MessageAdd", param);
    return data;
}

