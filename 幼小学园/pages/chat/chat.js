// pages/chat/chat.js
var websocket = require('../../utils/websocket.js');


let socketOpen = false
let socketMsgQueue = ['name', 'age', 'sex', 'province', 'city']

Page({
  data: {
    fid: 0,
    tid: 0,
    favatarUrl:'',
    isnull:false,
    message:"",
    text: "Page chat",
    userInfo: null,
    totalPeoples: [],
    msg: [],
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
    var value = wx.getStorageSync('User')

    var storage = [];
        storage.push({
          act: 'm',
          date: (new Date()).toLocaleDateString(),
          fid: this.data.fid,
          fname: value.avatarUrl,
          tid: this.data.tid,
          text: this.data.message,
          type: 2
        })
    this.setData({
      msg: this.data.msg.concat(storage)
    })
    // msg

    //websocket.send(a);
  },
  onLoad(options) {
    // 页面初始化 options为页面跳转所带来的参数
    //console.log(this.data.msg)
    if(this.data.msg !=null)
    {
      this.setData({
        isnull: true
      })
    }
    try {
      var value = wx.getStorageSync('User')
      //console.log(value)
      if(value){
        this.setData({fid: value.Id})
        this.setData({favatarUrl: value.avatarUrl})
        this.setData({tid:options.id})
      }
      console.log(this.data)
    }
    catch(e){

    }


    const that = this
    this.getUserInfo((res) => {
      that.data.totalPeoples.push(res)
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
      url: 'ws://flightingandblue.com:8181',
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
        userid: that.data.fid,
        auth: 1
      }
      wx.sendSocketMessage({data:JSON.stringify(obj)})
      var obj2 = {
        act: 'c',
        fid: that.data.fid,
        tid: that.data.tid
      }
      wx.sendSocketMessage({ data: JSON.stringify(obj2) })
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
       //console.log(res)
      // console.log(JSON.parse(res.data))
      var msg0 = JSON.parse(res.data);
      var storage = [];
      if (msg0.act == "m") {
        //var usm = { toid: msg0.fid, toname: msg0.fname }
         //console.log(msg0)
        // console.log(1);
        //console.log("m")
        storage.push({
          act: msg0.act,
          date: msg0.date,
          fid: msg0.fid,
          fname:msg0.fname,
          tid: that.data.fid,
          text: msg0.text,
          type: 1
        })
        // console.log(2);
        // console.log(that.data.msg);
        // console.log(3);
        that.setData({
          msg: that.data.msg.concat(storage)  
        })
        //console.log(that.data.msg)
        //_createSession(usm)
        //_showSession(msg.fid);
        //_appendusermsg(msg.text, msg.date);
      }
      else if (msg0.act == "c") {
        //var usc = { toid: msg0.fid, toname: msg0.fname }
        //_createSession(usc);
        //_appendwsmsg(msg.fname + "登录");
      }
      else if (msg0.act == "d") {
        //_showSession(msg.fid);
        //_appendwsmsg(msg.fname + "退出");
      }
      else if (msg0.act == "s") {
        //_appendwsmsg(msg.date + "  " + msg.text);
      }
      else if (msg0.act == "ml") {
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
        //console.log(msg0.ml)
        //console.log("ml")
        msg0.ml.forEach(function (t) {
          //console.log(t.fid)
          //console.log(that.data.fid)
          if (t.fid === that.data.fid)
          {
            storage.push({
              act: t.act,
              date: t.date,
              fid: t.fid,
              fname: t.fname,
              tid: t.tid,
              text: t.text,
              type: 2
            })
          }
          else
          {
            storage.push({
              act: t.act,
              date: t.date,
              fid: t.tid,
              fname: t.fname,
              tid: t.fid,
              text: t.text,
              type: 1
            })
          }
          that.setData({
            msg: that.data.msg.concat(storage)
          })
        })
        // var msg1 = JSON.parse(res.data.ml)
        // console.log(msg1)
        
        // console.log(that.data.msg)
      }
      else if (msg0.act == "um") {
        //var id = $("#showusername").attr("oid");
        //$.each(msg.ml, function (key, val) {
          //var usm = { toid: val.fid, toname: val.fname }
        //  _createSession(usm)
        //  if (val.fid == id) {
        //    _appendownermsg(val.text, val.date);
        //  }
        //  else {
        //    _appendusermsg(val.text, val.date);
        //  }
        //});
        console.log(msg0)
        msg0.ml.forEach(function (t) {
          // if (t.fid === that.data.fid) {
          //   storage.push({
          //     act: t.act,
          //     date: t.date,
          //     fid: t.fid,
          //     fname: t.fname,
          //     tid: t.tid,
          //     text: t.text,
          //     type: 2
          //   })
          // }
          // else {
          console.log(that.data.msg)
            storage.push({
              act: t.act,
              date: t.date,
              fid: t.tid,
              fname: t.fname,
              tid: t.fid,
              text: t.text,
              type: 1
            })
          //}
          that.setData({
            msg: that.data.msg.concat(storage)
          })
        })
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
