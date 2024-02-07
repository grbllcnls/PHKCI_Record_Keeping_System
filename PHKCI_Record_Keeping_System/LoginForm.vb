Imports System.Data.OleDb
Imports System.Windows

Public Class LoginForm
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\PHKCI.accdb;"
    Dim connection As OleDbConnection

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadForm()
        connection = New OleDbConnection(connectionString)
        Try
            connection.Open()
            ' Connection opened successfully
        Catch ex As Exception
            MessageBox.Show("Error connecting to the database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub LoginForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' Ensure that the form cannot be maximized
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = tbUsername.Text
        Dim password As String = tbPassword.Text
        Dim query As String = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password"
        Dim command As New OleDbCommand(query, connection)

        ' Use parameters to avoid SQL injection
        command.Parameters.AddWithValue("@Username", username)
        command.Parameters.AddWithValue("@Password", password)
        Try
            Dim result As Integer = CInt(command.ExecuteScalar())
            If result > 0 Then
                ' Login successful
                ' MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                Dim formHomeInstance As New HomeForm()
                formHomeInstance.Show()
            Else
                ' Invalid credentials
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error executing query: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub LoadForm()
        Me.Icon = New Icon("C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\Images\logo_ico.ico")

        pbLogin.Image = Image.FromFile("C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\Images\logo_transparent.png")
        pbLogin.SizeMode = PictureBoxSizeMode.StretchImage

        'pbLogo.Image = Image.FromFile("C:\Users\Gabrielle\source\repos\PHKCI_Record_Keeping_System\PHKCI_Record_Keeping_System\Images\logo.png")
        'pbLogo.SizeMode = PictureBoxSizeMode.StretchImage

        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height
        Dim posX As Integer = (screenWidth - formWidth) \ 2
        Dim posY As Integer = (screenHeight - formHeight) \ 2

        ' Set the form's position
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(posX, posY)
        Me.MaximizeBox = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizedBounds = Me.Bounds


    End Sub

End Class
