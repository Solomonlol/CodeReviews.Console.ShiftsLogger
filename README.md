# Shift Logger

This application consists of interacting server-side (backend) and client-side (frontend) components. The client-side provides an interface for selecting options, while the server-side handles the database and provides an API for data exchange with the client.

Upon launching the application, the user will see three options:

<img width="319" height="174" alt="image" src="https://github.com/user-attachments/assets/ca958d78-99e0-4ff3-83f9-900de7d8c37a" />

## 1) Employee management
   This menu item allows the user to view a list of all employees or the details of a specific employee (by ID), as well as to create, update, and delete employee records.
   
   <img width="296" height="248" alt="image" src="https://github.com/user-attachments/assets/13393129-3bc9-4c25-bd0f-0af3fc4a5e1f" />

   
  ### Create:
   
   The user enters the required data; if the data is valid, a new employee is created. Otherwise, an error message is displayed.
   
   <img width="504" height="153" alt="image" src="https://github.com/user-attachments/assets/bd7887ca-135c-4d5d-be9c-0e9c6a1e4b49" />
   <img width="1149" height="161" alt="image" src="https://github.com/user-attachments/assets/2598eb3b-6036-4239-93b5-74c89c5a3ef0" />

  ### Update:
   The user must enter the employee's personnel number and, if it is valid, select the parameters for updating. If the entered data is correct, the employee's information will be updated; otherwise, an error message will be displayed.

   <img width="657" height="234" alt="image" src="https://github.com/user-attachments/assets/68bae697-ab2b-4243-8efb-d26eca6e39b1" />
   <img width="838" height="226" alt="image" src="https://github.com/user-attachments/assets/78f1baaf-23af-482a-9514-8d48f8b298d4" />

 ### Delete: 
  The user must enter the employee number; if the number is entered correctly and an employee with that number exists, that employee will be deleted from the database.

## 2)Shifts
  This menu item contains:
  
  <img width="385" height="258" alt="image" src="https://github.com/user-attachments/assets/c3d94ab0-b54c-414f-b1ae-5e943d7232ba" />

 ### View all: 
 Displaying all shift records in the database.
 ### View all current: 
 Only current (incomplete) shifts are displayed.
 ### View current by employee: 
 Display of the current shift based on the employee's personnel number.
 ### View all by employee: 
 Display of all shifts for the employee with the entered number.

 ### Start shift: 
 Create a new shift for the employee. If the employee already has a shift, display an error message.
 ### End shift:
 Close the employee's current shift. If the employee does not have an open shift, display an error message.

  
  <img width="512" height="166" alt="image" src="https://github.com/user-attachments/assets/cb3f5c18-931c-4a6e-a027-c12125a55605" />
  <img width="1322" height="240" alt="image" src="https://github.com/user-attachments/assets/5968c688-b9b3-4c6e-b68a-e5b947e32aa5" />

<img width="1501" height="241" alt="image" src="https://github.com/user-attachments/assets/d9d6f89d-0e66-430f-b426-75356c558f74" />
<img width="1344" height="214" alt="image" src="https://github.com/user-attachments/assets/2d3f080c-0596-46d4-858b-f8bf93fd9642" />
<img width="1370" height="259" alt="image" src="https://github.com/user-attachments/assets/428e07cf-9a8f-4f18-bf3c-029479a85bf7" />

<img width="500" height="64" alt="image" src="https://github.com/user-attachments/assets/d1cca308-b28c-4c86-abd8-aba6acb0ad8e" />
<img width="1504" height="231" alt="image" src="https://github.com/user-attachments/assets/eb451fa5-922c-4243-8622-3d2d5cb2ff6e" />

## Exit
This option closes the application.
