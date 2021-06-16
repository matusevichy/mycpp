#ifndef WXPOINTS_H
#define WXPOINTS_H
#include "XYZ.h"
#include<wx/list.h>
#include <wx/msgdlg.h>
#include <list>

class XYZ;
//WX_DECLARE_LIST(XYZ,XYZList);

class wxPoints
{
    public:
        wxPoints();
        virtual ~wxPoints();
        wxPoints(const wxPoints& other);
        void addPoint(XYZ);
        wxArrayString print();
        int count();
        void clear();
        XYZ& operator[](int);
        XYZ getPoint(int);
        XYZ back();

    protected:

    private:
        list<XYZ> pointsList;
};

#endif // WXPOINTS_H
