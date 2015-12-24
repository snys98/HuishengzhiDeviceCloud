function DisableA() {

    for (var i = 0; i < document.getElementsByTagName("a").length; i++) {

        document.getElementsByTagName("a")[i].onclick = function () { return false }
    }
}

//*定义必要的公共变量
var siteRoot = "";

var distance;//测距对象
var Markers = [];//地图标注集合

var Line;//路径对象
var Points = [];//路径包含的点
var lineStyleOptions = {

strokeColor: "blue",    //边线颜色。

fillColor: "blue",      //填充颜色。当参数为空时，圆形将没有填充效果。

        strokeWeight: 4,       //边线的宽度，以像素为单位。

    strokeOpacity: 0.6,       //边线透明度，取值范围0 - 1。

        fillOpacity: 0.6,      //填充的透明度，取值范围0 - 1。

        strokeStyle: 'solid' //边线的样式，solid或dashed。

}

var markerStyleOption = { icon: new BMap.Icon(siteRoot + "Content/images/map/marker.png", new BMap.Size(20, 20)) };

var drag;//拖框缩放对象


//*

//*结束//



//*地图基础方法*//

//地图平移

function map_api_PanTo(lng, lat) {

    map.panTo(new BMap.Point(lng, lat));

}

//返回当前地图中心坐标

function map_api_GetCenter() {

    document.getElementById("lng").innerText = map.getCenter().lng;

    document.getElementById("lat").innerText = map.getCenter().lat;

}

//设置当前地图所在城市

function map_api_SetCity(CityName) {

    map.setCenter(CityName);

}

//将地图放大一级

function map_api_ZoomIn() {

    map.zoomIn();

}

//将地图缩小一级

function map_api_ZoomOut() {

    map.zoomOut();

}

//添加地图类型控件

function map_api_AddMapTypeControl() {

    map.addControl(new BMap.MapTypeControl());

}

//添加比例尺控件

function map_api_AddScaleControl() {

    map.addControl(new BMap.ScaleControl());

}

//添加缩略图控件

function map_api_AddOverviewMapControl() {

    map.addControl(new BMap.OverviewMapControl());

}

//开启滚轮调节地图

function map_api_EnableScrollWheelZoom() {

    map.enableScrollWheelZoom();

}

//关闭滚轮调节地图

function map_api_DisableScrollWheelZoom() {

    map.disableScrollWheelZoom();

}

//*

//*结束*//

//添加普通标注

function map_api_AddNormalMarker(lng, lat) {
    var point = new BMap.Point(lng, lat);
    var marker = new BMap.Marker(point);  // 创建标注

    map.addOverlay(marker);
    Points.push(point);
    Markers.push(marker);
}

//添加动画标注

function map_api_AddAnimationtempMarker(lng, lat) {

}

//添加包含一个标签的标注

function map_api_AddLabelMarker(lng, lat, content) {
    var point = new BMap.Point(lng, lat);
    var marker = new BMap.Marker(point);  // 创建标注

    var label = new BMap.Label(content);

    marker.setLabel(label);
    map.addOverlay(marker);
    Points.push(point);
    Markers.push(marker);
}

//添加包含一个信息窗口的标注

function map_api_AddWindowMarker(lng, lat, content) {
    var point = new BMap.Point(lng, lat);
    var marker = new BMap.Marker(point, markerStyleOption);  // 创建标注

    BMapLib.EventWrapper.addListener(marker, "click", function() {

        // 创建信息窗口对象

        var infoWindow = new BMap.InfoWindow(content);

        marker.openInfoWindow(infoWindow);

    });
    map.addOverlay(marker);
    Points.push(point);
    Markers.push(marker);
}

//添加一个信息窗口

function map_api_AddInfoWindow(lng, lat, content) {

    var point = new BMap.Point(lng, lat);

    var info = new BMap.InfoWindow(content);

    map.openInfoWindow(info, point);

}

//添加一个标注

