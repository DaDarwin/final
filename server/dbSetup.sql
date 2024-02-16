-- Active: 1707325572436@@SG-sandy-boii-db-8111-mysql-master.servers.mongodirector.com@3306@sand
CREATE TABLE IF NOT EXISTS accounts (
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(1000) COMMENT 'User Picture',
  Bio VARCHAR(2000) COMMENT 'User Bio',
  CoverImg varchar(1000) COMMENT 'User CoverImg',
  GitHub VARCHAR(255) COMMENT 'User GitHub',
  LinkedIn VARCHAR(255) COMMENT 'User LinkedIn'
) default charset utf8 COMMENT '';

CREATE TABLE keeps (
  id int AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  creatorID VARCHAR(255) NOT NULL,
  views INT NOT NULL DEFAULT 0,
  FOREIGN KEY (creatorID) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE vaults (
  id int AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  creatorID VARCHAR(255) NOT NULL,
  IsPrivate BOOLEAN NOT NULL DEFAULT false,
  FOREIGN KEY (creatorID) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE vaultKeeps (
  id int AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  keepId int NOT NULL,
  vaultId int NOT NULL,
  creatorID VARCHAR(255) NOT NULL,
  FOREIGN KEY (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
  FOREIGN KEY (creatorID) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO
  keeps (name, description, img, creatorId)
VALUES
  (
    'name',
    'description',
    'img',
    '65835d5f80d80bc692d5d8ed'
  );

SELECT
  keeps.*,
  COUNT(vaultKeeps.id) as kept,
  accounts.*
FROM
  keeps
  JOIN accounts ON accounts.id = keeps.creatorId
  LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
WHERE
  keeps.id = 1
GROUP BY
  (keeps.id);