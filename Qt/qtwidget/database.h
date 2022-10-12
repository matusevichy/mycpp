#ifndef DATABASE_H
#define DATABASE_H
#include <QtSql/QSql>
#include <QtSql/QSqlDatabase>
#include <QtSql/QSqlQuery>
#include <QtSql/QSqlError>
#include <QFile>
#include <QDir>
#include <QStandardPaths>
#include <QSqlTableModel>

#define DATABASE_NAME   "MyDatabase"
#define DATABASE_FILE   "mydb.db"

#define TABLE   "Users"
#define TABLE_FNAME "FirstName"
#define TABLE_LNAME "LastName"
#define TABLE_AGE   "Age"

class Database : public QObject
{

public:
    explicit Database();
    ~Database();
    bool connect();

private:
    QSqlDatabase db;

    bool openDb();
    bool restoreDb();
    void closeDb();
    bool createTable();
public:
    bool insertIntoTable(QVariantList &obj);
    bool insertIntoTable(const QString &fName, const QString &lName, const int &age);
    bool removeById(int id);
    int getCountRecord();
    QString getTables();
};

#endif // DATABASE_H
