var OxO3da8=["hiddenDirectory","hiddenFile","hiddenAlert","hiddenAction","hiddenActionData","This function is disabled in the demo mode.","disabled","[[Disabled]]","[[SpecifyNewFolderName]]","","value","createdir","[[CopyMoveto]]","/","move","copy","[[AreyouSureDelete]]","parentNode","text","isdir","true",".","[[SpecifyNewFileName]]","rename","path","True","False",":","FoldersAndFiles","TR","length","this.bgColor=\x27#eeeeee\x27;","onmouseover","this.bgColor=\x27\x27;","onmouseout","nodeName","INPUT","changedir","url","TargetUrl","htmlcode","onload","getElementsByTagName","table","sortable","className"," ","id","rows","cells","innerHTML","\x3Ca href=\x22#\x22 onclick=\x22ts_resortTable(this);return false;\x22\x3E","\x3Cspan class=\x22sortarrow\x22\x3E\x26nbsp;\x3C/span\x3E\x3C/a\x3E","string","undefined","innerText","childNodes","nodeValue","nodeType","span","cellIndex","TABLE","sortdir","down","\x26uarr;","up","\x26darr;","sortbottom","tBodies","sortarrow","\x26nbsp;","20","19","Form1","Image1","FolderDescription","CreateDir","Copy","Move","Delete","DoRefresh","name_Cell","size_Cell","op_Cell","row0","row0_cb","divpreview","Width","Height","AutoStart","ShowControls","ShowStatusBar","WindowlessVideo","Button1","Button2","btn_zoom_in","btn_zoom_out","btn_Actualsize","checked","\x3Cembed name=\x22MediaPlayer1\x22 src=\x22","\x22 autostart=\x22","\x22 showcontrols=\x22","\x22  windowlessvideo=\x22","\x22 showstatusbar=\x22","\x22 width=\x22","\x22 height=\x22","\x22 type=\x22application/x-mplayer2\x22 pluginspage=\x22http://www.microsoft.com/Windows/MediaPlayer\x22 \x3E\x3C/embed\x3E\x0A","\x3Cobject classid=\x22CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95\x22 "," codebase=\x22http://activex.microsoft.com/activex/"," controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902\x22 "," standby=\x22Loading Microsoft Windows Media Player components...\x22 "," type=\x22application/x-oleobject\x22","  height=\x22","\x22 \x3E","\x3Cparam name=\x22FileName\x22 value=\x22","\x22/\x3E","\x3Cparam name=\x22autoStart\x22 value=\x22","\x3Cparam name=\x22showControls\x22 value=\x22","\x3Cparam name=\x22showstatusbar\x22 value=\x22","\x3Cparam name=\x22windowlessvideo\x22 value=\x22","\x3C/object\x3E","onunload","onbeforeunload","Please choose a Media movie to insert","\x22 windowlessvideo=\x22","zoom","style","wrapupPrompt","iepromptfield","display","none","body","div","IEPromptBox","promptBlackout","border","1px solid #b0bec7","backgroundColor","#f0f0f0","position","absolute","width","330px","zIndex","100","\x3Cdiv style=\x22width: 100%; padding-top:3px;background-color: #DCE7EB; font-family: verdana; font-size: 10pt; font-weight: bold; height: 22px; text-align:center; background:url(Load.ashx?type=image\x26file=formbg2.gif) repeat-x left top;\x22\x3E[[InputRequired]]\x3C/div\x3E","\x3Cdiv style=\x22padding: 10px\x22\x3E","\x3CBR\x3E\x3CBR\x3E","\x3Cform action=\x22\x22 onsubmit=\x22return wrapupPrompt()\x22\x3E","\x3Cinput id=\x22iepromptfield\x22 name=\x22iepromptdata\x22 type=text size=46 value=\x22","\x22\x3E","\x3Cbr\x3E\x3Cbr\x3E\x3Ccenter\x3E","\x3Cinput type=\x22submit\x22 value=\x22\x26nbsp;\x26nbsp;\x26nbsp;[[OK]]\x26nbsp;\x26nbsp;\x26nbsp;\x22\x3E","\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;","\x3Cinput type=\x22button\x22 onclick=\x22wrapupPrompt(true)\x22 value=\x22\x26nbsp;[[Cancel]]\x26nbsp;\x22\x3E","\x3C/form\x3E\x3C/div\x3E","top","100px","offsetWidth","left","px","block","CuteEditor_ColorPicker_ButtonOver(this)"];var hiddenDirectory=Window_GetElement(window,OxO3da8[0x0],true);var hiddenFile=Window_GetElement(window,OxO3da8[0x1],true);var hiddenAlert=Window_GetElement(window,OxO3da8[0x2],true);var hiddenAction=Window_GetElement(window,OxO3da8[0x3],true);var hiddenActionData=Window_GetElement(window,OxO3da8[0x4],true); function CreateDir_click(){if(isDemoMode){ alert(OxO3da8[0x5]) ;return false;} ;if(Event_GetSrcElement()[OxO3da8[0x6]]){ alert(OxO3da8[0x7]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox19b,OxO3da8[0x8],OxO3da8[0x9]) ; function Ox19b(Ox300){if(Ox300){ hiddenActionData[OxO3da8[0xa]]=Ox300 ; hiddenAction[OxO3da8[0xa]]=OxO3da8[0xb] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox300=prompt(OxO3da8[0x8],OxO3da8[0x9]);if(Ox300){ hiddenActionData[OxO3da8[0xa]]=Ox300 ;return true;} else {return false;} ;return false;} ;}  ; function Move_click(){if(isDemoMode){ alert(OxO3da8[0x5]) ;return false;} ;if(Event_GetSrcElement()[OxO3da8[0x6]]){ alert(OxO3da8[0x7]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox19b,OxO3da8[0xc],OxO3da8[0xd]) ; function Ox19b(Ox300){if(Ox300){ hiddenActionData[OxO3da8[0xa]]=Ox300 ; hiddenAction[OxO3da8[0xa]]=OxO3da8[0xe] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox300=prompt(OxO3da8[0xc],OxO3da8[0xd]);if(Ox300){ hiddenActionData[OxO3da8[0xa]]=Ox300 ;return true;} else {return false;} ;return false;} ;}  ; function Copy_click(){if(isDemoMode){ alert(OxO3da8[0x5]) ;return false;} ;if(Event_GetSrcElement()[OxO3da8[0x6]]){ alert(OxO3da8[0x7]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox19b,OxO3da8[0xc],OxO3da8[0xd]) ; function Ox19b(Ox300){if(Ox300){ hiddenActionData[OxO3da8[0xa]]=Ox300 ; hiddenAction[OxO3da8[0xa]]=OxO3da8[0xf] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox300=prompt(OxO3da8[0xc],OxO3da8[0xd]);if(Ox300){ hiddenActionData[OxO3da8[0xa]]=Ox300 ;return true;} else {return false;} ;return false;} ;}  ; function Delete_click(){if(isDemoMode){ alert(OxO3da8[0x5]) ;return false;} ;if(Event_GetSrcElement()[OxO3da8[0x6]]){ alert(OxO3da8[0x7]) ;return false;} ;return confirm(OxO3da8[0x10]);}  ; function EditImg_click(img){if(isDemoMode){ alert(OxO3da8[0x5]) ;return false;} ;if(img[OxO3da8[0x6]]){ alert(OxO3da8[0x7]) ;return false;} ;var Ox305=img[OxO3da8[0x11]][OxO3da8[0x11]];var Ox306=Ox305[OxO3da8[0x12]];var name;var Ox307;if(Browser_IsOpera()){ Ox307=Ox305.getAttribute(OxO3da8[0x13])==OxO3da8[0x14] ;} else { Ox307=Ox305[OxO3da8[0x13]] ;} ;if(Browser_IsIE7()){var Oxc3;if(Ox307){ IEprompt(Ox19b,OxO3da8[0x8],Ox306) ;} else {var i=Ox306.lastIndexOf(OxO3da8[0x15]); Oxc3=Ox306.substr(i) ;var Ox12=Ox306.substr(0x0,Ox306.lastIndexOf(OxO3da8[0x15])); IEprompt(Ox19b,OxO3da8[0x16],Ox12) ;} ; function Ox19b(Ox300){if(Ox300&&Ox300!=Ox305[OxO3da8[0x12]]){if(!Ox307){ Ox300=Ox300+Oxc3 ;} ; hiddenAction[OxO3da8[0xa]]=OxO3da8[0x17] ; hiddenActionData[OxO3da8[0xa]]=(Ox307?OxO3da8[0x19]:OxO3da8[0x1a])+OxO3da8[0x1b]+Ox305[OxO3da8[0x18]]+OxO3da8[0x1b]+Ox300 ; window.PostBackAction() ;} ;}  ;} else {if(Ox307){ name=prompt(OxO3da8[0x8],Ox306) ;} else {var i=Ox306.lastIndexOf(OxO3da8[0x15]);var Oxc3=Ox306.substr(i);var Ox12=Ox306.substr(0x0,Ox306.lastIndexOf(OxO3da8[0x15])); name=prompt(OxO3da8[0x16],Ox12) ;if(name){ name=name+Oxc3 ;} ;} ;if(name&&name!=Ox305[OxO3da8[0x12]]){ hiddenAction[OxO3da8[0xa]]=OxO3da8[0x17] ; hiddenActionData[OxO3da8[0xa]]=(Ox307?OxO3da8[0x19]:OxO3da8[0x1a])+OxO3da8[0x1b]+Ox305[OxO3da8[0x18]]+OxO3da8[0x1b]+name ; window.PostBackAction() ;} ;} ;return Event_CancelEvent();}  ; setMouseOver() ; function setMouseOver(){var FoldersAndFiles=Window_GetElement(window,OxO3da8[0x1c],true);var Ox30a=FoldersAndFiles.getElementsByTagName(OxO3da8[0x1d]);for(var i=0x0;i<Ox30a[OxO3da8[0x1e]];i++){var Ox305=Ox30a[i]; Ox305[OxO3da8[0x20]]= new Function(OxO3da8[0x9],OxO3da8[0x1f]) ; Ox305[OxO3da8[0x22]]= new Function(OxO3da8[0x9],OxO3da8[0x21]) ;} ;}  ; function row_click(Ox305){var Ox307;if(Browser_IsOpera()){ Ox307=Ox305.getAttribute(OxO3da8[0x13])==OxO3da8[0x14] ;} else { Ox307=Ox305[OxO3da8[0x13]] ;} ;if(Ox307){if(Event_GetSrcElement()[OxO3da8[0x23]]==OxO3da8[0x24]){return ;} ; hiddenAction[OxO3da8[0xa]]=OxO3da8[0x25] ; hiddenActionData[OxO3da8[0xa]]=Ox305.getAttribute(OxO3da8[0x18]) ; window.PostBackAction() ;} else {var Ox102=Ox305.getAttribute(OxO3da8[0x18]); hiddenFile[OxO3da8[0xa]]=Ox102 ;var Ox205=Ox305.getAttribute(OxO3da8[0x26]); Window_GetElement(window,OxO3da8[0x27],true)[OxO3da8[0xa]]=Ox205 ;var htmlcode=Ox305.getAttribute(OxO3da8[0x28]);if(htmlcode!=OxO3da8[0x9]&&htmlcode!=null){ do_preview(htmlcode) ;} else {try{ Actualsize() ;} catch(x){ do_preview() ;} ;} ;} ;}  ; function do_preview(){}  ; function reset_hiddens(){if(hiddenAlert[OxO3da8[0xa]]){ alert(hiddenAlert.value) ;} ; hiddenAlert[OxO3da8[0xa]]=OxO3da8[0x9] ; hiddenAction[OxO3da8[0xa]]=OxO3da8[0x9] ; hiddenActionData[OxO3da8[0xa]]=OxO3da8[0x9] ;}  ; Event_Attach(window,OxO3da8[0x29],reset_hiddens) ; function RequireFileBrowseScript(){}  ; function Actualsize(){}  ; Event_Attach(window,OxO3da8[0x29],sortables_init) ;var SORT_COLUMN_INDEX; function sortables_init(){if(!document[OxO3da8[0x2a]]){return ;} ;var Ox30f=document.getElementsByTagName(OxO3da8[0x2b]);for(var Ox310=0x0;Ox310<Ox30f[OxO3da8[0x1e]];Ox310++){var Ox311=Ox30f[Ox310];if(((OxO3da8[0x2e]+Ox311[OxO3da8[0x2d]]+OxO3da8[0x2e]).indexOf(OxO3da8[0x2c])!=-0x1)&&(Ox311[OxO3da8[0x2f]])){ ts_makeSortable(Ox311) ;} ;} ;}  ; function ts_makeSortable(Ox313){if(Ox313[OxO3da8[0x30]]&&Ox313[OxO3da8[0x30]][OxO3da8[0x1e]]>0x0){var Ox314=Ox313[OxO3da8[0x30]][0x0];} ;if(!Ox314){return ;} ;for(var i=0x2;i<0x4;i++){var Ox315=Ox314[OxO3da8[0x31]][i];var Ox200=ts_getInnerText(Ox315); Ox315[OxO3da8[0x32]]=OxO3da8[0x33]+Ox200+OxO3da8[0x34] ;} ;}  ; function ts_getInnerText(Ox27){if( typeof Ox27==OxO3da8[0x35]){return Ox27;} ;if( typeof Ox27==OxO3da8[0x36]){return Ox27;} ;if(Ox27[OxO3da8[0x37]]){return Ox27[OxO3da8[0x37]];} ;var Ox24=OxO3da8[0x9];var Ox2c1=Ox27[OxO3da8[0x38]];var Ox11=Ox2c1[OxO3da8[0x1e]];for(var i=0x0;i<Ox11;i++){switch(Ox2c1[i][OxO3da8[0x3a]]){case 0x1: Ox24+=ts_getInnerText(Ox2c1[i]) ;break ;case 0x3: Ox24+=Ox2c1[i][OxO3da8[0x39]] ;break ;;;} ;} ;return Ox24;}  ; function ts_resortTable(Ox318){var Ox224;for(var Ox319=0x0;Ox319<Ox318[OxO3da8[0x38]][OxO3da8[0x1e]];Ox319++){if(Ox318[OxO3da8[0x38]][Ox319][OxO3da8[0x23]]&&Ox318[OxO3da8[0x38]][Ox319][OxO3da8[0x23]].toLowerCase()==OxO3da8[0x3b]){ Ox224=Ox318[OxO3da8[0x38]][Ox319] ;} ;} ;var Ox31a=ts_getInnerText(Ox224);var Ox31b=Ox318[OxO3da8[0x11]];var Ox31c=Ox31b[OxO3da8[0x3c]];var Ox313=getParent(Ox31b,OxO3da8[0x3d]);if(Ox313[OxO3da8[0x30]][OxO3da8[0x1e]]<=0x1){return ;} ;var Ox31d=ts_getInnerText(Ox313[OxO3da8[0x30]][0x1][OxO3da8[0x31]][Ox31c]);var Ox31e=ts_sort_caseinsensitive;if(Ox31d.match(/^\d\d[\/-]\d\d[\/-]\d\d\d\d$/)){ Ox31e=ts_sort_date ;} ;if(Ox31d.match(/^\d\d[\/-]\d\d[\/-]\d\d$/)){ Ox31e=ts_sort_date ;} ;if(Ox31d.match(/^[?]/)){ Ox31e=ts_sort_currency ;} ;if(Ox31d.match(/^[\d\.]+$/)){ Ox31e=ts_sort_numeric ;} ; SORT_COLUMN_INDEX=Ox31c ;var Ox314= new Array();var Ox31f= new Array();for(var i=0x0;i<Ox313[OxO3da8[0x30]][0x0][OxO3da8[0x1e]];i++){ Ox314[i]=Ox313[OxO3da8[0x30]][0x0][i] ;} ;for(var j=0x1;j<Ox313[OxO3da8[0x30]][OxO3da8[0x1e]];j++){ Ox31f[j-0x1]=Ox313[OxO3da8[0x30]][j] ;} ; Ox31f.sort(Ox31e) ;if(Ox224.getAttribute(OxO3da8[0x3e])==OxO3da8[0x3f]){var Ox320=OxO3da8[0x40]; Ox31f.reverse() ; Ox224.setAttribute(OxO3da8[0x3e],OxO3da8[0x41]) ;} else { Ox320=OxO3da8[0x42] ; Ox224.setAttribute(OxO3da8[0x3e],OxO3da8[0x3f]) ;} ;for( i=0x0 ;i<Ox31f[OxO3da8[0x1e]];i++){if(!Ox31f[i][OxO3da8[0x2d]]||(Ox31f[i][OxO3da8[0x2d]]&&(Ox31f[i][OxO3da8[0x2d]].indexOf(OxO3da8[0x43])==-0x1))){ Ox313[OxO3da8[0x44]][0x0].appendChild(Ox31f[i]) ;} ;} ;for( i=0x0 ;i<Ox31f[OxO3da8[0x1e]];i++){if(Ox31f[i][OxO3da8[0x2d]]&&(Ox31f[i][OxO3da8[0x2d]].indexOf(OxO3da8[0x43])!=-0x1)){ Ox313[OxO3da8[0x44]][0x0].appendChild(Ox31f[i]) ;} ;} ;var Ox321=document.getElementsByTagName(OxO3da8[0x3b]);for(var Ox319=0x0;Ox319<Ox321[OxO3da8[0x1e]];Ox319++){if(Ox321[Ox319][OxO3da8[0x2d]]==OxO3da8[0x45]){if(getParent(Ox321[Ox319],OxO3da8[0x2b])==getParent(Ox318,OxO3da8[0x2b])){ Ox321[Ox319][OxO3da8[0x32]]=OxO3da8[0x46] ;} ;} ;} ; Ox224[OxO3da8[0x32]]=Ox320 ;}  ; function getParent(Ox27,Ox323){if(Ox27==null){return null;} else {if(Ox27[OxO3da8[0x3a]]==0x1&&Ox27[OxO3da8[0x23]].toLowerCase()==Ox323.toLowerCase()){return Ox27;} else {return getParent(Ox27.parentNode,Ox323);} ;} ;}  ; function ts_sort_date(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO3da8[0x31]][SORT_COLUMN_INDEX]);var Ox326=ts_getInnerText(b[OxO3da8[0x31]][SORT_COLUMN_INDEX]);if(Ox325[OxO3da8[0x1e]]==0xa){var Ox327=Ox325.substr(0x6,0x4)+Ox325.substr(0x3,0x2)+Ox325.substr(0x0,0x2);} else {var Ox328=Ox325.substr(0x6,0x2);if(parseInt(Ox328)<0x32){ Ox328=OxO3da8[0x47]+Ox328 ;} else { Ox328=OxO3da8[0x48]+Ox328 ;} ;var Ox327=Ox328+Ox325.substr(0x3,0x2)+Ox325.substr(0x0,0x2);} ;if(Ox326[OxO3da8[0x1e]]==0xa){var Ox329=Ox326.substr(0x6,0x4)+Ox326.substr(0x3,0x2)+Ox326.substr(0x0,0x2);} else { Ox328=Ox326.substr(0x6,0x2) ;if(parseInt(Ox328)<0x32){ Ox328=OxO3da8[0x47]+Ox328 ;} else { Ox328=OxO3da8[0x48]+Ox328 ;} ;var Ox329=Ox328+Ox326.substr(0x3,0x2)+Ox326.substr(0x0,0x2);} ;if(Ox327==Ox329){return 0x0;} ;if(Ox327<Ox329){return -0x1;} ;return 0x1;}  ; function ts_sort_currency(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO3da8[0x31]][SORT_COLUMN_INDEX]).replace(/[^0-9.]/g,OxO3da8[0x9]);var Ox326=ts_getInnerText(b[OxO3da8[0x31]][SORT_COLUMN_INDEX]).replace(/[^0-9.]/g,OxO3da8[0x9]);return parseFloat(Ox325)-parseFloat(Ox326);}  ; function ts_sort_numeric(Oxe7,b){var Ox325=parseFloat(ts_getInnerText(Oxe7[OxO3da8[0x31]][SORT_COLUMN_INDEX]));if(isNaN(Ox325)){ Ox325=0x0 ;} ;var Ox326=parseFloat(ts_getInnerText(b[OxO3da8[0x31]][SORT_COLUMN_INDEX]));if(isNaN(Ox326)){ Ox326=0x0 ;} ;return Ox325-Ox326;}  ; function ts_sort_caseinsensitive(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO3da8[0x31]][SORT_COLUMN_INDEX]).toLowerCase();var Ox326=ts_getInnerText(b[OxO3da8[0x31]][SORT_COLUMN_INDEX]).toLowerCase();if(Ox325==Ox326){return 0x0;} ;if(Ox325<Ox326){return -0x1;} ;return 0x1;}  ; function ts_sort_default(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO3da8[0x31]][SORT_COLUMN_INDEX]);var Ox326=ts_getInnerText(b[OxO3da8[0x31]][SORT_COLUMN_INDEX]);if(Ox325==Ox326){return 0x0;} ;if(Ox325<Ox326){return -0x1;} ;return 0x1;} [sortables_init] ; RequireFileBrowseScript() ;var Form1=Window_GetElement(window,OxO3da8[0x49],true);var hiddenDirectory=Window_GetElement(window,OxO3da8[0x0],true);var hiddenFile=Window_GetElement(window,OxO3da8[0x1],true);var hiddenAlert=Window_GetElement(window,OxO3da8[0x2],true);var hiddenAction=Window_GetElement(window,OxO3da8[0x3],true);var hiddenActionData=Window_GetElement(window,OxO3da8[0x4],true);var Image1=Window_GetElement(window,OxO3da8[0x4a],true);var FolderDescription=Window_GetElement(window,OxO3da8[0x4b],true);var CreateDir=Window_GetElement(window,OxO3da8[0x4c],true);var Copy=Window_GetElement(window,OxO3da8[0x4d],true);var Move=Window_GetElement(window,OxO3da8[0x4e],true);var FoldersAndFiles=Window_GetElement(window,OxO3da8[0x1c],true);var Delete=Window_GetElement(window,OxO3da8[0x4f],true);var DoRefresh=Window_GetElement(window,OxO3da8[0x50],true);var name_Cell=Window_GetElement(window,OxO3da8[0x51],true);var size_Cell=Window_GetElement(window,OxO3da8[0x52],true);var op_Cell=Window_GetElement(window,OxO3da8[0x53],true);var row0=Window_GetElement(window,OxO3da8[0x54],true);var row0_cb=Window_GetElement(window,OxO3da8[0x55],true);var divpreview=Window_GetElement(window,OxO3da8[0x56],true);var Width=Window_GetElement(window,OxO3da8[0x57],true);var Height=Window_GetElement(window,OxO3da8[0x58],true);var AutoStart=Window_GetElement(window,OxO3da8[0x59],true);var ShowControls=Window_GetElement(window,OxO3da8[0x5a],true);var ShowStatusBar=Window_GetElement(window,OxO3da8[0x5b],true);var WindowlessVideo=Window_GetElement(window,OxO3da8[0x5c],true);var TargetUrl=Window_GetElement(window,OxO3da8[0x27],true);var Button1=Window_GetElement(window,OxO3da8[0x5d],true);var Button2=Window_GetElement(window,OxO3da8[0x5e],true);var btn_zoom_in=Window_GetElement(window,OxO3da8[0x5f],true);var btn_zoom_out=Window_GetElement(window,OxO3da8[0x60],true);var btn_Actualsize=Window_GetElement(window,OxO3da8[0x61],true);var editor=Window_GetDialogArguments(window); do_preview() ; function do_preview(){var Ox3aa;var Ox6d;var Ox6c;if(TargetUrl[OxO3da8[0xa]]==OxO3da8[0x9]){return ;} ;var Ox3ab,Ox3ac,Ox3ad,Ox3ae;if(AutoStart[OxO3da8[0x62]]){ Ox3ab=0x1 ;} else { Ox3ab=0x0 ;} ;if(ShowStatusBar[OxO3da8[0x62]]){ Ox3ac=0x1 ;} else { Ox3ac=0x0 ;} ;if(ShowControls[OxO3da8[0x62]]){ Ox3ad=0x1 ;} else { Ox3ad=0x0 ;} ;if(WindowlessVideo[OxO3da8[0x62]]){ Ox3ae=true ;} else { Ox3ae=false ;} ; Ox6d=Width[OxO3da8[0xa]] ; Ox6c=Height[OxO3da8[0xa]] ; Ox6d=parseInt(Ox6d) ; Ox6c=parseInt(Ox6c) ;var Ox36a=OxO3da8[0x63]+TargetUrl[OxO3da8[0xa]]+OxO3da8[0x64]+Ox3ab+OxO3da8[0x65]+Ox3ad+OxO3da8[0x66]+Ox3ae+OxO3da8[0x67]+Ox3ac+OxO3da8[0x68]+Ox6d+OxO3da8[0x69]+Ox6c+OxO3da8[0x6a];var Ox34b=OxO3da8[0x6b]+OxO3da8[0x6c]+OxO3da8[0x6d]+OxO3da8[0x6e]+OxO3da8[0x6f]+OxO3da8[0x70]+Ox6c+OxO3da8[0x68]+Ox6d+OxO3da8[0x71]; Ox34b=Ox34b+OxO3da8[0x72]+TargetUrl[OxO3da8[0xa]]+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x74]+Ox3ab+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x75]+Ox3ad+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x76]+Ox3ac+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x77]+Ox3ae+OxO3da8[0x73] ; Ox34b=Ox34b+Ox36a+OxO3da8[0x78] ; Ox36a=Ox34b ; divpreview[OxO3da8[0x32]]=Ox36a ;}  ; window[OxO3da8[0x7a]]=window[OxO3da8[0x79]]=function (){ divpreview[OxO3da8[0x32]]=OxO3da8[0x9] ;}  ;var parameters= new Array(); function do_insert(){ divpreview[OxO3da8[0x32]]=OxO3da8[0x9] ;if(TargetUrl[OxO3da8[0xa]]==OxO3da8[0x9]){ alert(OxO3da8[0x7b]) ;return false;} ;var Ox3ab,Ox3ac,Ox3ad,Ox3ae;if(AutoStart[OxO3da8[0x62]]){ Ox3ab=0x1 ;} else { Ox3ab=0x0 ;} ;if(ShowStatusBar[OxO3da8[0x62]]){ Ox3ac=0x1 ;} else { Ox3ac=0x0 ;} ;if(ShowControls[OxO3da8[0x62]]){ Ox3ad=0x1 ;} else { Ox3ad=0x0 ;} ;if(WindowlessVideo[OxO3da8[0x62]]){ Ox3ae=true ;} else { Ox3ae=false ;} ; width=Width[OxO3da8[0xa]]+OxO3da8[0x9] ; height=Height[OxO3da8[0xa]]+OxO3da8[0x9] ; width=parseInt(width) ; height=parseInt(height) ;var Ox36a=OxO3da8[0x63]+TargetUrl[OxO3da8[0xa]]+OxO3da8[0x64]+Ox3ab+OxO3da8[0x65]+Ox3ad+OxO3da8[0x67]+Ox3ac+OxO3da8[0x7c]+Ox3ae+OxO3da8[0x68]+width+OxO3da8[0x69]+height+OxO3da8[0x6a];var Ox34b=OxO3da8[0x6b]+OxO3da8[0x6c]+OxO3da8[0x6d]+OxO3da8[0x6e]+OxO3da8[0x6f]+OxO3da8[0x70]+height+OxO3da8[0x68]+width+OxO3da8[0x71]; Ox34b=Ox34b+OxO3da8[0x72]+TargetUrl[OxO3da8[0xa]]+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x74]+Ox3ab+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x75]+Ox3ad+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x76]+Ox3ac+OxO3da8[0x73] ; Ox34b=Ox34b+OxO3da8[0x77]+Ox3ae+OxO3da8[0x73] ; Ox34b=Ox34b+Ox36a+OxO3da8[0x78] ; Ox36a=Ox34b ; editor.PasteHTML(Ox36a) ; Window_CloseDialog(window) ;}  ; function do_Close(){ divpreview[OxO3da8[0x32]]=OxO3da8[0x9] ; Window_CloseDialog(window) ;}  ; function Zoom_In(){if(divpreview[OxO3da8[0x7e]][OxO3da8[0x7d]]!=0x0){ divpreview[OxO3da8[0x7e]][OxO3da8[0x7d]]*=1.2 ;} else { divpreview[OxO3da8[0x7e]][OxO3da8[0x7d]]=1.2 ;} ;}  ; function Zoom_Out(){if(divpreview[OxO3da8[0x7e]][OxO3da8[0x7d]]!=0x0){ divpreview[OxO3da8[0x7e]][OxO3da8[0x7d]]*=0.8 ;} else { divpreview[OxO3da8[0x7e]][OxO3da8[0x7d]]=0.8 ;} ;}  ; function Actualsize(){ divpreview[OxO3da8[0x7e]][OxO3da8[0x7d]]=0x1 ; do_preview() ;}  ;if(Browser_IsIE7()){var _dialogPromptID=null; function IEprompt(Ox19b,Ox19c,Ox19d){ that=this ; this[OxO3da8[0x7f]]=function (Ox19e){ val=document.getElementById(OxO3da8[0x80])[OxO3da8[0xa]] ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x81]]=OxO3da8[0x82] ; document.getElementById(OxO3da8[0x80])[OxO3da8[0xa]]=OxO3da8[0x9] ;if(Ox19e){ val=OxO3da8[0x9] ;} ; Ox19b(val) ;return false;}  ;if(Ox19d==undefined){ Ox19d=OxO3da8[0x9] ;} ;if(_dialogPromptID==null){var Ox19f=document.getElementsByTagName(OxO3da8[0x83])[0x0]; tnode=document.createElement(OxO3da8[0x84]) ; tnode[OxO3da8[0x2f]]=OxO3da8[0x85] ; Ox19f.appendChild(tnode) ; _dialogPromptID=document.getElementById(OxO3da8[0x85]) ; tnode=document.createElement(OxO3da8[0x84]) ; tnode[OxO3da8[0x2f]]=OxO3da8[0x86] ; Ox19f.appendChild(tnode) ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x87]]=OxO3da8[0x88] ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x89]]=OxO3da8[0x8a] ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x8b]]=OxO3da8[0x8c] ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x8d]]=OxO3da8[0x8e] ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x8f]]=OxO3da8[0x90] ;} ;var Ox1a0=OxO3da8[0x91]; Ox1a0+=OxO3da8[0x92]+Ox19c+OxO3da8[0x93] ; Ox1a0+=OxO3da8[0x94] ; Ox1a0+=OxO3da8[0x95]+Ox19d+OxO3da8[0x96] ; Ox1a0+=OxO3da8[0x97] ; Ox1a0+=OxO3da8[0x98] ; Ox1a0+=OxO3da8[0x99] ; Ox1a0+=OxO3da8[0x9a] ; Ox1a0+=OxO3da8[0x9b] ; _dialogPromptID[OxO3da8[0x32]]=Ox1a0 ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x9c]]=OxO3da8[0x9d] ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x9f]]=parseInt((document[OxO3da8[0x83]][OxO3da8[0x9e]]-0x13b)/0x2)+OxO3da8[0xa0] ; _dialogPromptID[OxO3da8[0x7e]][OxO3da8[0x81]]=OxO3da8[0xa1] ;var Ox1a1=document.getElementById(OxO3da8[0x80]);try{var Ox1a2=Ox1a1.createTextRange(); Ox1a2.collapse(false) ; Ox1a2.select() ;} catch(x){ Ox1a1.focus() ;} ;}  ;} ;if(!Browser_IsWinIE()){ btn_zoom_in[OxO3da8[0x7e]][OxO3da8[0x81]]=btn_zoom_out[OxO3da8[0x7e]][OxO3da8[0x81]]=btn_Actualsize[OxO3da8[0x7e]][OxO3da8[0x81]]=OxO3da8[0x82] ;} else {} ;if(CreateDir){ CreateDir[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;if(Copy){ Copy[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;if(Move){ Move[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;if(Delete){ Delete[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;if(DoRefresh){ DoRefresh[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;if(btn_zoom_in){ btn_zoom_in[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;if(btn_zoom_out){ btn_zoom_out[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;if(btn_Actualsize){ btn_Actualsize[OxO3da8[0x20]]= new Function(OxO3da8[0xa2]) ;} ;





