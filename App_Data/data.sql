CREATE DATABASE `news`  DEFAULT CHARACTER SET utf8 ;



/*
MySQL Data Transfer
Source Host: 192.168.6.222
Source Database: new
Target Host: 192.168.6.222
Target Database: new
Date: 2017/5/7 10:44:34
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for book
-- ----------------------------
CREATE TABLE `book` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `liuyantitle` varchar(100) DEFAULT NULL,
  `liuyangcontent` varchar(100) DEFAULT NULL,
  `liuyantitme` date DEFAULT NULL,
  `hueifu` text,
  `lianxiren` varchar(100) DEFAULT NULL,
  `lianxidianhua` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for gsclass
-- ----------------------------
CREATE TABLE `gsclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `classname` varchar(100) DEFAULT NULL,
  `classid` int(4) DEFAULT NULL,
  `content` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for newsbig
-- ----------------------------
CREATE TABLE `newsbig` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `newsclass` varchar(100) DEFAULT NULL,
  `newsid` int(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for newscontent
-- ----------------------------
CREATE TABLE `newscontent` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT NULL,
  `faburen` varchar(100) DEFAULT NULL,
  `time` date DEFAULT NULL,
  `content` text,
  `hit` int(4) DEFAULT NULL,
  `keywords` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for user
-- ----------------------------
CREATE TABLE `user` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `userpass` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for wangzhan
-- ----------------------------
CREATE TABLE `wangzhan` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `gsname` varchar(100) DEFAULT NULL,
  `zongbu` varchar(100) DEFAULT NULL,
  `jidi` varchar(100) DEFAULT NULL,
  `dianhua` varchar(100) DEFAULT NULL,
  `chuanzheng` varchar(100) DEFAULT NULL,
  `youbian` varchar(100) DEFAULT NULL,
  `dizhi` varchar(100) DEFAULT NULL,
  `lianxiwm` varchar(500) DEFAULT NULL,
  `link` varchar(100) DEFAULT NULL,
  `linkname` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for goods
-- ----------------------------
CREATE TABLE `goods` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Title` varchar(60) NOT NULL,
  `MainImage` varchar(200) NOT NULL,
  `ContentValidity` varchar(1000) DEFAULT NULL,
  `PurchaseDate` datetime DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `State` varchar(4) NOT NULL DEFAULT '0',
  `type` varchar(10) DEFAULT NULL,
  `Remark` varchar(1000) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for WXUser
-- ----------------------------
CREATE TABLE `WXUser` (
  `Id` bigint(16) NOT NULL AUTO_INCREMENT,
  `OpenId` varchar(100) NOT NULL,
  `UnionId` varchar(100) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `Province` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Country` varchar(50) DEFAULT NULL,
  `Sex` int(11) DEFAULT NULL,
  `HeadimgUrl` varchar(250) DEFAULT NULL,
  `AccessToken` varchar(250) DEFAULT NULL,
  `RefreshToken` varchar(250) DEFAULT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `Memo` varchar(1000) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `gsclass` VALUES ('1', '公司简介', '1', '<p style=\"text-indent: 2em;font-size: 12pt;\">&nbsp;上海 &nbsp;</p>\r\n<p>\r\n上海 平台。\r\n</p>');
INSERT INTO `gsclass` VALUES ('2', '投资理念', '5', null);
INSERT INTO `gsclass` VALUES ('3', '旗下产品', '6', null);
INSERT INTO `gsclass` VALUES ('4', '核心团队', '4', null);
INSERT INTO `gsclass` VALUES ('5', '业务介绍', '1', '&nbsp;sadfsadfsadf&nbsp;');
INSERT INTO `gsclass` VALUES ('6', '信托结构', '7', null);
INSERT INTO `newsbig` VALUES ('1', '新闻动态', '0');
INSERT INTO `newsbig` VALUES ('2', '公司新闻', '1');
INSERT INTO `newsbig` VALUES ('3', '行业新闻', '1');
INSERT INTO `newsbig` VALUES ('4', '小动态', '1');
INSERT INTO `newsbig` VALUES ('5', '小动态', '1');
INSERT INTO `newsbig` VALUES ('6', '大动态', '0');
INSERT INTO `newscontent` VALUES ('3', 'test', 'test ', '2017-05-05', 'test\r\n@import url(http://localhost/houtai/CuteSoft_Client/CuteEditor/Load.ashx?type=style&file=SyntaxHighlighter.css);', '1', null);
INSERT INTO `user` VALUES ('1', 'admin', '202cb962ac59075b964b07152d234b70');
INSERT INTO `wangzhan` VALUES ('1', 'b', 'a', 'a', '1', '1', '1', 'b', '<span style=\"font-size: 11pt\">&nbsp;<br />\r\n传 真： 86-21-XXXXXXXX<br />\r\n<br />\r\n诚聘英才： XXXXXXXXXXX<br />\r\n<br />\r\n公司地址：上海市嘉定区曹安路1877号628室\r\n</span>', null, null);
