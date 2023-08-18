-- Active: 1692119137939@@SG-LilDew-MySQL-7784-mysql-master.servers.mongodirector.com@3306@student

CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE
recipes(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL,
  instructions VARCHAR(750) NOT NULL,
  img VARCHAR(700) NOT NULL,
  category VARCHAR(550) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE
ingredients(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  quantity VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY(recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

CREATE TABLE
favorites
(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update', 
  recipeId INT NOT NULL,
  accountId VARCHAR(255)NOT NULL,
  FOREIGN KEY(recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
  FOREIGN KEY(accountId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';



DROP TABLE recipes;

DROP TABLE ingredients;

DROP TABLE favorites


INSERT INTO recipes (title, instructions, img, category, creatorId )
VALUES ('french toast', 'Dip in egg, cin and milk then fry','https://images.unsplash.com/photo-1595044643502-616eeebbdff3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1740&q=80','breakfast', '64c49aff4205aa3b679342ad');

INSERT INTO ingredients(name, quantity, recipeId, creatorId)
VALUES('Toast', 'One Toast', 1, '64c49aff4205aa3b679342ad')

SELECT * ingredients WHERE id = 1;

INSERT INTO favorites(recipeId, accountId)
VALUES('1', '64c49aff4205aa3b679342ad')