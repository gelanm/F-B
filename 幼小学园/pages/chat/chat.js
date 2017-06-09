// pages/chat/chat.js
var websocket = require('../../utils/websocket.js');


let socketOpen = false
let socketMsgQueue = ['name', 'age', 'sex', 'province', 'city']

Page({
  data: {
    fid: 2,
    tid: 3,
    isnull:false,
    message:"",
    text: "Page chat",
    userInfo: null,
    totalPeoples: [],
    msg: [{ type: 1, text: "dfsdfds", avatarUrl: "http://wx.qlogo.cn/mmopen/vi_32/PiajxSqBRaELEhicOciarUa8tL0SicyqpSyb6og0wdkwmTlamLmYeduSIIP2dD2DA2qPw7Uq8QNIshvPQClN6HULPg/0" }, { type: 1, text: "dsdfsfsdfsfdsfd", avatarUrl: "http://wx.qlogo.cn/mmopen/vi_32/PiajxSqBRaELEhicOciarUa8tL0SicyqpSyb6og0wdkwmTlamLmYeduSIIP2dD2DA2qPw7Uq8QNIshvPQClN6HULPg/0" }, { type: 2, text: "123123213213", avatarUrl: "http://wx.qlogo.cn/mmopen/vi_32/Q0j4TwGTfTIicWhBAYZ1lKRH0bIfoqj3NSksvzwiaXy9dciaib4zz1O8icAtO7ibkSopuHXu843BLC6YFlf9npF1IRWA/0" }],
  },
  MessageInput: function (e){
    this.setData({
      message:e.detail.value
    })
  },
  sendMessage: function (e){
    console.log(this.data.message)
    // var obj = '{"act": "l","userid":"2","auth":"1"}'
    // wx.sendSocketMessage({ data: obj })
    //websocket.send(obj);
    var obj = {
      act: 'm',
      tid: this.data.tid,
      fid: this.data.fid,
      text: this.data.message
    };
    //var a = '{"act": "m","tid":"3","fid":"2","text":"' + this.data.message + '"}'
    wx.sendSocketMessage({ data: JSON.stringify(obj) })
    var storage = [];
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
          UpdateTime: util.getLocalTime(t.UpdateTime.replace("/Date(", "").replace("-0000)/", ""))
        })
    this.setData({
      msg: this.data.msg.concat(storage)
    })
    msg

    //websocket.send(a);
  },
  onLoad(options) {
    // 页面初始化 options为页面跳转所带来的参数
console.log(this.data.msg)
    if(this.data.msg !=null)
    {
      this.setData({
        isnull: true
      })
    }
    const that = this
    this.getUserInfo((res) => {
      that
        .data
        .totalPeoples
        .push(res)
      that.setData({ totalPeoples: that.data.totalPeoples })
    })

    // websocket.connect(this.data.userInfo, function (res) {
    //   text = res.data + "\n" + text;
    //   that.setData({
    //     text: text
    //   });
    // })

    
    //创建一个 socket 连接(必须是wss协议)
    wx.connectSocket({
      // url: 'ws://localhost:3000',
      url: 'ws://192.168.6.235:8181',
      data: {
        x: '',
        y: ''
      },
      header: {
        'content-type': 'application/json'
      },
      method: 'GET',
      success: function (res) {
        console.log('connect success: ', res)
      },
      complete: function (res) {
        console.log('complete: ', res)
      },
      fail: function (err) {
        console.log('connect error: ', err)
      }
    })

    // 监听websocket打开事件
    wx.onSocketOpen(function (res) {
      console.log('WebSocket连接已经打开!')

      socketOpen = true
      //var obj = '{"act": "l","userid":"2","auth":"1"}'
      var obj = {
        act: 'l',
        userid: 2,
        auth: 1
      }
      wx.sendSocketMessage({data:JSON.stringify(obj)})
      // for (var i = 0, len = socketMsgQueue.length; i < len; i++) {
      //   sendSocketMessage(socketMsgQueue[i])
      // }    
    })

    // function sendSocketMessage(msg) {
    //   if (socketOpen) {
    //     wx.sendSocketMessage({ data: msg })
    //   } else {
    //     socketMsgQueue.push(msg)
    //   }
    // }

    // 监听WebSocket错误
    wx.onSocketError(function (res) {
        console.log('WebSocket连接打开失败, 请检查!')
    })

    // wx.sendSocketMessage 通过WebSocket连接发送数据, 需要先先 wx.connectSocket, 并在
    // wx.onSocketOpen 回调之后才能发送 监听WebSocket 接收到拂去其的消息事件
    wx.onSocketMessage(function (res) {
      console.log(JSON.parse(res.data))
      var msg = JSON.parse(event.data);
      if (msg.act == "m") {
        var usm = { toid: msg.fid, toname: msg.fname }
        console.log(msg.text)

        //_createSession(usm)
        //_showSession(msg.fid);
        //_appendusermsg(msg.text, msg.date);
      }
      else if (msg.act == "c") {
        var usc = { toid: msg.fid, toname: msg.fname }
        //_createSession(usc);
        //_appendwsmsg(msg.fname + "登录");
      }
      else if (msg.act == "d") {
        //_showSession(msg.fid);
        //_appendwsmsg(msg.fname + "退出");
      }
      else if (msg.act == "s") {
        //_appendwsmsg(msg.date + "  " + msg.text);
      }
      else if (msg.act == "ml") {
        //_showSession(msg.tid);
        //var id = $("#showusername").attr("oid");
        //$.each(msg.ml, function (key, val) {
          //if (val.fid == id) {
           // _appendownermsg(val.text, val.date);
         // }
         // else {
         //   _appendusermsg(val.text, val.date);
          //}
        //});
      }
      else if (msg.act == "um") {
        //var id = $("#showusername").attr("oid");
        //$.each(msg.ml, function (key, val) {
          var usm = { toid: val.fid, toname: val.fname }
        //  _createSession(usm)
        //  if (val.fid == id) {
        //    _appendownermsg(val.text, val.date);
        //  }
        //  else {
        //    _appendusermsg(val.text, val.date);
        //  }
        //});
      }


      //console.log('收到服务器内容: ' + res.data)
    })

    // // 关闭WebSocket连接 监听websocket连接
    // wx.onSocketClose(function (res) {
    //   console.log('WebSocket 已关闭!')
    // })
  },
  onReady: function () {
    // 页面渲染完成
  },
  onShow: function () {
    // 页面显示

  },
  onHide: function () {
    // 页面隐藏
    // 关闭socket
    wx.closeSocket()
      // socketMsgQueue = []
  },
  onUnload: function () {
    // 页面关闭
    // 关闭socket
    wx.closeSocket()
      // socketMsgQueue = []
  },
  getUserInfo(cb = () => { }) {
    var that = this
    if (this.data.userInfo) {
      typeof cb == "function" && cb(this.userInfo)
    } else {
      //调用登录接口
      wx.login({
        success: function () {
          wx.getUserInfo({
            success: function (res) {
              that.setData({ userInfo: res.userInfo })
              that.setData({ text: '个人信息' })
              typeof cb == "function" && cb(that.data.userInfo)
            }
          })
        }
      })
    }
  }
})
