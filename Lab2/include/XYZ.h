#ifndef XYZ_H
#define XYZ_H
#include<iostream>
#include<wx/dynarray.h>
using namespace std;

class XYZ
{
    public:
        float X,Y,Z;
        void print();

    protected:

    private:
};

WX_DECLARE_OBJARRAY(XYZ,XYZArray);
#endif // XYZ_H