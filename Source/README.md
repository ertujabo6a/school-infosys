# Introduction 
ICS Project 2024: "School Information System" 

# Phase 1
The application contains four sections:
1. Student
2. Activity
3. Subject
4. Evaluation

Each section allows the user to view the list of records in the corresponding table and manipulate them.
The names of the tables are the same as the names of the section. 
The set of attributes for each table is described here: https://github.com/nesfit/ICS/tree/master/Project
Please pay attention to the values in brackets, as they correspond to relations between different tables.
Examples of C# code for entity records (including indications of their relations) can be found here:  https://github.com/nesfit/ICS/tree/master/src/CookBook/CookBook.DAL/Entities 

Functionality of Student section:
* Showing the list of all students
* CRUD (Create, Read, Update, and Delete) operations
* Searching by attributes
* Sorting by attributes in the list

Functionality of Activity section:
* Showing the list of all activities
* CRUD (Create, Read, Update, and Delete) operations
* Filtering by start time, end time, and chosen subject
* Sorting by attributes in the list

Functionality of Subject section:
* Showing the list of all subjects
* CRUD (Create, Read, Update, and Delete) operations
* Searching by attributes
* Sorting by attributes in the list

Functionality of Evaluation section:
* Showing the list of all evaluations
* CRUD (Create, Read, Update, and Delete) operations
* Sorting by attributes in the list

TODO: Wireframes for each section: deadline is 13.03 in the evening

TODO: C# entity records for each entity: deadline is 15.03 in the evening

TODO: DBContext of the whole system, InitialMigration, and ERD: deadline is 16.03 in the evening

WARNING: We don't have different types of users and login system anymore, so the wireframes must contain the list of sections and the content of the chosen section only.