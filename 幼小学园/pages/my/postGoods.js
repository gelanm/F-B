var api = require('../../utils/api.js');

Page({
  data: {
    pn: { 'RegisterId': 1 },
    list: [],
    showMore: true,
    showLoading: true
  },
  redirect: function (e) {
    var id = e.currentTarget.dataset.id;
    wx.navigateTo({
      url: '/pages/detail/detail?id=' + id,
      success: function (res) {
        // success
      },
      fail: function (res) {
        // fail
      },
      complete: function (res) {
        // complete
      }
    })
  },
  scrolltolower: function (e) {
    //console.log(e);
    if (!this.data.showMore) return;
    this.loadData(this.data.pn);
  },
  loadData: function (pn) {
    api.Api('in_theaters', pn).then(res => {
      //console.log(res);
      if (res.subjects.length > 0) {
        this.setData({
          list: this.data.list.concat(res.subjects),
          showLoading: false,
          pn: pn + 1
        })
      } else {
        this.setData({
          showMore: false
        })
      }
    })
  },
  onLoad: function (options) {
    // 页面初始化 options为页面跳转所带来的参数
    this.loadData(this.data.pn);
  },
  onReady: function () {
    // 页面渲染完成
  },
  onShow: function () {
    // 页面显示
  },
  onHide: function () {
    // 页面隐藏
  },
  onUnload: function () {
    // 页面关闭
  }
})