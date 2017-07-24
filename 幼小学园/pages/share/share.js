var api = require('../../utils/api.js');
var util = require('../../utils/util.js');

Page({
  data: {
    count: 10,
    pn: 0,
    list: [],
    showMore: true,
    showLoading: true,
    a: {},
    region: ['上海市', '上海市', '嘉定区']
  },
  bindRegionChange: function (e) {
    console.log('picker发送选择改变，携带值为', e.detail.value)
    this.setData({
      region: e.detail.value
    })
    var that = this;
    try {
      var value = wx.getStorageSync('User')
      if (value) {
        // Do something with return value
        console.log(value)
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 2, "start": 0, "count": that.data.count, "Province": that.data.region[0], "City": that.data.region[1] }
        })
      }
    } catch (e) {
      // Do something when catch error
    }
    this.loadNewData(this.data.a);
  },
  redirect: function (e) {
    var id = e.currentTarget.dataset.idx;
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
  chat: function (e) {
    // var id = e.currentTarget.dataset.idx;
    // wx.navigateTo({
    //   url: '/pages/chat/chat?id=' + id,
    //   success: function (res) {
    //     // success
    //   },
    //   fail: function (res) {
    //     // fail
    //   },
    //   complete: function (res) {
    //     // complete
    //   }
    // })
    wx.showToast({
      title: "如果该商品未点击交换，请先点击交换，再进行聊天，2天内可取消交换。如果该商品已被交换，请耐心等待交换结束，先查看其它商品",
      icon: 'loading',
      duration: 6000
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
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 2, "start": that.data.pn * that.data.count, "count": that.data.count, "Province": that.data.region[0], "City": that.data.region[1]  }
        })
        
      }
    } catch (e) {
      // Do something when catch error
    }
    this.loadData(this.data.a);
  },
  loadData: function (obj) {
    api.Api('viewGoods2', obj).then(res => {
      console.log(res);
      var storage = [];
      if (res.length > 0) {
        res.forEach(function (t) {
          storage.push({
            id: t.id,
            ContentValidity: t.ContentValidity,
            MainImage: t.MainImage,
            Price: t.Price,
            State: t.State,
            TableName: t.TableName,
            Title: t.Title,
            UserId: t.UserId,
            AddTime: util.getLocalTime(t.AddTime.replace("/Date(", "").replace("-0000)/", "")),
            PurchaseDate: util.getLocalTime(t.PurchaseDate.replace("/Date(", "").replace("-0000)/", "")),
            UpdateTime: util.getLocalTime(t.UpdateTime.replace("/Date(", "").replace("-0000)/", "")),
            Remark:t.Remark
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
  loadNewData: function (obj) {
    api.Api('viewGoods2', obj).then(res => {
      console.log(res);
      var storage = [];
      if (res.length > 0) {
        res.forEach(function (t) {
          storage.push({
            id: t.id,
            ContentValidity: t.ContentValidity,
            MainImage: t.MainImage,
            Price: t.Price,
            State: t.State,
            TableName: t.TableName,
            Title: t.Title,
            UserId: t.UserId,
            AddTime: util.getLocalTime(t.AddTime.replace("/Date(", "").replace("-0000)/", "")),
            PurchaseDate: util.getLocalTime(t.PurchaseDate.replace("/Date(", "").replace("-0000)/", "")),
            UpdateTime: util.getLocalTime(t.UpdateTime.replace("/Date(", "").replace("-0000)/", "")),
            Remark: t.Remark
          })
        })
        this.setData({
          list: storage,
          showLoading: false,
          pn: this.data.pn + 1
        })
      } else {
        this.setData({
          showMore: false
        })
        this.setData({
          list: null
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
        var Region;
        if (value.User.Province.substr(value.User.Province.length-1,1)==="市")
        {
          Region[0] = value.User.Province
          Region[1] = value.User.Province
          Region[2] = value.User.City
          //console.log("市")
          //console.log("[" + value.User.Province + "," + value.User.Province + "," + value.User.City + "]")
          // that.setData({
          //   //region: "[" + value.User.Province + "," + value.User.Province + "," + value.User.City + "]"
          //   region: Region
          // })
        }else{
          Region[0] = value.User.Province
          Region[1] = value.User.City
          Region[2] = ""
          // that.setData({
          //   //region: "[" + value.User.Province + "," + value.User.City + ", ]"
          // })
        }
        that.setData({
          region: Region
        })
        console.log("1")
        console.log(that.data.region)
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 2, "start": 0, "count": that.data.count, "Province": that.data.region[0], "City": that.data.region[1] }
        })
        console.log(a);
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
    var that = this;
    try {
      var value = wx.getStorageSync('User')
      if (value) {
        // Do something with return value
        console.log(value)
        that.setData({
          a: { "OpenId": value.OpenId, "RegisterId": value.Id, "State": 1, "Type": 2, "start": 0, "count": that.data.count, "Province": that.data.region[0], "City": that.data.region[1]  }
        })
      }
    } catch (e) {
      // Do something when catch error
    }
    console.log(this.data.a)
    this.loadNewData(this.data.a);
  },
  onHide: function () {
    // 页面隐藏
  },
  onUnload: function () {
    // 页面关闭
  }
})
