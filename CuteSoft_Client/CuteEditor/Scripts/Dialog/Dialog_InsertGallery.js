var OxOf2e9=["Form1","FoldersAndFiles","Image1","FolderDescription","cbThumbSize","cbColumns","cbRows","cbTypes","cbSorts","ThumbList1_MyList","ThumbList1_hdnCurPage","ThumbList1_hdnPrevPath","hiddenAlert","lightyellow","0px","-3px","value","","onload","all","getElementById","\x3Cdiv id=\x22tooltipdiv\x22 style=\x22visibility:hidden;background-color:","\x22 \x3E\x3C/div\x3E","tooltipdiv","left","offsetLeft","offsetTop","offsetParent","top","style","visibility","compatMode","BackCompat","documentElement","body","rightedge","opera","clientWidth","scrollLeft","innerWidth","pageXOffset","offsetWidth","contentmeasure","x","clientHeight","scrollTop","innerHeight","pageYOffset","offsetHeight","y","innerHTML","visible","hidden","px","bottomedge","undefined","hidetip()","element","editor","editdoc","^[a-z]*:[/][/][^/]*","src","height","width","IMG","border","alt","product","Gecko","src_cetemp","Edit"];var Form1=Window_GetElement(window,OxOf2e9[0x0],true);var FoldersAndFiles=Window_GetElement(window,OxOf2e9[0x1],true);var Image1=Window_GetElement(window,OxOf2e9[0x2],true);var FolderDescription=Window_GetElement(window,OxOf2e9[0x3],true);var cbThumbSize=Window_GetElement(window,OxOf2e9[0x4],true);var cbColumns=Window_GetElement(window,OxOf2e9[0x5],true);var cbRows=Window_GetElement(window,OxOf2e9[0x6],true);var cbTypes=Window_GetElement(window,OxOf2e9[0x7],true);var cbSorts=Window_GetElement(window,OxOf2e9[0x8],true);var ThumbList1_MyList=Window_GetElement(window,OxOf2e9[0x9],true);var ThumbList1_hdnCurPage=Window_GetElement(window,OxOf2e9[0xa],true);var ThumbList1_hdnPrevPath=Window_GetElement(window,OxOf2e9[0xb],true);var hiddenAlert=Window_GetElement(window,OxOf2e9[0xc],true);var tipbgcolor=OxOf2e9[0xd];var disappeardelay=0xfa;var vertical_offset=OxOf2e9[0xe];var horizontal_offset=OxOf2e9[0xf];var delayhidetimerid; function reset_hiddens(){if(hiddenAlert[OxOf2e9[0x10]]){ alert(hiddenAlert.value) ;} ; hiddenAlert[OxOf2e9[0x10]]=OxOf2e9[0x11] ;}  ; Event_Attach(window,OxOf2e9[0x12],reset_hiddens) ;var ie4=document[OxOf2e9[0x13]];var ns6=document[OxOf2e9[0x14]]&&!document[OxOf2e9[0x13]];if(ie4||ns6){ document.write(OxOf2e9[0x15]+tipbgcolor+OxOf2e9[0x16]) ;var dropmenuobj=Window_GetElement(window,OxOf2e9[0x17],true);} ; function getposOffset(Ox37f,Ox380){var Ox381=(Ox380==OxOf2e9[0x18])?Ox37f[OxOf2e9[0x19]]:Ox37f[OxOf2e9[0x1a]];var Ox382=Ox37f[OxOf2e9[0x1b]];while(Ox382!=null){ Ox381+=(Ox380==OxOf2e9[0x18])?Ox382[OxOf2e9[0x19]]:Ox382[OxOf2e9[0x1a]] ; Ox382=Ox382[OxOf2e9[0x1b]] ;} ;return Ox381;}  ; function showhide(obj,Ox384,Ox385){if(ie4||ns6){ dropmenuobj[OxOf2e9[0x1d]][OxOf2e9[0x18]]=dropmenuobj[OxOf2e9[0x1d]][OxOf2e9[0x1c]]=-0x1f4 ;} ; obj[OxOf2e9[0x1e]]=Ox384 ;}  ; function iecompattest(){return (document[OxOf2e9[0x1f]]&&document[OxOf2e9[0x1f]]!=OxOf2e9[0x20])?document[OxOf2e9[0x21]]:document[OxOf2e9[0x22]];}  ; function clearbrowseredge(obj,Ox388){var Ox389=(Ox388==OxOf2e9[0x23])?parseInt(horizontal_offset)*-0x1:parseInt(vertical_offset)*-0x1;if(Ox388==OxOf2e9[0x23]){var Ox38a=ie4&&!window[OxOf2e9[0x24]]?iecompattest()[OxOf2e9[0x26]]+iecompattest()[OxOf2e9[0x25]]-0xf:window[OxOf2e9[0x28]]+window[OxOf2e9[0x27]]-0xf; dropmenuobj[OxOf2e9[0x2a]]=dropmenuobj[OxOf2e9[0x29]] ;if(Ox38a-dropmenuobj[OxOf2e9[0x2b]]<dropmenuobj[OxOf2e9[0x2a]]){ Ox389=dropmenuobj[OxOf2e9[0x2a]]-obj[OxOf2e9[0x29]] ;} ;} else {var Ox38a=ie4&&!window[OxOf2e9[0x24]]?iecompattest()[OxOf2e9[0x2d]]+iecompattest()[OxOf2e9[0x2c]]-0xf:window[OxOf2e9[0x2f]]+window[OxOf2e9[0x2e]]-0x12; dropmenuobj[OxOf2e9[0x2a]]=dropmenuobj[OxOf2e9[0x30]] ;if(Ox38a-dropmenuobj[OxOf2e9[0x31]]<dropmenuobj[OxOf2e9[0x2a]]){ Ox389=dropmenuobj[OxOf2e9[0x2a]]+obj[OxOf2e9[0x30]] ;} ;} ;return Ox389;}  ; function showTooltip(Ox41,obj){ Event_CancelEvent() ; clearhidetip() ; dropmenuobj[OxOf2e9[0x32]]=Ox41 ;if(ie4||ns6){ showhide(dropmenuobj.style,OxOf2e9[0x33],OxOf2e9[0x34]) ; dropmenuobj[OxOf2e9[0x2b]]=getposOffset(obj,OxOf2e9[0x18]) ; dropmenuobj[OxOf2e9[0x31]]=getposOffset(obj,OxOf2e9[0x1c]) ; dropmenuobj[OxOf2e9[0x1d]][OxOf2e9[0x18]]=dropmenuobj[OxOf2e9[0x2b]]-clearbrowseredge(obj,OxOf2e9[0x23])+OxOf2e9[0x35] ; dropmenuobj[OxOf2e9[0x1d]][OxOf2e9[0x1c]]=dropmenuobj[OxOf2e9[0x31]]-clearbrowseredge(obj,OxOf2e9[0x36])+obj[OxOf2e9[0x30]]*1.1+0x2+OxOf2e9[0x35] ;} ;}  ; function hidetip(){if( typeof dropmenuobj!=OxOf2e9[0x37]){if(ie4||ns6){ dropmenuobj[OxOf2e9[0x1d]][OxOf2e9[0x1e]]=OxOf2e9[0x34] ;} ;} ;}  ; function delayhidetip(){if(ie4||ns6){ delayhidetimerid=setTimeout(OxOf2e9[0x38],disappeardelay) ;} ;}  ; function clearhidetip(){ clearTimeout(delayhidetimerid) ;}  ; function cancel(){ Window_CloseDialog(window) ;}  ;var obj=Window_GetDialogArguments(window);var element=obj[OxOf2e9[0x39]];var editor=obj[OxOf2e9[0x3a]];var editdoc=obj[OxOf2e9[0x3b]]; function insert(src){if(src){var Ox205=src.replace( new RegExp(OxOf2e9[0x3c],OxOf2e9[0x11]),OxOf2e9[0x11]); function Actualsize(){var Ox76= new Image(); Ox76[OxOf2e9[0x3d]]=Ox205 ;if(Ox76[OxOf2e9[0x3f]]>0x0&&Ox76[OxOf2e9[0x3e]]>0x0){ element[OxOf2e9[0x3f]]=Ox76[OxOf2e9[0x3f]] ; element[OxOf2e9[0x3e]]=Ox76[OxOf2e9[0x3e]] ;} else { setTimeout(Actualsize,0x190) ;} ;}  ;if(element){ element[OxOf2e9[0x3d]]=Ox205 ;} else { element=editdoc.createElement(OxOf2e9[0x40]) ; element[OxOf2e9[0x3d]]=Ox205 ; element[OxOf2e9[0x41]]=0x0 ; element[OxOf2e9[0x42]]=OxOf2e9[0x11] ; Actualsize() ;} ;if(navigator[OxOf2e9[0x43]]==OxOf2e9[0x44]){try{ element.setAttribute(OxOf2e9[0x45],Ox205) ;} catch(e){} ;} else {if(editor.GetActiveTab()==OxOf2e9[0x46]){ element.setAttribute(OxOf2e9[0x45],Ox205) ;} ;} ; editor.InsertElement(element) ; Window_CloseDialog(window) ;} ;}  ;





