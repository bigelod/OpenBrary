Imports System.IO
Imports System.Console

Module GlobalDataFunc
    'Using a folder database for easier sharing between computers, or possible use on a central server

    Public strDBPath As String

    Public Students(9999999) As String 'All student barcodes
    Public intStudents As Integer

    Public Books(9999999) As String 'All book barcodes
    Public intBooks As Integer

    Public strCurrBook(3) As String 'Title, Last, First
    Public intCurrBook As Integer

    Public strCurrStudent(3) As String 'Last, First, Books
    Public intCurrStudent As Integer

    Public Sub LoadSettings()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\LCSettings.txt") Then
            Dim strFilePath As String

            strFilePath = Application.StartupPath & "\LCSettings.txt"

            Try
                ' Create an instance of StreamReader to read from a file. 
                Dim sr As StreamReader = New StreamReader(strFilePath)

                strDBPath = sr.ReadLine()

                If strDBPath = "APPDIR" Then strDBPath = ""

                sr.Close()

            Catch E As Exception
                ' Let the user know what went wrong.
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(E.Message)
            End Try
        End If
    End Sub

    Public Sub LoadData(Optional ByVal strPath As String = "")

        intStudents = 0
        intBooks = 0

        If strPath = "" Then strPath = Application.StartupPath & "\LCData\"

        Try 'If the directory doesn't exist, we can try to create it
            If Directory.Exists(strPath) = False Then
                My.Computer.FileSystem.CreateDirectory(strPath)
            End If
        Catch ex As Exception

        End Try

        Try 'Now to prepare the sub folders
            If Directory.Exists(strPath) Then

                If Directory.Exists(strPath & "\Books\") = False Then
                    My.Computer.FileSystem.CreateDirectory(strPath & "\Books\")
                End If

                If Directory.Exists(strPath & "\Covers\") = False Then
                    My.Computer.FileSystem.CreateDirectory(strPath & "\Covers\")
                End If

                If Directory.Exists(strPath & "\Students\") = False Then
                    My.Computer.FileSystem.CreateDirectory(strPath & "\Students\")
                End If

                Dim numStudents = My.Computer.FileSystem.GetFiles(strPath & "\Students\")
                Dim numBooks = My.Computer.FileSystem.GetFiles(strPath & "\Books\")

                intStudents = numStudents.Count - 1
                intBooks = numBooks.Count - 1

                'Load Students

                For i = 0 To intStudents

                    Students(i) = Path.GetFileName(numStudents(i))

                Next

                'Load Books

                For i = 0 To intBooks

                    Books(i) = Path.GetFileName(numBooks(i))

                Next

                strDBPath = strPath

            Else
                MessageBox.Show("Database not found. Please choose a folder", "No database found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        
    End Sub

    Public Function LoadBook(Optional ByVal strBarcode As String = "", Optional ByVal intIndex As Integer = 0)

        If strBarcode = "" Then 'Load next book file when searching

            Try
                ' Create an instance of StreamReader to read from a file. 
                Dim sr As StreamReader = New StreamReader(strDBPath & "\Books\" & Books(intIndex))

                strCurrBook(0) = Books(intIndex)

                strCurrBook(1) = sr.ReadLine()

                strCurrBook(2) = sr.ReadLine()

                strCurrBook(3) = sr.ReadLine()

                sr.Close()

            Catch E As Exception
                ' Let the user know what went wrong.
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(E.Message)
            End Try

            Return True


        ElseIf My.Computer.FileSystem.FileExists(strDBPath & "\Books\" & strBarcode & ".txt") Then 'If we know who to look for

            Try

                Dim sr As StreamReader = New StreamReader(strDBPath & "\Books\" & strBarcode & ".txt")

                strCurrBook(0) = strBarcode

                strCurrBook(1) = sr.ReadLine()

                strCurrBook(2) = sr.ReadLine()

                strCurrBook(3) = sr.ReadLine()

                sr.Close()

                Return True
            Catch ex As Exception
                Return False
            End Try

        End If

        Return False

    End Function

    Public Function LoadStudent(Optional ByVal strBarcode As String = "", Optional ByVal intIndex As Integer = 0)

        If strBarcode = "" Then 'Load next student file when searching

            Try
                ' Create an instance of StreamReader to read from a file. 
                Dim sr As StreamReader = New StreamReader(strDBPath & "\Students\" & Students(intIndex))

                strCurrStudent(0) = Mid(Students(intIndex), 1, Students(intIndex).Length - 4)

                strCurrStudent(1) = sr.ReadLine()

                strCurrStudent(2) = sr.ReadLine()

                strCurrStudent(3) = sr.ReadLine()

                sr.Close()

            Catch E As Exception
                ' Let the user know what went wrong.
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(E.Message)
            End Try

            Return True

        ElseIf My.Computer.FileSystem.FileExists(strDBPath & "\Students\" & strBarcode & ".txt") Then 'If we know who to look for
            Try

                Dim sr As StreamReader = New StreamReader(strDBPath & "\Students\" & strBarcode & ".txt")

                strCurrStudent(0) = strBarcode

                strCurrStudent(1) = sr.ReadLine()

                strCurrStudent(2) = sr.ReadLine()

                strCurrStudent(3) = sr.ReadLine()

                sr.Close()

                Return True
            Catch ex As Exception
                ' Let the user know what went wrong.
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(ex.Message)

                Return False
            End Try
        End If

        Return False

    End Function

    Public Sub SaveBook(ByVal strBarcode As String, Optional ByVal strTitle As String = "", Optional ByVal strLastName As String = "", Optional ByVal strFirstName As String = "")
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(strDBPath & "\Books\" & strBarcode & ".txt", False)
        'Simple code to overwrite the file
        file.WriteLine(strTitle)
        file.WriteLine(strLastName)
        file.WriteLine(strFirstName)

        file.Close()
    End Sub

    Public Sub SaveStudent(ByVal strBarcode As String, Optional ByVal strLastName As String = "", Optional ByVal strFirstName As String = "", Optional ByVal strBooksOut As String = "0;")
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(strDBPath & "\Students\" & strBarcode & ".txt", False)
        'Simple code to overwrite the file
        file.WriteLine(strLastName)
        file.WriteLine(strFirstName)
        file.WriteLine(strBooksOut)

        file.Close()
    End Sub

    Public Function GetISBN13(ByVal ISBN As String)
        Dim newISBN As String = "978" + Mid(ISBN, 1, 9)

        Dim intTotalCheck As Integer = 0
        Dim intFlip As Integer = 1

        Dim intNum As Integer

        For i = 1 To 12

            intNum = Int(Mid(newISBN, i, 1))

            If intFlip = 1 Then
                intTotalCheck += intNum * 1
            Else
                intTotalCheck += intNum * 3
            End If

            intFlip *= -1
        Next

        Dim modAns As Integer = intTotalCheck Mod 10

        Dim checkDigit As Integer

        If modAns = 0 Then
            checkDigit = 0
        Else
            checkDigit = 10 - modAns
        End If

        newISBN &= checkDigit

        Return newISBN

    End Function
End Module
