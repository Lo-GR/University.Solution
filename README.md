# <div align="center"> **University Registrar** </div>
### This is a web application in order to track Courses, Instructors, and Students

 ### _Contributor(s) and Contact Info_
> Logan Roth diamondintheroth@gmail.com - [GitHub(Lo-GR)](https://github.com/Lo-GR)

> Glen Buck [GitHub](https://github.com/glenbuck503)

> Scott [GitHub](https://github.com/spnoneil)

> Connor Burgess [GitHub](https://github.com/ConnorBurgess)

---

## _Technologies Used_ ⚙

* **C# 9**
* **.NET 5.0.102**
* **SDK 8.0.19**
* **Razor**
* **Bootstrap 4.5**
* **HTML 5 (CS version)/CSS3**
* **My SQL 8.0.19/WorkBench 8.0.19**
* **Entity Framework**
* **HTML Helper**

## _Concepts Used_ 🧠

* **MVC**
* **RESTful Conventions**
* **CRUD Functionality**
* **Database Retrieval/Storage**
* **Many-To-Many Relationships**

---

## _Description_ 📃
This MVC webpage will present it's user with a splash screen and options to view Course, Instructor, or Student indexes. All CRUD functionality is present for both Course and Student data and options are presented in an explorable fashion on the webpage. 

This is a practice project for practicing C#, Razor, ASP .NET framework, Entity Framework, MySQl, Databases and MVC for a course at Epicodus.

---

## _Installation Guide_ 💻 

<details>
<summary>Open for full Guide</summary>

### _Cloning and Initial Setup_

> Repository: https://github.com/Lo-GR/University.Solution.git
1. In your terminal of choice or [GitHub's Desktop Application](https://desktop.github.com/) , clone the above repository from Github. For further explanation on how to clone this repository, please visit [GitHub's Documentation](https://docs.github.com/en/github/using-git/which-remote-url-should-i-use).
2. Ensure you are running .NET Core SDK by using the command dotnet --version in your terminal. If a version number is not presented, please visit [this download page for .NET 5 and install the applicable software for your OS](https://dotnet.microsoft.com/download/dotnet/5.0). 
3. Once you verify you are running a .NET 5, navigate in your terminal to University directory within the University.Solution directory you just cloned. Once there, run "dotnet build" in your terminal to build application within directory. 
4. In your terminal, while still in University directory, run "dotnet restore."
5. You will require a text or code editor to complete the following steps. [VS Code is recommended](https://code.visualstudio.com/)


### _Installation: Database Recreation_

1. Ensure you are running MySQL Server 8 and MySQL WorkBench 8. If you are running windows, use the [Windows Installer ](https://dev.mysql.com/downloads/installer/) for MySQL and follow the instructions provided by the installer. For Macs, visit [MySQL Commuinity Downloads](https://dev.mysql.com/downloads/mysql/) and select macOS from the Operation Systems. This will be a manual installation. If you need additonal assistance on this, please visit Epicodus's [Learn How to Program Article](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
2. Once you verify you have SQL installed, create a file called "appsettings.json" in the root directory University.Solution. Paste the following into this file.
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port={PORT OF SERVER};database=university;uid=root;pwd={PASSWORD OF SERVER};"
  }
}
```
3. In your terminal, run "dotnet ef database update"
### _Installation: General Use_

1. Back in your terminal in the University production directory, type "dotnet run." The terminal will present local host routes for you to navigate to in your browser. An example would be "http://localhost:5000." Enter this into a web browser of choice to use this application. Keep the terminal running as it is being used to control the local server.
2. When finished, exit the terminal or use the command "CTRL C"(Windows) or "CMD C"(Mac) to shut down the local server.

</details>

---

## _Known Bugs_ 🩹
* No known bugs at this time. Please contact a contributor to report any bugs found during use.

---

## _Future Updates_ 🛠
* Additional UI

---

## _Preplanning/Whiteboard Work_ 📋
```
Expectations___
1. As a registrar, I want to enter a student, so I can keep track of all students enrolled at this University. I should be able to provide a name and date of enrollment. CHECK!

2. As a registrar, I want to enter a course, so I can keep track of all of the courses the University offers. I should be able to provide a course name and a course number (ex. HIST100). SORTA CHECK! (no course number)

3. As a registrar, I want to be able to assign students to a course, so that teachers know which students are in their course. A course can have many students and a student can take many courses at the same time. CHECK!

If you make it this far, great job! If you have time, work on these other user stories.

Functionality___

1. Student Class:
  - Date of Enrollment Property
  - Name Property
  - Student Table to include:
    - StudentId
    - name
    - date_of_enrollment
    - CourseStudentId (If applicable)
2. Course Class:
  - Course Name Property
  - Course Number Property
  - Course Table to Include:
    - CourseId
    - name
    - course_number
    - CourseStudentId (if applicable)
3. Many to Many database 
  - Utilize Join table.
4. Join Entity
  - CourseStudent
    - CourseStudentId
    - CourseId
    - StudentId
```
---

## _License_ ⚖️

[![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2021, Logan Roth, Connor Burgess, Scott, Glen Buck.

Please contact Contributor for further use information or if you would like to make a contribution.