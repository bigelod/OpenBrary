Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strDBPath = ""
        LoadSettings()
        LoadData(strDBPath)
    End Sub

    Private Sub btnEditStudents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditStudents.Click
        intCurrStudent = 0
        frmStudents.Show()
        frmStudents.BringToFront()
    End Sub

    Private Sub btnSignInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignInOut.Click
        If frmBooks.Enabled = False Or frmStudents.Enabled = False Then
            MessageBox.Show("Please close waiting editor windows before signing in or out a book", "Edtior windows waiting to be closed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        frmSignInOut.Show()
        frmSignInOut.BringToFront()
    End Sub

    Private Sub btnEditBooks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditBooks.Click
        intCurrBook = 0
        frmBooks.Show()
        frmBooks.BringToFront()
    End Sub

    Private Sub btnChangeDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeDB.Click

        If frmBooks.Visible = True Or frmStudents.Visible = True Or frmSignInOut.Visible = True Then
            If MessageBox.Show("Close open windows? Any unsaved changes will be lost.", "Change database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                frmBooks.Close()
                frmStudents.Close()
                frmSignInOut.Close()
            Else
                Exit Sub
            End If
        End If

        If strDBPath <> "" Then folDatabaseDir.SelectedPath = strDBPath

        folDatabaseDir.ShowDialog()

        LoadData(folDatabaseDir.SelectedPath())

        'Save the selected folder to the settings file

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\LCSettings.txt", False)
        'Simple code to overwrite the file

        If strDBPath <> (Application.StartupPath & "\LCData") Then
            file.WriteLine(strDBPath)
            file.WriteLine(";Edit the above line to change the application directory, or enter APPDIR for the LCData database")
        Else
            file.WriteLine("APPDIR")
            file.WriteLine(";Edit the above line to change the application directory, or enter APPDIR for the LCData database")
        End If

        file.Close()
    End Sub

    Private Sub lblWelcome_Click(sender As Object, e As EventArgs) Handles lblWelcome.Click

    End Sub
End Class
