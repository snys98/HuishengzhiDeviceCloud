﻿//去除网页中的连接地址

window.onload = inifA;

function inifA() {

    for (var i = 0; i < document.getElementsByTagName("a").length; i++) {

        document.getElementsByTagName("a")[i].onclick = function () { return false }

    }

}

//*定义必要的公共变量

var Marker;//标注对象

var distance;//测距对象

var drawingManager;//绘图对象

var drag;//拖框缩放对象

//绘制工具栏外观设定

var styleOptions = {

    strokeColor: "red",    //边线颜色。

    fillColor: "red",      //填充颜色。当参数为空时，圆形将没有填充效果。

    strokeWeight: 3,       //边线的宽度，以像素为单位。

    strokeOpacity: 0.8,       //边线透明度，取值范围0 - 1。

    fillOpacity: 0.6,      //填充的透明度，取值范围0 - 1。

    strokeStyle: 'solid' //边线的样式，solid或dashed。

}

//*

//*结束//



//*地图基础方法*//

//地图平移

function PanTo(lat, lng) {

    map.panTo(new BMap.Point(lat, lng));

}

//返回当前地图中心坐标

function GetCenter() {

    document.getElementById("lat").innerText = map.getCenter().lat;

    document.getElementById("lng").innerText = map.getCenter().lng;

}

//设置当前地图所在城市

function SetCity(CityName) {

    map.setCenter(CityName);

}

//将地图放大一级

function ZoomIn() {

    map.zoomIn();

}

//将地图缩小一级

function ZoomOut() {

    map.zoomOut();

}

//添加地图类型控件

function AddMapTypeControl() {

    map.addControl(new BMap.MapTypeControl());

}

//添加比例尺控件

function AddScaleControl() {

    map.addControl(new BMap.ScaleControl());

}

//添加缩略图控件

function AddOverviewMapControl() {

    map.addControl(new BMap.OverviewMapControl());

}

//开启滚轮调节地图

function EnableScrollWheelZoom() {

    map.enableScrollWheelZoom();

}

//关闭滚轮调节地图

function DisableScrollWheelZoom() {

    map.disableScrollWheelZoom();

}

//*

//*结束*//

//添加普通标注

function AddNormalMarker(lat, lng) {

    var marker = new BMap.Marker(new BMap.Point(lat, lng));  // 创建标注

    map.addOverlay(marker);

}

//标注开启拖拽

function OpenMarkerDraging() {

    marker.enableDragging(true);

}

//标注关闭拖拽

function CloseMarkerDraging() {

    marker.disableDragging(true);

}

//添加动画标注

function AddAnimationMarker(lat, lng) {

}

//添加包含一个标签的标注

function AddLabelMarker(lat, lng, content) {

    var marker = new BMap.Marker(new BMap.Point(lat, lng));  // 创建标注

    var label = new BMap.Label(content);

    marker.setLabel(label);
    map.addOverlay(marker);

}

//添加包含一个信息窗口的标注

function AddWindowMarker(lat, lng, content) {

    var marker = new BMap.Marker(new BMap.Point(lat, lng));  // 创建标注

    marker.addEventListener("click", function () {

        // 创建信息窗口对象

        var infoWindow = new BMap.InfoWindow(content);

        marker.openInfoWindow(infoWindow);

    });
    map.addOverlay(marker);

}

//添加一个信息窗口

function AddInfoWindow(lat, lng, content) {

    var point = new BMap.Point(lat, lng);

    var info = new BMap.InfoWindow(content);

    map.openInfoWindow(info, point);

}

//添加一个标注

function AddLabel(lat, lng, content) {

    var point = new BMap.Point(lat, lng);

    var label = new BMap.Label(content, { point: point });

}

//*

//*结束*//



//*地图服务*//



function GetInnerText() {

    return document.getElementById("r-result").innerText;

}



function Remove() {

    document.getElementById("r-result").innerText = "";

}



//返回指定坐标所在地址

function GetByPoint(lat, lng) {

    var gc = new BMap.Geocoder();

    pt = new BMap.Point(lat, lng);

    gc.getLocation(pt, function (rs) {

        var addComp = rs.addressComponents;

        document.getElementById("geo").innerText = addComp.province + ", " + addComp.city + ", " + addComp.district + ", " + addComp.street + ", " + addComp.streetNumber;

    });

}

//返回指定地址的坐标

function GetByAddress(geo) {

    //通过IP定位获取当前城市名称

    IP();

    var cityName = document.getElementById("geo").innerText

    var myGeo = new BMap.Geocoder();

    // 将地址解析结果显示在地图上,并调整地图视野

    myGeo.getPoint(geo, function (point) {

        if (point) {

            map.centerAndZoom(point, 16);

            map.addOverlay(new BMap.Marker(point));

            document.getElementById("lat").innerText = point.lat;

            document.getElementById("lng").innerText = point.lng;

        }

    }, cityName);

}

//IP定位

function IP() {

    var myCity = new BMap.LocalCity();

    myCity.get(myFun);

    function myFun(result) {

        var cityName = result.name;

        document.getElementById("geo").innerText = cityName;

        map.setCenter(cityName);

    }



}

//*

//*结束*//



//*地图工具*//

//开启地图测距工具

function DistanceToolOpen() {

    var distance = new BMapLib.DistanceTool(map);//测距组件

    distance.open();

}

//关闭地图测距工具

function DistanceToolOpen() {

    distance.close();

}

//开启地图拖拽放大工具

function DragAndZoomOpen() {

    var drag = new BMap.DragAndZoomTool(map);

    drag.open();

}

//关闭地图拖拽放大工具

function DragAndZoomOpen() {

    drag.close();

}

//开启地图绘制工具

function DrawingManagerOpen() {



    //实例化鼠标绘制工具

    var drawingManager = new BMapLib.DrawingManager(map, {

        isOpen: true, //是否开启绘制模式

        enableDrawingTool: true, //是否显示工具栏

        drawingToolOptions: {

            anchor: BMAP_ANCHOR_BOTTOM_RIGHT, //位置

            offset: new BMap.Size(5, 5), //偏离值

            scale: 0.8 //工具栏缩放比例

        },

        circleOptions: styleOptions, //圆的样式

        polylineOptions: styleOptions, //线的样式

        polygonOptions: styleOptions, //多边形的样式

        rectangleOptions: styleOptions //矩形的样式

    });

}

//关闭地图绘制工具

function DrawingManagerClose() {

    drawingManager.close();

}

//*

//*结束*//



//*地图事件*//