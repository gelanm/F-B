// pages/my/set.js
var app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    userInfo: {},
    projectSource: 'https://github.com/liuxuanqiang/wechat-weapp-mall',
    userListInfo: [{
      id: 1,
      icon: '../../img/iconfont-dingdan.png',
      text: '补全信息',
      isunread: true,
      unreadNum: 3
    }, {
      id: 2,
      icon: '../../img/iconfont-card.png',
      text: '未分享的宝贝',
      isunread: false,
      unreadNum: 2
    }, {
      id: 3,
      icon: '../../img/iconfont-icontuan.png',
      text: '发布宝贝',
      isunread: true,
      unreadNum: 1
    }, {
      id: 4,
      icon: '../../img/iconfont-shouhuodizhi.png',
      text: '收货地址管理'
    }, {
      id: 5,
      icon: '../../img/iconfont-kefu.png',
      text: '联系客服'
    }, {
      id: 6,
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
    //调用应用实例的方法获取全局数据
    app.getUserInfo(function (userInfo) {
      //更新数据
      that.setData({
        userInfo: userInfo
      })
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