#include "wxPoints.h"
#include <wx/listimpl.cpp>

//WX_DEFINE_LIST(XYZList);

wxPoints::wxPoints()
{
 //   pointsArray.Alloc(1);
}

wxPoints::~wxPoints()
{
    pointsList.clear();
}

wxPoints::wxPoints(const wxPoints& other)
{
    //copy ctor
    this->pointsList=other.pointsList;
}

void wxPoints::addPoint(XYZ obj)
{
    pointsList.push_back(obj);
}

wxArrayString wxPoints::print()
{
    wxArrayString tmp;
    if(pointsList.size())
    {
        for(auto iter=pointsList.begin();iter!=pointsList.end();iter++)
        {
            tmp.Add(iter->print());
        }
    }
    return tmp;
}

int wxPoints::count()
{
    return pointsList.size();
}

void wxPoints::clear()
{
    pointsList.clear();
}

XYZ& wxPoints::operator[](int n)
{
        for(auto iter=pointsList.begin();iter!=pointsList.end();iter++)
        {
            if(n==0)
            {
                return *iter;
            }
            n--;
        }
}

XYZ wxPoints::getPoint(int n)
{
       for(auto iter=pointsList.begin();iter!=pointsList.end();iter++)
        {
            if(n==0)
            {
                return *iter;
            }
            n--;
        }
}

XYZ wxPoints::back()
{
    return pointsList.back();
}

