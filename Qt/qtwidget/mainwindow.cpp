#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include "database.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    Layout->addWidget(LineEdit_1);
    Layout->addWidget(Btn_1);
    Layout->addWidget(Btn_W1);
    Layout->addWidget(Btn_W2);
    MainWidget->setLayout(Layout);
    setCentralWidget(MainWidget);
    ui->stackedWidget = new QStackedWidget(this);
    ui->stackedWidget->addWidget(form1);
    ui->stackedWidget->addWidget(form2);
    centralWidget()->layout()->addWidget(ui->stackedWidget);
    connect(Btn_1, SIGNAL(clicked()), this, SLOT(btnPress()));
    connect(Btn_W1, &QPushButton::clicked, this, &MainWindow::show1);
    connect(Btn_W2, &QPushButton::clicked, this, &MainWindow::show2);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::btnPress(){
    Database db;
    db.connect();
    QString fName="vasya";
    QString lName="pupkin";
    int age=23;
    LineEdit_1->setText(db.insertIntoTable(fName,lName,age)?"true":"false");
    Btn_1->setText(QVariant(db.getCountRecord()).toString());
}

void MainWindow::show1()
{
    ui->stackedWidget->setCurrentWidget(form1);
}

void MainWindow::show2()
{
    ui->stackedWidget->setCurrentWidget(form2);
}
