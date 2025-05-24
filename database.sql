CREATE DATABASE cadastro_clientes;
USE cadastro_clientes;

CREATE TABLE Clientes (
    IdClientes INT PRIMARY KEY,
    Nome VARCHAR(100),
    Endereco VARCHAR(200),
    Telefone VARCHAR(20)
);
