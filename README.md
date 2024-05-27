# Prerequisites
<ul>
 <li>Visual Studio 2022 or Higher</li>
 <li>ASP.NET Web Development</li>
 <li>MSSQL</li>
</ul>

# Steps to setup the project
1. On opening the project, open the <b>Package Manager Console</b>.
2. The database is backed up inside the migrations folder. Please write and run the following in Package Manager Console: <b>database-update</b>
   This will create the database inside of MSSQL
3. Run the project and create an account on the website.
   This will insert a row (an account) in the <b>AspNetUsers</b> table.
5. Open MSSQL and navigate to the <b>AspNetRoles</b> table and insert the following row:<br>
   <b>ID | Name | NormalizedName</b><br>
   1  | Administrator | ADMINISTRATOR
6. Navigate to <b>AspNetUsers</b> and copy the user id (column <b>'Id'</b>)
7. Navigate to <b>AspNetUserRoles</b> and insert the USERID and the ROLEID
8. Reload the project
9. Admin user is setup!
10. You should now have admin privileges.

## Setup the category and subcategory for products
1. In MSSQL navigate to table <b>Category (Kategorija)</b>
2. Insert desired category (ex. PC | Laptop | Monitors | ETC..
3. Insert desired subcategory (CategoryIDFK please link it with CategoryID) (ex. Component | Laptop Parts | LCD | ETC..

*DISCLAIMER - This part should have been integrated in the website project and not tinkered via. MSSSQL

<b>You can explore the project from here</b>

# Project info
## Admin
1. View all orders
2. Approve or dissaprove orders
3. CRUD on all products (There is no hard delete on products, they get flagged as Active/Inactive)
4. CRUD on all accounts and assign roles to other accounts
5. Approve or dissaprove customer complaints (With sending an e-mail to the customer)

## User
1. Order a product
2. Recieve an e-mail upon Admin approve
3. Search for products
4. Filter products (This part is not finished)

For more details please go to the project showcase on my portfolio<br>
Link: https://branislavzivanovic.github.io/electronicsstore.html
