<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStudents
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
        Me.lstAllStudents = New System.Windows.Forms.ListBox()
        Me.lblAllStudents = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lstBooksOut = New System.Windows.Forms.ListBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblBooksOut = New System.Windows.Forms.Label()
        Me.lblBarcodeText = New System.Windows.Forms.Label()
        Me.btnSearchBack = New System.Windows.Forms.Button()
        Me.btnSearchNext = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.btnBarcodeSearch = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstAllStudents
        '
        Me.lstAllStudents.FormattingEnabled = True
        Me.lstAllStudents.Location = New System.Drawing.Point(12, 25)
        Me.lstAllStudents.Name = "lstAllStudents"
        Me.lstAllStudents.ScrollAlwaysVisible = True
        Me.lstAllStudents.Size = New System.Drawing.Size(429, 511)
        Me.lstAllStudents.TabIndex = 0
        '
        'lblAllStudents
        '
        Me.lblAllStudents.AutoSize = True
        Me.lblAllStudents.Location = New System.Drawing.Point(12, 9)
        Me.lblAllStudents.Name = "lblAllStudents"
        Me.lblAllStudents.Size = New System.Drawing.Size(66, 13)
        Me.lblAllStudents.TabIndex = 1
        Me.lblAllStudents.Text = "All Students:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(683, 498)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 62)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(516, 14)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(5)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(264, 20)
        Me.txtLastName.TabIndex = 1
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(447, 17)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(61, 13)
        Me.lblLastName.TabIndex = 4
        Me.lblLastName.Text = "Last Name:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(448, 47)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(60, 13)
        Me.lblFirstName.TabIndex = 6
        Me.lblFirstName.Text = "First Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(516, 44)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(5)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(264, 20)
        Me.txtFirstName.TabIndex = 2
        '
        'lstBooksOut
        '
        Me.lstBooksOut.FormattingEnabled = True
        Me.lstBooksOut.HorizontalScrollbar = True
        Me.lstBooksOut.Location = New System.Drawing.Point(513, 98)
        Me.lstBooksOut.Name = "lstBooksOut"
        Me.lstBooksOut.ScrollAlwaysVisible = True
        Me.lstBooksOut.Size = New System.Drawing.Size(269, 394)
        Me.lstBooksOut.TabIndex = 6
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(470, 533)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(207, 27)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(470, 500)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(207, 27)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblBooksOut
        '
        Me.lblBooksOut.AutoSize = True
        Me.lblBooksOut.Location = New System.Drawing.Point(447, 98)
        Me.lblBooksOut.Name = "lblBooksOut"
        Me.lblBooksOut.Size = New System.Drawing.Size(60, 13)
        Me.lblBooksOut.TabIndex = 10
        Me.lblBooksOut.Text = "Books Out:"
        '
        'lblBarcodeText
        '
        Me.lblBarcodeText.Location = New System.Drawing.Point(448, 69)
        Me.lblBarcodeText.Name = "lblBarcodeText"
        Me.lblBarcodeText.Size = New System.Drawing.Size(332, 17)
        Me.lblBarcodeText.TabIndex = 11
        Me.lblBarcodeText.Text = "Barcode: N/A"
        '
        'btnSearchBack
        '
        Me.btnSearchBack.Location = New System.Drawing.Point(360, 545)
        Me.btnSearchBack.Name = "btnSearchBack"
        Me.btnSearchBack.Size = New System.Drawing.Size(43, 23)
        Me.btnSearchBack.TabIndex = 35
        Me.btnSearchBack.Text = "Back"
        Me.btnSearchBack.UseVisualStyleBackColor = True
        '
        'btnSearchNext
        '
        Me.btnSearchNext.Location = New System.Drawing.Point(409, 545)
        Me.btnSearchNext.Name = "btnSearchNext"
        Me.btnSearchNext.Size = New System.Drawing.Size(43, 23)
        Me.btnSearchNext.TabIndex = 34
        Me.btnSearchNext.Text = "Next"
        Me.btnSearchNext.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(62, 547)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(221, 20)
        Me.txtSearch.TabIndex = 32
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(9, 550)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(47, 13)
        Me.lblSearch.TabIndex = 33
        Me.lblSearch.Text = "Search: "
        '
        'btnBarcodeSearch
        '
        Me.btnBarcodeSearch.Location = New System.Drawing.Point(289, 545)
        Me.btnBarcodeSearch.Name = "btnBarcodeSearch"
        Me.btnBarcodeSearch.Size = New System.Drawing.Size(65, 23)
        Me.btnBarcodeSearch.TabIndex = 36
        Me.btnBarcodeSearch.Text = "Barcode"
        Me.btnBarcodeSearch.UseVisualStyleBackColor = True
        '
        'frmStudents
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 572)
        Me.Controls.Add(Me.btnBarcodeSearch)
        Me.Controls.Add(Me.btnSearchBack)
        Me.Controls.Add(Me.btnSearchNext)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.lblBarcodeText)
        Me.Controls.Add(Me.lblBooksOut)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lstBooksOut)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblAllStudents)
        Me.Controls.Add(Me.lstAllStudents)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmStudents"
        Me.Text = "Student Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstAllStudents As System.Windows.Forms.ListBox
    Friend WithEvents lblAllStudents As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lstBooksOut As System.Windows.Forms.ListBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblBooksOut As System.Windows.Forms.Label
    Friend WithEvents lblBarcodeText As System.Windows.Forms.Label
    Friend WithEvents btnSearchBack As System.Windows.Forms.Button
    Friend WithEvents btnSearchNext As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents btnBarcodeSearch As System.Windows.Forms.Button
End Class
