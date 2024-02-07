Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Public Class HomeForm
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\PHKCI.accdb;;"
    Dim connection As OleDbConnection
    Dim adapter As OleDbDataAdapter
    Dim dataTable As DataTable
    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadForm()
        ' Initialize the connection
        connection = New OleDbConnection(connectionString)
        dgvStudent.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        btnAddStudent.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ' Load student records into DataGridView
        LoadStudentRecords()
    End Sub
    Private Sub LoadStudentRecords()
        ' SQL query to select all fields from the Student table
        Dim query As String = "SELECT * FROM Students"

        Try
            ' Open the connection
            connection.Open()

            ' Initialize the data adapter with the query and connection
            adapter = New OleDbDataAdapter(query, connection)

            ' Initialize a new DataTable
            dataTable = New DataTable()

            ' Fill the DataTable with data from the adapter
            adapter.Fill(dataTable)

            ' Bind the DataTable to the DataGridView
            dgvStudent.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error loading student records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the connection
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
    Private Sub HomeForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub LoadForm()
        Me.Icon = New Icon("C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\Images\logo_ico.ico")


    End Sub


End Class