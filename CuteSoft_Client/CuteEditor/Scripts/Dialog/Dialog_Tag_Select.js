var OxO2f04=["inp_name","inp_access","inp_id","inp_index","inp_size","inp_Multiple","inp_Disabled","inp_item_text","inp_item_value","btnInsertItem","btnUpdateItem","btnDeleteItem","btnMoveUpItem","btnMoveDownItem","list_options","list_options2","inp_item_forecolor","inp_item_forecolor_Preview","inp_item_backcolor_Preview","value","text","color","style","backgroundColor","selectedIndex","options","Please select an item first","length","ondblclick","onclick","OPTION","document","id","cssText","Name","name","size","disabled","checked","multiple","tabIndex","","accessKey"];var inp_name=Window_GetElement(window,OxO2f04[0x0],true);var inp_access=Window_GetElement(window,OxO2f04[0x1],true);var inp_id=Window_GetElement(window,OxO2f04[0x2],true);var inp_index=Window_GetElement(window,OxO2f04[0x3],true);var inp_size=Window_GetElement(window,OxO2f04[0x4],true);var inp_Multiple=Window_GetElement(window,OxO2f04[0x5],true);var inp_Disabled=Window_GetElement(window,OxO2f04[0x6],true);var inp_item_text=Window_GetElement(window,OxO2f04[0x7],true);var inp_item_value=Window_GetElement(window,OxO2f04[0x8],true);var btnInsertItem=Window_GetElement(window,OxO2f04[0x9],true);var btnUpdateItem=Window_GetElement(window,OxO2f04[0xa],true);var btnDeleteItem=Window_GetElement(window,OxO2f04[0xb],true);var btnMoveUpItem=Window_GetElement(window,OxO2f04[0xc],true);var btnMoveDownItem=Window_GetElement(window,OxO2f04[0xd],true);var list_options=Window_GetElement(window,OxO2f04[0xe],true);var list_options2=Window_GetElement(window,OxO2f04[0xf],true);var inp_item_forecolor=Window_GetElement(window,OxO2f04[0x10],true);var inp_item_forecolor=Window_GetElement(window,OxO2f04[0x10],true);var inp_item_forecolor_Preview=Window_GetElement(window,OxO2f04[0x11],true);var inp_item_backcolor_Preview=Window_GetElement(window,OxO2f04[0x12],true); function SetOption(Ox51f){ Ox51f[OxO2f04[0x14]]=inp_item_text[OxO2f04[0x13]] ; Ox51f[OxO2f04[0x13]]=inp_item_value[OxO2f04[0x13]] ; Ox51f[OxO2f04[0x16]][OxO2f04[0x15]]=inp_item_forecolor[OxO2f04[0x13]] ; Ox51f[OxO2f04[0x16]][OxO2f04[0x17]]=inp_item_backcolor[OxO2f04[0x13]] ;}  ; function SetOption2(Ox51f){ Ox51f[OxO2f04[0x14]]=inp_item_value[OxO2f04[0x13]] ; Ox51f[OxO2f04[0x13]]=inp_item_text[OxO2f04[0x13]] ; Ox51f[OxO2f04[0x16]][OxO2f04[0x15]]=inp_item_forecolor[OxO2f04[0x13]] ; Ox51f[OxO2f04[0x16]][OxO2f04[0x17]]=inp_item_backcolor[OxO2f04[0x13]] ;}  ; function Select(Ox51f){var Ox522=Ox51f[OxO2f04[0x18]]; list_options[OxO2f04[0x18]]=Ox522 ; list_options2[OxO2f04[0x18]]=Ox522 ; inp_item_text[OxO2f04[0x13]]=list_options2[OxO2f04[0x13]] ; inp_item_value[OxO2f04[0x13]]=list_options[OxO2f04[0x13]] ;}  ; function Insert(){var Ox51f= new Option(); SetOption(Ox51f) ; list_options[OxO2f04[0x19]].add(Ox51f) ;var Ox524= new Option(); SetOption2(Ox524) ; list_options2[OxO2f04[0x19]].add(Ox524) ; FireUIChanged() ;}  ; function Update(){if(list_options[OxO2f04[0x18]]==-0x1){ alert(OxO2f04[0x1a]) ;return ;} ;var Ox51f=list_options.options(list_options.selectedIndex); SetOption(Ox51f) ;var Ox524=list_options2.options(list_options2.selectedIndex); SetOption2(Ox524) ; FireUIChanged() ;}  ; function Move(Ox13b){var Ox522=list_options[OxO2f04[0x18]];if(Ox522<0x0){return ;} ;var Ox526=Ox522-Ox13b;if(Ox526<0x0){ Ox526=0x0 ;} ;if(Ox526>(list_options[OxO2f04[0x19]][OxO2f04[0x1b]]-0x1)){ Ox526=list_options[OxO2f04[0x19]][OxO2f04[0x1b]]-0x1 ;} ;if(Ox522==Ox526){return ;} ;var Ox51f=list_options.options(list_options.selectedIndex);var Ox12=list_options2[OxO2f04[0x13]];var Ox8=list_options[OxO2f04[0x13]]; Delete() ; inp_item_text[OxO2f04[0x13]]=Ox12 ; inp_item_value[OxO2f04[0x13]]=Ox8 ;var Ox51f= new Option(); SetOption(Ox51f) ; list_options[OxO2f04[0x19]].add(Ox51f,Ox526) ;var Ox524= new Option(); SetOption2(Ox524) ; list_options2[OxO2f04[0x19]].add(Ox524,Ox526) ; list_options[OxO2f04[0x18]]=Ox526 ; list_options2[OxO2f04[0x18]]=Ox526 ; FireUIChanged() ;}  ; function Delete(){if(list_options[OxO2f04[0x18]]==-0x1||list_options[OxO2f04[0x18]]==-0x1){ alert(OxO2f04[0x1a]) ;return ;} ;var Ox527=list_options[OxO2f04[0x18]];var Ox51f=list_options.options(list_options.selectedIndex); Ox51f.removeNode(true) ; Ox51f=list_options2.options(list_options2.selectedIndex) ; Ox51f.removeNode(true) ;if(list_options[OxO2f04[0x19]][OxO2f04[0x1b]]>Ox527){ list_options[OxO2f04[0x18]]=Ox527 ;} else {if(list_options[OxO2f04[0x19]][OxO2f04[0x1b]]){ list_options[OxO2f04[0x18]]=list_options[OxO2f04[0x19]][OxO2f04[0x1b]]-0x1 ;} ;} ; list_options.ondblclick() ;if(list_options2[OxO2f04[0x19]][OxO2f04[0x1b]]>Ox527){ list_options2[OxO2f04[0x18]]=Ox527 ;} else {if(list_options2[OxO2f04[0x19]][OxO2f04[0x1b]]){ list_options2[OxO2f04[0x18]]=list_options2[OxO2f04[0x19]][OxO2f04[0x1b]]-0x1 ;} ;} ; FireUIChanged() ;}  ; list_options[OxO2f04[0x1c]]=function list_options_ondblclick(){if(list_options[OxO2f04[0x18]]==-0x1){return ;} ;var Ox51f=list_options.options(list_options.selectedIndex); inp_item_text[OxO2f04[0x13]]=Ox51f[OxO2f04[0x14]] ; inp_item_value[OxO2f04[0x13]]=Ox51f[OxO2f04[0x13]] ; inp_item_forecolor[OxO2f04[0x13]]=inp_item_forecolor[OxO2f04[0x16]][OxO2f04[0x17]]=inp_item_forecolor_Preview[OxO2f04[0x16]][OxO2f04[0x17]]=Ox51f[OxO2f04[0x16]][OxO2f04[0x15]] ; inp_item_backcolor[OxO2f04[0x13]]=inp_item_backcolor[OxO2f04[0x16]][OxO2f04[0x17]]=inp_item_backcolor_Preview[OxO2f04[0x16]][OxO2f04[0x17]]=Ox51f[OxO2f04[0x16]][OxO2f04[0x17]] ;}  ; inp_item_forecolor[OxO2f04[0x1d]]=inp_item_forecolor_Preview[OxO2f04[0x1d]]=function inp_item_forecolor_onclick(){ SelectColor(inp_item_forecolor,inp_item_forecolor_Preview) ;}  ; inp_item_backcolor[OxO2f04[0x1d]]=inp_item_backcolor_Preview[OxO2f04[0x1d]]=function inp_item_backcolor_onclick(){ SelectColor(inp_item_backcolor,inp_item_backcolor_Preview) ;}  ; function CopySelect(Ox52c,Ox52d){ Ox52d[OxO2f04[0x19]][OxO2f04[0x1b]]=0x0 ;for(var i=0x0;i<Ox52c[OxO2f04[0x19]][OxO2f04[0x1b]];i++){var Ox52e=Ox52c[OxO2f04[0x19]][i];var Ox524;if(Browser_IsWinIE()){ Ox524=Ox52d[OxO2f04[0x1f]].createElement(OxO2f04[0x1e]) ;} else { Ox524=document.createElement(OxO2f04[0x1e]) ;} ;if(Ox52d[OxO2f04[0x20]]!=OxO2f04[0xf]){ Ox524[OxO2f04[0x13]]=Ox52e[OxO2f04[0x13]] ; Ox524[OxO2f04[0x14]]=Ox52e[OxO2f04[0x14]] ;} else { Ox524[OxO2f04[0x13]]=Ox52e[OxO2f04[0x14]] ; Ox524[OxO2f04[0x14]]=Ox52e[OxO2f04[0x13]] ;} ; Ox524[OxO2f04[0x16]][OxO2f04[0x21]]=Ox52e[OxO2f04[0x16]][OxO2f04[0x21]] ; Ox52d[OxO2f04[0x19]].add(Ox524) ;} ; Ox52d[OxO2f04[0x18]]=Ox52c[OxO2f04[0x18]] ;}  ; UpdateState=function UpdateState_Select(){}  ; SyncToView=function SyncToView_Select(){if(element[OxO2f04[0x22]]){ inp_name[OxO2f04[0x13]]=element[OxO2f04[0x22]] ;} ;if(element[OxO2f04[0x23]]){ inp_name[OxO2f04[0x13]]=element[OxO2f04[0x23]] ;} ; inp_id[OxO2f04[0x13]]=element[OxO2f04[0x20]] ; inp_size[OxO2f04[0x13]]=element[OxO2f04[0x24]] ; CopySelect(element,list_options) ; CopySelect(element,list_options2) ; inp_Disabled[OxO2f04[0x26]]=element[OxO2f04[0x25]] ; inp_Multiple[OxO2f04[0x26]]=element[OxO2f04[0x27]] ;if(element[OxO2f04[0x28]]==0x0){ inp_index[OxO2f04[0x13]]=OxO2f04[0x29] ;} else { inp_index[OxO2f04[0x13]]=element[OxO2f04[0x28]] ;} ;if(element[OxO2f04[0x2a]]){ inp_access[OxO2f04[0x13]]=element[OxO2f04[0x2a]] ;} ;}  ; SyncTo=function SyncTo_Select(element){ element[OxO2f04[0x23]]=inp_name[OxO2f04[0x13]] ;if(element[OxO2f04[0x22]]){ element[OxO2f04[0x22]]=inp_name[OxO2f04[0x13]] ;} else {if(element[OxO2f04[0x23]]){ element.removeAttribute(OxO2f04[0x23],0x0) ; element[OxO2f04[0x22]]=inp_name[OxO2f04[0x13]] ;} else { element[OxO2f04[0x22]]=inp_name[OxO2f04[0x13]] ;} ;} ; element[OxO2f04[0x20]]=inp_id[OxO2f04[0x13]] ; element[OxO2f04[0x24]]=inp_size[OxO2f04[0x13]] ; element[OxO2f04[0x25]]=inp_Disabled[OxO2f04[0x26]] ; element[OxO2f04[0x27]]=inp_Multiple[OxO2f04[0x26]] ; element[OxO2f04[0x2a]]=inp_access[OxO2f04[0x13]] ; element[OxO2f04[0x28]]=inp_index[OxO2f04[0x13]] ;if(element[OxO2f04[0x28]]==OxO2f04[0x29]){ element.removeAttribute(OxO2f04[0x28]) ;} ;if(element[OxO2f04[0x2a]]==OxO2f04[0x29]){ element.removeAttribute(OxO2f04[0x2a]) ;} ; CopySelect(list_options,element) ;}  ;





