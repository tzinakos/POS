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
![Class Diagram](/Images/Class Diagram.png)


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
![Sprint2 Kanban Board at the End](/Images/KanbanBoard-Sprint2_End.png)

#### Sprint Review

In the second Sprint I managed to complete user stories from sprint one, added functionality so that new users can update their password, Created "Order", "ProductCategory, "Product", and "Allergen" tables in the database, and update GUI for displaying products by category.


#### Sprint Retrospective

In terms of time management sprint 2 was better than sprint 1. I managed to complete a lot of user stories. However, since the user stories were many and the time little, the quality was not as good as aimed. In this sprint I used Timeboxing which helped me with time management. 

In this Sprint I learned how to create horizontal listbox views. Moreover, I learned how to add style and event handlers to generated ListBoxItems in my listbox

Next Time I would like to take less user stories and upscale the quality of my work.
### <u>Sprint 3</u>

#### Kanban Board at the beginning

![Sprint3 Kanban Board at the beginning](/Images/KanbanBoard-Sprint3_Beginning.png)

#### Sprint Goals

For The Third Sprint I aim to create CRUD methods for tables "ProductCategories", "Producs", "Allergens", "Orders". Moreover by the end of the sprint i need to have several test cases testing the above CRUD methods. Finally I need to extend the application's GUI functionality  to be able to display products and Products details with any allergen associated with it.

More Specific I need to:

- [x] Complete User Story 4.3 : Display products and its details to GUI 
- [x] Complete User Story 4.4 : Display, associated to products, allergens
- [x] Complete User Story 4.6 : Create CRUD Methods for tables "ProductCategories", "Producs", "Allergens", "Orders"
- [x] Complete User Story 4.7 : Create NUnit Tests for the above CRUD methods.

#### Kanban Board at the end
![Sprint3 Kanban Board at the end](/Images/KanbanBoard-Sprint3_End.png)
#### Sprint Review

In this Sprint I managed to complete all the sprint's user stories. More Specifically, I added CRUD methods for "Product", "Product Category", "Allergen" tables. Moreover, I created several Testcases for each one of those crud methods and finally I updated the GUI so that it can display products and their details. 

#### Sprint Retrospective

This sprint was better than the previous ones in terms of time and work management. After struggling a wile with "MouseRightButtonDown" mousebutton event handler on ListBoxItems, I found out that you can not implement that event handler on ListboxItems because WPF handles them internally so that it avoids bubbling; Hence, I needed to come around that problem and change my GUI design and functionality to meet the new implementation. 

### Sprint 4

#### Kanban Board at the beginning
![Sprint4 Kanban Board at the beginning](/Images/KanbanBoard-Sprint4_Beginning.png)
#### Sprint Goals

By The end of Sprint 4 I aim to add functionality to the application so that users can add products to their order, and then send the order to the "restaurants printers" in this case save it to a text file. Moreover, I need to make sure that each printer gets relevant products from the order; For example, the Sheff will get products related to food and bartenders, products related to drinks.

In general I aim to complete:

- [x] User Story 4.3 part 2
- [x] User Story 4.1
- [x] User Story 4.8
- [x] User Story 5.1
- [x] User Story 5.2

#### Kanban Board at the end
![Sprint4 Kanban Board at the end](/Images/KanbanBoard-Sprint4_End.png)

#### Sprint Review

In This Sprint I managed to achieve all the sprints goals, where users can create new orders and add products to the orders and at the end send the order to the printers.

#### Sprint Retrospective

In this sprint I had a blocker as I had to change the design of the database. More specific I had to add a many to many relationship between the tables: "Orders" and "Products" through a junction table called "OrdersProducts". However, now, I've become more experienced and familiar with database designs and Entity Framework.

By the end of this sprint I learned how to generate and populate Grids through C# Code and add them to a listbox.

### Sprint 5
#### Kanban Board at the beginning
![Sprint4 Kanban Board at the beginning](/Images/KanbanBoard-Sprint5_Beginning.png)
#### Sprint Goals

This Sprint is the final one; Thus, I aim to complete all remaining user stories and if I have the time to refactor my code and implement some minor design features. More Specific I need to complete User Stories:

- [ ] Complete User Story 6.1
- [ ] Complete User Story 6.2

#### Kanban Board at the end
#### Sprint Review
#### Sprint Retrospective