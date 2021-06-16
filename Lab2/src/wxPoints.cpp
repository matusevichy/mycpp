#include "../include/wxPoints.h"

wxPoints::wxPoints()
{
    pointsArray.Alloc(1);
}

wxPoints::~wxPoints()
{
    pointsArray.Clear();
}

wxPoints::wxPoints(const wxPoints& other)
{
    //copy ctor
    this->pointsArray=other.pointsArray;
}

void wxPoints::addPoint(XYZ& obj)
{
    this->pointsArray.Add(obj);
}

void wxPoints::print()
{
    if(pointsArray.GetCount())
    {
        for(int i=0;i<pointsArray.GetCount();i++)
        {
            pointsArray.Item(i).print();
        }
    }
    else
    {
        cout<<"Array is empty..."<<endl;
    }
}
int wxPoints::count()
{
    return pointsArray.GetCount();
}

void wxPoints::clear()
{
    pointsArray.Empty();
}

XYZ& wxPoints::operator[](int n)
{
    return pointsArray[n];
}

XYZ wxPoints::getPoint(int n)
{
    return pointsArray[n];
}

