CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key', createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created', updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update', name varchar(255) COMMENT 'User Name', email varchar(255) COMMENT 'User Email', picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

  id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL, quantity VARCHAR(100), recipeId INT NOT NULL, creatorId VARCHAR(255) NOT NULL, FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE
) default charset utf8mb4 COMMENT '';

CREATE TABLE favorites (
    id INT AUTO_INCREMENT PRIMARY KEY, accountId VARCHAR(255) NOT NULL, recipeId int NOT NULL, Foreign Key (accountId) REFERENCES accounts (id) ON DELETE CASCADE, Foreign Key (recipeId) REFERENCES recipes (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO
    recipes (
        title, instructions, img, category, creatorId
    )
VALUES (
        "Jeremy Juice", "You do not want to know....", "https://plus.unsplash.com/premium_photo-1675949335329-d42910909742?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDR8eGpQUjRobGtCR0F8fGVufDB8fHx8fA%3D%3D", "Specialty Coffee", "634844a08c9d1ba02348913d"
    )