/***************************************************************
 * Name:      Lab4_newApp.cpp
 * Purpose:   Code for Application Class
 * Author:     ()
 * Created:   2021-01-07
 * Copyright:  ()
 * License:
 **************************************************************/

#include "Lab4_newApp.h"

//(*AppHeaders
#include "Lab4_newMain.h"
#include <wx/image.h>
//*)

IMPLEMENT_APP(Lab4_newApp);

bool Lab4_newApp::OnInit()
{
    //(*AppInitialize
    bool wxsOK = true;
    wxInitAllImageHandlers();
    if ( wxsOK )
    {
    	Lab4_newFrame* Frame = new Lab4_newFrame(0);
    	Frame->Show();
    	SetTopWindow(Frame);
    }
    //*)
    return wxsOK;

}
