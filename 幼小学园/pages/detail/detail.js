var api = require('../../utils/api.js');

Page({
  data: {
    count: 10,
    pn: 0,
    list: [],
    showMore: true,
    showLoading: true,
    a: {},
    Bid: '',
    Aid: 0
  },
  //   添加订单  
  btn_default: function (e) {
    this.setData({
      Bid : e.target.dataset.idx      
    }
    )
    var a;
    var value = wx.getStorageSync('User')
    a = { "OpenId": value.OpenId, "RegisterId": value.Id, "Aid": this.data.Aid, "Bid": this.data.Bid, Head : {"name": "", "auth": "", "id":value.Id }}
    var response = api.Api('Orders', a);
    console.log("成功"); 
    
  },
  scrolltolower: function (e) {
    //console.log(e);
    if (!this.data.showMore) return;
    var that = this;
    try {
      var value = wx.getStorageSync('User')
      if (value) {
        // Do something with return value
        console.log(value)
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 0, "start": that.data.pn * that.data.count, "count": that.data.count }
        })
      }
    } catch (e) {
      // Do something when catch error
    }
    this.loadData(this.data.a);
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
  onLoad: function (options) {
    // 页面初始化 options为页面跳转所带来的参数
    var that = this;
    try {
      var value = wx.getStorageSync('User')
      if (value) {
        that.data.Aid = options.id;
        // Do something with return value
        console.log(value);
        console.log('test');
        console.log(that.data.Aid);
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 0, "start": 0, "count": that.data.count }
        })
      }
    } catch (e) {
      // Do something when catch error
    }
    console.log(this.data.a)
    this.loadData(this.data.a);
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