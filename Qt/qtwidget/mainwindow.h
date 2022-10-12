#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QWidget>
#include <QGridLayout>
#include <QPushButton>
#include <QLineEdit>
#include <QStackedWidget>
#include <database.h>
#include <form1.h>
#include <form2.h>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    QWidget *MainWidget = new QWidget;
    QGridLayout *Layout = new QGridLayout;
    QPushButton *Btn_1 = new QPushButton;
    QPushButton *Btn_W1 = new QPushButton;
    QPushButton *Btn_W2 = new QPushButton;
    QLineEdit *LineEdit_1 = new QLineEdit;
    Form1 *form1 = new Form1(this);
    Form2 *form2 = new Form2(this);

public slots:
    void btnPress();
    void show1();
    void show2();

private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
