# POS 

## Project Description

The Application's purpose is to assist coffee shop's employees to manage both "sit-in" and "take-away" orders as well as table reservations. More specific, it will enable waiters to take orders from their tablet* and send the order ticket directly to the kitchen or bar. Managers, through the application, will be able to add or delete users as well as assign new roles to them. Moreover, they will be able to book reservations with a couple of touches. Sheff's and Bartenders will have the ease to change the availability of a product if that product is sold out.

\* *The tablet will be a Microsoft Surface running windows 10*

## Project Goals

* The Project has to be a 3 - Tier Application
    * It should include a Model Layer
    * It should include a Business Layer
    * It should include a GUI Layer
* The Project has to include a Test Layer where several testcases will ensure the good functionality of the application
* The project should include an SQL database with at least two linked tables.
* In the project should be used Entity Framework to manage the relationship between the Model and Business layer

* The Project should be easily tracked by git commits and implement a thorough and readable documentation.

* The project should comply with the project description

## Class Diagrams

## ERD

## Sprints

### <u>Sprint  1</u>

#### Kanban Board at the beginning

![Sprint1 Kanban Board at the beginning](/Images/KanbanBoard-Sprint1_Beginning.png)

#### Sprint Goals

For the First Sprint Goal I want to Create and Add some tables to my database. Those tables are: "User" , "UserRole", "Table", "TableStatus","Reservations". Moreover, I need to create CRUD Methods for "User" and "Table" tables. Additionally, I will create Test Cases for my crud methods and finally  GUI layer with adding, deleting and updating users as well as displaying tables, its details and being able to reserve a table.

More Specific I need to:

- [x] Complete User Story 1.1  
- [x] Complete User Story 1.2
- [x] Complete User Story 1.3
- [x] Complete User Story 1.4
- [x] Complete User Story 1.5
- [x] Complete User Story 1.6
- [x] Complete User Story 1.7
- [ ] Complete User Story 2.1
- [ ] Complete User Story 2.2
- [ ] Complete User Story 2.3
- [x] Complete User Story 2.4
- [x] Complete User Story 2.5
- [x] Complete User Story 2.6
- [ ] Complete User Story 2.7
- [ ] Complete User Story 2.8

#### Kanban Board at the end

![Sprint1 Kanban Board at the end](/Images/KanbanBoard-Sprint1_End.png)
#### Sprint Review

In this sprint I did not manage to complete all user stories. The user stories that I completed where 1.1 -> 1.7 and 2.4 -> 2.6.

More Specific I created the database, added  "User" , "UserRole", "Table", "TableStatus","Reservations" tables. Then I created my CRUD methods for the "User" and "Table" Tables, created test cases for my Users CRUD Methods and created a GUI where Users are displayed and users can add new users. Finally I set up the GUI skeleton for its next updates.

#### Sprint Retrospective

This sprint had a bigger workload than I thought. However, I managed to deal with a lot of it and prepared the ground for next sprint work. Next time I need to select my sprint backlog more carefully and do a better time management; Timeboxing for each user story is a good idea.

### <u>Sprint  2</u>

#### Kanban Board at the beginning

![Sprint2 Kanban Board at the beginning](/Images/KanbanBoard-Sprint2_Beginning.png)

#### Sprint Goals

By the end of the second sprint, I need to complete user stories from sprint one, the application must have functionality where new users can update their password, Create "Order", "ProductCategory, "Product", and "Allergen" tables in the database, update GUI for displaying products by category.

More Specific I need to:

- [x] Complete user Story 2.1
- [x] Complete user Story 2.2
- [x] Complete user Story 2.3
- [x] Complete user Story 2.7
- [x] Complete user Story 2.8
- [x] Complete user Story 3.1
- [x] Complete user Story 3.2
- [x] Complete user Story 4.2
- [x] Complete user Story 4.5
- [ ] Complete user Story 4.6


#### Kanban Board at the end
![Sprint2 Kanban Board at the beginning](/Images/KanbanBoard-Sprint2_End.png)

#### Sprint Review

In the second Sprint I managed to complete user stories from sprint one, added functionality so that new users can update their password, Created "Order", "ProductCategory, "Product", and "Allergen" tables in the database, and update GUI for displaying products by category.


#### Sprint Retrospective

In terms of time management sprint 2 was better than sprint 1. I managed to complete a lot of user stories. However, since the user stories were many and the time little, the quality was not as good as aimed. In this sprint I used Timeboxing which helped me with time management. 

In this Sprint I learned how to create horizontal listbox views. Moreover, I learned how to add style and event handlers to generated ListBoxItems in my listbox

Next Time I would like to take less user stories and upscale the quality of my work.