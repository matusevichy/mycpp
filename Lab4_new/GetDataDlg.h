#ifndef GETDATADLG_H
#define GETDATADLG_H

///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Oct 26 2018)
// http://www.wxformbuilder.org/
//
// PLEASE DO *NOT* EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#pragma once

#include <wx/artprov.h>
#include <wx/xrc/xmlres.h>
#include <wx/string.h>
#include <wx/stattext.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/textctrl.h>
#include <wx/sizer.h>
#include <wx/button.h>
#include <wx/dialog.h>
#include "XYZ.h"
///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class GetDataDlg
///////////////////////////////////////////////////////////////////////////////
class GetDataDlg : public wxDialog
{
	private:

	protected:
		wxStaticText* m_staticText1;
		wxTextCtrl* m_textCtrl3;
		wxStaticText* m_staticText4;
		wxTextCtrl* m_textCtrl2;
		wxStaticText* m_staticText5;
		wxTextCtrl* m_textCtrl1;
		wxStaticText* m_staticText6;
		wxStaticText* m_staticText2;
		wxTextCtrl* m_textCtrl4;
		wxStaticText* m_staticText7;
		wxTextCtrl* m_textCtrl5;
		wxStaticText* m_staticText8;
		wxTextCtrl* m_textCtrl6;
		wxStaticText* m_staticText9;
		wxStaticText* m_staticText3;
		wxTextCtrl* m_textCtrl7;
		wxStdDialogButtonSizer* m_sdbSizer1;
		wxButton* m_sdbSizer1OK;
		wxButton* m_sdbSizer1Cancel;

		// Virtual event handlers, overide them in your derived class
		virtual void OnCancelClick( wxCommandEvent& event ) { event.Skip(); }
		virtual void OnOkClick( wxCommandEvent& event ) { event.Skip(); }


	public:

		GetDataDlg( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Generate points"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 289,251 ), long style = wxDEFAULT_DIALOG_STYLE );
		~GetDataDlg();
		int GetPoints(XYZ&,XYZ&);

};

#endif // GETDATADLG_H