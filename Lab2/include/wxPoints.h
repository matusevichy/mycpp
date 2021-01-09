#ifndef WXPOINTS_H
#define WXPOINTS_H
#include "XYZ.h"

class wxPoints
{
    public:
        wxPoints();
        virtual ~wxPoints();
        wxPoints(const wxPoints& other);
        void addPoint(XYZ&);
        void print();
        int count();
        void clear();
        XYZ& operator[](int);
        XYZ getPoint(int);

    protected:

    private:
        XYZArray pointsArray;
};

#endif // WXPOINTS_H
