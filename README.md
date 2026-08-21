# Shift Logger

This application contains backend and fronend that works together. Frontend side show UI to navigate options. Backend works with database and give API to frontend application to communicate.

When app is started user will see 3 options: 

<img width="319" height="174" alt="image" src="https://github.com/user-attachments/assets/ca958d78-99e0-4ff3-83f9-900de7d8c37a" />

## 1) Employee management
   This menu option give user options to view all employees, one by employee number, create, update and delete.
   
   <img width="296" height="248" alt="image" src="https://github.com/user-attachments/assets/13393129-3bc9-4c25-bd0f-0af3fc4a5e1f" />

   
  ### Create:
   
   User enter requared data, if its correct - new employee will be created. Otherwise it show error
   
   <img width="504" height="153" alt="image" src="https://github.com/user-attachments/assets/bd7887ca-135c-4d5d-be9c-0e9c6a1e4b49" />
   <img width="1149" height="161" alt="image" src="https://github.com/user-attachments/assets/2598eb3b-6036-4239-93b5-74c89c5a3ef0" />

  ### Update:
   User should enter employee number, and, if its correct, choose options to update. If entered data is correct, employee would be updated, otherwise its show error.

   <img width="657" height="234" alt="image" src="https://github.com/user-attachments/assets/68bae697-ab2b-4243-8efb-d26eca6e39b1" />
   <img width="838" height="226" alt="image" src="https://github.com/user-attachments/assets/78f1baaf-23af-482a-9514-8d48f8b298d4" />

 ### Delete: 
  User should enter employee number, if its correct and employee with this number is exist, this employee will be deleted from database.

## 2)Shifts
  This menu option contains:
  
  <img width="385" height="258" alt="image" src="https://github.com/user-attachments/assets/c3d94ab0-b54c-414f-b1ae-5e943d7232ba" />

 ### View all: 
 showing all shift records in database.
 ### View all current: 
 showing only current(not ended) shifts.
 ### View current by employee: 
 showing current shift by employee number.
 ### View all by employee: 
 showing all shifts that employee with entered number has have.

 ### Start shift: 
 Create new shift to employee. If employee already have one, show error message.
 ### End shift:
 Close current shift to employee. If employee not have one, show error message.

  
  <img width="512" height="166" alt="image" src="https://github.com/user-attachments/assets/cb3f5c18-931c-4a6e-a027-c12125a55605" />
  <img width="1322" height="240" alt="image" src="https://github.com/user-attachments/assets/5968c688-b9b3-4c6e-b68a-e5b947e32aa5" />

<img width="1501" height="241" alt="image" src="https://github.com/user-attachments/assets/d9d6f89d-0e66-430f-b426-75356c558f74" />
<img width="1344" height="214" alt="image" src="https://github.com/user-attachments/assets/2d3f080c-0596-46d4-858b-f8bf93fd9642" />
<img width="1370" height="259" alt="image" src="https://github.com/user-attachments/assets/428e07cf-9a8f-4f18-bf3c-029479a85bf7" />

<img width="500" height="64" alt="image" src="https://github.com/user-attachments/assets/d1cca308-b28c-4c86-abd8-aba6acb0ad8e" />
<img width="1504" height="231" alt="image" src="https://github.com/user-attachments/assets/eb451fa5-922c-4243-8622-3d2d5cb2ff6e" />

## Exit
This option close UI app.
