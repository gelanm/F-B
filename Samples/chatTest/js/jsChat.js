var ws = null;
(function ($) {
    var owner = null;
    var settings = null;

    $.fn.extend({
        Chat: function (options) {
            owner = this;
            settings = $.extend({
                userid: '0',
                username: '',
                auth: '',
                InitUser: null
            }, options);

            _initChatBox();
            if (settings.InitUser != null) {
                var us = settings.InitUser();
                _createSession(us);
            }
            _connect(settings.url);
            _bind(this);
        }
    });
    function _bind(owner) {
        $(owner).find("#mjr_send").click(function () {
            var msg = $("#content").val();
            if (msg == "")
                return;
            _send(msg);
            $("#content").val('');
        });

        $(owner).find("#content").keydown(function (e) {
            if ($(this).val() == "")
                return;
            e = e || event;
            if (e.keyCode === 13) {
                _send($(this).val());
                $(this).val('');
            }
        });
    }
    //显示聊天
    function _showSession(uid) {
        $(owner).find(".chatconn").each(function (e) {
            if ($(this).attr("uid") == uid) {
                $(this).attr("act", "1");
                $(this).show();
            }
            else {
                $(this).attr("act", "0");
                $(this).hide();
            }
        });
        $(owner).find(".user").each(function (e) {
            if ($(this).attr("uid") == uid) {
                $(this).attr("act", "1");
                $(this).css('font-weight', 'bolder');
                $(this).addClass("nowchat");
            }
            else {
                $(this).attr("act", "0");
                $(this).css('font-weight', '');
                $(this).removeClass("nowchat");
            }
        });
    }
    //创建一个聊天
    function _createSession(us) {
        var q = "a[uid='" + us.toid + "']";
        var cnt = $(owner).find(q).size();
        if (cnt == 0) {
            var message = $("<div class='chatconn'></div>")
                            .attr("uid", us.toid)
                            .attr("id", "u" + us.toid);
            var userTab = $("<a class='user' act='1'></a>")
                            .attr("id", us.toname)
                            .attr("uid", us.toid)
                            .text(us.toname);
            userTab.click(function () {
                var uid = $(this).attr("uid");
                _showSession(uid);
            });
            $(owner).find("#title").append(userTab);
            //$(owner).append(message);
            $(message).insertBefore("#cl");
        }
        _showSession(us.toid);
    };
    //创建聊天界面
    function _initChatBox() {
        var inputBox = _createInputBox();
        var title = _createTitle();
        var cl = $("<div style='clear:both;height:60px;' id='cl'></div>");
        $(owner).append(title)
                .append(cl)
                .append(inputBox);
    };
    //创建输入
    function _createInputBox() {
        var content = $("<input type='text' maxlength='140' placeholder='请输入聊天内容' class='form-control' id='content' name='content'></input>");
        var img = $("<img src='img/sendtext.png'></img>");
        var send = $("<a class='login-field-icon' id='mjr_send'></a>")
                        .append(img);
        var inputbox = $("<div class='sendchat'></dev>")
                            .append(content)
                            .append(send);
        return inputbox;
    };
    //创建Title
    function _createTitle() {
        var user = $("<span id='showusername' style='display:none;'></span>")
                        .text(settings.username)
                        .attr("oid", settings.userid);
        var right = $("<span style='float:right; margin-right:10px;display:none;'></span>")
                        .append(user);
        var title = $("<div class='huihuaduixiang' id='title'></div>")
                        .append(right);
        return title;
    };

    //添加用户消息
    function _appendownermsg(msg, tm) {
        var uid = $(owner).find("a[act='1']").attr("uid");
        var t = $("<dd class='chattimes rt'></dd>").text(tm);
        var span = $("<span></span>").text(msg);
        var dd = $("<dd class='chatconns lt'></dd>")
                    .append(span);
        var img = $("<img src='img/loginmanout.jpg'></img>");
        var dt = $("<dt class='lt'></dt>")
                    .append(img);
        var div = $("<div style='clear:both;'></div>");
        var dl = $("<dl></dl>")
                    .append(dt)
                    .append(dd)
                    .append(t)
                    .append(div);

        var content = $("<section class='chatconitemlt'></section>")
            .append(dl);
        var q = "div[uid='" + uid + "']";
        var con = $(owner).find(q);
        $(owner).find(q).append(content);
        var sh = document.getElementById("u" + uid).scrollHeight;
        $(q).scrollTop(sh);
    };
    //添加朋友消息
    function _appendusermsg(msg, tm) {
        var uid = $(owner).find("a[act='1']").attr("uid");
        var t = $("<dd class='chattimes lt'></dd>").text(tm);

        var s = msg.indexOf("http");
        if (s > 0) {
            var a = msg.split("http://www.shcmsc.com/product.aspx?Id=");
            msg = msg.replace("http://www.shcmsc.com/product.aspx?Id=", "");
            s = "<a href='http://www.shcmsc.com/product.aspx?Id=" + a[1] + "'>链接</a>";
        }
        else {
            s = "";
        }

        var span = $("<span></span>").text(msg);
        var dd = $("<dd class='chatconns lt'></dd>")
                    .append(span)
                    .append(s);

        var img = $("<img src='img/loginmanout.jpg'></img>");
        var dt = $("<dt class='rt'></dt>")
                    .append(img);
        var div = $("<div style='clear:both;'></div>");
        var dl = $("<dl></dl>")
                    .append(t)
                    .append(dd)
                    .append(dt)
        var content = $("<section class='chatconitemrt'></section>")
            .append(dl);
        var q = "div[uid='" + uid + "']";
        $(owner).find(q).append(content);
        var sh = document.getElementById("u" + uid).scrollHeight;
        $(q).scrollTop(sh);
    };
    //添加系统消息
    function _appendwsmsg(msg) {
        var uid = $(owner).find("a[act='1']").attr("uid");
        var span = $("<span style='text-align:center;color:gray;'></span>").text(msg);
        var content = $("<section></section>")
            .append(span);
        var q = "div[uid='" + uid + "']";
        $(owner).find(q).append(content);
    };
    //登录
    function _login() {
        var obj = {
            act: 'l',
            userid: settings.userid,
            auth: settings.auth
        };
        ws.send(JSON.stringify(obj));
    }
    //连接用户
    function _connectuser(toUserId) {
        var obj = {
            act: 'c',
            fid: settings.userid,
            tid: toUserId
        };
        ws.send(JSON.stringify(obj));
    }
    //连接ws
    function _onopen() {
        if (ws == null)
            return;

        _login();
        if (settings.InitUser != null) {
            var us = settings.InitUser();
            _connectuser(us.toid);
        }
    };
    //监听消息
    function _onmessage(event) {
        var msg = JSON.parse(event.data);
        if (msg.act == "m") {
            var usm = { toid: msg.fid, toname: msg.fname }
            _createSession(usm)
            _showSession(msg.fid);
            _appendusermsg(msg.text, msg.date);
        }
        else if (msg.act == "c") {
            var usc = { toid: msg.fid, toname: msg.fname }
            _createSession(usc);
            _appendwsmsg(msg.fname + "登录");
        }
        else if (msg.act == "d") {
            _showSession(msg.fid);
            _appendwsmsg(msg.fname + "退出");
        }
        else if (msg.act == "s") {
            _appendwsmsg(msg.date + "  " + msg.text);
        }
        else if (msg.act == "ml") {
            _showSession(msg.tid);
            var id = $("#showusername").attr("oid");
            $.each(msg.ml, function (key, val) {
                if (val.fid == id) {
                    _appendownermsg(val.text, val.date);
                }
                else {
                    _appendusermsg(val.text, val.date);
                }
            });
        }
        else if (msg.act == "um") {
            var id = $("#showusername").attr("oid");
            $.each(msg.ml, function (key, val) {
                var usm = { toid: val.fid, toname: val.fname }
                _createSession(usm)
                if (val.fid == id) {
                    _appendownermsg(val.text, val.date);
                }
                else {
                    _appendusermsg(val.text, val.date);
                }
            });
        }
    };
    function _send(msg) {
        var toUserId = 0;
        $(owner).find('.user').each(function (e) {
            if ($(this).attr("act") == "1") {
                toUserId = parseInt($(this).attr("uid"));
            }
        });
        if (toUserId > 0) {
            _sendmessage(toUserId, msg);
            var data = new Date();
            var hours = data.getHours();
            var minutes = data.getMinutes();
            var tm = hours + ":" + minutes;
            _appendownermsg(msg);
        }
    };
    //发送消息
    function _sendmessage(toUserId, msg) {
        if (ws == null)
            return;
        var id = $("#showusername").attr("oid");
        var obj = {
            act: 'm',
            tid: toUserId,
            fid: id,
            text: msg
        };
        ws.send(JSON.stringify(obj));
    };
    function _onclose() {

    }
    //发生错误
    function _onerror() {        
        jump(15);
        $(owner).find(".sendchat").hide();
    };
    function jump(count) {
        window.setTimeout(function () {
            count--;
            if (count > 0) {
                _appendwsmsg('服务器(由于你停留时间超时)中断链接，请刷新页面.' + count);
                jump(count);
            } else {
                window.location.reload();
            }
        }, 1000);
    }
 
    //连接远程
    function _connect(url) {
        var wsImpl = window.WebSocket || window.MozWebSocket;
        try {
            //if ("WebSocket" in window) {
            //    ws = new WebSocket(url);
            //}
            //else if ("MozWebSocket" in window) {
            //    ws = new MozWebSocket(url);
            //}
			window.ws = new wsImpl(url);
            ws.onopen = _onopen;
            ws.onmessage = _onmessage;
            ws.onclose = _onclose;
            ws.onerror = _onerror;
        } catch (ex) {
            _appendwsmsg('远程无法连接');
            return;
        }
    };
})(jQuery);