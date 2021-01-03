#include "mainwindow.h"
#include "ui_mainwindow.h"

#include<QJsonDocument>
#include<QJsonObject>
#include<QJsonArray>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    networkmanager=new QNetworkAccessManager();
    connect(networkmanager, &QNetworkAccessManager::finished,this,&MainWindow::onResult);
//    connect(ui->pushButton, SIGNAL(clicked()), this, SLOT(mousePressEvent()));
//    networkmanager->get(QNetworkRequest(QUrl("http://openlibrary.org/books/OL1M/lists.json")));


}

MainWindow::~MainWindow()
{
    delete networkmanager;
    delete ui;
}

void MainWindow::onResult(QNetworkReply* networkreply)
{
    if(!networkreply->error())
    {
        QJsonDocument document=QJsonDocument::fromJson(networkreply->readAll());
        QJsonObject jtext=document.object();
        //ui->TextEdit->appendPlainText(jtext.keys().at(0)+":"+jtext.value(jtext.keys().at(0)).toString());
//        QJsonValue jv = jtext.value("entries");
//        if(jv.isArray())
//        {
//            QJsonArray ja = jv.toArray();
//            for (int i=0; i<ja.count(); i++) {
//                QJsonObject row = ja.at(i).toObject();
//                ui->TextEdit->appendPlainText(row.value("url").toString());
//            }
//        }
        QJsonValue jv = jtext.value("docs");
        if(jv.isArray())
        {
            QJsonArray ja = jv.toArray();
            for (int i=0; i<ja.count(); i++) {
                QJsonObject row = ja.at(i).toObject();
                ui->TextEdit->appendPlainText(row.value("title").toString());
            }
        }
    }
}

    void MainWindow::on_pushButton_clicked()
    {
        networkmanager->get(QNetworkRequest(QUrl("http://openlibrary.org/search.json?q="+ui->lineEdit->text())));

    }
