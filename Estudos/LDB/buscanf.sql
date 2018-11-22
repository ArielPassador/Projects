SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_BuscarNf] 
	@numeroNota INT = 0, 
	@numeroRps INT = 0, 
	@serie NVARCHAR(10) = NULL, 
	@nomeCliente NVARCHAR(200) = NULL,
	@IdFilial INT = 0,
	@emissao DATETIME = NULL,
	@cadastro DATETIME = NULL,
	@situacao INT = 0
	
	
AS 
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @sql NVARCHAR(4000);
	
	SET @sql = 'SELECT 
	NFS.IdNotaFiscalServico AS numeroControle,
	NFS.NumeroNf AS numeroNota,
	NFS.NumeroRps AS numeroRps,
	NFS.SerieRps AS serie,
	CLI.NomeFantasia AS clienteNome,
	NFS.SituacaoNota AS situacao,
	NFS.DataEmissao AS Emissao,
	inf.DataCadastro AS Cadastro,
	nfs.ValorServicos as valorNf,
	nfs.ValorLiquidoNfse as valorLiquidoNf,
	nfs.url_pdf,
	(select top(1) ag.TipoOS from nota_fiscal_servico_agrupamentos as nf inner join agrupamento_ordem_servicos as ag 
	on nf.agrupamento_id = ag.idAgrupamentoOS
	where nf.nota_fiscal_servico_id = nfs.IdNotaFiscalServico ) as TipoOS
	FROM NOTA_FISCAL_SERVICOS NFS (NOLOCK)
	INNER JOIN nota_fiscal_informacoes INF (NOLOCK)
	ON NFS.IdNotaFiscalServico = INF.IdNotaFiscalFk
	INNER JOIN CLIENTES CLI (NOLOCK)
	ON nfs.cliente_id = CLI.IdCliente
	WHERE nfs.SituacaoNota IS NOT NULL '
	
	IF @idFilial > 0
    	SET @sql +=  ' AND nfs.filial_id =' + CONVERT(VARCHAR,@idFilial);
		
	IF @numeroNota > 0
    	SET @sql +=  ' AND NFS.NumeroNf =' + CONVERT(VARCHAR,@numeroNota);
		
	IF @numeroRps > 0
    	SET @sql +=  ' AND nfs.NumeroRps =' + CONVERT(VARCHAR,@numeroRps);
	
	IF @situacao > 0
    	SET @sql +=  ' AND nfs.SituacaoNota =' + CONVERT(VARCHAR,@situacao);
	
	IF @serie > 0
		SET @sql +=  ' AND nfs.SerieRps = ''' + CONVERT(VARCHAR,@serie) + ''' ';
	
	IF LEN(CONVERT(VARCHAR,@nomeCliente)) > 0
		SET @sql +=  ' AND CLI.RazaoSocial LIKE ''%' + CONVERT(VARCHAR,@nomeCliente) + '%'' ';
	
	IF LEN(CONVERT(VARCHAR,@emissao)) > 0
		SET @sql += ' AND nfs.DataEmissao BETWEEN ''' + CONVERT(CHAR(10),@emissao, 103) + ' 00:00:00' + ''' AND ''' + CONVERT(CHAR(10),@emissao, 103) + ' 23:59:59'' ';
	
	IF LEN(CONVERT(VARCHAR,@cadastro)) > 0
		SET @sql += ' AND INF.DataCadastro BETWEEN ''' + CONVERT(CHAR(10),@cadastro, 103) + ' 00:00:00' + ''' AND ''' + CONVERT(CHAR(10),@cadastro, 103) + ' 23:59:59'' ';
	
	SET @sql += ' ORDER BY INF.DataCadastro DESC;';
		
	exec sp_executesql @sql;
	
END;

GO
