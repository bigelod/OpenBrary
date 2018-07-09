Public Class frmSignInOut
    Dim intStage As Integer
    Dim strBook As String = ""
    Private Sub frmSignInOut_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtInput.Focus()
        intStage = 0
    End Sub

    Private Sub txtInput_LostFocus(sender As Object, e As System.EventArgs) Handles txtInput.LostFocus
        If txtInput.Enabled Then
            txtInput.Focus()
        End If
    End Sub

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        Dim strText As String
        Dim bolAddedBook As Boolean = False

        If txtInput.Text = "" Then
            MessageBox.Show("Please enter a barcode.", "No barcode entered", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        strText = txtInput.Text

        Select Case intStage
            Case 0 'Book barcode

                If strText.Length = 10 Then strText = GetISBN13(strText)

                strBook = strText

                Try
                    Dim bolAllowed = False

                    If LoadBook(strText) = True Then 'Is the book in our database? Load it if so
                        bolAllowed = True
                    End If

                    If bolAllowed = True Then
                        lblInstructions.Text = "Scan or enter student barcode."
                        intStage += 1
                        txtInput.Text = ""
                    Else
                        If MessageBox.Show("Book is not in database, would you like to add it?", "Book not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            intBooks += 1 'If the book isn't in the database then add it
                            Books(intBooks) = strText
                            SaveBook(strText, "New Book", "New", "Author")

                            LoadData(strDBPath) 'Reload the database now that a book has been added

                            bolAddedBook = True

                            frmBooks.Show()
                            frmBooks.BringToFront()
                            Me.Enabled = False
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("An error has occured, please try again.", "Error scanning book", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case 1 'Student barcode
                Try
                    Dim bolAllowed = False
                    Dim intInOut As Integer

                    If LoadStudent(strText) = True Then 'Check if the student exists and load their data
                        bolAllowed = True
                    End If

                    If bolAllowed = True Then 'If we have a real student
                        txtInput.Text = ""
                        lblInstructions.Text = ""

                        Dim strBooksOut() As String = Split(strCurrStudent(3), ";")

                        For i = 0 To strBooksOut.Count - 1 'See if they already have the book
                            If strBooksOut(i) = strBook Then intInOut = 1
                        Next

                        If intInOut = 0 Then 'If they don't then add it

                            If strCurrStudent(3) = "0;" Then strCurrStudent(3) = "" 'Wipe any 0 vals

                            strCurrStudent(3) &= strBook & ";"

                        Else 'Otherwise remove it from their currently signed out books list

                            strCurrStudent(3) = ""

                            For i = 0 To strBooksOut.Count - 1
                                If strBooksOut(i) <> strBook Then strCurrStudent(3) &= strBooksOut(i) & ";"
                            Next

                            If strCurrStudent(3) = ";" Then strCurrStudent(3) = "0;" 'Replace the 0 val when no books are out
                            If strCurrStudent(3) = "" Then strCurrStudent(3) = "0;" 'Replace the 0 val when no books are out

                        End If

                        Select Case intInOut 'Message if the book has been signed in or out
                            Case 0
                                If bolAddedBook = False Then
                                    txtInput.Text = strCurrBook(1) & " signed out to " & strCurrStudent(1) & ", " & strCurrStudent(2)
                                Else
                                    txtInput.Text = strCurrBook(1) & " signed out to " & strCurrStudent(1) & ", " & strCurrStudent(2)
                                End If

                            Case 1
                                If bolAddedBook = False Then
                                    txtInput.Text = strCurrBook(1) & " signed in by " & strCurrStudent(1) & ", " & strCurrStudent(2)
                                Else
                                    txtInput.Text = "Book signed in by " & strCurrStudent(1) & ", " & strCurrStudent(2)
                                End If
                        End Select

                        SaveStudent(strCurrStudent(0), strCurrStudent(1), strCurrStudent(2), strCurrStudent(3)) 'Save the updated profile

                        txtInput.Enabled = False

                        If frmBooks.Visible = True Then frmBooks.ReloadData()
                        If frmStudents.Visible = True Then frmStudents.ReloadData()

                        btnNext.Text = "Ok"
                        intStage += 1
                    Else
                        If MessageBox.Show("Student is not in database, would you like to add them?", "Student not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            intStudents += 1 'If they don't exist, add them to the database when the user says Yes
                            Students(intBooks) = strText
                            SaveStudent(strText, "New", "Student")

                            LoadData(strDBPath) 'Reload the database now that a student has been added

                            frmStudents.Show()
                            frmStudents.BringToFront()
                            Me.Enabled = False
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("An error has occured, please try again.", "Error scanning student", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Case 2 'Done
                Me.Close()
        End Select
    End Sub
End Class