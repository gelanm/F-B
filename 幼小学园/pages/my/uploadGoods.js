// pages/my/uploadGoods.js
//var PostData = require('../../js/PostData.js');
var api = require('../../utils/api.js');
Page({
  data: {
    titleClass: " ",
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
  },
  onLoad: function (options) {
    // 页面初始化 options为页面跳转所带来的参数
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
    // if (valueAll.desc.length === 0) {
    //   this.setData({
    //     "descClass": "descClass"
    //   })
    // }
    // if (!verifyHttp(valueAll.url) && valueAll.who.length > 0 && valueAll.type.length > 0 && valueAll.desc.length > 0) {
    // if (valueAll.title.length>0 && valueAll.who.length > 0 && valueAll.type.length > 0 && valueAll.desc.length > 0) {
    //   valueAll['debug'] = 'true';
    //   var options = {
    //     'data': valueAll
    //   }
      var a = { "Title": valueAll.title, "RegisterId": 1}
      api.Api("upload", a).then(res2 => {
        //console.log(res2);
        if (res2.Status.IsSuccess) {
          console.log(res2)
        } else {
          console.log(res2.Status.ErrorMessage)
        }
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
    })
    //}
  }
})



function verifyHttp(value) {
  var regex = /(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?/;
  return !regex.test(value)
}