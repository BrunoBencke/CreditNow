--Listar todos os clientes do estado de SP que possuem mais de 60% das parcelas pagas:

SELECT c.Nome, c.CPF, COUNT(p.ID) AS ParcelasPagas, COUNT(p.ID) * 100.0 / COUNT(*) AS PorcentagemPagas
FROM Clientes c
JOIN Financiamentos f ON c.CPF = f.CPF
JOIN Parcelas p ON f.ID = p.IdFinanciamento
WHERE c.UF = 'SP' AND p.DataPagamento IS NOT NULL
GROUP BY c.Nome, c.CPF
HAVING COUNT(p.ID) * 100.0 / COUNT(*) > 60.0;

--Listar os primeiros quatro clientes que possuem alguma parcela com mais de cinco dias sem atraso (Data Vencimento maior que data atual E Data Pagamento nula):

SELECT TOP 4 c.Nome, c.CPF
FROM Clientes c
JOIN Financiamentos f ON c.CPF = f.CPF
JOIN Parcelas p ON f.ID = p.IdFinanciamento
WHERE p.DataVencimento > GETDATE() AND p.DataPagamento IS NULL;