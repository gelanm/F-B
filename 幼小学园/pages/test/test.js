// pages/test/test.js

var api = require('../../utils/api.js');

Page({
  data:{},
  onLoad:function(options){
    // 页面初始化 options为页面跳转所带来的参数
    //api.Api("CheckRenZheng",{ "Head": { "name": "testlu", "auth": "5fe5c78d1cbf4ebda27f2ef9d910624e", "id": 467598 } }).then(res=>{
    //   console.log(res);
    //   if(res.Status.IsSuccess){
    //     console.log(res.Status.IsSuccess)
    //   }else{
    //     console.log(res.Status.ErrorMessage)
    //   }
    // })
  },
  onReady:function(){
    // 页面渲染完成
  },
  onShow:function(){
    // 页面显示
  },
  onHide:function(){
    // 页面隐藏
  },
  onUnload:function(){
    // 页面关闭
  }
})