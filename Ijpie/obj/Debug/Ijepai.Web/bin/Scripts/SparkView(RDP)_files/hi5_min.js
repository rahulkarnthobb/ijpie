var hi5=hi5||{};hi5.init={inited:false,funcs:[],push:function(a){hi5.init.funcs.push(a)},start:function(a){if(hi5.init.inited)return;hi5.browser.innerHeight=window.innerHeight;hi5.init.inited=true;var b=hi5.init.funcs;var c=0;for(var d=b.length;c<d;c++)b[c]();hi5.init.release()},release:function(){document.removeEventListener("DOMContentLoaded",hi5.init.start,false)}};if(!String.prototype.trim)String.prototype.trim=function(){return this.replace(/^\s+|\s+$/g,"")};
if(!Number.prototype.toByte)Number.prototype.toByte=function(){var a=this&255;return a>127?a-256:a};if(!Date.now)Date.now=function b(){return(new Date).getTime()};if(!String.prototype.applyArgs)String.prototype.applyArgs=function(a){var b=this.split("%");var c;var d;var e=b[0];var f=1;for(var g=b.length;f<g;f++){c=b[f];var h=parseInt(c,10);if(isNaN(h))e+=c;else{d=c.substring((h+"").length);c=a[h-1];if(c)e+=c;e+=d}}return e};
if(!String.prototype.hashCode)String.prototype.hashCode=function(){var a=0|0;var b=0;var c=this.length;for(var d=0;d<c;d++){b=this.charCodeAt(d);a=(a<<5)-a+b|0}return a};if(!Array.prototype.removeElm)Array.prototype.removeElm=function(a){var b=this.indexOf(a);if(b==-1)return;this.splice(b,1)};if(!Date.prototype.getStdTimezoneOffset)Date.prototype.getStdTimezoneOffset=function(){var a=new Date(this.getFullYear(),0,1);var b=new Date(this.getFullYear(),6,1);return Math.max(a.getTimezoneOffset(),b.getTimezoneOffset())};
if(!window.requestAnimationFrame)window.requestAnimationFrame=window.webkitRequestAnimationFrame||window.mozRequestAnimationFrame||window.msRequestAnimationFrame||function(a){window.setTimeout(a,30,Date.now())};window.URL=window.URL||window.webkitURL;
hi5.DateUtils={formatNum:function(a){return a<10?"0"+a:""+a},formatDate:function(a,b){if(!a)return"";var c=new Date(a);var d=c.getFullYear()+"-"+hi5.DateUtils.formatNum(c.getMonth()+1)+"-"+hi5.DateUtils.formatNum(c.getDate());if(b)d+=+" "+c.getHours()+":"+c.getMinutes();return d},parseDate:function(a){var b=a.split(" ");var c=b[0].split("-");if(c.length!=3)return null;if(b.length>1){var d=b[1].split(":");if(d.length!=2)return null;return new Date(c[0],c[1]-1,c[2],d[0],d[1])}else return new Date(c[0],
c[1]-1,c[2])}};window.WebSocket=window.WebSocket||window.MozWebSocket;hi5.WebSocket=window.WebSocket;hi5.$=function(a){return document.getElementById(a)};hi5.html={hasClass:function(a,b){return a.className.match(new RegExp("(\\s|^)"+b+"(\\s|$)"))},addClass:function(a,b){if(!hi5.html.hasClass(a,b))a.className+=" "+b},removeClass:function(a,b){if(hi5.html.hasClass(a,b)){var c=new RegExp("(\\s|^)"+b+"(\\s|$)");a.className=a.className.replace(c," ")}}};
hi5.browser=new function(){var a=navigator.userAgent;this.innerHeight=0;this.isEdge=a.indexOf("Edge")!=-1;var b=a.indexOf("MSIE")!=-1||a.indexOf("Trident")!=-1||this.isEdge;this.isIE=b;this.isTouch="ontouchstart"in window||"createTouch"in document||"DocumentTouch"in window&&window.document instanceof window.DocumentTouch||!!navigator.msMaxTouchPoints||navigator.maxTouchPoints>1||a.indexOf("Mobile")!=-1;this.isFirefox=a.indexOf("Firefox")!=-1&&!b;this.isOpera=a.indexOf("Opera")!=-1;this.isRIM=a.indexOf(" RIM ")!=
-1;this.isChrome=a.indexOf("Chrome")!=-1&&!b;this.isMacOS=a.indexOf("Mac OS")!=-1;this.isWindows=a.indexOf("Windows ")!=-1;this.isiOS=navigator.userAgent.match(/(iPad|iPhone|iPod)/i)?true:false;this.isSafari=a.indexOf("Chrome")==-1&&a.indexOf("Safari")!=-1&&!b;this.isWebKit=a.indexOf("WebKit")!=-1;this.isCrOS=a.indexOf("CrOS")!=-1;this.isOperaNext=a.indexOf("Edition Next")!=-1;this.isAndroid=a.indexOf("Android")!=-1;this.isChromeApp="chrome"in window&&"app"in chrome&&"window"in chrome.app;this.isDesktop=
!a.match(/(iPhone|iPod|iPad|Android|BlackBerry|Mobile)/);var c=window.outerHeight-window.innerHeight;this.isMetro=window.screenY==0&&(window.screenX==0||window.screenX+window.outerWidth==screen.width)&&c>3&&c<31;this.isMultitask=!(this.isiOS&&this.isSafari&&a.indexOf("Version/5")>0);this.binaryWS=function(){return hi5.browser.isChrome?true:hi5.tool.hasProperty(WebSocket,"binaryType")};this.cookie2Obj=function(){var a=document.cookie;var f={};var b;var c;if(a=="")return f;var d=a.split(";");var k=
0;for(var l=d.length;k<l;k++){for(var n=d[k];n.charAt(0)==" ";)n=n.substring(1,n.length);b=n.indexOf("=");if(b>0){c=decodeURIComponent(n.substring(b+1).replace(/\+/g," "));if(hi5.tool.isNumber(c)&&c[0]!="0"&&parseFloat(c)==c)c=parseFloat(c);if(c=="true"||c=="on")c=true;else if(c=="false"||c=="off")c=false;f[n.substring(0,b)]=c}}return f};this.getLibPath=function(a){var f=document.getElementsByTagName("script");var b;var c;var d="";var k=f.length;for(var l=0;l<k;l++){c=f[l].src;b=c.indexOf(a);if(b>
-1){d=c.substring(0,b);break}}return d};this.loadJS=function(a){if(a.indexOf("/")<0)a=hi5.libPath+a;if(hi5.browser.getLibPath(a))return;var f=document.createElement("script");f.type="text/javascript";f.src=a;var b=document.body||document.getElementsByTagName("script")[0].parentNode;b.appendChild(f)};this.formToObj=function(a,f){var b=a.elements;var c;var d;var k;var l;var n=b.length;if(!f)f={};for(var p=0;p<n;p++){c=b[p];k=c.name;if(!k)continue;d=c.type;switch(d){case "submit":case "button":case "reset":continue;
case "checkbox":l=c.checked;break;case "radio":if(!c.checked)continue;l=c.value;break;case "number":l=parseFloat(c.value);default:l=c.value}if(l=="")continue;f[k]=l}return f};this.objToForm=function(a,c){var b;var d;var m=c.elements;for(var k in a){b=m[k];if(!b)continue;d=a[k];var l=typeof d;if(l=="boolean")b.checked=d;else b.value=d}};this.objToCookie=function(a){for(var b in a){if(a[b]=="")continue;document.cookie=b+"="+a[b]}};this.getScale=function(){return document.documentElement.clientWidth/
window.innerWidth};this.httpGet=function(a,b){var c=new XMLHttpRequest;c.open("GET",a,b);c.setRequestHeader("Content-Type","text/plain;charset=UTF-8");c.send(null);return c.responseText};this.selectEditable=function(a){try{var b=document.createRange();b.selectNodeContents(a);var c=window.getSelection();c.removeAllRanges();c.addRange(b)}catch(d){console.log(d)}};this.setOrientaionHandler=function(a){if("onorientationchange"in screen)screen.onorientationchange=a;else if("onmozorientationchange"in screen)screen.onmozorientationchange=
a;else if("onmsorientationchange"in screen)screen.onmsorientationchange=a;else window.addEventListener("orientationchange",a,false)};var d={x:0,y:0};this.getMousePos=function(a){var b=a.target.getBoundingClientRect();d.x=a.clientX-b.left;d.y=a.clientY-b.top;return d};this.calMousePos=function(a,b,c){var h=c.getBoundingClientRect();d.x=a-h.left;d.y=b-h.top;return d};this.getHost=function(){var a=hi5.tool.queryToObj().gateway;if(!a&&!hi5.browser.isChromeApp){a=location.host;if(!a)a="localhost";else{var b=
location.pathname;var c=b.indexOf("://");if(c>0)a+=b.substring(0,b.indexOf("/",c+3))}}return a}};hi5.libPath=hi5.browser.getLibPath("hi5_min.js");if(!hi5.libPath)hi5.libPath=hi5.browser.getLibPath("hi5.js");
hi5.storage=new function(){function a(a,b){this._state=b||0;this._value=a}function b(a){if(a&&a.indexOf("{")==0){var b=JSON.parse(a);if(b&&"_state"in b&&"_value"in b)return b}return null}var c="chrome"in window&&!!chrome.storage;var d="localStorage"in window;if(d)try{localStorage.setItem("_t_s_t","1");localStorage.removeItem("_t_s_t")}catch(f){this.isAvailable=false;d=false}this.isAvailable=!!c||d;var e=c||!this.isAvailable?{}:localStorage;if(c)chrome.storage.local.get(null,function(a){for(var b in a)e[b]=
a[b]});this.set=function(b,c){e[b]=JSON.stringify(new a(c,1))};this.get=function(a){var c=e[a];var d=b(c);return d?d._value:c};this.clear=function(a){e={};if(c)chrome.storage.local.clear(a||function(){});else if(d)localStorage.clear()};this.remove=function(a){if(e.removeItem)e.removeItem(a);else{var c=b(e[a]);if(c){c._state=2;e[a]=JSON.stringify(c)}}};this.commit=function(a){a=a||function(){};if(c){var d={};var h=[];var m=false;for(var k in e){var l=b(e[k]);if(!l)continue;if(l._state==1){d[k]=l._value;
m=true}else if(l._state==2)h.push(k)}if(h.length>0){var n=function(){var b=0;for(var c=h.length;b<c;b++)delete e[h[b]];a&&a()};chrome.storage.local.remove(h,n)}if(m)chrome.storage.local.set(d,a)}else a()}};
hi5.Arrays={fill:function(a,b,c,d){if(a.fill)a.fill(d,b,c);else for(var e=b;e<c;e++)a[e]=d},arraycopy:function(a,b,c,d,e){if(c.set&&a.subarray)c.set(a.subarray(b,b+e),d);else for(var f=0;f<e;f++)c[d+f]=a[b+f]},equals:function(a,b){if(a==b)return true;if(!a||!b)return false;var c=a.length;if(c!=b.length)return false;for(var d=0;d<c;d++)if(a[d]!=b[d])return false;return true},startWidth:function(a,b){var c=0;for(var d=b.length;c<d;c++)if(a[c]!=b[c])return false;return true},__sortNumber:function(a,
b){return a-b},sortNumber:function(a){return a.sort(hi5.Arrays.__sortNumber)},hashCode:function(a){var b=1|0;var c=0;for(var d=a.length;c<d;c++)b=31*b+a[c]|0;return b}};hi5.callback={callbacks:{},no:0,put:function(a){var b="CB"+this.no++;this.callbacks[b]=a;return b},get:function(a){var b=this.callbacks[a];if(b)delete this.callbacks[a];return b}};
hi5.tool={isNumber:function(a){return!isNaN(parseFloat(a))&&isFinite(a)},cumulativePos:function(a){var b=0;var c=0;do{b+=a.offsetTop||0;c+=a.offsetLeft||0;b+=parseInt(a.style.borderLeftWidth)||0;c+=parseInt(a.style.borderTopWidth)||0;b-=a.scrollTop;c-=a.scrollLeft;a=a.offsetParent;if(a==document.body)break}while(a);return{x:c,y:b}},getPos:function(a,b){var c=0;var d=0;if(a.offsetParent){do{if(b&&a.style.position)break;c+=a.offsetLeft;d+=a.offsetTop}while(a=a.offsetParent)}return{x:c,y:d}},bytesToSize:function(a){if(isNaN(a))return"";
var b=[" bytes"," KB"," MB"," GB"," TB"," PB"," EB"," ZB"," YB"];var c=Math.floor(Math.log(+a)/Math.log(2));if(c<1)c=0;var d=Math.floor(c/10);a=+a/Math.pow(2,10*d);if(a.toString().length>a.toFixed(3).toString().length)a=a.toFixed(3);return a+b[d]},queryToObj:function(a,b){if(!a)a=location.search.substring(1);var c=b||{};if(!!a){var d=a.split("&");var e=d.length;for(var f=0;f<e;f++){var g=d[f].split("=");c[g[0]]=decodeURIComponent(g[1])}}return c},replaceQuery:function(a,b,c){var d=a.indexOf(b+"=");
var e=false;if(d>0){var f=a.charAt(d-1);if(f=="&"||f=="?")e=true}if(!e)return a+="&"+b+"="+encodeURIComponent(c);var g=new RegExp("[\\?&]"+b+"=([^&#]*)");return a.replace(g,function(a){return a.charAt(0)+b+"="+encodeURIComponent(c)})},disableInput:function(){var a=document.createElement("div");a.style.position="fixed";a.style.left=0;a.style.top=0;a.style.width="100%";a.style.height="100%";a.style.zIndex=99999;a.style.background="url("+hi5.libPath+"spinner.gif) no-repeat center center";document.body.appendChild(a);
window.__hi5_bk=a},enableInput:function(){if(window.__hi5_bk){document.body.removeChild(window.__hi5_bk);window.__hi5_bk=null}},scale:function(a,b,c,d,e){var f=d===undefined?"left top":d+" "+e;if(!c)c=b;a.style.transformOrigin=f;a.style.MozTransformOrigin=f;a.style.webkitTransformOrigin=f;a.style.msTransformOrigin=f;a.style.OTransformOrigin=f;b="scale("+b+","+c+")";a.style.transform=b;a.style.MozTransform=b;a.style.webkitTransform=b;a.style.msTransform=b;a.style.OTransform=b},openWebSocket:function(a,
b,c){var d=false;if(c){var e=hi5.callback.put(c);a+="&callback="+e}var f=new WebSocket(a,"ctrl");f.onopen=function(a){d=true;if(b)f.send(b)};f.onclose=function(a){if(!d)alert("Failed to connect")};f.onmessage=function(a){var b=JSON.parse(a.data);f.close();if(b.callback)hi5.callback.get(b.callback)(b);else console.log(b)};return f},getChildNodesByTag:function(a,b){var c=a.childNodes;var d=[];var e=0;for(var f=c.length;e<f;e++){if(c[e].nodeName.toLowerCase()!=b)continue;d.push(c[e])}return d},hasProperty:function(a,
b){var c=b in a||b in a.prototype;if(c)return true;var d=a.__proto__||a.constructor.prototype;return b in d},isCapslock:function(a){var b=String.fromCharCode(a.keyCode||a.which);if(b.toUpperCase()==b&&b.toLowerCase()!=b&&!a.shiftKey)return true;return false},getImage:function(a,b){if(b&&b.indexOf("/")!=0)b=hi5.libPath+b;return hi5&&hi5.appcfg&&hi5.appcfg.img?hi5.appcfg.img[a]||b:b},uuid:function(){return"xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g,function(a){var b=Math.random()*16|0;var c=
a=="x"?b:b&3|8;return c.toString(16)})},text2html:function(a){return a.replace(/\n/g,"<br>")},PingPong:function(a,b,c){function d(b){var c=b?2+b.length:2;var e=new Uint8Array(c);e[0]=146;e[1]=0;if(b)e.set(b,2);a(e.buffer)}function e(){if(h>0){if(l&&c&&m-k>l)if(c()){h=0;return}else k=m;d(null);m++;g=setTimeout(e,h)}}function f(){if(h>0){if(g)clearTimeout(g);g=setTimeout(e,h)}}var g=0;var h=0;var m=0;var k=0;var l=0;this.setInterval=function(b,c){var e=h<1E3&&b>1;h=b*1E3;l=c||0;var d=new Uint8Array(3);
d[0]=146;d[1]=2;d[2]=b;a(d.buffer);if(e)f()};this.getInterval=function(){return h};this.processPong=function(a){k++;if(b)b(a)};this.sendPingData=d;this.sendPing=f},Profiler:function(){function a(){this.count=0;this.totalTime=0}var b={};var c=0;var d=null;this.begin=function(e){d=e;var f=b[e];if(f==undefined){f=new a;b[e]=f}c=(new Date).getTime();return f};this.end=function(a){var f=b[a||d];var g=(new Date).getTime()-c;f.totalTime=f.totalTime+g;f.count++;return f};this.print=function(){console.log(this.getResult())};
this.getResult=function(a){var c="\r\ncase\t\t\tcount\t\t\ttotal\t\t\tavg";var d=typeof a=="undefined"?0:a.length;for(var h in b){if(d>0)if(h.substring(0,d)!=a)continue;var m=b[h];c+="\r\n"+(h+"\t\t\t"+m.count+"\t\t\t"+m.totalTime+"\t\t\t"+m.totalTime/m.count)}return c}}};navigator.getUserMedia=navigator.getUserMedia||navigator.webkitGetUserMedia||navigator.mozGetUserMedia||navigator.msGetUserMedia;
hi5.audio={recordable:!!navigator.getUserMedia,getAudioContext:function(){var a=window.__autoContextInstance;if(!a)try{a=window.parent.__autoContextInstance}catch(c){}if(!a){var b=window.AudioContext||window.webkitAudioContext||null;if(b){a=new b;window.__autoContextInstance=a;try{if(window.parent!=window)window.parent.__autoContextInstance=a}catch(c){}}}return a}};
hi5.EventControl=function(a){a.addEvent=function(b,c){if(!a[b]||!a[b]._evt_listeners){a[b]=function(){a.fireEvent(b,arguments)};a[b]._evt_listeners=[]}a[b]._evt_listeners.push(c)};a.removeEvent=function(b,c){if(!a[b]&&!a[b]._evt_listeners)return false;var d=a[b]._evt_listeners;var e=d.indexOf(c);if(e>-1){d.removeElm(e);return true}return false};a.fireEvent=function(b,c){if(!a[b]||!a[b]._evt_listeners)return;var d=a[b]._evt_listeners;if(!c)c=[];var e=0;for(var f=d.length;e<f;e++)d[e].apply(a,c)};return a};
hi5.ui=hi5.ui||{};hi5.ui.confirm=function(a){return hi5.browser.isChromeApp?true:confirm(a)};hi5.chromeapp={convertLink:function(a){var b=0;for(var c=a.length;b<c;b++)a[b].onclick=function(a){var b=a.target.href;var c=b.lastIndexOf("/");if(c!=-1)b=b.substring(c+1);chrome.app.window.create(b,{left:window.screenLeft+20,top:window.screenTop+20,width:window.innerWidth,height:window.innerHeight});return false}}};
hi5.Dragable=function(a){function b(b){if(b.stopPropagation)b.stopPropagation();if(b.touches)b=b.touches[0];e.x=b.pageX;e.y=b.pageY;a.style.bottom="auto"}function c(b){if(b.preventDefault)b.preventDefault();if(b.touches)b=b.touches.length==1?b.touches[0]:b.changedTouches[0];var c=getPos(a,true);var d=c.x-e.x;var f=c.y-e.y;a.style.left=a.offsetLeft+d+"px";a.style.top=a.offsetTop+f+"px";e.x=c.x;e.y=c.y}function d(b){if(b.stopPropagation)b.stopPropagation();if(b.touches)return;var c=b.pageX-e.x;var d=
b.pageY-e.y;a.offsetLeft=a.offsetLeft+c+"px";a.offsetTop=a.offsetTop+d+"px"}a.draggable=true;var e={x:0,y:0};var f=hi5.browser.isTouch;a.addEventListener(f?"touchstart":"dragstart",b,false);a.addEventListener(f?"touchend":"dragend",d,false);if(f)a.addEventListener("touchmove",c,false);return a};
hi5.Fadable=function(a,b,c){function d(){if(document.activeElement==a.activeObj)setTimeout(d,g);else a.style.display="none"}function e(b){if(b&&b.preventDefault)b.preventDefault();if(a.style.display=="block")return;if(a.beforeDisplay)a.beforeDisplay();a.style.display="block";if(!m)return;if(h!=null)clearTimeout(h);h=setTimeout(d,g);return false}if(a.tabIndex<0)a.tabIndex=999;var f=c||document;var g=b||3E3;var h=null;var m=true;a.setFadable=function(b){m=b;if(b){var c="mouseup";if(navigator.pointerEnabled)c=
"pointerup";else if(navigator.msPointerEnabled)c="MSPointerUp";else if(hi5.browser.isTouch)c="touchend";f.addEventListener(c,e,false);if(c="touchend")f.addEventListener("mouseup",e,false)}else a.style.display="block"};a.startFade=e};hi5.cancelDefault=function(a){if(a.preventDefault)a.preventDefault();if(a.stopPropagation)a.stopPropagation();return false};
hi5.Toolbar=function(a){a.addButton=function(b,c,d){var e=document.createElement("img");e.src=b;if(hi5.browser.isTouch){if(!navigator.msMaxTouchPoints)e.addEventListener("touchend",c,false)}else e.onclick=c;a.appendChild(e);if(d)e.id=d;return e};a.getButton=function(b){var c=a.getElementsByTagName("img");var d=c.length;for(var e=0;e<d;e++)if(c[e].id==b)return c[e];return null};a.removeButton=function(b){var c=a.getElementsByTagName("img");var d=c.length;for(var e=0;e<d;e++)if(c[e].id==b){a.removeChild(c[e]);
break}};return a};hi5.ProgressBar=function(a){a.progress=0;a.maxValue=0;var b=a.getElementsByTagName("div")[0];a.setProgress=function(c){var d=Math.floor(c/a.maxValue*100);if(d==a.progress)return;a.progress=d;b.style.width=d/100*a.offsetWidth+"px"};return a};
hi5.Lightbox=function(a,b,c){function d(){var b=e.clientWidth;var c=e.clientHeight;var d=a.offsetWidth;var g=a.offsetHeight;if(d>b*.96){d=b*.96;a.style.width=d+"px"}if(g>c*.96){g=c*.96;a.style.height=g+"px";a.style.width=a.offsetWidth+22+"px"}var n=(b-d)/2;var p=(c-g)/3;a.style.left=n+"px";a.style.top=p+"px";f.style.left=n+a.offsetWidth-6+"px";f.style.top=p-6+"px"}var e=document.createElement("div");e.id="divBackground";e.style.position="fixed";e.style.left=0;e.style.top=0;e.style.width="100%";e.style.height=
"100%";e.style.zIndex=999;e.style.backgroundColor=c?c:"#222";if(!b)b=.4;if(b<1)e.style.opacity=b;a.style.position="absolute";a.style.zIndex=1E3;a.style.visibility="hidden";var f=document.createElement("div");f.id="divCloseButton";f.style.position="absolute";var g=document.createElement("img");g.width=25;g.height=25;g.src=hi5.tool.getImage("del","del.png");g.style.cursor="pointer";f.style.zIndex=10001;g.align="top";f.appendChild(g);a.resize=d;a.show=function(){var b=document.body;b.appendChild(e);
b.appendChild(f);a.style.display="block";a.style.visibility="visible";d();if(a.onopen)a.onopen(a)};a.visible=function(){return a&&a.style.visibility=="visible"};a.dismiss=function(b){function c(){var b=document.body;b.removeChild(e);b.removeChild(f);a.style.display="none";a.style.visibility="hidden";if(a.onclose)a.onclose()}if(typeof b=="number")setTimeout(c,b);else c()};a.background=e;g.addEventListener("click",a.dismiss,false);return a};
hi5.DataTable=function(a){hi5.EventControl(a);var b=typeof a;if(b=="string")a=JSON.parse(a);var c=a.rows;var d=a.cols;a.rowNo=-1;a.beforeGetValue=null;a.moveTo=function(b){a.rowNo=b};a.getColNo=function(a){var b=0;for(var c=d.length;b<c;b++)if(d[b].name==a)return b;return-1};a.getValue=function(b){var d=c[a.rowNo][b];return!a.beforeGetValue?d:a.beforeGetValue(b,d)};a.setValue=function(b,d){if(a.beforeSetValue)d=a.beforeSetValue(b,d);c[a.rowNo][b]=d;a.fireEvent("onchange",[b,a.rowNo,d])};a.first=function(){a.moveTo(0)};
a.next=function(){a.moveTo(a.rowNo+1)};a.last=function(){a.moveTo(c.length-1)};a.hasNext=function(){return a.rowNo<c.length-1};a.remove=function(b){if(!b)b=a.rowNo;var d=[b];a.fireEvent("beforeremove",d);c.splice(b,1);a.fireEvent("onremove",d)};a.perform=function(b){if(typeof a[b]=="function")a[b].apply(a);else a.fireEvent("onaction",[b])};a.getObject=function(){var b=new Object;var c=0;for(var g=d.length;c<g;c++)b[d[c].name]=a.getValue(c);return b};a.find=function(a,b){var d=0;for(var h=c.length;d<
h;d++)if(c[d][a]==b)return c[d];return null};a.fireEvent("onopen");return a};
hi5.DataGrid=function(a){function b(b){var c=this.rowIndex;if(typeof c=="number"){c=c-a.tHead.rows.length;d=c;a.dataTable.moveTo(c)}if(a.onrowclick)a.onrowclick(b)}function c(){if(!a._rowTemp){var b=a.tBodies[0].rows[0];a._rowTemp=b.cloneNode(true)}return a._rowTemp}if("TABLE"!=a.nodeName)throw"Not HTML Table";a.dataTable=null;a.onrowclick=null;var d=-1;a.getValue=function(b){var c=a.dataTable;c.moveTo(d);return c.getValue(c.getColNo(b))};a.fillData=function(e){var f=e.rows;var g=e.cols;var h=a.tBodies[0];
var m;var k;var l;var n;var p=c();var q=p.cells.length;var r;var t=h.cloneNode(false);var u;l=f.length;for(k=0;k<l;k++){r=p.cloneNode(true);u=r.cells;e.moveTo(k);for(m=0;m<q;m++)if(!u[m].innerHTML){n=e.getValue(m);if(a.beforeDisplayValue)n=a.beforeDisplayValue(m,n);u[m].innerHTML=n}d=k;r.addEventListener("click",b,false);if(a.beforeAppendRow)a.beforeAppendRow(r);t.appendChild(r)}a.removeChild(h);a.appendChild(t)};a.open=function(){function b(c){var d=a.tBodies[0];var e=d.rows[c];if(e)d.removeChild(e)}
if(!a.dataTable)return;a.fillData(a.dataTable);a.dataTable.addEvent("onremove",b)};return a};
hi5.Select=function(a,b,c){var d=a.parentNode;var e=document.createElement("div");e.style.padding="0";e.style.display="inline";d.insertBefore(e,a);var f=document.createElement("img");f.src=hi5.tool.getImage("select","select.png");f.height=a.offsetHeight;f.style.verticalAlign="-6px";e.appendChild(a);e.appendChild(f);var g=document.createElement("select");if(b){g.multiple=true;if(!c)c=","}var h=a.getAttribute("hi5_size");g.size=h?h:10;var m=a.getAttribute("hi5_list");if(m){var k=m.split(";");var l=
k.length;if(l>0){var n=g.options;for(var p=0;p<l;p++)n[p]=new Option(k[p])}}g.style.position="absolute";g.style.zIndex=99999;g.style.display="none";document.body.appendChild(g);a.show=function(){if(a.beforedropdown)a.beforedropdown(a);g.style.display="";g.focus()};a.hide=function(){g.style.display="none";a.focus()};f.onclick=function(){if(g.style.display=="none"){if(g.options.length==0){var b=a.getAttribute("onfetchlist");if(b)eval(b)}var c=hi5.tool.getPos(a,false);g.style.left=c.x+"px";g.style.top=
c.y+a.offsetHeight+"px";g.style.width=a.offsetWidth+f.width+3+"px";a.show()}else a.hide()};g.onchange=function(){if(!b){a.value=g.value;g.style.display="none"}else{var d=[];var e;var f=g.options;var h=0;for(var k=f.length;h<k;h++){e=f[h];if(e.selected)d.push(e.value)}a.value=d.join(c)}if(a.onchange)a.onchange()};a.options=g.options;return a};hi5.init.push(function(){var a=document.getElementsByClassName("Hi5Select");var b=a.length;for(var c=0;c<b;c++)new hi5.Select(a[c])});
hi5.Tab=function(a){function b(b){var c=f;if(f!=b){g[f].className="tab_back";h[f].className="tab_hide";f=b}g[b].className="tab_front";h[b].className="tab_show";g[b].focus();if(c!=b)a.fireEvent("ontabchange",[b,c])}function c(a){var c=g.indexOf(a.target);if(c==-1)return;b(c)}hi5.EventControl(a);var d=a.getElementsByClassName("tab")[0].getElementsByClassName("tab_title")[0].childNodes;var e=d.length;var f=0;var g=new Array(0);var h=new Array(0);for(var m=0;m<e;m++){var k=d[m];if(k.nodeName.toUpperCase()!=
"SPAN")continue;k.className="tab_back";k.onclick=c;k.onfocus=c;g[g.length]=k}var l=a.getElementsByClassName("tab_body")[0].childNodes;e=l.length;for(m=0;m<e;m++){var n=l[m];if(n.nodeName.toUpperCase()!="DIV")continue;h[h.length]=n;n.className="tab_hide"}b(f);a.setSelected=b;a.getSelected=function(){return f};return a};hi5.init.push(function(){var a=document.getElementsByClassName("tab_all");var b=a.length;for(var c=0;c<b;c++)new hi5.Tab(a[c])});hi5.graphic={};
hi5.graphic.Line=function(){this.x1=0;this.y1=0;this.x2=0;this.y2=0};hi5.graphic.Line.prototype.set=function(a,b,c,d){this.x1=a;this.y1=b;this.x2=c;this.y2=d};
hi5.graphic.Line.prototype.intersection=function(a,b,c,d){var e;var f;var g;var h;var m;var k={x:null,y:null,onLine1:false,onLine2:false};var l=this.x1;var n=this.y1;var p=this.x2;var q=this.y2;e=(d-b)*(p-l)-(c-a)*(q-n);if(e==0)return k;f=n-b;g=l-a;h=(c-a)*f-(d-b)*g;m=(p-l)*f-(q-n)*g;f=h/e;g=m/e;k.x=l+(f*(p-l)|0);k.y=n+(f*(q-n)|0);if(f>0&&f<1)k.onLine1=true;if(g>0&&g<1)k.onLine2=true;return k};
hi5.graphic.Rectangle=function(a,b,c,d){this.x=a;this.y=b;this.width=c;this.height=d;var e=this;this.union=function(a,b,c,d){var k=e.width;var l=e.height;if((k|l)<0){e.x=a;e.y=b;e.width=c;e.height=d;return}var n=c;var p=d;if((n|p)<0)return;var q=e.x;var r=e.y;k+=q;l+=r;var t=a;var u=b;n+=t;p+=u;if(q>t)q=t;if(r>u)r=u;if(k<n)k=n;if(l<p)l=p;k-=q;l-=r;e.x=q;e.y=r;e.width=k;e.height=l};this.intersection=function(a,b,c,d,k){var l=e.x;var n=e.y;var p=l;p+=e.width;var q=n;q+=e.height;var r=a;r+=c;var t=b;
t+=d;if(l<a)l=a;if(n<b)n=b;if(p>r)p=r;if(q>t)q=t;p-=l;q-=n;if(k){k.x=l;k.y=n;k.width=p;k.height=q;return k}return new hi5.graphic.Rectangle(l,n,p,q)};this.isEmpty=function(){return e.width<=0||e.height<=0}};
hi5.notifications=new function(){function a(c){function d(a,b){var c=document.createElement("span");c.className=b;c.onclick=function(b){a.apply(e,[b])};return c}var e=document.createElement("div");e.className="hi5_notifer slideUp";e.title=c.title;e.message=c.msg;e.msgCount=1;var f=document.createElement("div");f.className="hi5_notifer_title";var g=document.createElement("span");g.className="hi5_notifer_icon";f.appendChild(g);f.appendChild(document.createTextNode(e.title));e.appendChild(f);var h=document.createElement("div");
var m=document.createElement("span");m.innerHTML=c.msg;h.appendChild(m);if(!b.disableCounter){var k=document.createElement("span");k.className="hi5_notifer_count";e.addCount=function(a){a=a||1;e.msgCount+=a;k.innerHTML="("+e.msgCount+")"};if(c.count&&c.count>1)e.addCount(c.count-1);h.appendChild(k)}if(c.cbNo)h.appendChild(d(c.cbNo,"hi5_notifer_button_no"));if(c.cbYes)h.appendChild(d(c.cbYes,"hi5_notifer_button_yes"));e.appendChild(h);e.destroy=function(){if(e.parentNode){e.parentNode.removeChild(e);
var d=b.notifyPool.shift();if(d)b.getElement().appendChild(new a(d));else if(b.onempty&&b.notifySize()==0)b.onempty();if(c.cbClose)c.cbClose()}};if(c.timeout)setTimeout(function(){e.destroy()},c.timeout);if(!c.cbYes&&!c.cbNo)e.onclick=e.destroy;return e}this.notifyPool=[];this.disableCounter=false;this.getElement=function(){var a=hi5.$("hi5_notifer_all");if(!a){a=document.createElement("div");a.id="hi5_notifer_all";document.body.appendChild(a)}return a};var b=this;this.notify=function(c){var d=typeof c==
"string"?{msg:c,title:"",count:1}:c;if(!d.title)d.title="";if(!d.count)d.count=1;if(b.onnotify&&b.onnotify(d))return;var e=hi5.tool.getChildNodesByTag(b.getElement(),"div");var f=e.length;if(!b.disableCounter&&f>0){var g=e[f-1];if(g.title==d.title&&g.message==d.msg){g.addCount();return}}if(f<3)b.getElement().appendChild(new a(d));else{var h=b.notifyPool;if(!b.disableCounter&&h.length>0){var m=h[h.length-1];if(m.title==d.title&&m.msg==d.msg){m.count++;return}}h.push(d)}};this.notifySize=function(){return hi5.tool.getChildNodesByTag(b.getElement(),
"div").length};this.clearAll=function(){b.notifyPool.length=0;for(var a=b.getElement();a.hasChildNodes();)a.removeChild(a.firstChild)}};
hi5.Base64={table:"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".split(""),enc:function(a,b,c){var d="";var e=this.table;if(!b)b=a.length;if(!c)c=0;var f=c;var g=c+b-2;for(var h=b%3;f<g;f+=3){d+=e[a[f]>>2];d+=e[((a[f]&3)<<4)+(a[f+1]>>4)];d+=e[((a[f+1]&15)<<2)+(a[f+2]>>6)];d+=e[a[f+2]&63]}if(h==2){f=c+b-2;d+=e[a[f]>>2];d+=e[((a[f]&3)<<4)+(a[f+1]>>4)];d+=e[(a[f+1]&15)<<2];d+="="}else if(h==1){f=c+b-1;d+=e[a[f]>>2];d+=e[(a[f]&3)<<4];d+="=="}return d},binaries:[-1,-1,-1,-1,-1,-1,-1,
-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,62,-1,-1,-1,63,52,53,54,55,56,57,58,59,60,61,-1,-1,-1,0,-1,-1,-1,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,-1,-1,-1,-1,-1,-1,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,-1,-1,-1,-1,-1],dec:function(a,b){var c=this.binaries;var d;var e;var f;var g;var h;var m;var k=0;var l=0;var n=a.indexOf("=")-b;var p=a.length;if(n<0)n=p-b;e=(n>>2)*
3+Math.floor(n%4/1.5);d=new Array(e);d[0]=0;for(f=0,g=b;g<p;g++){h=c[a.charCodeAt(g)&127];m=a.charAt(g)=="=";if(h==-1){console.log("Illegal character '"+a.charCodeAt(g)+"'");continue}l=l<<6|h;k+=6;if(k>=8){k-=8;if(!m)d[f++]=l>>k&255;l&=(1<<k)-1}}return d}};
hi5.file={readAsArrayBuffer:function(a,b){var c=new FileReader;c.onloadend=function(a){b(new Uint8Array(a.target.result))};c.readAsArrayBuffer(a)},getEntries:function(a){var b=a.target&&(a.target.webkitEntries||a.target.entries||[]);if(!b.length){var c=a.dataTransfer&&a.dataTransfer.items;if(c){var d=0;for(var e;e=c[d];++d){if(e.kind!="file")continue;if(!e.webkitGetAsEntry&&!e.getAsEntry)break;var f=e.webkitGetAsEntry()||e.getAsEntry();if(!f)break;b.push(f)}}}return b},DirectoryReader:function(a){function b(a){return Array.prototype.slice.call(a||
[],0)}function c(a,c){var d=a.createReader();var e=[];var k=function(){d.readEntries(function(a){if(!a.length)c(e);else{e=e.concat(b(a));k()}})};k()}function d(a){var b=0;for(var h=a.length;b<h;b++){var m=a[b];if(m.isFile){var k=function(a){return function(b){e.onfile(b,a)}};m.file(k(m.fullPath))}else if(m.isDirectory)c(m,function(a){d(a)})}}var e=this;this.start=function(){d(a)}}};
hi5.DataBuffer=function(a,b,c){if(!b)b=0;if(!c)c=a.length;this.size=c;var d=b;var e=b+c;var f=hi5.Arrays.arraycopy;var g=this;this.attach=function(b,c,f){if(a)a=null;a=b;d=c;g.size=f;e=c+f};this.reset=function(a){d=0;g.size=e=a};this.markEnd=function(a){e=a||g.getPosition()};this.getEnd=function(){return e};this.has=function(a){return e-d>=a};this.getByte=function(){return a[d++]};this.getBytes=function(b){var c;if(a.slice)c=a.slice(d,d+b);else if(a.buffer&&a.buffer.slice)c=new Uint8Array(a.buffer.slice(d,
d+b));else{c=!!Uint8Array?new Uint8Array(b):new Array(b);c[0]=0;for(var e=0;e<b;e++)c[e]=a[d+e]}d+=b;return c};this.copyToByteArray=function(b,c,d,e){f(a,d,b,c,e)};this.getCapacity=function(){return a.length};this.getPosition=function(){return d};this.getLittleEndian16=function(){var b=a[d+1]<<8|a[d];d+=2;return b};this.getBigEndian16=function(){var b=a[d]<<8|a[d+1];d+=2;return b};this.getLittleEndian32=function(){var b=a[d+3]<<24|a[d+2]<<16|a[d+1]<<8|a[d];d+=4;return b};this.getLittleEndian64=function(){var b=
a[d+7]<<56|a[d+6]<<48|a[d+5]<<40|a[d+4]<<32|a[d+3]<<24|a[d+2]<<16|a[d+1]<<8|a[d];d+=8;return b};this.getBigEndian32=function(){var b=a[d]<<24|a[d+1]<<16|a[d+2]<<8|a[d+3];d+=4;return b};this.getUnicodeString=function(a,b){var c=Math.floor(a/2);var d="";for(var e=0;e<c;e++){var f=this.getLittleEndian16();if(b&&f==0){this.skipPosition((c-e-1)*2);break}d+=String.fromCharCode(f)}return d};this.getAscllString=function(a){var b="";var c=a||e;for(var d=0;d<c;d++){var f=this.getByte();if(f==0){if(a)this.skipPosition(a-
d-1);break}b+=String.fromCharCode(f)}return b};this.setAscllString=function(b){var c=0;for(var e=b.length;c<e;c++)a[d++]=b.charCodeAt(c)};this.setUnicodeString=function(a){var b=a.length;for(var c=0;c<b;c++)this.setLittleEndian16(a.charCodeAt(c))};this.skipPosition=function(a){d+=a};this.setPosition=function(a){d=a};this.getData=function(){return a};this.setByte=function(b){a[d++]=b};this.setBytes=function(b,c,e){if(!e)e=b.length;if(!c)c=0;for(var f=c;f<e;f++)a[d++]=b[f]};this.setLittleEndian16=function(b){a[d++]=
b&255;a[d++]=b>>8&255};this.setLittleEndian32=function(b){a[d++]=b&255;a[d++]=b>>8&255;a[d++]=b>>16&255;a[d++]=b>>24&255}};
hi5.Chat=function(a,b){function c(a,b,c){var d=document.createElement("span");d.className=b;d.innerHTML=a;c.appendChild(d);return d}function d(){var a=f.value;h.add(a,b);f.value="";if(h.onchat)h.onchat(a,b)}var e=hi5.$("chatHistory");var f=hi5.$("chatText");var g=hi5.$("chatSend");var h=this;this.add=function(d,f){var g=document.createElement("div");c((f||b)+":","chatFrom",g);c(d,"chatMsg",g);var h=new Date;c(h.getHours()+":"+h.getMinutes()+":"+h.getSeconds(),"chatTime",g);if(a.style.display!="block")a.style.display=
"block";e.appendChild(g);e.scrollTop=e.scrollHeight};f.addEventListener("keydown",function(a){if(a.keyCode==13)d()},false);g.addEventListener("click",d,false)};document.addEventListener("DOMContentLoaded",hi5.init.start,false);
