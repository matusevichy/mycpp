///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Oct 26 2018)
// http://www.wxformbuilder.org/
//
// PLEASE DO *NOT* EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "GetDataDlg.h"

///////////////////////////////////////////////////////////////////////////

GetDataDlg::GetDataDlg( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );

	wxBoxSizer* bSizer1;
	bSizer1 = new wxBoxSizer( wxVERTICAL );

	wxBoxSizer* bSizer2;
	bSizer2 = new wxBoxSizer( wxHORIZONTAL );

	wxBoxSizer* bSizer4;
	bSizer4 = new wxBoxSizer( wxVERTICAL );

	m_staticText1 = new wxStaticText( this, wxID_ANY, wxT("Point1 Coords"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText1->Wrap( -1 );
	bSizer4->Add( m_staticText1, 0, wxALIGN_CENTER_HORIZONTAL|wxALL, 5 );

	wxBoxSizer* bSizer9;
	bSizer9 = new wxBoxSizer( wxHORIZONTAL );

	m_textCtrl3 = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer9->Add( m_textCtrl3, 0, wxALL, 5 );

	m_staticText4 = new wxStaticText( this, wxID_ANY, wxT("X"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText4->Wrap( -1 );
	bSizer9->Add( m_staticText4, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );


	bSizer4->Add( bSizer9, 1, wxEXPAND, 5 );

	wxBoxSizer* bSizer10;
	bSizer10 = new wxBoxSizer( wxHORIZONTAL );

	m_textCtrl2 = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer10->Add( m_textCtrl2, 0, wxALL, 5 );

	m_staticText5 = new wxStaticText( this, wxID_ANY, wxT("Y"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText5->Wrap( -1 );
	bSizer10->Add( m_staticText5, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );


	bSizer4->Add( bSizer10, 1, wxEXPAND, 5 );

	wxBoxSizer* bSizer11;
	bSizer11 = new wxBoxSizer( wxHORIZONTAL );

	m_textCtrl1 = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer11->Add( m_textCtrl1, 0, wxALL, 5 );

	m_staticText6 = new wxStaticText( this, wxID_ANY, wxT("Z"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText6->Wrap( -1 );
	bSizer11->Add( m_staticText6, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );


	bSizer4->Add( bSizer11, 1, wxEXPAND, 5 );


	bSizer2->Add( bSizer4, 1, wxEXPAND, 5 );

	wxBoxSizer* bSizer6;
	bSizer6 = new wxBoxSizer( wxVERTICAL );

	m_staticText2 = new wxStaticText( this, wxID_ANY, wxT("Point2 Coords"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText2->Wrap( -1 );
	bSizer6->Add( m_staticText2, 0, wxALIGN_CENTER_HORIZONTAL|wxALL, 5 );

	wxBoxSizer* bSizer12;
	bSizer12 = new wxBoxSizer( wxHORIZONTAL );

	m_textCtrl4 = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer12->Add( m_textCtrl4, 0, wxALL, 5 );

	m_staticText7 = new wxStaticText( this, wxID_ANY, wxT("X"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText7->Wrap( -1 );
	bSizer12->Add( m_staticText7, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );


	bSizer6->Add( bSizer12, 1, wxEXPAND, 5 );

	wxBoxSizer* bSizer13;
	bSizer13 = new wxBoxSizer( wxHORIZONTAL );

	m_textCtrl5 = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer13->Add( m_textCtrl5, 0, wxALL, 5 );

	m_staticText8 = new wxStaticText( this, wxID_ANY, wxT("Y"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText8->Wrap( -1 );
	bSizer13->Add( m_staticText8, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );


	bSizer6->Add( bSizer13, 1, wxEXPAND, 5 );

	wxBoxSizer* bSizer14;
	bSizer14 = new wxBoxSizer( wxHORIZONTAL );

	m_textCtrl6 = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer14->Add( m_textCtrl6, 0, wxALL, 5 );

	m_staticText9 = new wxStaticText( this, wxID_ANY, wxT("Z"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText9->Wrap( -1 );
	bSizer14->Add( m_staticText9, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );


	bSizer6->Add( bSizer14, 1, wxEXPAND, 5 );


	bSizer2->Add( bSizer6, 1, wxEXPAND, 5 );


	bSizer1->Add( bSizer2, 1, wxEXPAND, 5 );

	wxBoxSizer* bSizer7;
	bSizer7 = new wxBoxSizer( wxVERTICAL );

	wxBoxSizer* bSizer8;
	bSizer8 = new wxBoxSizer( wxVERTICAL );

	m_staticText3 = new wxStaticText( this, wxID_ANY, wxT("Points number"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText3->Wrap( -1 );
	bSizer8->Add( m_staticText3, 0, wxALIGN_CENTER_HORIZONTAL|wxALL, 5 );

	m_textCtrl7 = new wxTextCtrl( this, wxID_ANY, wxT("0"), wxDefaultPosition, wxDefaultSize, 0 );
	bSizer8->Add( m_textCtrl7, 0, wxALL, 5 );


	bSizer7->Add( bSizer8, 1, wxALIGN_CENTER_HORIZONTAL, 5 );

	m_sdbSizer1 = new wxStdDialogButtonSizer();
	m_sdbSizer1OK = new wxButton( this, wxID_OK );
	m_sdbSizer1->AddButton( m_sdbSizer1OK );
	m_sdbSizer1Cancel = new wxButton( this, wxID_CANCEL );
	m_sdbSizer1->AddButton( m_sdbSizer1Cancel );
	m_sdbSizer1->Realize();

	bSizer7->Add( m_sdbSizer1, 1, wxALIGN_CENTER_HORIZONTAL, 5 );


	bSizer1->Add( bSizer7, 1, wxEXPAND, 5 );


	this->SetSizer( bSizer1 );
	this->Layout();

	this->Centre( wxBOTH );

	// Connect Events
	m_sdbSizer1Cancel->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( GetDataDlg::OnCancelClick ), NULL, this );
	m_sdbSizer1OK->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( GetDataDlg::OnOkClick ), NULL, this );
}

GetDataDlg::~GetDataDlg()
{
	// Disconnect Events
	m_sdbSizer1Cancel->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( GetDataDlg::OnCancelClick ), NULL, this );
	m_sdbSizer1OK->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( GetDataDlg::OnOkClick ), NULL, this );

}

int GetDataDlg::GetPoints(XYZ& pstart,XYZ& pend)
{
    long pointcount;
    m_textCtrl7->GetValue().ToLong(&pointcount);
    m_textCtrl3->GetValue().ToDouble(&pstart.X);
    m_textCtrl2->GetValue().ToDouble(&pstart.Y);
    m_textCtrl1->GetValue().ToDouble(&pstart.Z);
    m_textCtrl4->GetValue().ToDouble(&pend.X);
    m_textCtrl5->GetValue().ToDouble(&pend.Y);
    m_textCtrl6->GetValue().ToDouble(&pend.Z);
    return pointcount;
}