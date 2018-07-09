<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnEditStudents = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblWhatIs = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEditBooks = New System.Windows.Forms.Button()
        Me.btnSignInOut = New System.Windows.Forms.Button()
        Me.btnChangeDB = New System.Windows.Forms.Button()
        Me.folDatabaseDir = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'btnEditStudents
        '
        Me.btnEditStudents.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditStudents.Location = New System.Drawing.Point(135, 65)
        Me.btnEditStudents.Name = "btnEditStudents"
        Me.btnEditStudents.Size = New System.Drawing.Size(168, 37)
        Me.btnEditStudents.TabIndex = 0
        Me.btnEditStudents.Text = "Student Database"
        Me.btnEditStudents.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(30, 13)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(365, 23)
        Me.lblWelcome.TabIndex = 1
        Me.lblWelcome.Text = "Welcome to OpenBrary"
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWhatIs
        '
        Me.lblWhatIs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhatIs.Location = New System.Drawing.Point(12, 38)
        Me.lblWhatIs.Name = "lblWhatIs"
        Me.lblWhatIs.Size = New System.Drawing.Size(412, 20)
        Me.lblWhatIs.TabIndex = 2
        Me.lblWhatIs.Text = "A digital library card system for small scale libraries"
        Me.lblWhatIs.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Created by Daven Bigelow 2013, Public Domain 2018"
        '
        'btnEditBooks
        '
        Me.btnEditBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditBooks.Location = New System.Drawing.Point(135, 108)
        Me.btnEditBooks.Name = "btnEditBooks"
        Me.btnEditBooks.Size = New System.Drawing.Size(168, 37)
        Me.btnEditBooks.TabIndex = 4
        Me.btnEditBooks.Text = "Book Database"
        Me.btnEditBooks.UseVisualStyleBackColor = True
        '
        'btnSignInOut
        '
        Me.btnSignInOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignInOut.Location = New System.Drawing.Point(135, 151)
        Me.btnSignInOut.Name = "btnSignInOut"
        Me.btnSignInOut.Size = New System.Drawing.Size(168, 37)
        Me.btnSignInOut.TabIndex = 5
        Me.btnSignInOut.Text = "Sign In/Out Book"
        Me.btnSignInOut.UseVisualStyleBackColor = True
        '
        'btnChangeDB
        '
        Me.btnChangeDB.Location = New System.Drawing.Point(12, 202)
        Me.btnChangeDB.Name = "btnChangeDB"
        Me.btnChangeDB.Size = New System.Drawing.Size(118, 23)
        Me.btnChangeDB.TabIndex = 6
        Me.btnChangeDB.Text = "Change Database"
        Me.btnChangeDB.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 229)
        Me.Controls.Add(Me.btnChangeDB)
        Me.Controls.Add(Me.btnSignInOut)
        Me.Controls.Add(Me.btnEditBooks)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblWhatIs)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.btnEditStudents)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "OpenBrary V1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEditStudents As System.Windows.Forms.Button
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents lblWhatIs As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEditBooks As System.Windows.Forms.Button
    Friend WithEvents btnSignInOut As System.Windows.Forms.Button
    Friend WithEvents btnChangeDB As System.Windows.Forms.Button
    Friend WithEvents folDatabaseDir As System.Windows.Forms.FolderBrowserDialog

End Class
