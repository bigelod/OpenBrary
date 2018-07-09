<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBooks
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
        Me.lblBookTitle = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblAllBooks = New System.Windows.Forms.Label()
        Me.lstAllBooks = New System.Windows.Forms.ListBox()
        Me.txtBookTitle = New System.Windows.Forms.TextBox()
        Me.picCover = New System.Windows.Forms.PictureBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.ofdSelectCover = New System.Windows.Forms.OpenFileDialog()
        Me.lblBarcodeText = New System.Windows.Forms.Label()
        Me.lstStudentsBorrowed = New System.Windows.Forms.ListBox()
        Me.lblStudents = New System.Windows.Forms.Label()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnDeleteBook = New System.Windows.Forms.Button()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearchNext = New System.Windows.Forms.Button()
        Me.btnSearchBack = New System.Windows.Forms.Button()
        Me.btnBarcodeSearch = New System.Windows.Forms.Button()
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBookTitle
        '
        Me.lblBookTitle.AutoSize = True
        Me.lblBookTitle.Location = New System.Drawing.Point(467, 29)
        Me.lblBookTitle.Name = "lblBookTitle"
        Me.lblBookTitle.Size = New System.Drawing.Size(58, 13)
        Me.lblBookTitle.TabIndex = 21
        Me.lblBookTitle.Text = "Book Title:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(491, 533)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(167, 27)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Manually Add Book"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(466, 89)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(94, 13)
        Me.lblFirstName.TabIndex = 17
        Me.lblFirstName.Text = "Author First Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(568, 86)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(5)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(214, 20)
        Me.txtFirstName.TabIndex = 3
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(467, 59)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(95, 13)
        Me.lblLastName.TabIndex = 15
        Me.lblLastName.Text = "Author Last Name:"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(570, 56)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(5)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(212, 20)
        Me.txtLastName.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(664, 498)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(118, 62)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblAllBooks
        '
        Me.lblAllBooks.AutoSize = True
        Me.lblAllBooks.Location = New System.Drawing.Point(12, 10)
        Me.lblAllBooks.Name = "lblAllBooks"
        Me.lblAllBooks.Size = New System.Drawing.Size(54, 13)
        Me.lblAllBooks.TabIndex = 12
        Me.lblAllBooks.Text = "All Books:"
        '
        'lstAllBooks
        '
        Me.lstAllBooks.FormattingEnabled = True
        Me.lstAllBooks.HorizontalScrollbar = True
        Me.lstAllBooks.Location = New System.Drawing.Point(12, 26)
        Me.lstAllBooks.Name = "lstAllBooks"
        Me.lstAllBooks.ScrollAlwaysVisible = True
        Me.lstAllBooks.Size = New System.Drawing.Size(445, 511)
        Me.lstAllBooks.TabIndex = 0
        '
        'txtBookTitle
        '
        Me.txtBookTitle.Location = New System.Drawing.Point(533, 26)
        Me.txtBookTitle.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBookTitle.Name = "txtBookTitle"
        Me.txtBookTitle.Size = New System.Drawing.Size(249, 20)
        Me.txtBookTitle.TabIndex = 1
        '
        'picCover
        '
        Me.picCover.Location = New System.Drawing.Point(623, 290)
        Me.picCover.Name = "picCover"
        Me.picCover.Size = New System.Drawing.Size(159, 195)
        Me.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCover.TabIndex = 24
        Me.picCover.TabStop = False
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(539, 290)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(78, 65)
        Me.btnImport.TabIndex = 4
        Me.btnImport.Text = "Import Cover"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'ofdSelectCover
        '
        Me.ofdSelectCover.Filter = "Jpg|*.jpg"
        '
        'lblBarcodeText
        '
        Me.lblBarcodeText.Location = New System.Drawing.Point(466, 111)
        Me.lblBarcodeText.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblBarcodeText.Name = "lblBarcodeText"
        Me.lblBarcodeText.Size = New System.Drawing.Size(314, 23)
        Me.lblBarcodeText.TabIndex = 26
        Me.lblBarcodeText.Text = "ISBN13: N/A"
        '
        'lstStudentsBorrowed
        '
        Me.lstStudentsBorrowed.FormattingEnabled = True
        Me.lstStudentsBorrowed.HorizontalScrollbar = True
        Me.lstStudentsBorrowed.Location = New System.Drawing.Point(539, 137)
        Me.lstStudentsBorrowed.Name = "lstStudentsBorrowed"
        Me.lstStudentsBorrowed.ScrollAlwaysVisible = True
        Me.lstStudentsBorrowed.Size = New System.Drawing.Size(243, 147)
        Me.lstStudentsBorrowed.TabIndex = 9
        '
        'lblStudents
        '
        Me.lblStudents.AutoSize = True
        Me.lblStudents.Location = New System.Drawing.Point(466, 137)
        Me.lblStudents.Name = "lblStudents"
        Me.lblStudents.Size = New System.Drawing.Size(71, 13)
        Me.lblStudents.TabIndex = 28
        Me.lblStudents.Text = "Borrowed To:"
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(491, 500)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(167, 27)
        Me.btnDownload.TabIndex = 6
        Me.btnDownload.Text = "Auto Add Book"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'btnDeleteBook
        '
        Me.btnDeleteBook.Location = New System.Drawing.Point(517, 458)
        Me.btnDeleteBook.Name = "btnDeleteBook"
        Me.btnDeleteBook.Size = New System.Drawing.Size(100, 27)
        Me.btnDeleteBook.TabIndex = 8
        Me.btnDeleteBook.Text = "Delete Book"
        Me.btnDeleteBook.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(12, 547)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(47, 13)
        Me.lblSearch.TabIndex = 29
        Me.lblSearch.Text = "Search: "
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(55, 544)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(261, 20)
        Me.txtSearch.TabIndex = 10
        '
        'btnSearchNext
        '
        Me.btnSearchNext.Location = New System.Drawing.Point(442, 542)
        Me.btnSearchNext.Name = "btnSearchNext"
        Me.btnSearchNext.Size = New System.Drawing.Size(43, 23)
        Me.btnSearchNext.TabIndex = 30
        Me.btnSearchNext.Text = "Next"
        Me.btnSearchNext.UseVisualStyleBackColor = True
        '
        'btnSearchBack
        '
        Me.btnSearchBack.Location = New System.Drawing.Point(393, 542)
        Me.btnSearchBack.Name = "btnSearchBack"
        Me.btnSearchBack.Size = New System.Drawing.Size(43, 23)
        Me.btnSearchBack.TabIndex = 31
        Me.btnSearchBack.Text = "Back"
        Me.btnSearchBack.UseVisualStyleBackColor = True
        '
        'btnBarcodeSearch
        '
        Me.btnBarcodeSearch.Location = New System.Drawing.Point(322, 542)
        Me.btnBarcodeSearch.Name = "btnBarcodeSearch"
        Me.btnBarcodeSearch.Size = New System.Drawing.Size(65, 23)
        Me.btnBarcodeSearch.TabIndex = 32
        Me.btnBarcodeSearch.Text = "Barcode"
        Me.btnBarcodeSearch.UseVisualStyleBackColor = True
        '
        'frmBooks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 572)
        Me.Controls.Add(Me.btnBarcodeSearch)
        Me.Controls.Add(Me.btnSearchBack)
        Me.Controls.Add(Me.btnSearchNext)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.btnDeleteBook)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.lblStudents)
        Me.Controls.Add(Me.lstStudentsBorrowed)
        Me.Controls.Add(Me.lblBarcodeText)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.picCover)
        Me.Controls.Add(Me.txtBookTitle)
        Me.Controls.Add(Me.lblBookTitle)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblAllBooks)
        Me.Controls.Add(Me.lstAllBooks)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmBooks"
        Me.Text = "Book Database"
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblBookTitle As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblAllBooks As System.Windows.Forms.Label
    Friend WithEvents lstAllBooks As System.Windows.Forms.ListBox
    Friend WithEvents txtBookTitle As System.Windows.Forms.TextBox
    Friend WithEvents picCover As System.Windows.Forms.PictureBox
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents ofdSelectCover As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblBarcodeText As System.Windows.Forms.Label
    Friend WithEvents lstStudentsBorrowed As System.Windows.Forms.ListBox
    Friend WithEvents lblStudents As System.Windows.Forms.Label
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents btnDeleteBook As System.Windows.Forms.Button
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchNext As System.Windows.Forms.Button
    Friend WithEvents btnSearchBack As System.Windows.Forms.Button
    Friend WithEvents btnBarcodeSearch As System.Windows.Forms.Button
End Class
