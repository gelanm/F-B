//var baseUrl = "https://api.test.com/api/api.ashx/json/";
var baseUrl = "https://api.test.com/apisk/json/reply/";

function fetchApi(name, param) {
    return new Promise((resolve,reject)=>{
        wx.request({
            url:`${baseUrl}${name}`,
            data:param,
            method:'POST',
            header:{
               'content-type':'josn' 
            },
            success:resolve,
            fail:reject
        })
    })
}

module.exports={
    Api:function(name,param){
        return fetchApi(name,param).then(res=>res.data)//.catch(rej=>rej.data)
    },
    getList: function (type, pn = 0, count = 10) {
      return fetchApi(type, { "start": pn * count, "count": count }).then(res => res.data)
    }
}