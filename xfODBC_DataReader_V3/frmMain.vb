'Project:      xfODBC_DataReader_V3
'Programmer:   Blair Varley - Synergex (www.synergex.com)
'Date:         February 2004
'Description:  ListBox is populated with a list of all the records 
'              in the CUSTOMERS table in the xfODBC sample database
'              using the DataReader object from ADO.NET.

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OdbcConnection1 As System.Data.Odbc.OdbcConnection
    Friend WithEvents OdbcSelectCommand1 As System.Data.Odbc.OdbcCommand
    Friend DataReader As System.Data.Odbc.OdbcDataReader
    Friend WithEvents LstData As System.Windows.Forms.ListBox
    Friend WithEvents btnPopulateListBox As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnPopulateListBox = New System.Windows.Forms.Button
        Me.OdbcConnection1 = New System.Data.Odbc.OdbcConnection
        Me.OdbcSelectCommand1 = New System.Data.Odbc.OdbcCommand
        Me.LstData = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'btnPopulateListBox
        '
        Me.btnPopulateListBox.Location = New System.Drawing.Point(232, 144)
        Me.btnPopulateListBox.Name = "btnPopulateListBox"
        Me.btnPopulateListBox.Size = New System.Drawing.Size(248, 48)
        Me.btnPopulateListBox.TabIndex = 1
        Me.btnPopulateListBox.Text = "&Populate List Box"
        '
        'OdbcSelectCommand1
        '
        Me.OdbcSelectCommand1.CommandText = "SELECT CUST_KEY, CUST_RTYPE, CUST_NAME, CUST_STREET, CUST_CITY, CUST_STATE, CUST_" & _
        "ZIP, CUST_CONTACT, CUST_PHONE, CUST_FAX, CUST_GIFT, CUST_TCODE, CUST_TAXNO, CUST" & _
        "_LIMIT FROM CUSTOMERS"
        Me.OdbcSelectCommand1.Connection = Me.OdbcConnection1
        '
        'LstData
        '
        Me.LstData.Location = New System.Drawing.Point(176, 16)
        Me.LstData.Name = "LstData"
        Me.LstData.Size = New System.Drawing.Size(376, 108)
        Me.LstData.TabIndex = 2
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(736, 213)
        Me.Controls.Add(Me.LstData)
        Me.Controls.Add(Me.btnPopulateListBox)
        Me.Name = "frmMain"
        Me.Text = "xfODBC using DataReader"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnPopulateListBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopulateListBox.Click
        'Load data from sample customers table
        Dim oCmdObj As Odbc.OdbcCommand
        Dim oDataReader As Odbc.OdbcDataReader 'Forward reading only!
        Dim sSQL As String

        'Retrieve the data
        sSQL = "SELECT CUST_KEY, CUST_RTYPE, CUST_NAME, CUST_STREET, CUST_CITY, CUST_STATE, CUST_ZIP, CUST_CONTACT, CUST_PHONE, CUST_FAX, CUST_GIFT,CUST_TCODE, CUST_TAXNO, CUST_LIMIT FROM CUSTOMERS"

        Try
            oCmdObj = New Odbc.OdbcCommand  'Create the command object
            With oCmdObj
                .Connection = New Odbc.OdbcConnection("DSN=xfODBC;UID=DBADMIN;PWD=MANAGER;DBQ=sodbc_sa")
                .Connection.Open()
                .CommandText = sSQL
                oDataReader = .ExecuteReader()
            End With

            'Load the list box
            LstData.Items.Clear()
            Do While oDataReader.Read() 'No more EOF?

                LstData.Items.Add("NEW RECORD")
                LstData.Items.Add("*****************************************")
                LstData.Items.Add(oDataReader.Item("CUST_KEY"))
                LstData.Items.Add(oDataReader.Item("CUST_RTYPE"))
                LstData.Items.Add(oDataReader.Item("CUST_NAME"))
                LstData.Items.Add(oDataReader.Item("CUST_STREET"))
                LstData.Items.Add(oDataReader.Item("CUST_CITY"))
                LstData.Items.Add(oDataReader.Item("CUST_STATE"))
                LstData.Items.Add(oDataReader.Item("CUST_ZIP"))
                LstData.Items.Add(oDataReader.Item("CUST_CONTACT"))
                LstData.Items.Add(oDataReader.Item("CUST_FAX"))
                LstData.Items.Add(oDataReader.Item("CUST_GIFT"))
                LstData.Items.Add(oDataReader.Item("CUST_TCODE"))
                LstData.Items.Add(oDataReader.Item("CUST_TAXNO"))
                LstData.Items.Add(oDataReader.Item("CUST_LIMIT"))
                LstData.Items.Add("*****************************************")
            Loop
            oDataReader.Close()
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
End Class
