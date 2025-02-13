CREATE DATABASE aulaPOO;

USE aulaPOO;

CREATE TABLE Alunos(
id_alu INT PRIMARY KEY AUTO_INCREMENT,
nome_alu VARCHAR(50) NOT NULL,
email_alu VARCHAR(50) NOT NULL,
telefone_alu VARCHAR(100),
dataNascimento_alu DATE
);

SELECT * FROM Alunos;
