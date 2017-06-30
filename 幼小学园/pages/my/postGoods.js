var api = require('../../utils/api.js');
var util = require('../../utils/util.js');

Page({
  data: {
    count: 10,
    pn: 0,
    list: [],
    showMore: true,
    showLoading: true,
    a: {}
  }, 
  chat: function (e) {
    var id = e.currentTarget.dataset.idx;
    if(id === 0)
    {
      wx.showToast({
        title: "请稍候再试。",
        icon: 'false',
        duration: 2000
      })
      return
    }
    wx.navigateTo({
      url: '/pages/chat/chat?id=' + id,
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
  endExchange: function (e) {
    console.log("changeOver")
    console.log(e)
    var id = e.currentTarget.dataset.idx;
    console.log(id)
    var that = this;
    try {
      var value = wx.getStorageSync('User')
      if (value) {
        var b = { "OpenId": value.OpenId, "RegisterId": value.Id, "Id": id, Head: { "name": "", "auth": "", "id": value.Id }}
        api.Api('EndOrders', b).then(res => {
            console.log(res);
            if (res.IsSuccess == false) {
              wx.showToast({
                title: "失败",
                icon: 'false',
                duration: 2000
              })
            } else {
              wx.showToast({
                title: "成功",
                icon: 'success',
                duration: 2000
              })
              wx.navigateTo({
                url: '../my/unpostGoods'
              })
            }
          })
        }
      }
    catch (e) {
      // Do something when catch error
    }
  },
  // redirect: function (e) {
  //   console.log("redirect")
  //   console.log(e)
  //   var id = e.currentTarget.dataset.id;
  //   wx.navigateTo({
  //     url: '/pages/detail/detail?id=' + id,
  //     success: function (res) {
  //       // success
  //     },
  //     fail: function (res) {
  //       // fail
  //     },
  //     complete: function (res) {
  //       // complete
  //     }
  //   })
  // },
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
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 3, "start": that.data.pn * that.data.count, "count": that.data.count }
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
      var storage = [];
      if (res.length > 0) {
        // res.forEach(function (t) {
        //   storage.push({
        //     id: t.id,
        //     ContentValidity: t.ContentValidity,
        //     MainImage: t.MainImage,
        //     Price: t.Price,
        //     State: t.State,
        //     TableName: t.TableName,
        //     Title: t.Title,
        //     UserId: t.UserId,
        //     AddTime: util.getLocalTime(t.AddTime.replace("/Date(", "").replace("-0000)/", "")),
        //     PurchaseDate: util.getLocalTime(t.PurchaseDate.replace("/Date(", "").replace("-0000)/", "")),
        //     UpdateTime: util.getLocalTime(t.UpdateTime.replace("/Date(", "").replace("-0000)/", "")),
        //     unreadNum: parseInt(t.Remark),
        //     bool: parseInt(t.Remark)>0?true:false
        //   })
        // })
        res.forEach(function (t) {
          storage.push({
            objorders:t.objorders,
            objGoodsA: t.objGoodsA,
            objGoodsB: t.objGoodsB,
            unreadNum: parseInt(t.objGoodsB.Remark),
            bool: parseInt(t.objGoodsB.Remark)>0?true:false
          })
        })
        console.log(storage);
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
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 3, "start": 0, "count": that.data.count }
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