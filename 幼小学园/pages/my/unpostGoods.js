var api = require('../../utils/api.js');
var util = require('../../utils/util.js');
Page({
  data: {
    count:10,
    pn: 0,
    list: [],
    showMore: true,
    showLoading: true,
    a:{}
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
    var that = this;
    try {
      var value = wx.getStorageSync('User')
      if (value) {
        // Do something with return value
        console.log(value)
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 0,"Type": 0, "start": that.data.pn * that.data.count, "count": that.data.count }
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
      // console.log(Date.now());
      // console.log(new Date);
      // console.log(util.formatTime(new Date));
      // var datetime;
      // datetime = new Date("1476113456849");
    
      // console.log(datetime);
      // console.log(util.formatTime(datetime));
      // console.log(util.formatTime("1476113456849"));
      var storage = [];
      if (res.length > 0) {
        res.forEach(function (t) {
          //console.log(util.date('Y-m-d', (parseInt(t.AddTime.replace("/Date(", "").replace("-0000)/", ""))/1000).toString()))
          //console.log(Date.now())
          //console.log(new Date(t.AddTime))
          //console.log(new Date(t.AddTime.replace("/Date(", "").replace("-0000)/", "")))
          //console.log(t.AddTime.replace("/Date(", "").replace("-0000)/", ""))
          //var datetime;
          //datetime = new Date("1476113456849");
          storage.push({
            id: t.id,
            ContentValidity: t.ContentValidity,
            MainImage: t.MainImage,
            Price:t.Price,
            State:t.State,
            TableName:t.TableName,
            Title:t.Title,
            UserId:t.UserId,
            AddTime: util.getLocalTime(t.AddTime.replace("/Date(","").replace("-0000)/","")),
            PurchaseDate: util.getLocalTime( t.PurchaseDate.replace("/Date(", "").replace("-0000)/", "")),
            UpdateTime: util.getLocalTime(t.UpdateTime.replace("/Date(", "").replace("-0000)/", ""))
          })
        })
        this.setData({
          list: this.data.list.concat(storage),
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
        // Do something with return value
        console.log(value)
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 0,"Type": 0, "start": 0, "count": that.data.count }
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