/*I assumed that the database contains the tables "Product", "Category" and "Product_Category" 
  which links the first two tables together.
  Below is the code that creates these tables and fills them with test data.
  And after that my solution for this case.
 */
 
CREATE TABLE Product
(
    productId int IDENTITY (1,1) PRIMARY KEY,
    name      varchar(100)
);

INSERT INTO Product(name) VALUES ('Chair');
INSERT INTO Product(name) VALUES ('Cup');
INSERT INTO Product(name) VALUES ('Hat');

CREATE TABLE Category
(
    categoryId int IDENTITY (1,1) PRIMARY KEY,
    name varchar(100)
);

INSERT INTO Category(name) VALUES ('household products');
INSERT INTO Category(name) VALUES ('dishes');

CREATE TABLE Product_Category
(
    productId int not null,
    categoryId int not null,
    PRIMARY KEY (productId, categoryId)
)

INSERT INTO Product_Category(productId, categoryId) VALUES (1,1);
INSERT INTO Product_Category(productId, categoryId) VALUES (2,1);
INSERT INTO Product_Category(productId, categoryId) VALUES (2,2);


-- Solution --
SELECT p.name, c.name
FROM Product p
         LEFT JOIN Product_Category ON Product_Category.productId = p.productId
         LEFT JOIN Category c ON c.categoryId = Product_Category.categoryId