CREATE TABLE Clientes (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100),
    CPF VARCHAR(11) UNIQUE,
    UF VARCHAR(2),
    Celular VARCHAR(20)
);

CREATE TABLE Financiamentos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CPF VARCHAR(11),
    TipoFinanciamento VARCHAR(100),
    ValorTotal DECIMAL(10, 2),
    DataUltimoVencimento DATE,
    FOREIGN KEY (CPF) REFERENCES Clientes (CPF)
);

CREATE TABLE Parcelas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    IdFinanciamento INT,
    NumeroParcela INT,
    ValorParcela DECIMAL(10, 2),
    DataVencimento DATE,
    DataPagamento DATE,
    FOREIGN KEY (IdFinanciamento) REFERENCES Financiamentos (ID)
);

-- Inserindo clientes
INSERT INTO Clientes (Nome, CPF, UF, Celular)
VALUES ('João Silva', '12345678901', 'SP', '9999999999');

INSERT INTO Clientes (Nome, CPF, UF, Celular)
VALUES ('Maria Santos', '98765432101', 'RJ', '8888888888');

-- Inserindo financiamentos
INSERT INTO Financiamentos (CPF, TipoFinanciamento, ValorTotal, DataUltimoVencimento)
VALUES ('12345678901', 'Financiamento A', 5000.00, '2023-06-30');

INSERT INTO Financiamentos (CPF, TipoFinanciamento, ValorTotal, DataUltimoVencimento)
VALUES ('98765432101', 'Financiamento B', 10000.00, '2023-05-31');

-- Inserindo parcelas
INSERT INTO Parcelas (IdFinanciamento, NumeroParcela, ValorParcela, DataVencimento, DataPagamento)
VALUES (1, 1, 1000.00, '2023-01-31', '2023-01-30');

INSERT INTO Parcelas (IdFinanciamento, NumeroParcela, ValorParcela, DataVencimento, DataPagamento)
VALUES (1, 2, 1000.00, '2023-02-28', '2023-02-27');

INSERT INTO Parcelas (IdFinanciamento, NumeroParcela, ValorParcela, DataVencimento, DataPagamento)
VALUES (1, 3, 1000.00, '2023-03-31', '2023-03-30');

INSERT INTO Parcelas (IdFinanciamento, NumeroParcela, ValorParcela, DataVencimento, DataPagamento)
VALUES (2, 1, 2000.00, '2023-06-01', NULL);
