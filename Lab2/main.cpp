#include <wx/string.h>
#include "include/XYZ.h"
#include "include/wxPoints.h"

int main (int argc ,char **argv )
{
    wxPoints newPoints;
    cout<<newPoints.count()<<endl;
    srand(time(0));

    for(int i=0; i<10;i++)
    {
        XYZ newpoint;
        newpoint.X=rand()%25;
        newpoint.Y=rand()%25;
        newpoint.Z=rand()%25;
        newPoints.addPoint(newpoint);

    }

    cout<<newPoints.count()<<endl;
    newPoints.print();
    newPoints[2].X=55;
    newPoints[2].Y=55;
    newPoints[2].Z=55;
    newPoints.getPoint(2).print();
    newPoints.clear();
    newPoints.print();
}
