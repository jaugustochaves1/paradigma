DECLARE @Pessoa TABLE
(
     Id int,
     Nome VARCHAR(MAX),
     Salario NUMERIC,
     DeptId INT
);

DECLARE @Departamento TABLE
(
     Id int,
     Nome VARCHAR(MAX)
);

INSERT INTO @Pessoa VALUES
(1, 'Joe', 70000, 1),
(2, 'Henry', 80000,2),
(3, 'Sam', 60000,2),
(4,'Max', 90000, 1);

INSERT INTO @Departamento VALUES
(1,'TI'),
(2, 'Vendas');


SELECT

    d.[Nome] AS "Departamento",
    p.[Nome] AS "Pessoa",
    p.Salario AS "Salário"

FROM @Pessoa p
INNER JOIN @Departamento d ON d.[Id] = p.[DeptId]
WHERE p.[Salario] IN (SELECT max(p.[Salario]) 
                      FROM @Pessoa p 
                      GROUP BY p.[DeptID]);