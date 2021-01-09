#include "XYZ.h"
#include <wx/msgdlg.h>
//#include<wx/arrimpl.cpp>

wxString XYZ::print()
{
    wxString str=wxString::Format(wxT("%f"), (double)X)+wxT(" ")+wxString::Format(wxT("%f"), (double)Y)+wxT(" ")+wxString::Format(wxT("%f"), (double)Z);
//    wxString str=wxT("X: ")+wxString::Format(wxT("%f"), (double)X)+wxT(" Y: ")+wxString::Format(wxT("%f"), (double)Y)+wxT(" Z: ")+wxString::Format(wxT("%f"), (double)Z);
//    wxMessageBox(str, _("Text"));
    return str;
}

//WX_DEFINE_OBJARRAY(XYZArray);
