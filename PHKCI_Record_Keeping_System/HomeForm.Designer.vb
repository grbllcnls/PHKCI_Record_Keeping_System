<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvStudent = New System.Windows.Forms.DataGridView()
        Me.btnAddStudent = New System.Windows.Forms.Button()
        Me.btnEditStuden = New System.Windows.Forms.Button()
        Me.btnDeleteStudent = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvStudent
        '
        Me.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudent.Location = New System.Drawing.Point(28, 122)
        Me.dgvStudent.Name = "dgvStudent"
        Me.dgvStudent.RowHeadersWidth = 51
        Me.dgvStudent.RowTemplate.Height = 29
        Me.dgvStudent.Size = New System.Drawing.Size(926, 470)
        Me.dgvStudent.TabIndex = 0
        '
        'btnAddStudent
        '
        Me.btnAddStudent.Location = New System.Drawing.Point(1016, 122)
        Me.btnAddStudent.Name = "btnAddStudent"
        Me.btnAddStudent.Size = New System.Drawing.Size(127, 46)
        Me.btnAddStudent.TabIndex = 1
        Me.btnAddStudent.Text = "Add Student"
        Me.btnAddStudent.UseVisualStyleBackColor = True
        '
        'btnEditStuden
        '
        Me.btnEditStuden.Location = New System.Drawing.Point(1016, 225)
        Me.btnEditStuden.Name = "btnEditStuden"
        Me.btnEditStuden.Size = New System.Drawing.Size(127, 46)
        Me.btnEditStuden.TabIndex = 2
        Me.btnEditStuden.Text = "Edit Student"
        Me.btnEditStuden.UseVisualStyleBackColor = True
        '
        'btnDeleteStudent
        '
        Me.btnDeleteStudent.Location = New System.Drawing.Point(1016, 321)
        Me.btnDeleteStudent.Name = "btnDeleteStudent"
        Me.btnDeleteStudent.Size = New System.Drawing.Size(127, 46)
        Me.btnDeleteStudent.TabIndex = 3
        Me.btnDeleteStudent.Text = "Delete Student"
        Me.btnDeleteStudent.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(28, 62)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(174, 27)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "Search Student..."
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(227, 62)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(94, 29)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'HomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1189, 663)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnDeleteStudent)
        Me.Controls.Add(Me.btnEditStuden)
        Me.Controls.Add(Me.btnAddStudent)
        Me.Controls.Add(Me.dgvStudent)
        Me.Name = "HomeForm"
        Me.Text = "Student Records"
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvStudent As DataGridView
    Friend WithEvents btnAddStudent As Button
    Friend WithEvents btnEditStuden As Button
    Friend WithEvents btnDeleteStudent As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnSearch As Button
End Class
