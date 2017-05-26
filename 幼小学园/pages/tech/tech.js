// pages/tech/tech.js
var api = require('../../utils/api.js');
Page({

  /**
   * 页面的初始数据
   */
  data: {
    count: 10,
    pn: 0,
    list: [],
    showMore: true,
    showLoading: true,
    a: {}
  },
  loadData: function (obj) {
    api.Api('viewGoods', obj).then(res => {
      console.log(res);
      if (res.length > 0) {
        this.setData({
          list: this.data.list.concat(res),
          showLoading: false,
          pn: this.data.pn + 1
        })
      } else {
        this.setData({
          showMore: false
        })
      }
    })
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this;
    try {
      var value = wx.getStorageSync('User')
      if (value) {
        // Do something with return value
        console.log(value)
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 0, "Type": 1, "start": 0, "count": that.data.count }
        })
      }
    } catch (e) {
      // Do something when catch error
    }
    console.log(this.data.a)
    this.loadData(this.data.a);
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
  
  }
})