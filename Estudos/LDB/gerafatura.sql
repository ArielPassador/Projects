SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_GerarFaturamento]
	@IdsAgrupamento NVARCHAR(128),
	@user_id NVARCHAR(128)
AS
BEGIN
	DECLARE 
	@array VARCHAR(8000), 
	@delimitador VARCHAR(100), 
	@item VARCHAR(8000),  
	@sql NVARCHAR(4000),
	@valorTotalServ DECIMAL(10,2),
	@valorTotalServ_0 DECIMAL(10,2),
	@quantidadeTotal INT,
	@quantidadeTotal_0 INT,
	@id INT,
	@CONTPRECOS INT,
	@MyCursor CURSOR, -- Para loop de inserção no
	@Cursor CURSOR, -- Para loop de inserção no
	@ErrorMessage NVARCHAR(4000),
	@ErrorSeverity NVARCHAR(4000),
	@ErrorState NVARCHAR(4000),
	@filial INT,
	@cliente INT,
	@agrupamento INT,
	@servico INT,
	@preco INT,
	@ultimo_nf INT,
	@ultimo_rps INT,
	@valor_liquido DECIMAL(10,2)
	
	BEGIN TRY
		BEGIN TRANSACTION
		-- cria tabela temporaria para armazenar os IDs dos Agrupamentos
		SELECT @array = @IdsAgrupamento
		SELECT @delimitador = ','

		IF LEN(@array) > 0 SET @array = @array + @delimitador
		CREATE TABLE #temp_FAT(item_temp VARCHAR(8000)) 
		WHILE LEN(@ARRAY) > 0   

		BEGIN 
			SELECT @item = LTRIM(SUBSTRING(@array, 1, CHARINDEX(@delimitador, @array) - 1))   
			INSERT INTO #temp_FAT (item_temp) VALUES (@item)   
			SELECT @array = SUBSTRING(@array, CHARINDEX(@delimitador, @array) + 1, LEN(@array))   
		END 
		-- 
		
		SELECT @valorTotalServ = SUM((AOS.ValorUnitario * AOS.Quantidade)), @quantidadeTotal = SUM(AOS.Quantidade)  
		FROM AGRUPAMENTO_ORDEM_SERVICOs AOS (NOLOCK) 
		WHERE AOS.IdAgrupamentoOs IN (select * from #temp_FAT)

		--EXEC sp_executesql @sql, N'@valorTotalServ_0 decimal(10,2) output, @quantidadeTotal_0 int output', @valorTotalServ_0 = @valorTotalServ OUTPUT, @quantidadeTotal_0 = @quantidadeTotal OUTPUT;

		-- OBTEM A FILIAL DO AGRUPAMENTO
		SELECT top 1 @filial = IdFilialFK FROM agrupamento_ordem_servicos where IdAgrupamentoOs IN (select * from #temp_FAT)
		
		-- OBTEM ULTIMO NUMERO NFSE, ULTIMO LOTE E ULTIMO RPS
		SELECT  @ultimo_nf = UtimoNf, @ultimo_rps = UltimoRps  FROM ParametrosFiscais WHERE Filial_Id = @filial

		-- OBTEM O CLIENTE
		SELECT TOP 1 @cliente = IdClienteFk FROM agrupamento_ordem_servicos where IdAgrupamentoOs IN (select * from #temp_FAT) 
		
		-- OBTEM O ID DO AGRUPAMENTO
		SELECT TOP 1 @agrupamento = IdAgrupamentoOs FROM agrupamento_ordem_servicos where IdAgrupamentoOs IN (select * from #temp_FAT)  
		
		INSERT INTO titulos_faturas
		SELECT
		TOP 1
		NULL AS IdTituloFaturaFk,
		(select count(*) + 1 from titulos_faturas) as Numero,
		GETDATE() AS DataEmissao,
		GETDATE() AS DataVencimento, /* Data de vencimento, confirmar com a vanessa */
		GETDATE() AS DataBaixa, /* DATA DA BAIXA NULL */
		@valorTotalServ AS Valor, /*VALOR TOTAL DA FATURA*/
		GETDATE() AS DataCompetencia, /* DATA DA COMPETENCIA NULL */
		0 AS ValorAcrescimo,
		0 AS ValorMulta,
		0 AS ValorJuros,
		0 AS ValorDesconto,
		0 AS ValorPago,
		@filial AS idFilial,
		@cliente AS idCliente,
		@agrupamento AS idAgrupamento,
		AOS.DataQuinzenalInicial AS DataInicialPeriodo,
		AOS.DataQuinzenalFinal AS DataFinalPeriodo,
		'' AS Observacao,
		NULL as NotaFiscalServico_IdNotaFiscalServico,
		@valorTotalServ as ValorLiquido
		FROM
		AGRUPAMENTO_ORDEM_SERVICOs AOS (NOLOCK)
		INNER JOIN CLIENTES CLI (NOLOCK)
		ON CLI.IdCliente = AOS.IdClienteFk
		WHERE AOS.IdAgrupamentoOs IN (select * from #temp_FAT)

		SET @id = SCOPE_IDENTITY();
		/*---------------------------------------------------------------------------------------------------------*/
		
		
		
		-- OBTEM O ID DO SERVICO
		SELECT TOP 1 @servico = IdServicoFk FROM agrupamento_ordem_servicos where IdAgrupamentoOs IN (select * from #temp_FAT)  AND Status = 1

		
		-- LOOP INSERT PARA CADA ID PRECO
		BEGIN
			SET @MyCursor = CURSOR FOR
			
			SELECT DISTINCT IOS.PRECO_ID AS PRECOID
			FROM 
				ORDEM_SERVICO_AGRUPAMENTO_OS OSAO,
				AGRUPAMENTO_ORDEM_SERVICOS AOS,
				ITEM_ORDEM_SERVICO IOS,
				SERVICOS SVC
			WHERE 1=1
			AND AOS.IDAGRUPAMENTOOS = OSAO.AGRUPAMENTO_ORDEM_SERVICO_ID
			AND IOS.ORDEM_SERVICO_ID = OSAO.ORDEM_SERVICO_ID
			AND SVC.ID = IOS.SERVICO_ID
			AND IS_FATURA = 1
			AND AOS.IDAGRUPAMENTOOS IN (select * from #temp_FAT)
		
			OPEN @MyCursor 
			FETCH NEXT FROM @MyCursor 
			INTO @preco
		
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
			INSERT INTO titulo_fatura_itens
			SELECT top 1
			@id AS fatura_id,
			@servico AS servico_id,
			@preco AS preco_id,
			AOS.Quantidade AS quantidade,
			GETDATE() AS data_cadastro,
			@valorTotalServ AS valor_total
			FROM
			AGRUPAMENTO_ORDEM_SERVICOs AOS (NOLOCK)
			INNER JOIN CLIENTES CLI (NOLOCK)
			ON CLI.IdCliente = AOS.IdClienteFk
			WHERE AOS.IdAgrupamentoOs IN (select * from #temp_FAT)
			AND AOS.Status = 1;	
			
			FETCH NEXT FROM @MyCursor 
			INTO @preco 
			END; 
		
			CLOSE @MyCursor ;
			DEALLOCATE @MyCursor;
		END;

		-- LOOP INSERT PARA CADA AGRUPAMENTO
		BEGIN
			SET @Cursor = CURSOR FOR
			
			select * from #temp_FAT
		
			OPEN @Cursor 
			FETCH NEXT FROM @Cursor 
			INTO @agrupamento
		
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
			INSERT INTO titulo_fatura_agrupamentos values
			(@id,@agrupamento,@user_id,GETDATE())
			
			
			FETCH NEXT FROM @Cursor 
			INTO @agrupamento
			END; 
		
			CLOSE @Cursor ;
			DEALLOCATE @Cursor;
		END;


		DROP TABLE #temp_FAT
		COMMIT TRANSACTION
		
	END TRY
	
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrorMessage  = ERROR_MESSAGE()
    	SET @ErrorSeverity = ERROR_SEVERITY()
    	SET @ErrorState    = ERROR_STATE()
    	RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
	END CATCH;	
END

GO
