//index.js
//获取应用实例
var api = require('../../utils/api.js');
var app = getApp()
Page({
  data: {
    motto: 'Hello World',
    userInfo: {},
    appid:app.appId,
    appsecret:app.appSecret,
  },
  //事件处理函数
  bindViewTap: function() {
    wx.navigateTo({
      url: '../logs/logs'
    })
  },
  onLoad: function () {
    var that = this
    wx.login({
      success: function(res) {
        console.log(res)
        if (res.code) {
          wx.getUserInfo({
                withCredentials:true,
                success: function(res1){
                  var a = { "Code":res.code,"IV":res1.iv,"EncryptedData":res1.encryptedData,"Head": { "name": "testlu", "auth": "5fe5c78d1cbf4ebda27f2ef9d910624e", "id": 467598 }}
                  api.Api("GetUnionId",a).then(res2=>{
                    //console.log(res2);
                    if(res2.Status.IsSuccess){
                      console.log(res2)
                    }else{
                      console.log(res2.Status.ErrorMessage)
                    }
                   })//.catch(rej=>{
                  //   console.log(rej)
                  // })
                  // success
                },
                fail: function(res1) {
                  // fail
                  //console.log(res1)
                },
                complete: function(res1) {
                  // complete
                  //console.log(res1)
                }
              })
          
          //发起网络请求
          // wx.request({
          //   url: 'https://api.weixin.qq.com/sns/jscode2session',
          //   data: {
          //     appid:that.data.appid,
          //     secret:that.data.appsecret,
          //     js_code: res.code,
          //     grant_type:'authorization_code'
          //   },
          //   header: {'content-type': 'json'},
          //   success: function(res) {
          //     console.log(res.data)
          //     wx.getUserInfo({
          //       withCredentials:true,
          //       success: function(res1){
          //         console.log(res1)
          //         console.log(that.data.appid)
          //         console.log(res.data.session_key)
          //         console.log(res1.encryptedData)
          //         console.log(res1.iv)
          //         // success
          //       },
          //       fail: function(res1) {
          //         // fail
          //         //console.log(res1)
          //       },
          //       complete: function(res1) {
          //         // complete
          //         //console.log(res1)
          //       }
          //     })
          //   }
          // })
        } else {
          console.log('获取用户登录态失败！' + res.errMsg)
        }
      }
    })

    console.log('onLoad')
    var that = this
    

    //调用应用实例的方法获取全局数据
    //app.withCredentials=true 
    app.getUserInfo(function(userInfo){
      console.log(userInfo)
      //更新数据
      that.setData({
        userInfo:userInfo
      })
    })
    
  }
})
