Public Class frmStudents
    Dim bolChangeMade As Boolean = False
    Dim bolOverrideChange As Boolean = False

    Private Sub frmStudents_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        bolChangeMade = False

        If frmSignInOut.Enabled = False Then
            frmSignInOut.Enabled = True
            frmSignInOut.Show()
            frmSignInOut.BringToFront()
        End If

        If frmBooks.Enabled = False Then
            frmBooks.Enabled = True
            frmBooks.Show()
            frmBooks.BringToFront()
        End If

        If strCurrStudent(1) <> txtLastName.Text Then bolChangeMade = True
        If strCurrStudent(2) <> txtFirstName.Text Then bolChangeMade = True

        If bolOverrideChange = True Then
            bolChangeMade = False
            bolOverrideChange = False
        End If

        If bolChangeMade = True Then
            If MessageBox.Show("Changes have been made to the student, continue without saving them?", "Cancel changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                bolChangeMade = False
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmStudents_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ReloadData(False)
        
    End Sub

    Public Sub ReloadData(Optional ByVal TotalReload As Boolean = True) 'Called by SignInOut to refresh the data
        'Reload all data, rather than try to replace it in memory
        If TotalReload Then LoadData(strDBPath)

        If intStudents >= 0 Then
            txtLastName.Enabled = True
            txtFirstName.Enabled = True

            'Reset the display
            intCurrStudent = 0 'Go to the first student

            ListStudents() 'List all students
            LoadStudent("", intCurrStudent) 'Select the currently selected student

            Try
                lstAllStudents.SelectedIndex = intCurrStudent 'Highlight the selected student
            Catch ex As Exception

            End Try

            lblBarcodeText.Text = "Barcode: " & strCurrStudent(0) 'Load the student barcode
            txtLastName.Text = strCurrStudent(1) 'Load student last name
            txtFirstName.Text = strCurrStudent(2) 'Load student first name

            If strCurrStudent(3) <> "0" Then ListBooks() 'Show the books for this student

            bolChangeMade = False
        Else
            'Otherwise

            lblAllStudents.Text = "No students in library database"

            txtLastName.Text = ""
            txtLastName.Enabled = False
            txtFirstName.Text = ""
            txtFirstName.Enabled = False
            lblBarcodeText.Text = "Barcode: N/A"

            lstAllStudents.Items.Clear()
            lstBooksOut.Items.Clear()

            bolOverrideChange = True

        End If

    End Sub

    Private Sub ListStudents()
        lstAllStudents.Items.Clear()

        For i = 0 To intStudents 'Add all the items to the list
            Dim intBooks As Integer = 0

            LoadStudent("", i)

            If strCurrStudent(3) <> "0;" Then
                Dim tmpBooksOut() = Split(strCurrStudent(3), ";")

                intBooks = tmpBooksOut.Count - 1
            End If

            If intBooks = 0 Then
                lstAllStudents.Items.Add(strCurrStudent(1) & ", " & strCurrStudent(2))
            ElseIf intBooks = 1 Then
                lstAllStudents.Items.Add(strCurrStudent(1) & ", " & strCurrStudent(2) & " (borrowing " & intBooks & " book)")
            Else
                lstAllStudents.Items.Add(strCurrStudent(1) & ", " & strCurrStudent(2) & " (borrowing " & intBooks & " books)")
            End If
        Next

        lblAllStudents.Text = "All Students: (" & (intStudents + 1) & " students in database)"
    End Sub

    Private Sub ListBooks()
        Dim strBooksOut() As String = Split(strCurrStudent(3), ";") 'Find all the books they have

        lstBooksOut.Items.Clear()

        For i = 0 To strBooksOut.Count - 1 'Loop through the books to put their details in

            If (strBooksOut(i) <> "0") And (strBooksOut(i) <> "") Then
                LoadBook(strBooksOut(i))

                lstBooksOut.Items.Add(strCurrBook(1))
            End If
            
        Next
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim strBarcode As String

        strBarcode = Replace(InputBox("Please scan or enter student barcode", "Enter student barcode"), "-", "")

        If strBarcode <> "" Then

            For i = 0 To intStudents 'If the student exists exit the sub
                If (strBarcode & ".txt") = Students(i) Then
                    MessageBox.Show("This student already exists, unable to add", "Error: Student exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            'Add them to the database
            intStudents += 1
            Students(intStudents) = strBarcode
            SaveStudent(strBarcode, "New", "Student")

            ReloadData()

            Try
                lstAllStudents.SelectedIndex = intCurrStudent 'Highlight the selected student
            Catch ex As Exception

            End Try

            lblBarcodeText.Text = "Barcode: " & strCurrStudent(0) 'Load the student barcode
            txtLastName.Text = strCurrStudent(1) 'Load student last name
            txtFirstName.Text = strCurrStudent(2) 'Load student first name

            If strCurrStudent(3) <> "0" Then ListBooks() 'Show the books for this student

            bolChangeMade = False
        End If

        bolOverrideChange = True
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If intStudents < 0 Then
                MessageBox.Show("No students in database to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Exit Sub 'Nobody to delete
            End If


            If MessageBox.Show("This will permanently delete the student, continue?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                'Remove the student file
                My.Computer.FileSystem.DeleteFile(strDBPath & "\Students\" & Students(intCurrStudent))

                lstAllStudents.SelectedIndex = intCurrStudent - 1 'Select the previous student

                ReloadData()
                If frmBooks.Visible = True Then frmBooks.ReloadData(False)
            End If

            bolOverrideChange = True

        Catch ex As Exception
            MessageBox.Show("Unable to delete student: " & ex.Message, "Error deleting student", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If intStudents < 0 Then
            MessageBox.Show("No student to save data to.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SaveStudent(strCurrStudent(0), txtLastName.Text, txtFirstName.Text, strCurrStudent(3)) 'Save the updated profile
            bolChangeMade = False

            'Reset the display
            lstAllStudents.SelectedIndex = intCurrStudent 'Highlight the selected student
            ListStudents() 'List all students
            LoadStudent("", intCurrStudent) 'Select the currently selected student
            If strCurrStudent(3) <> "0" Then ListBooks() 'Show the books for this student
        End If
    End Sub

    Private Sub lstAllStudents_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstAllStudents.SelectedIndexChanged
        'Check if changes were made
        If strCurrStudent(1) <> txtLastName.Text Then bolChangeMade = True
        If strCurrStudent(2) <> txtFirstName.Text Then bolChangeMade = True

        If bolOverrideChange = True Then
            bolChangeMade = False
            bolOverrideChange = False
        End If

        If bolChangeMade = True And (lstAllStudents.SelectedIndex <> intCurrStudent) Then
            If MessageBox.Show("Changes have been made to the student, continue without saving them?", "Cancel changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                lstAllStudents.SelectedIndex = intCurrStudent
                bolChangeMade = False
                Exit Sub
            End If
        ElseIf lstAllStudents.SelectedIndex = intCurrStudent Then
            bolChangeMade = False
            Exit Sub
        End If

        intCurrStudent = lstAllStudents.SelectedIndex
        LoadStudent("", intCurrStudent) 'Select the currently selected student
        If strCurrStudent(3) <> "0" Then ListBooks() 'Show the books for this student

        lblBarcodeText.Text = "Barcode: " & strCurrStudent(0) 'Load the student barcode
        txtLastName.Text = strCurrStudent(1)
        txtFirstName.Text = strCurrStudent(2)

        bolChangeMade = False

    End Sub

    Private Sub lstBooksOut_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstBooksOut.MouseDoubleClick
        If frmBooks.Enabled = False Then
            MessageBox.Show("Please close this window to return to the book editor", "Book editor already opened", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If lstBooksOut.SelectedItem() <> Nothing Then

            For i = 0 To intBooks

                LoadBook("", i)

                If lstBooksOut.SelectedItem = strCurrBook(1) Then
                    intCurrBook = i

                    frmBooks.Show()

                    frmBooks.txtSearch.Text = Mid(Books(i), 1, Books(i).Length - 4)
                    frmBooks.btnBarcodeSearch.PerformClick()

                    frmBooks.BringToFront()
                    Me.Enabled = False

                    Exit For
                End If

            Next

            
        End If
    End Sub

    Private Sub lblBarcodeText_Click(sender As System.Object, e As System.EventArgs) Handles lblBarcodeText.Click
        Try
            Clipboard.SetText(strCurrStudent(0))

            MessageBox.Show("Barcode copied", "Copied to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub btnSearchBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBack.Click
        Dim bolBookFound As Boolean = False

        If Replace(txtSearch.Text, " ", "") <> "" Then

            For i = intCurrStudent To 0 Step -1

                If i < intCurrStudent Then 'Try to find the next book

                    If lstAllStudents.Items.Item(i).ToString.ToUpper.Contains(txtSearch.Text.ToUpper) Then

                        bolOverrideChange = True
                        bolBookFound = True

                        lstAllStudents.SelectedIndex = i 'Highlight the selected book

                        Exit For

                    End If

                End If


            Next

            If bolBookFound = False Then MessageBox.Show("Unable to find previous student in search for: " & txtSearch.Text, "Student not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            txtSearch.Text = ""

        End If
    End Sub

    Private Sub btnSearchNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchNext.Click
        Dim bolBookFound As Boolean = False

        If Replace(txtSearch.Text, " ", "") <> "" Then

            For i = intCurrStudent To lstAllStudents.Items.Count - 1

                If i > intCurrStudent Then 'Try to find the next book

                    If lstAllStudents.Items.Item(i).ToString.ToUpper.Contains(txtSearch.Text.ToUpper) Then

                        bolOverrideChange = True
                        bolBookFound = True

                        lstAllStudents.SelectedIndex = i 'Highlight the selected book

                        Exit For

                    End If

                End If


            Next

            If bolBookFound = False Then MessageBox.Show("Unable to find next student in search for: " & txtSearch.Text, "Student not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            txtSearch.Text = ""

        End If
    End Sub

    Private Sub btnBarcodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcodeSearch.Click
        Dim bolBookFound As Boolean = False

        Dim strBarcode As String = Replace(txtSearch.Text, " ", "")

        If strBarcode <> "" Then

            For i = 0 To lstAllStudents.Items.Count - 1

                If Students(i) = (strBarcode & ".txt") Then

                    bolOverrideChange = True
                    bolBookFound = True

                    lstAllStudents.SelectedIndex = i 'Highlight the selected book

                    Exit For

                End If

            Next

            If bolBookFound = False Then MessageBox.Show("Unable to find student with barcode: " & txtSearch.Text, "Student barcode not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            txtSearch.Text = ""

        End If
    End Sub
End Class