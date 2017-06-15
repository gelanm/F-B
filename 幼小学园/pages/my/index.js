// pages/my/index.js
var api = require('../../utils/api.js');
var app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    userInfo: {},
    //projectSource: 'https://github.com/liuxuanqiang/wechat-weapp-mall',
    userListInfo: [{
      id: 'postGoods',
      icon: '../../img/iconfont-dingdan.png',
      text: '已分享的宝贝',
      isunread: false,
      unreadNum: 3
    }, {
        id: 'unpostGoods',
        icon: '../../img/iconfont-card.png',
        text: '未分享的宝贝',
      isunread: false,
      unreadNum: 2
    }, {
        id: 'uploadGoods',
        icon: '../../img/iconfont-icontuan.png',
      text: '发布宝贝',
      isunread: false,
      unreadNum: 1
    }, {
      id: 'uploadTech',
      icon: '../../img/iconfont-icontuan.png',
      text: '发布技术视频',
      isunread: false,
      unreadNum: 1
    }, {
        id: 'mapAddress',
        icon: '../../img/iconfont-shouhuodizhi.png',
      text: '收货地址管理'
    }, {
        id: 'chat',
        icon: '../../img/iconfont-kefu.png',
      text: '联系客服'
    }, {
        id: 'problem',
        icon: '../../img/iconfont-help.png',
        text: '常见问题'
    }, {
        id: 'set',
      icon: '../../img/set.png',
      text: '设置'
    }]
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this
    wx.login({
      success: function (res) {
        console.log(res)
        if (res.code) {
          wx.getUserInfo({
            withCredentials: true,
            success: function (res1) {
              that.setData({
                userInfo: res1.userInfo
              })
              var a = { "Code": res.code, "IV": res1.iv, "EncryptedData": res1.encryptedData}
              api.Api("WXUser", a).then(res2 => {
                //console.log(res2);
                if (res2.Status.IsSuccess) {
                  console.log(res2)
                  wx.setStorage({
                    key: "User",
                    data: res2
                  })
                } else {
                  console.log(res2.Status.ErrorMessage)
                }
              })//.catch(rej=>{
              //   console.log(rej)
              // })
              // success
            },
            fail: function (res1) {
              // fail
              //console.log(res1)
            },
            complete: function (res1) {
              // complete
              //console.log(res1)
            }
          })
    //调用应用实例的方法获取全局数据
  //   app.getUserInfo(function (userInfo) {
  //     //更新数据
  //     that.setData({
  //       userInfo: userInfo
  //     })
  //   })
        }
      }
    })
    wx.getLocation({
      type: 'wgs84',
      success: function (res) {
        var latitude = res.latitude
        var longitude = res.longitude
        var speed = res.speed
        var accuracy = res.accuracy
        console.log(res)
      }
    })
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {
  
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {
  
  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {
  
  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {
  
  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {
  
  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
  
  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {
  
  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
  
  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {
  
  }
})