function map_api_AddLabel(lng, lat, content) {

    var point = new BMap.Point(lng, lat);

    var label = new BMap.Label(content, { point: point });

}

//用当前的markers构造一条线
function map_api_BuildLine() {
    var polyline = new BMap.Polyline(Points, lineStyleOptions);
    map.addOverlay(polyline);
    var startOption = { icon: new BMap.Icon(siteRoot + "Content/images/map/marker_start.png", new BMap.Size(20, 20)) };
    var endOption = { icon: new BMap.Icon(siteRoot + "Content/images/map/marker_end.png", new BMap.Size(20, 20)) };
    var startMarker = new BMap.Marker(Points[0], startOption);
    var endMarker = new BMap.Marker(Points[Points.length-1], endOption);
    map.addOverlay(startMarker);
    map.addOverlay(endMarker);
}
//*

//*结束*//



//*地图服务*//



function map_api_GetInnerText() {

    return document.getElementById("r-result").innerText;

}



function map_api_Remove() {

    document.getElementById("r-result").innerText = "";

}



//返回指定坐标所在地址

function map_api_GetByPoint(lng, lat) {

    var gc = new BMap.Geocoder();

    pt = new BMap.Point(lng, lat);

    gc.getLocation(pt, function (rs) {

        var addComp = rs.addressComponents;

        document.getElementById("geo").innerText = addComp.province + ", " + addComp.city + ", " + addComp.district + ", " + addComp.street + ", " + addComp.streetNumber;

    });

}

//返回指定地址的坐标

function map_api_GetByAddress(geo) {

    //通过IP定位获取当前城市名称

    IP();

    var cityName = document.getElementById("geo").innerText;

    var myGeo = new BMap.Geocoder();

    // 将地址解析结果显示在地图上,并调整地图视野

    myGeo.getPoint(geo, function (point) {

        if (point) {

            map.centerAndZoom(point, 16);

            map.addOverlay(new BMap.Marker(point));

            document.getElementById("lng").innerText = point.lng;

            document.getElementById("lat").innerText = point.lat;

        }

    }, cityName);

}

//IP定位

function map_api_IP() {

    var myCity = new BMap.LocalCity();

    myCity.get(myFun);

    function map_api_myFun(result) {

        var cityName = result.name;

        document.getElementById("geo").innerText = cityName;

        map.setCenter(cityName);

    }



}

//*

//*结束*//



//*地图工具*//

//开启地图测距工具

function map_api_DistanceToolOpen() {

    var distance = new BMapLib.DistanceTool(map);//测距组件

    distance.open();

}

//关闭地图测距工具

function map_api_DistanceToolOpen() {

    distance.close();

}

//开启地图拖拽放大工具

function map_api_DragAndZoomOpen() {

    var drag = new BMap.DragAndZoomTool(map);

    drag.open();

}

//关闭地图拖拽放大工具

function map_api_DragAndZoomOpen() {

    drag.close();

}

//开启地图绘制工具

function map_api_DrawingManagerOpen() {



    //实例化鼠标绘制工具

    var drawingManager = new BMapLib.DrawingManager(map, {

        isOpen: true, //是否开启绘制模式

        enableDrawingTool: true, //是否显示工具栏

        drawingToolOptions: {

            anchor: BMAP_ANCHOR_BOTTOM_RIGHT, //位置

            offset: new BMap.Size(5, 5), //偏离值

            scale: 0.8 //工具栏缩放比例

        },

        circleOptions: lineStyleOptions, //圆的样式

        polylineOptions: lineStyleOptions, //线的样式

        polygonOptions: lineStyleOptions, //多边形的样式

        rectangleOptions: lineStyleOptions //矩形的样式

    });

}

function map_api_Clear() {
    Points = [];
    Line = [];
}

//关闭地图绘制工具

function map_api_DrawingManagerClose() {

    drawingManager.close();

}

//*

//*结束*//



//*地图事件*//