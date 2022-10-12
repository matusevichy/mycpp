import QtQuick
import QtSensors 5.9

Window {
    id: mainWindow;
    width: 640
    height: 480
    visible: true
    title: qsTr("Hello World")

    Image {
           id: img1
           source: propolis-pchelinyj.jpg
           smooth: true;
           property real centerX: mainWindow.width/2;
           property real centerY: mainWindow.height/2;
           property real imgCenter: img1.width/2;
           x:centerX-imgCenter;
           y: centery-imgCenter;
    }

    Accelerometer{
        id: accel;
        dataRate: 100;
        active: true;
    }
}

