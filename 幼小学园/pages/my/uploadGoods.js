// pages/my/uploadGoods.js
//var PostData = require('../../js/PostData.js');
var api = require('../../utils/api.js');
Page({
  data: {
    UserId:" ",
    titleClass: " ",
    priceClass:" ",
    urlClass: " ",
    whoClass: " ",
    typeClass: " ",
    descClass: " ",
    tempFilePaths: " ",
    addTypeDis: false,
    actionType: true,
    actionSheetItems: ['Android ', 'iOS', '休息视频', '福利', '拓展资源', '前端', '瞎推荐', 'App'],
    addTypeData: "",
    callbackDesc: " ",
    toast1Hidden: true,
    date: '2017-01-01',
  },
  bindDateChange: function (e) {
    this.setData({
      date: e.detail.value
    })
  },
  onLoad: function (options) {
    // 页面初始化 options为页面跳转所带来的参数
    var that=this;
    var value = wx.getStorageSync('User')
    if (value) {
      // Do something with return value
      console.log(value)
      that.setData({
        UserId: value.Id
      })
    }
    // wx.getStorage({
    //   key: 'User',
    //   success: function (res) {
    //     console.log(res.data.Id)
    //     that.setData({
    //       UserId:res.data.Id
    //     })
    //   }
    // })
  },
  chooseimage: function () {
    var _this = this;
    wx.chooseImage({
      count: 9, // 默认9  
      sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有  
      sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有  
      success: function (res) {
        var tempFilePaths0 = res.tempFilePaths
        // 返回选定照片的本地文件路径列表，tempFilePath可以作为img标签的src属性显示图片  
        _this.setData({
          tempFilePaths: tempFilePaths0
        })
        console.log(tempFilePaths0)
        // wx.uploadFile({
        //   url: 'http://api.test.com/apisk/upload', //仅为示例，非真实的接口地址
        //   filePath: tempFilePaths0[0],
        //   name: 'file',
        //   formData: {
        //     'user': 'test'
        //   },
        //   success: function (res) {
        //     var data = res.data
        //     //do something
        //   }
        // })
      }
    })
  },
  // 验证是否为http
  // verifyHtpp: function (event) {
  //   var value = event.detail.value;
  //   if (verifyHttp(value)) {
  //     this.setData({
  //       "urlClass": "urlClass"
  //     })

  //   } else {
  //     this.setData({
  //       "urlClass": " "
  //     })
  //   }
  // },
  // 验证是否为数字
  verifyInt: function (event) {
    var value = event.detail.value;
    if (verifyInt(value)) {
      this.setData({
        "priceClass": "priceClass"
      })
    } else {
      this.setData({
        "priceClass": " "
      })
    }
  },
  // 验证不能为空
  verifyNotT: function (event) {
    var value = event.detail.value;
    if (value.length === 0) {
      this.setData({
        "titleClass": "titleClass"
      })
    } else {
      this.setData({
        "titleClass": " "
      })
    }
  },
  verifyNotK: function (event) {
    var value = event.detail.value;
    if (value.length === 0) {
      this.setData({
        "whoClass": "whoClass"
      })
    } else {
      this.setData({
        "whoClass": " "
      })
    }
  },
  verifyNotD: function (event) {
    var value = event.detail.value;
    if (value.length === 0) {
      this.setData({
        "descClass": "descClass"
      })
    } else {
      this.setData({
        "descClass": " "
      })
    }
  },

  // 类型验证
  addType: function (event) {
    this.setData({
      addTypeDis: true,
      actionType: false,
    })
  },

  bindItemTap: function (e) {
    this.setData({
      addTypeDis: false,
      actionType: true,
      addTypeData: e.currentTarget.dataset.name,
    })
  },

  actionSheetChange: function (e) {
    this.setData({
      addTypeDis: false,
      actionType: true,
    })
  },
  hiddenToast: function () {
    this.setData({
      toast1Hidden: true,
    })
  },
  // 表单提交
  formSubmit: function (e) {
    var _self = this;
    var valueAll = e.detail.value;
    if (valueAll.title.length === 0) {
      this.setData({
        "titleClass": "titleClass"
      })
    }
    if (verifyInt(valueAll.price) || (valueAll.price === 0)) {
      this.setData({
        "priceClass": "priceClass"
      })
    }
    // if (verifyHttp(valueAll.url)) {
    //   this.setData({
    //     "urlClass": "urlClass"
    //   })
    // }
    // if (valueAll.who.length === 0) {
    //   this.setData({
    //     "whoClass": "whoClass"
    //   })
    // }
    // if (valueAll.type.length === 0) {
    //   this.setData({
    //     "typeClass": "typeClass"
    //   })
    // }
    if (valueAll.desc.length === 0) {
      this.setData({
        "descClass": "descClass"
      })
    }
    // if (!verifyHttp(valueAll.url) && valueAll.who.length > 0 && valueAll.type.length > 0 && valueAll.desc.length > 0) {
    // if (valueAll.title.length>0 && valueAll.who.length > 0 && valueAll.type.length > 0 && valueAll.desc.length > 0) {
    //   valueAll['debug'] = 'true';
      // var options = {
      //   'data': valueAll
      // }
      // var a = { "Title": valueAll.title, "RegisterId": 1}
      // api.Api("upload", options).then(res2 => {
      //   //console.log(res2);
      //   if (res2.Status.IsSuccess) {
      //     console.log(res2)
      //   } else {
      //     console.log(res2.Status.ErrorMessage)
      //   }
    console.log(this.data)
    console.log(valueAll)
        wx.uploadFile({
          url: 'http://api.test.com/apisk/upload', //仅为示例，非真实的接口地址
          filePath: _self.data.tempFilePaths[0],
          name: 'file',
          formData: {
            "Title": valueAll.title,
            "RegisterId": _self.data.UserId,
            "PurchaseDate": _self.data.date,
            "Desc":valueAll.desc,
            "Price": valueAll.price,
            "Type":0
          },
          success: function (res) {
            console.log(res)
            wx.showToast({
              title: res.data,
              icon: 'success',
              duration: 2000
            })
            //do something
          }
        })
      // PostData(options, function (res) {
      //   if (res.data && !res.data.error) {
      //     _self.setData({
      //       toast1Hidden: false,
      //       callbackDesc: res.data.msg
      //     })
      //   } else {
      //     _self.setData({
      //       toast1Hidden: false,
      //       callbackDesc: res.data.msg
      //     })
      //   }
      // })
    //}
  }
})



function verifyHttp(value) {
  var regex = /(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?/;
  return !regex.test(value)
}
function verifyInt(value) {
  var regex = /^[0 - 9]\d*$/;
  return !regex.test(value)
}