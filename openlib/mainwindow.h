#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QNetworkReply>
#include <QPushButton>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void onResult(QNetworkReply* networkreply);
    void on_pushButton_clicked();

private:
    Ui::MainWindow *ui;
    QNetworkAccessManager* networkmanager;
};
#endif // MAINWINDOW_H
