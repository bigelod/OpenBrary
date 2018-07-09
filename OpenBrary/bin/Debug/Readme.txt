LibraryCard v1.0 - Copyright (C) 2012 - 2013 Daven Bigelow (452Soft)
"A digital library card system designed for schools"
E-mail: davenbigelow92@yahoo.co.uk
----------------------------------
To start LibraryCard
----------------------------------
1.) Copy and paste LibraryCard folder onto the target computer

2.) Run LibraryCard.exe

----------------------------------
If the program fails to start
----------------------------------
1.)Install the following "Required Files" for the target computer
The .NET 4.0 framework
The Visual C++ Redistributable

32bit (x86) computer:
dotNetFx40_Full_x86_x64.exe
vcredist_x86.exe

64bit (x64) computer:
dotNetFx40_Full_x86_x64.exe
vcredist_x64.exe

2.) If using Windows Vista or Windows 7, right click LibraryCard.exe and click "Run as administrator"

3.) If further issues occur, e-mail davenbigelow92@yahoo.co.uk

----------------------------------
Adding students
----------------------------------
1.) On the main menu screen click "Student Database" to bring up the student database editor with a list of students in the database and showing how many books each student is currently borrowing

2.) Click the "Add" button to add a new student. An input box will appear to enter the barcode.

3.) The new student will show in the list of all students. Click the student in the list to begin editing their name

4.) Click the "Save" button to save changes made

5.) Double click a book in the Books Out list to bring it up in the book database editor. This editor must be closed before the student database editor will be enabled again. If the book editor does not appear then it is waiting for the current student editor to be saved and closed first

6.) To delete a student, select it from the list and click the "Delete" button

Click the barcode text to copy it to the clipboard, where it can be pasted by right clicking and selecting "Paste" from the context menu, or pressing the keyboard keys CTRL and V at once.

----------------------------------
Adding books
----------------------------------
1.) On the main menu screen click "Book Database" to bring up the book database editor with the list of books in the database and showing how many copies are currently being borrowed of each book

2.) There are two ways to add books, either by hand or attempting to download the correct information online.

a. Click the "Auto Add Book" button to attempt downloading the book information and cover online. An input box will appear to enter the barcode (NOTE: This barcode can not be changed from the software once saved!). The program will report either that it could not find the book, or the information it found for that barcode, you can click "Yes" to add the book to the library, or "No" to cancel. If the book already exists, you will be prompted to ask whether or not to overwrite/update the existing file and cover files.

b. Click the "Manually Add Book" button to add a new book by hand. An input box will appear to enter the barcode (NOTE: This barcode can not be changed from the software once saved!). This method will not let you overwrite an existing book, and will require you to manually edit the information.

3.) The new book will show up in the list of all books. Click the book in the list at any time to begin editing its title and author name

4.) To change a book cover, click "Import Cover" and find the JPEG (.jpg) file for the cover image and click "Open". This will copy the file to the "Covers" folder in the database. Double clicking the cover image inside the application will bring the database version up in your normal picture viewer/editor.

5.) Click the "Save" button to save changes made

6.) Double click a student in the Borrowed To list to bring them up in the student database editor. This editor must be closed before the student database editor will be enabled again. If the student editor does not appear then it is waiting for the current book editor to be saved and closed first

7.) To delete a book, click "Delete" (NOTE: This will permanently delete the book), this will automatically sign the book out for all students who currently have a copy

Click the barcode text to copy it to the clipboard, where it can be pasted by right clicking and selecting "Paste" from the context menu, or pressing the keyboard keys CTRL and V at once.

----------------------------------
Signing in/out books
----------------------------------
1.) On the main menu screen click "Sign In/Out Book" to bring up the input window. This may give a prompt if a Student or Book editor is waiting on the other to save and close

2.) Scan or type the barcode of the book and click "Next"

3.) Scan or type the barcode of the student and click "Next"

4.) The software will automatically detect if the book is being signed in to the library or out to the student. Click the exit button on this window to return to the main program

If a barcode is not in the database already, the software will give a prompt asking whether or not to add the book/student to the database. Clicking "Yes" will automatically bring up the editor for the new book/student, and this new window must be closed before the "Sign In/Out" window becomes active again

----------------------------------
Changing the database
----------------------------------
LibraryCard allows for easy database editing by storing data in a text file/folder database. Here are the instructions to start using another database directory:

1.) On the main menu screen click "Change Database", if you have other editors open then it will let you choose to close them or cancel the database change

2.) On the folder browser that appears, navigate to the new database folder you would like to use (eg: over a network share). You can also create a new folder and choose that for the new database

The subfolders "Books", "Covers" and "Students" will be created within the new directory automatically

----------------------------------
Further support & information
----------------------------------
E-mail davenbigelow92@yahoo.co.uk for any further support or information