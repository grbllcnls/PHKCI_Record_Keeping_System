Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Public Class HomeForm
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\PHKCI.accdb;;"
    Dim connection As OleDbConnection
    Dim adapter As OleDbDataAdapter
    Dim dataTable As DataTable
    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the connection

        connection = New OleDbConnection(connectionString)
        LoadForm()
        LoadGrade()
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

    Private Sub LoadGrade()
        Try
            connection.Open()

            Dim query As String = "SELECT Grade FROM Students"

            ' Create a command object
            Dim command As New OleDbCommand(query, connection)

            ' Execute the command and retrieve the data using a DataReader
            Dim reader As OleDbDataReader = command.ExecuteReader()

            ' Clear the ComboBox before populating it
            cbGrade.Items.Clear()

            ' Use a HashSet to keep track of unique values
            Dim uniqueValues As New HashSet(Of String)()

            ' Loop through the data and add unique values to the ComboBox
            While reader.Read()
                Dim value As String = reader.GetString(0) ' Assuming the column is of type string
                If Not uniqueValues.Contains(value) Then
                    cbGrade.Items.Add(value)
                    uniqueValues.Add(value)
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the connection
            connection.Close()
        End Try
    End Sub
    Private Sub LoadForm()
        Me.Icon = New Icon("C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\Images\logo_ico.ico")
        pbLogo.Image = Image.FromFile("C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\Images\logo_transparent.png")
        pbLogo.SizeMode = PictureBoxSizeMode.StretchImage
        pbLogo.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        dgvStudent.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        btnAdd.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEdit.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUpdate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tbSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        cbGrade.Anchor = AnchorStyles.Top Or AnchorStyles.Left
    End Sub


    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.Click
        tbSearch.Clear()
    End Sub

    Private Sub cbGrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrade.SelectedIndexChanged

        Dim query As String = "SELECT * FROM Students WHERE Grade = @Grade"
        Try
            ' Open the connection
            connection.Open()

            ' Initialize the data adapter with the query and connection
            adapter = New OleDbDataAdapter(query, connection)
            Using command As New OleDbCommand(query, connection)
                ' Add parameter to the command object
                command.Parameters.AddWithValue("@Grade", cbGrade.Text)

                ' Set the command for the adapter
                adapter.SelectCommand = command

                ' Initialize a new DataTable
                dataTable = New DataTable()

                ' Fill the DataTable with data from the adapter
                adapter.Fill(dataTable)

                ' Bind the DataTable to the DataGridView
                dgvStudent.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading student records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the connection
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStudentRecords()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim query As String = "SELECT * FROM Students WHERE FirstName = @Name OR LastName = @Name"
        Try
            ' Open the connection
            connection.Open()

            ' Initialize the data adapter with the query and connection
            adapter = New OleDbDataAdapter(query, connection)
            Using command As New OleDbCommand(query, connection)
                ' Add parameter to the command object
                command.Parameters.AddWithValue("@Name", tbSearch.Text)

                ' Set the command for the adapter
                adapter.SelectCommand = command

                ' Initialize a new DataTable
                dataTable = New DataTable()

                ' Fill the DataTable with data from the adapter
                adapter.Fill(dataTable)

                ' Bind the DataTable to the DataGridView
                dgvStudent.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading student records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the connection
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
End Class