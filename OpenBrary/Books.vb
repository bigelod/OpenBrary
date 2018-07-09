Imports System.Net
Public Class frmBooks
    Dim bolChangeMade As Boolean = False
    Dim bolOverrideChange As Boolean = False
    Dim intTotalOut As Integer
    Dim intTotalBooks As Integer

    Private Sub frmBooks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        bolChangeMade = False

        If frmSignInOut.Enabled = False Then
            frmSignInOut.Enabled = True
            frmSignInOut.Show()
            frmSignInOut.BringToFront()
        End If

        If frmStudents.Enabled = False Then
            frmStudents.Enabled = True
            frmStudents.Show()
            frmStudents.BringToFront()
        End If

        If strCurrBook(1) <> txtBookTitle.Text Then bolChangeMade = True
        If strCurrBook(2) <> txtLastName.Text Then bolChangeMade = True
        If strCurrBook(3) <> txtFirstName.Text Then bolChangeMade = True

        If bolOverrideChange = True Then
            bolChangeMade = False
            bolOverrideChange = False
        End If


        If bolChangeMade = True Then
            If MessageBox.Show("Changes have been made to the book, continue without saving them?", "Cancel changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                bolChangeMade = False
                e.Cancel = True
            End If
        End If

    End Sub

    Public Sub ReloadData(Optional ByVal TotalReload As Boolean = True) 'Called by SignInOut to refresh the data
        'Reload all data, rather than try to replace it in memory
        If TotalReload Then LoadData(strDBPath)

        If intBooks >= 0 Then
            txtBookTitle.Enabled = True
            txtLastName.Enabled = True
            txtFirstName.Enabled = True
            btnImport.Enabled = True

            'Reset the display
            intCurrBook = 0 'Go to the first book
            ListBooks() 'List all books
            LoadBook("", intCurrBook) 'Select the currently selected book

            lblBarcodeText.Text = "ISBN13: " & Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) 'Load the book barcode
            txtBookTitle.Text = strCurrBook(1) 'Load book title
            txtFirstName.Text = strCurrBook(2) 'Load book author last name
            txtLastName.Text = strCurrBook(3) 'Load book author first name

            lstAllBooks.SelectedIndex = intCurrBook 'Highlight the first book

            ListBorrowers() 'Update the list of students borrowing the book

            If My.Computer.FileSystem.FileExists(strDBPath & "\Covers\" & Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) & ".jpg") Then
                picCover.ImageLocation = strDBPath & "\Covers\" & Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) & ".jpg"
            Else
                picCover.ImageLocation = strDBPath & "\Covers\Cover.jpg"
            End If

            bolChangeMade = False

        Else
            'Otherwise, lock data entry

            lblAllBooks.Text = "No books in library database"

            txtBookTitle.Text = ""
            txtBookTitle.Enabled = False
            txtLastName.Text = ""
            txtLastName.Enabled = False
            txtFirstName.Text = ""
            txtFirstName.Enabled = False
            picCover.ImageLocation = strDBPath & "\Covers\Cover.jpg"
            btnImport.Enabled = False

            lstAllBooks.Items.Clear()
            lstStudentsBorrowed.Items.Clear()

            bolOverrideChange = True

        End If
    End Sub

    Private Sub frmBooks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picCover.ImageLocation = strDBPath & "\Covers\Cover.jpg"

        ReloadData(False)
    End Sub

    Private Sub ListBooks()
        intTotalOut = 0
        lstAllBooks.Items.Clear()

        For i = 0 To intBooks 'Add all the items to the list
            Dim intCopiesOut As Integer = 0

            LoadBook("", i)

            For n = 0 To intStudents 'Find if the book is out
                LoadStudent("", n)

                If strCurrStudent(3) <> "0;" Then 'Search student books

                    Dim tmpBooksOut() = Split(strCurrStudent(3), ";")

                    For x = 0 To tmpBooksOut.Count - 1

                        If tmpBooksOut(x) = Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) Then
                            intCopiesOut += 1 'Student has a copy
                            intTotalOut += 1 'Add to the total books out

                            Exit For 'Done with this student
                        End If

                    Next

                End If

            Next

            If intCopiesOut = 0 Then
                lstAllBooks.Items.Add(strCurrBook(1) & " - " & strCurrBook(2) & ", " & strCurrBook(3))
            ElseIf intCopiesOut = 1 Then
                lstAllBooks.Items.Add(strCurrBook(1) & " - " & strCurrBook(2) & ", " & strCurrBook(3) & " (" & intCopiesOut & " copy out)")
            Else
                lstAllBooks.Items.Add(strCurrBook(1) & " - " & strCurrBook(2) & ", " & strCurrBook(3) & " (" & intCopiesOut & " copies out)")
            End If

        Next

        intTotalBooks = intBooks + 1

        If intTotalOut > intTotalBooks Then intTotalBooks = intTotalOut 'Temporary, make up for books we don't know about

        lblAllBooks.Text = "All Books: (" & intTotalOut & " of " & intTotalBooks & " currently out)"
    End Sub

    Private Sub ListBorrowers()
        lstStudentsBorrowed.Items.Clear() 'Empty the students list to repopulate

        For n = 0 To intStudents 'Find if the book is out
            LoadStudent("", n)

            If strCurrStudent(3) <> "0;" Then 'Search student books

                Dim tmpBooksOut() = Split(strCurrStudent(3), ";")

                For x = 0 To tmpBooksOut.Count - 1

                    If tmpBooksOut(x) = Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) Then
                        lstStudentsBorrowed.Items.Add(strCurrStudent(1) & ", " & strCurrStudent(2))
                        Exit For 'Done with this student
                    End If

                Next

            End If

        Next
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If intCurrBook >= 0 Then

            ofdSelectCover.FileName = ""

            ofdSelectCover.ShowDialog()

            If ofdSelectCover.FileName = "" Then Exit Sub

            Dim FileToCopy As String
            Dim NewCopy As String

            FileToCopy = ofdSelectCover.FileName()
            NewCopy = strDBPath & "\Covers\" & Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) & ".jpg"

            If System.IO.File.Exists(FileToCopy) = True Then

                System.IO.File.Copy(FileToCopy, NewCopy, True)
                MessageBox.Show("Cover copied successfully", "Cover copied to database", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            picCover.ImageLocation = NewCopy
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim strBarcode As String

        strBarcode = Replace(InputBox("Please scan or enter book barcode", "Enter book barcode"), "-", "")

        If strBarcode = "" Then Exit Sub

        If strBarcode.Length = 10 Then strBarcode = GetISBN13(strBarcode)

        If MessageBox.Show("Is: " & strBarcode & " the correct barcode? This can not be changed later!", "Confirm book barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
            Exit Sub 'Wrong book barcode
        End If

        If strBarcode <> "" Then

            For i = 0 To intBooks 'If the Books exists exit the sub
                If (strBarcode & ".txt") = Books(i) Then
                    MessageBox.Show("This book already exists, unable to add", "Error: Books exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            'Add them to the database
            intBooks += 1
            Books(intBooks) = strBarcode
            SaveBook(strBarcode, "New Book", "New", "Author")

            ReloadData()

            bolChangeMade = False

            bolOverrideChange = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If intBooks < 0 Then
            MessageBox.Show("No books to save data to.", "Unable to save data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SaveBook(Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4), txtBookTitle.Text, txtLastName.Text, txtFirstName.Text) 'Save the updated profile
            bolChangeMade = False

            'Reset the display
            lstAllBooks.SelectedIndex = intCurrBook 'Highlight the selected book
            ListBooks() 'List all books
            LoadBook("", intCurrBook) 'Select the currently selected book
        End If
    End Sub

    Private Sub lstAllBooks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAllBooks.SelectedIndexChanged
        'Check if changes were made
        If strCurrBook(1) <> txtBookTitle.Text Then bolChangeMade = True
        If strCurrBook(2) <> txtLastName.Text Then bolChangeMade = True
        If strCurrBook(3) <> txtFirstName.Text Then bolChangeMade = True

        If bolOverrideChange = True Then
            bolChangeMade = False
            bolOverrideChange = False
        End If

        If bolChangeMade = True And (lstAllBooks.SelectedIndex <> intCurrBook) Then
            If MessageBox.Show("Changes have been made to the book, continue without saving them?", "Cancel changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                lstAllBooks.SelectedIndex = intCurrBook
                bolChangeMade = False
                Exit Sub
            End If
        ElseIf lstAllBooks.SelectedIndex = intCurrBook Then
            bolChangeMade = False
            Exit Sub
        End If

        intCurrBook = lstAllBooks.SelectedIndex
        LoadBook("", intCurrBook) 'Select the currently selected book

        lblBarcodeText.Text = "ISBN13: " & Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) 'Load the book barcode
        txtBookTitle.Text = strCurrBook(1)
        txtLastName.Text = strCurrBook(2)
        txtFirstName.Text = strCurrBook(3)

        ListBorrowers() 'Update the list of students borrowing the book

        If My.Computer.FileSystem.FileExists(strDBPath & "\Covers\" & Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) & ".jpg") Then
            picCover.ImageLocation = strDBPath & "\Covers\" & Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) & ".jpg"
        Else
            picCover.ImageLocation = strDBPath & "\Covers\Cover.jpg"
        End If

        bolChangeMade = False
    End Sub

    Private Sub lstStudentsBorrowed_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstStudentsBorrowed.MouseDoubleClick
        If frmStudents.Enabled = False Then
            MessageBox.Show("Please close this window to return to the student editor", "Student editor already opened", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If lstStudentsBorrowed.SelectedItem() <> Nothing Then

            For i = 0 To intStudents

                LoadStudent("", i)

                If lstStudentsBorrowed.SelectedItem = (strCurrStudent(1) & ", " & strCurrStudent(2)) Then
                    intCurrStudent = i

                    frmStudents.Show()

                    frmStudents.txtSearch.Text = Mid(Students(i), 1, Students(i).Length - 4)
                    frmStudents.btnBarcodeSearch.PerformClick()

                    frmStudents.BringToFront()
                    Me.Enabled = False

                    Exit For
                End If

            Next

        End If
    End Sub

    Private Sub picCover_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picCover.DoubleClick
        Process.Start(picCover.ImageLocation) 'Double click to open the picture file
    End Sub

    Private Sub lblBarcodeText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBarcodeText.Click
        Try
            Clipboard.SetText(Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4))

            MessageBox.Show("ISBN13 barcode copied", "Copied to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Dim strBarcode As String

        Dim strTitle As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strThumbnail As String = ""

        If bolChangeMade = True Then
            If MessageBox.Show("Changes have been made to the book, continue without saving them?", "Cancel changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                Exit Sub
            End If
        End If

        strBarcode = Replace(InputBox("Please scan or enter book barcode", "Enter book barcode"), "-", "")

        If strBarcode = "" Then Exit Sub

        If strBarcode.Length = 10 Then strBarcode = GetISBN13(strBarcode)

        If strBarcode <> "" Then
            Try
                Dim Client As New WebClient
                Dim strTempData As String

                strTempData = Replace(Replace(Client.DownloadString("https://www.googleapis.com/books/v1/volumes?q=isbn:" & strBarcode), """", ""), " ", "")
                Dim strBookData() = Split(strTempData, vbLf)

                Dim bolAuthorLine As Boolean = False

                For Each tmpLine As String In strBookData
                    Dim tmpData() = Split(tmpLine, ":")

                    Select Case tmpData(0)
                        Case "totalItems"
                            If tmpData(1) <= 0 Then
                                MessageBox.Show("Unknown book, unable to auto-complete data", "Error downloading book information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        Case "title"
                            'Grab the book title
                            strTitle = ""
                            Dim intStart As Integer = 1

                            For i = 1 To tmpData(1).Length - 1
                                If Char.IsUpper(tmpData(1), i) Or i = tmpData(1).Length - 1 Then
                                    If intStart > 1 Then strTitle &= " "
                                    'MsgBox(Mid(tmpData(1), i, 1))
                                    strTitle &= Replace(Replace(Replace(Replace(Mid(tmpData(1), intStart, i - intStart + 1), ",", ""), "the", " The"), "of", " Of"), "for", " For")
                                    intStart = i + 1
                                End If
                            Next
                        Case "authors"
                            'Next line is the author
                            bolAuthorLine = True
                        Case "thumbnail"
                            'Grab the thumbnail URI and throw : back into it
                            strThumbnail = tmpData(1) & ":" & tmpData(2)
                            Exit Select
                        Case Else
                            'Check if we are grabbing the author name
                            If bolAuthorLine = True Then
                                For i = 2 To tmpData(0).Length - 1 'As we removed the spaces before, split it into two words
                                    If Char.IsUpper(tmpData(0), i) Then
                                        strFirstName = Replace(Mid(tmpData(0), 1, i), ",", "")
                                        strLastName = Replace(Mid(tmpData(0), i + 1, tmpData(0).Length - 1), ",", "")
                                    End If
                                Next

                                bolAuthorLine = False
                            End If
                    End Select
                Next

                If MessageBox.Show("Are the following details correct?" & vbNewLine & "Title: " & strTitle & vbNewLine & "Author: " & strLastName & ", " & strFirstName, "Possible match found", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

                    Try
                        'Check for duplicates
                        For i = 0 To intBooks
                            If Books(i) = strBarcode & ".txt" Then
                                If MessageBox.Show("It appears this book already exists, would you like to overwrite it?", "Existing book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    'Continue
                                Else
                                    Exit Sub
                                End If
                            End If
                        Next
                    Catch ex As Exception
                        MessageBox.Show("Error checking for duplicates: " & ex.Message, "Error during duplicate check", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    Try
                        'Download the cover image
                        Try
                            Client.DownloadFile(strThumbnail, strDBPath & "\Covers\" & strBarcode & ".jpg")
                        Catch ex As Exception
                            MessageBox.Show("An error occured downloading cover: " & ex.Message, "Error downloading cover image", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        'Add them to the database
                        intBooks += 1
                        Books(intBooks) = strBarcode
                        SaveBook(strBarcode, strTitle, strLastName, strFirstName)

                        ReloadData()

                        bolChangeMade = False
                    Catch ex As Exception
                        MessageBox.Show("Error adding book to database: " & ex.Message, "Error adding book", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If

                Client.Dispose() 'Close the web client
            Catch ex As Exception
                MessageBox.Show("An unknown error has occured: " & ex.Message, "Error collecting book information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            bolOverrideChange = True

        End If

    End Sub

    Private Sub btnDeleteBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBook.Click
        Try
            If intBooks < 0 Then
                MessageBox.Show("No books in database to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Exit Sub 'No books to delete
            End If

            If MessageBox.Show("This will permanently delete the book from the database, continue?", "Permanently delete book?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = vbYes Then

                Dim intInOut As Integer

                For n = 0 To intStudents 'Find if the book is out to any of the students
                    LoadStudent("", n)

                    If strCurrStudent(3) <> "0;" Then 'Search student books

                        Dim tmpBooksOut() = Split(strCurrStudent(3), ";")

                        For x = 0 To tmpBooksOut.Count - 1 'Check their books out if they have any

                            If tmpBooksOut(x) = Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4) Then

                                Dim strBook As String = Mid(strCurrBook(0), 1, strCurrBook(0).Length - 4)

                                Dim strBooksOut() As String = Split(strCurrStudent(3), ";")

                                For i = 0 To strBooksOut.Count - 1 'See if they already have the book we are deleting
                                    If strBooksOut(i) = strBook Then intInOut = 1
                                Next

                                strCurrStudent(3) = "" 'Get ready to rebuild the list

                                For i = 0 To strBooksOut.Count - 1 'Getting rid of the book during rebuild
                                    If strBooksOut(i) <> strBook Then strCurrStudent(3) &= strBooksOut(i) & ";"
                                Next

                                If strCurrStudent(3) = ";" Then strCurrStudent(3) = "0;" 'Replace the 0 val when no books are out
                                If strCurrStudent(3) = "" Then strCurrStudent(3) = "0;" 'Replace the 0 val when no books are out


                                SaveStudent(strCurrStudent(0), strCurrStudent(1), strCurrStudent(2), strCurrStudent(3)) 'Save the updated student profile

                                Exit For 'Done with this student
                            End If

                        Next

                    End If

                Next

                If intInOut > 0 Then
                    'Book was deleted while students registered as having it
                    If frmStudents.Visible = True Then frmStudents.ReloadData(False)
                End If

                'Now we delete the book and cover itself and update the displays
                If My.Computer.FileSystem.FileExists(strDBPath & "\Covers\" & Mid(Books(intCurrBook), 1, Books(intCurrBook).Length - 4) & ".jpg") Then
                    My.Computer.FileSystem.DeleteFile(strDBPath & "\Covers\" & Mid(Books(intCurrBook), 1, Books(intCurrBook).Length - 4) & ".jpg")
                End If

                My.Computer.FileSystem.DeleteFile(strDBPath & "\Books\" & Books(intCurrBook))

                ReloadData()

                bolOverrideChange = True

            End If
        Catch ex As Exception
            MessageBox.Show("Unable to delete book: " & ex.Message, "Error deleting book", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        
    End Sub

    Private Sub btnSearchBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBack.Click
        Dim bolBookFound As Boolean = False

        If Replace(txtSearch.Text, " ", "") <> "" Then

            For i = intCurrBook To 0 Step -1

                If i < intCurrBook Then 'Try to find the next book

                    If lstAllBooks.Items.Item(i).ToString.ToUpper.Contains(txtSearch.Text.ToUpper) Then

                        bolOverrideChange = True
                        bolBookFound = True

                        lstAllBooks.SelectedIndex = i 'Highlight the selected book

                        Exit For

                    End If

                End If


            Next

            If bolBookFound = False Then MessageBox.Show("Unable to find previous book in search for: " & txtSearch.Text, "Book not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            txtSearch.Text = ""

        End If
    End Sub

    Private Sub btnSearchNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchNext.Click
        Dim bolBookFound As Boolean = False


        If Replace(txtSearch.Text, " ", "") <> "" Then

            For i = intCurrBook To lstAllBooks.Items.Count - 1

                If i > intCurrBook Then 'Try to find the next book

                    If lstAllBooks.Items.Item(i).ToString.ToUpper.Contains(txtSearch.Text.ToUpper) Then

                        bolOverrideChange = True
                        bolBookFound = True

                        lstAllBooks.SelectedIndex = i 'Highlight the selected book

                        Exit For

                    End If

                End If


            Next

            If bolBookFound = False Then MessageBox.Show("Unable to find next book in search for: " & txtSearch.Text, "Book not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            txtSearch.Text = ""

        End If
    End Sub

    Private Sub btnBarcodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcodeSearch.Click
        Dim bolBookFound As Boolean = False

        Dim strBarcode As String = Replace(txtSearch.Text, " ", "")

        If strBarcode <> "" Then

            If strBarcode.Length = 10 Then strBarcode = GetISBN13(strBarcode)

            For i = 0 To lstAllBooks.Items.Count - 1

                If Books(i) = (strBarcode & ".txt") Then

                    bolOverrideChange = True
                    bolBookFound = True

                    lstAllBooks.SelectedIndex = i 'Highlight the selected book

                    Exit For

                End If

            Next

            If bolBookFound = False Then MessageBox.Show("Unable to find book with barcode: " & txtSearch.Text, "Book barcode not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            txtSearch.Text = ""

        End If
    End Sub
End Class