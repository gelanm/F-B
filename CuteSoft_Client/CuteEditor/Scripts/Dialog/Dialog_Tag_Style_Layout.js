var OxO64c5=["","sel_position","sel_display","sel_float","sel_clear","tb_top","sel_top_unit","tb_height","sel_height_unit","tb_left","sel_left_unit","tb_width","sel_width_unit","tb_cliptop","sel_cliptop_unit","tb_clipbottom","sel_clipbottom_unit","tb_clipleft","sel_clipleft_unit","tb_clipright","sel_clipright_unit","sel_overflow","tb_zindex","sel_pagebreakbefore","sel_pagebreakafter","outer","div_demo","cssText","style","position","value","display","styleFloat","cssFloat","clear","left","top","width","height","length","tb_","sel_","_unit","selectedIndex","options","right","bottom","clip","tb_clip","sel_clip","currentStyle","overflow","zIndex","pageBreakBefore","pageBreakAfter"]; function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO64c5[0x0];} ;return Ox8+OxO64c5[0x0];}  ;var sel_position=Window_GetElement(window,OxO64c5[0x1],true);var sel_display=Window_GetElement(window,OxO64c5[0x2],true);var sel_float=Window_GetElement(window,OxO64c5[0x3],true);var sel_clear=Window_GetElement(window,OxO64c5[0x4],true);var tb_top=Window_GetElement(window,OxO64c5[0x5],true);var sel_top_unit=Window_GetElement(window,OxO64c5[0x6],true);var tb_height=Window_GetElement(window,OxO64c5[0x7],true);var sel_height_unit=Window_GetElement(window,OxO64c5[0x8],true);var tb_left=Window_GetElement(window,OxO64c5[0x9],true);var sel_left_unit=Window_GetElement(window,OxO64c5[0xa],true);var tb_width=Window_GetElement(window,OxO64c5[0xb],true);var sel_width_unit=Window_GetElement(window,OxO64c5[0xc],true);var tb_cliptop=Window_GetElement(window,OxO64c5[0xd],true);var sel_cliptop_unit=Window_GetElement(window,OxO64c5[0xe],true);var tb_clipbottom=Window_GetElement(window,OxO64c5[0xf],true);var sel_clipbottom_unit=Window_GetElement(window,OxO64c5[0x10],true);var tb_clipleft=Window_GetElement(window,OxO64c5[0x11],true);var sel_clipleft_unit=Window_GetElement(window,OxO64c5[0x12],true);var tb_clipright=Window_GetElement(window,OxO64c5[0x13],true);var sel_clipright_unit=Window_GetElement(window,OxO64c5[0x14],true);var sel_overflow=Window_GetElement(window,OxO64c5[0x15],true);var tb_zindex=Window_GetElement(window,OxO64c5[0x16],true);var sel_pagebreakbefore=Window_GetElement(window,OxO64c5[0x17],true);var sel_pagebreakafter=Window_GetElement(window,OxO64c5[0x18],true);var outer=Window_GetElement(window,OxO64c5[0x19],true);var div_demo=Window_GetElement(window,OxO64c5[0x1a],true); UpdateState=function UpdateState_Layout(){ div_demo[OxO64c5[0x1c]][OxO64c5[0x1b]]=element[OxO64c5[0x1c]][OxO64c5[0x1b]] ;}  ; SyncToView=function SyncToView_Layout(){ sel_position[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x1d]] ; sel_display[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x1f]] ;if(Browser_IsWinIE()){ sel_float[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x20]] ;} else { sel_float[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x21]] ;} ; sel_clear[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x22]] ;var arr=[OxO64c5[0x23],OxO64c5[0x24],OxO64c5[0x25],OxO64c5[0x26]];for(var Ox178=0x0;Ox178<arr[OxO64c5[0x27]];Ox178++){var n=arr[Ox178];var Ox42=document.getElementById(OxO64c5[0x28]+n);var Ox119=document.getElementById(OxO64c5[0x29]+n+OxO64c5[0x2a]); Ox119[OxO64c5[0x2b]]=0x0 ;if(ParseFloatToString(element[OxO64c5[0x1c]][n])){ Ox42[OxO64c5[0x1e]]=ParseFloatToString(element[OxO64c5[0x1c]][n]) ;for(var i=0x0;i<Ox119[OxO64c5[0x2c]][OxO64c5[0x27]];i++){var Ox13b=Ox119[OxO64c5[0x2c]][i][OxO64c5[0x1e]];if(Ox13b&&element[OxO64c5[0x1c]][n].indexOf(Ox13b)!=-0x1){ Ox119[OxO64c5[0x2b]]=i ;break ;} ;} ;} ;} ;var arr=[OxO64c5[0x23],OxO64c5[0x24],OxO64c5[0x2d],OxO64c5[0x2e]];for(var Ox178=0x0;Ox178<arr[OxO64c5[0x27]];Ox178++){var n=arr[Ox178];var Ox582=OxO64c5[0x2f]+n.charAt(0x0).toUpperCase()+n.substring(0x1);var Ox42=document.getElementById(OxO64c5[0x30]+n);var Ox119=document.getElementById(OxO64c5[0x31]+n+OxO64c5[0x2a]); Ox119[OxO64c5[0x2b]]=0x0 ;var Ox583;if(Browser_IsWinIE()){ Ox583=element[OxO64c5[0x32]][Ox582] ;} else { Ox583=element[OxO64c5[0x1c]][Ox582] ;} ;if(ParseFloatToString(Ox583)){ Ox42[OxO64c5[0x1e]]=ParseFloatToString(Ox583) ;for(var i=0x0;i<Ox119[OxO64c5[0x2c]][OxO64c5[0x27]];i++){var Ox13b=Ox119[OxO64c5[0x2c]][i][OxO64c5[0x1e]];if(Ox13b&&Ox583.indexOf(Ox13b)!=-0x1){ Ox119[OxO64c5[0x2b]]=i ;break ;} ;} ;} ;} ; sel_overflow[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x33]] ; tb_zindex[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x34]] ; sel_pagebreakbefore[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x35]] ; sel_pagebreakafter[OxO64c5[0x1e]]=element[OxO64c5[0x1c]][OxO64c5[0x36]] ;}  ; SyncTo=function SyncTo_Layout(element){ element[OxO64c5[0x1c]][OxO64c5[0x1d]]=sel_position[OxO64c5[0x1e]] ; element[OxO64c5[0x1c]][OxO64c5[0x1f]]=sel_display[OxO64c5[0x1e]] ;if(Browser_IsWinIE()){ element[OxO64c5[0x1c]][OxO64c5[0x20]]=sel_float[OxO64c5[0x1e]] ;} else { element[OxO64c5[0x1c]][OxO64c5[0x21]]=sel_float[OxO64c5[0x1e]] ;} ; element[OxO64c5[0x1c]][OxO64c5[0x22]]=sel_clear[OxO64c5[0x1e]] ;var arr=[OxO64c5[0x23],OxO64c5[0x24],OxO64c5[0x25],OxO64c5[0x26]];for(var Ox178=0x0;Ox178<arr[OxO64c5[0x27]];Ox178++){var n=arr[Ox178];var Ox42=document.getElementById(OxO64c5[0x28]+n);if(ParseFloatToString(Ox42.value)){ element[OxO64c5[0x1c]][n]=ParseFloatToString(Ox42.value)+document.all(OxO64c5[0x29]+n+OxO64c5[0x2a])[OxO64c5[0x1e]] ;} else { element[OxO64c5[0x1c]][n]=OxO64c5[0x0] ;} ;} ;var arr=[OxO64c5[0x23],OxO64c5[0x24],OxO64c5[0x2d],OxO64c5[0x2e]];for(var Ox178=0x0;Ox178<arr[OxO64c5[0x27]];Ox178++){var n=arr[Ox178];var Ox582=OxO64c5[0x2f]+n.charAt(0x0).toUpperCase()+n.substring(0x1);var Ox42=document.getElementById(OxO64c5[0x30]+n);if(ParseFloatToString(Ox42.value)){ element[OxO64c5[0x1c]][Ox582]=ParseFloatToString(Ox42.value)+document.all(OxO64c5[0x31]+n+OxO64c5[0x2a])[OxO64c5[0x1e]] ;} else { element[OxO64c5[0x1c]][Ox582]=OxO64c5[0x0] ;} ;} ; element[OxO64c5[0x1c]][OxO64c5[0x33]]=sel_overflow[OxO64c5[0x1e]] ; element[OxO64c5[0x1c]][OxO64c5[0x34]]=ParseFloatToString(tb_zindex.value) ; element[OxO64c5[0x1c]][OxO64c5[0x35]]=sel_pagebreakbefore[OxO64c5[0x1e]] ; element[OxO64c5[0x1c]][OxO64c5[0x36]]=sel_pagebreakafter[OxO64c5[0x1e]] ;}  ;





