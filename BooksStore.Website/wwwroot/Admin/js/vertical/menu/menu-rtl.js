"use strict!"
$(document).ready(function(){var noofdays=1;var Navbarbg="theme1";var headerbg="themelight1";var logobg="theme1";var menucaption="theme6";var bgpattern="theme1";var activeitemtheme="theme1";var frametype="theme1";var nav_image="false";var active_image="img1";var layout_type="light";var layout_width="wide";var menu_effect_desktop="shrink";var menu_effect_tablet="overlay";var menu_effect_phone="overlay";var menu_icon_style="st2";$("#pcoded").pcodedmenu({themelayout:'vertical',verticalMenuplacement:'right',verticalMenulayout:layout_width,MenuTrigger:'click',SubMenuTrigger:'click',activeMenuClass:'active',ThemeBackgroundPattern:bgpattern,HeaderBackground:headerbg,LHeaderBackground:menucaption,NavbarBackground:Navbarbg,logoBackground:logobg,ActiveItemBackground:activeitemtheme,NavbarImage:nav_image,ActiveNavbarImage:active_image,SubItemBackground:'theme2',ActiveItemStyle:'style0',ItemBorder:false,ItemBorderStyle:'solid',freamtype:frametype,SubItemBorder:false,DropDownIconStyle:'style1',menutype:menu_icon_style,layouttype:layout_type,FixedNavbarPosition:true,FixedHeaderPosition:true,collapseVerticalLeftHeader:true,VerticalSubMenuItemIconStyle:'style5',VerticalNavigationView:'view1',verticalMenueffect:{desktop:menu_effect_desktop,tablet:menu_effect_tablet,phone:menu_effect_phone,},defaultVerticalMenu:{desktop:"expanded",tablet:"offcanvas",phone:"offcanvas",},onToggleVerticalMenu:{desktop:"collapsed",tablet:"expanded",phone:"expanded",},});function handlenavimg(){$('.theme-color > a.navbg-pattern').on("click",function(){var value=$(this).attr("navbg-pattern");$('.pcoded').attr('sidebar-img-type',value);$('.pcoded').attr("sidebar-img","true");$('.pcoded-navbar').attr("navbar-theme","theme1");$('.pcoded-navigation-label').attr("menu-title-theme","theme6");});};handlenavimg();function handleogortheme(){$('.theme-color > a.logo-theme').on("click",function(){var logotheme=$(this).attr("logo-theme");$('.navbar-logo').attr("logo-theme",logotheme);$('.pcoded-navigation-label').attr("menu-title-theme","theme6");});};handleogortheme();function handlelayouttheme(){$('.theme-color > a.Layout-type').on("click",function(){var layout=$(this).attr("layout-type");if(layout=='dark'){$('.pcoded-header').attr("header-theme","theme6");$('.navbar-logo').attr("logo-theme",'themelight1');$('.pcoded-navbar').attr("navbar-theme","theme1");$('.pcoded-navbar').attr("active-item-theme","theme1");$('.pcoded').attr("sidebar-img","false");$('body').attr("themebg-pattern","theme1");$('.pcoded-navigation-label').attr("menu-title-theme","theme6");$('.profile-notification').attr("active-item-theme","theme1");$('.pcoded').attr("layout-type",layout);$('body').addClass('dark');}
if(layout=='light'){$('.pcoded-header').attr("header-theme","themelight1");$('.navbar-logo').attr("logo-theme",'themelight1');$('.pcoded-navbar').attr("navbar-theme","theme1");$('.pcoded-navbar').attr("active-item-theme","theme1");$('.pcoded').attr("sidebar-img","false");$('body').attr("themebg-pattern","theme1");$('.pcoded-navigation-label').attr("menu-title-theme","theme6");$('.profile-notification').attr("active-item-theme","theme1");$('.pcoded-navbar').attr("active-item-theme","theme1");$('.pcoded').attr("layout-type",layout);$('body').removeClass('dark');}
if(layout=='img'){$('.pcoded-navbar').attr("navbar-theme","theme1");$('.pcoded').attr("sidebar-img","true");$('.pcoded').attr("frame-type","theme1");$('.pcoded-navigation-label').attr("menu-title-theme","theme6");}
if(layout=='reset'){}});};handlelayouttheme();function handleleftheadertheme(){$('.theme-color > a.leftheader-theme').on("click",function(){var lheadertheme=$(this).attr("menu-caption");$('.pcoded-navigation-label').attr("menu-title-theme",lheadertheme);});};handleleftheadertheme();function handleheadertheme(){$('.theme-color > a.header-theme').on("click",function(){var headertheme=$(this).attr("header-theme");var activeitem=$(this).attr("active-item-color");$('.pcoded-navbar').attr("active-item-theme",activeitem);$('.pcoded').attr("fream-type",headertheme);if(headertheme=='themelight1'){$('body').attr("themebg-pattern",'theme1');}else{$('body').attr("themebg-pattern",headertheme);}
if(headertheme=='themelight1'){$('.pcoded-navigation-label').attr("menu-title-theme",'theme6');}else{$('.pcoded-navigation-label').attr("menu-title-theme",headertheme);}
$('.profile-notification').attr("active-item-theme",headertheme);$('.pcoded-header').attr("header-theme",headertheme);$('.navbar-logo').attr("logo-theme",headertheme);});};handleheadertheme();function handlenavbartheme(){$('.theme-color > a.navbar-theme').on("click",function(){var navbartheme=$(this).attr("navbar-theme");$('.pcoded-navbar').attr("navbar-theme",navbartheme);if(navbartheme=='themelight1'){$('.pcoded').attr("sidebar-img","false");$('.pcoded-navigation-label').attr("menu-title-theme","theme8");$('.profile-notification').attr("active-item-theme","theme1");}
if(navbartheme=='theme1'){$('.pcoded').attr("sidebar-img","false");$('.pcoded-navigation-label').attr("menu-title-theme","theme1");$('.profile-notification').attr("active-item-theme","theme1");}});};handlenavbartheme();function handleactiveitemtheme(){$('.theme-color > a.active-item-theme').on("click",function(){var activeitemtheme=$(this).attr("active-item-theme");$('.pcoded-navbar').attr("active-item-theme",activeitemtheme);$('.profile-notification').attr("active-item-theme",activeitemtheme);});};handleactiveitemtheme();function handlethemebgpattern(){$('.theme-color > a.themebg-pattern').on("click",function(){var themebgpattern=$(this).attr("themebg-pattern");$('body').attr("themebg-pattern",themebgpattern);});};handlethemebgpattern();function handlethemeverticallayout(){$('#theme-layout').change(function(){if($(this).is(":checked")){$('.pcoded').attr('vertical-layout',"box");$('#bg-pattern-visiblity').removeClass('d-none');}else{$('.pcoded').attr('vertical-layout',"wide");$('#bg-pattern-visiblity').addClass('d-none');}});};handlethemeverticallayout();function handleverticalMenueffect(){$('#vertical-menu-effect').val('shrink').on('change',function(get_value){get_value=$(this).val();$('.pcoded').attr('vertical-effect',get_value);});};handleverticalMenueffect();function handleverticalboderstyle(){$('#vertical-border-style').val('solid').on('change',function(get_value){get_value=$(this).val();$('.pcoded-navbar .pcoded-item').attr('item-border-style',get_value);});};handleverticalboderstyle();function handleVerticalDropDownIconStyle(){$('#vertical-dropdown-icon').val('style1').on('change',function(get_value){get_value=$(this).val();$('.pcoded-navbar .pcoded-hasmenu').attr('dropdown-icon',get_value);});};handleVerticalDropDownIconStyle();function handleVerticalSubMenuItemIconStyle(){$('#vertical-subitem-icon').val('style5').on('change',function(get_value){get_value=$(this).val();$('.pcoded-navbar .pcoded-hasmenu').attr('subitem-icon',get_value);});};handleVerticalSubMenuItemIconStyle();function handlesidebarposition(){$('#sidebar-position').change(function(){if($(this).is(":checked")){$('.pcoded-navbar').attr("pcoded-navbar-position",'fixed');$('.pcoded-header .pcoded-left-header').attr("pcoded-lheader-position",'fixed');}else{$('.pcoded-navbar').attr("pcoded-navbar-position",'absolute');$('.pcoded-header .pcoded-left-header').attr("pcoded-lheader-position",'relative');}});};handlesidebarposition();function handleheaderposition(){$('#header-position').change(function(){if($(this).is(":checked")){$('.pcoded-header').attr("pcoded-header-position",'fixed');$('.pcoded-navbar').attr("pcoded-header-position",'fixed');$('.pcoded-main-container').css('margin-top',$(".pcoded-header").outerHeight());}else{$('.pcoded-header').attr("pcoded-header-position",'relative');$('.pcoded-navbar').attr("pcoded-header-position",'relative');$('.pcoded-main-container').css('margin-top','0px');}});};handleheaderposition();function handlecollapseLeftHeader(){$('#collapse-left-header').change(function(){if($(this).is(":checked")){$('.pcoded-header, .pcoded ').removeClass('iscollapsed');$('.pcoded-header, .pcoded').addClass('nocollapsed');}else{$('.pcoded-header, .pcoded').addClass('iscollapsed');$('.pcoded-header, .pcoded').removeClass('nocollapsed');}});};handlecollapseLeftHeader();});function handlemenutype(get_value){$('.pcoded').attr('nav-type',get_value);$('.pcoded').attr('nav-type',get_value);};handlemenutype("st2");