#include "database.h"
#include "iostream"
Database::Database()
{

}

Database::~Database()
{

}

bool Database::connect()
{
    if (!QFile(DATABASE_FILE).exists()) {
        return this->restoreDb();
    }
    else {
        return this->openDb();
    }
}

bool Database::openDb()
{
    db = QSqlDatabase::addDatabase("QSQLITE");
    db.setHostName(DATABASE_NAME);
    QString path = QStandardPaths::writableLocation(QStandardPaths::AppDataLocation);
    QDir dir(path);
    if(!dir.exists()){
        dir.mkdir(".");
    }
    db.setDatabaseName(path+"/"+DATABASE_FILE);
    if (db.open()) {
        return true;
    }
    else {
        return false;
    }
}

bool Database::restoreDb()
{
    if (openDb()) {
        return createTable();
    }
    else {
        qDebug() << "Error restore DB";
        return false;
    }
}

void Database::closeDb()
{

}

bool Database::createTable()
{
    QSqlQuery query;
    if(!query.exec("CREATE TABLE " TABLE " ("
                   "id INTEGER PRIMARY KEY AUTOINCREMENT,"
                   TABLE_FNAME " VARCHAR(255) NOT NULL,"
                   TABLE_LNAME " VARCHAR(255) NOT NULL,"
                   TABLE_AGE " INTEGER NOT NULL"
               ")"
                  ))
    {
        qDebug() << "Error of create " << TABLE;
        qDebug() << query.lastError().text();
        return false;
    }
    else {
        return true;
    }
    return false;
}

bool Database::insertIntoTable(QVariantList &obj)
{
    QSqlQuery query;
    QString fName = obj[0].toString();
    QString lName = obj[1].toString();
    query.prepare("insert into " TABLE " (" TABLE_FNAME ", "
                                                 TABLE_LNAME ", "
                                                 TABLE_AGE ") "
                  "values ('vasya', 'pupkin',23)");
    query.bindValue(":FNAME", fName);
    query.bindValue(":LNAME", lName);
    query.bindValue(":AGE", obj[2]);
    if (!query.exec()) {
        qDebug() << "Error insert into " << TABLE;
        qDebug() << query.lastError().text();
        return false;
    }
    else {
        return true;
    }
    return false;
}

bool Database::insertIntoTable(const QString &fName, const QString &lName, const int &age)
{
    QVariantList list;
    list.append(fName);
    list.append(lName);
    list.append(age);
    return insertIntoTable(list);
}

bool Database::removeById(int id)
{
    QSqlQuery query;
    query.prepare("delete from " TABLE "where id = :ID;");
    query.bindValue(":ID", id);
    if (!query.exec()) {
        qDebug() << "Error remove record from " << TABLE;
        qDebug() << query.lastError().text();
        return false;
    }
    else {
        return true;
    }
    return false;
}

int Database::getCountRecord()
{
    QSqlQuery query("select count(*) from " TABLE);
    if (query.next()) {
        return query.value(0).toInt();
    }
    return 0;
}

QString Database::getTables()
{
    QSqlQuery query("select * from Users");
    return query.lastError().text();
}
