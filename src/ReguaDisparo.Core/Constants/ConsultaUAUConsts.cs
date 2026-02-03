using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReguaDisparo.Core.Constants
{
    public static class ConsultaUAUConsts
    {
        #region Dados Pessoas UAU

        public const string DADOS_PESSOAS = @"SELECT
	                                                                A.COD_PES,  
	                                                                NOME_PES,
	                                                                CPF_PES,
	                                                                DTNASC_PES,
                                                                    TIPO_PEND,
	                                                                ISNULL(EMAIL_PES,'')EMAIL_PES,
	                                                                ISNULL(B.NACION_PF,'') NACION_PF,
                                                                    LOGIN_PES,
                                                                    SENHA_PES,
	                                                                CASE 
		                                                                B.ESTCIV_PF
			                                                                WHEN 0 THEN 'SEPARADO'
			                                                                WHEN 1 THEN 'SOLTEIRO'
			                                                                WHEN 2 THEN 'CASADO'
			                                                                WHEN 3 THEN 'DESQUITADO'
			                                                                WHEN 4 THEN 'VIUVO'
			                                                                WHEN 5 THEN 'DIVORCIADO'
			                                                                ELSE 'OUTROS'
		                                                                END ESTCIV_PF,
	                                                                ISNULL(B.CARGO_PF,'')CARGO_PF,
	                                                                ISNULL(C.ENDERECO_PEND,'')ENDERECO_PEND,
	                                                                ISNULL(C.BAIRRO_PEND,'')BAIRRO_PEND,
	                                                                ISNULL(C.CIDADE_PEND,'')CIDADE_PEND,
	                                                                ISNULL(C.UF_PEND,'')UF_PEND,
	                                                                ISNULL(C.NUMEND_PEND,0)NUMEND_PEND,
	                                                                ISNULL(COMPLENDERECO_PEND,'') COMPLENDERECO_PEND,
                                                                    ISNULL(CEP_PEND,'') CEP_PEND
                                                                FROM PESSOAS A 
	                                                                LEFT JOIN PESFIS B ON A.COD_PES=B.COD_PF
	                                                                LEFT JOIN PESENDERECO C ON A.COD_PES=C.CODPES_PEND
                                                                WHERE
	                                                                (TIPO_PEND=0 or TIPO_PEND=1) and A.COD_PES={0}";



        public const string PRONENTES_VENDA = @"SELECT 

            case 	when Tipo_Cven = 0 then 'Titular' 
		            when Tipo_Cven = 1 then 'Não Titular' 
		            when Tipo_Cven = 2 then 'Avalista' 
		            else '-' end TIPO_CLIENTE,
	            case  	when EmiteBoleto_Cven = 1 THEN 'Sim' else 'Não' end EMITE_BOLETO,


            VendaClientes.*, Pessoas.nome_pes FROM (
               SELECT * FROM VendaClientes
               UNION
               SELECT * FROM VendaRecClientes
             )AS VendaClientes
             INNER JOIN Pessoas
               ON VendaClientes.Cliente_CVen = Pessoas.cod_pes 
            WHERE VendaClientes.Empresa_cven = {0}
            AND VendaClientes.Obra_CVen = '{1}'   
            AND VendaClientes.Num_CVen = {2}
            ORDER BY Tipo_CVen";

        public const string DADOS_PESSOAS_VENDA_COMPLETO = @"SELECT distinct
                                                                0 ID_FATO_PROPONENTE,
                                                                CONVERT(VARCHAR(200),UPPER(P.NOME_PES)) DS_NOME,
                                                                CONVERT(VARCHAR(18),P.CPF_PES) NR_CPF,
                                                                CONVERT(VARCHAR(200),P.EMAIL_PES) DS_EMAIL,
                                                                0 ID_CIDADE,
                                                                CONVERT(VARCHAR(200),PE.BAIRRO_PEND) DS_BAIRRO,
                                                                CONVERT(VARCHAR(200),PE.ENDERECO_PEND) DS_LOGRADOURO,
                                                                CONVERT(VARCHAR(20),PE.NUMEND_PEND) NR_ENDERECO,
                                                                CONVERT(VARCHAR(200),PE.COMPLENDERECO_PEND) DS_COMPLEMENTO_ENDERECO,
                                                                CONVERT(VARCHAR(20),PE.CEP_PEND) NR_CEP,
                                                                NRTITULO.REGISTRO_DOC DS_TITULO, --5
                                                                CONVERT(VARCHAR(50),P.COD_PES) ID_CHAVE_ERP_CLIENTE,
                                                                '' DS_MELHOR_HORARIO_ATENDIMENTO,
                                                                CONVERT(VARCHAR(50),NRIDENTIDADE.REGISTRO_DOC) NR_RG,
                                                                NRIDENTIDADE.ORGAOEMISSOR_DOC DS_RG_ORGAO_EMISSOR,
                                                                NRIDENTIDADE.DATAEMISSAO_DOC DT_RG_EMISSAO,
                                                                '' DS_NACIONALIDADE,
                                                                NULL ID_PROFISSAO,
                                                                '' DS_PROFISSAO,
                                                                PAI_PF DS_NOME_PAI,
                                                                MAE_PF DS_NOME_MAE,
                                                                DATEADD(M, DATEDIFF(M, 0, GETDATE()), 0) DT_MES_REFERENCIA,  
                                                                isnull(PorcTitular_Cven,0) PERC_CLIENTE,
																EMITEBOLETO_CVEN,
                                                                CASE EMITEBOLETO_CVEN WHEN 1 THEN 'SIM'  ELSE 'NÃO' END TITULAR,
																vendas.Empresa_cven as ID_EMPRESA,
																vendas.Obra_CVen AS ID_OBRA,
																vendas.Num_CVen AS ID_VENDA,
																ISNULL(PESVENDA.RECEBEBOLETOCORREIO_PVEN,0) RECEBEBOLETOCORREIO_PVEN,
																ISNULL(PESVENDA.RECEBEBOLETOEMAIL_PVEN,0) RECEBEBOLETOEMAIL_PVEN,
																P.LOGIN_PES,
                                                                P.DTNASC_PES,
                                                                CASE 
		                                                                    ESTCIV_PF
			                                                                    WHEN 0 THEN 'SEPARADO'
			                                                                    WHEN 1 THEN 'SOLTEIRO'
			                                                                    WHEN 2 THEN 'CASADO'
			                                                                    WHEN 3 THEN 'DESQUITADO'
			                                                                    WHEN 4 THEN 'VIUVO'
			                                                                    WHEN 5 THEN 'DIVORCIADO'
			                                                                    ELSE 'OUTROS'
		                                                                    END ESTCIV_PF,
                                                                P.COD_PES
                                FROM PESSOAS P
                                LEFT JOIN
                                (SELECT    V.*
                                FROM      VENDACLIENTES V INNER JOIN PESSOAS P ON V.CLIENTE_CVEN = P.COD_PES
                                UNION ALL
                                SELECT    V.*
                                FROM      VENDARECCLIENTES V INNER JOIN PESSOAS P ON V.CLIENTE_VRC = P.COD_PES		                                
                                
								) VENDAS  ON P.COD_PES = VENDAS.CLIENTE_CVEN
                                LEFT JOIN PESFIS PF ON PF.COD_PF = P.COD_PES
                                LEFT JOIN PESENDERECO PE ON P.COD_PES = PE.CODPES_PEND AND PE.TIPO_PEND = 0
                                LEFT JOIN PESSOASDOC NRIDENTIDADE  ON NRIDENTIDADE.CODPES_DOC=P.COD_PES AND NRIDENTIDADE.TIPO_DOC=1
                                LEFT JOIN PESSOASDOC NRTITULO  ON NRTITULO.CODPES_DOC=P.COD_PES AND NRTITULO.TIPO_DOC=5
								LEFT JOIN PESVENDA PESVENDA ON PESVENDA.CODPES_PVEN = P.COD_PES 
								WHERE P.COD_PES = {0}";


        public const string LISTA_TELEFONES = @"SELECT * FROM PESTEL WITH(NOLOCK) WHERE pes_tel ={0}";

        public const string TELEFONE_PESSOAS = @"SELECT 
	                                    PES_TEL,
	                                    FONE_TEL,
	                                    DDD_TEL,
	                                    RAM_TEL,
	                                    TIPO_TEL,
	                                    CASE TIPO_TEL 
		                                    WHEN 0 THEN 'RESIDENCIAL' 
		                                    WHEN 1 THEN 'COMERCIAL'
		                                    WHEN 2 THEN 'CELULAR'
		                                    WHEN 3 THEN 'RECADO'
		                                    WHEN 4 THEN 'FAX'
		                                    WHEN 5 THEN 'BIP'
		                                    WHEN 6 THEN 'TELEX'
		                                    WHEN 7 THEN 'OUTRO'
		                                    ELSE 'FONE/FAX'
	                                    END DESCRICAO_TIPO_TEL
                                    FROM PESTEL WHERE PES_TEL = {0}";

        public const string DADOS_PESSOAS_UAU = @"select *,
                            (SELECT TOP 1 Endereco_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) Endereco_pend,
                            (SELECT TOP 1 Bairro_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) Bairro_pend,
                            (SELECT TOP 1 Cidade_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) Cidade_pend,
                            (SELECT TOP 1 UF_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) UF_pend,
                            (SELECT TOP 1 CEP_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) CEP_pend,
                            (SELECT TOP 1 NumEnd_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) NumEnd_pend,
                            (SELECT TOP 1 ComplEndereco_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) ComplEndereco_pend,
                            (SELECT TOP 1 ReferEnd_pend FROM pesendereco pe WHERE p.cod_pes = pe.CodPes_pend and Tipo_pend = 1) ReferEnd_pend
                            from pessoas p
                            where cpf_pes ='{0}' AND AtInat_pes = 0";

        #endregion

        #region Modelo Renegociacao - Cobrança

        public const string MODELO_RENEGOCIACAO = @" SELECT	distinct
		Num_Mven,
		Descricao_Mven
  FROM	[ModeloVenda]
		inner join [ModVenObr]
			on Num_Mven = NumMven_MvObr
  where	atinat_Mven = 0	and
		Tipo_MvObr = 1
  order by 2";


        public const string DADOS_EMPRESA_TERMO = @"SELECT *
                                                    FROM empresas
                                                    where codigo_emp = {0}";

        #endregion

        #region CategoriaAtendimento

        public const string CATEGORIA_ATENDIMENTOS = @" SELECT	CategoriasDeComentario.* 
                                                        FROM	( 
			                                                        SELECT  CategoriasDeComentario.Codigo_cger, 
					                                                        CategoriasDeComentario.Anexos_Cger, 
					                                                        CategoriasDeComentario.CodCategPai_cger, 
					                                                        CategoriasDeComentario.UsrCad_cger, 
					                                                        0 AS Tipo, 
					                                                        'Categorias de Comentário' AS DescTipo, 
					                                                        CategoriasDeComentario.DataCad_cger, 
					                                                        CategoriasDeComentario.AtInat_cger, 
					                                                        CategoriasDeComentario.NumVcwf_cger,  
					                                                        COALESCE(CDC.Desc_cger + ': ', '') + 
					                                                        CategoriasDeComentario.Desc_cger AS Desc_cger ,
					                                                        CategoriasDeComentario.GerarAvaliacao_cger  
			                                                        FROM	CategoriasDeComentario 
					                                                        LEFT JOIN CategoriasDeComentario CDC 
						                                                        ON CategoriasDeComentario.CodCategPai_cger = CDC.Codigo_cger 
		                                                        ) CategoriasDeComentario 
                                                        WHERE AtInat_Cger = 0  
                                                        ORDER BY Desc_Cger";

        public const string CATEGORIA_ATENDIMENTOS_VENDA = @" SELECT 
	                                                            C.NUMDOC_COM NumeroComentario
	                                                            ,C.COMENTARIO_COM Comentario
	                                                            ,CONVERT(DATETIME, CONVERT(VARCHAR, C.DATAHORA_COM, 111), 20) AS DataComentario
	                                                            ,C.USER_COM UsuarioReponsavel
	                                                            ,CDCF.Codigo_cger CodigoCategoria
	                                                            ,COALESCE(CDCP.Desc_cger + ': ', '') + CDCF.Desc_cger AS Categoria
                                                            FROM 
	                                                            Comentario C
                                                            INNER JOIN
	                                                            CategoriasDeComentario CDCF
		                                                            ON C.Categoria_com = CDCF.Codigo_cger
                                                            LEFT JOIN 
	                                                            CategoriasDeComentario CDCP
		                                                            ON CDCF.CodCategPai_cger = CDCF.Codigo_cger 
                                                            WHERE 
	                                                            C.NumDoc_com = 'VENDAS {1}-{0}'
                                                            ORDER BY 
	                                                            DataComentario DESC";

        #endregion

        #region ContaContatoVendaProduto

        public const string CONTA_CONTATO_VENDA_PRODUTO_POR_DATA = @"declare @Produto varchar(20)
set @Produto = '%'

declare @Cliente varchar(20)
set @Cliente = '%'


SELECT		
			
			Obras.Descr_Obr EMPREENDIMENTO, 
            PrdSrv.Descricao_Psc BLOCO, 
			UnidadePer.Identificador_Unid UNIDADE, 
			Pessoas.nome_pes NOME, 
            Pessoas.cpf_pes CPF, 
            TelCol.FoneRes FIXO, 
            TelCol.FoneCel CELULAR, 
            TelCol.FoneCom COMERCIAL, 
            Pessoas.Email_pes EMAIL, 
            PesEndereco.CEP_pend CEP,
            Vendas.ValorTot_Ven - Vendas.Desconto_Ven + Vendas.Acrescimo_Ven VALORVENDA, 
            Vendas.Data_Ven DATAVENDA, 
			
            Pessoas.cod_pes CODPES,  
            Vendas.Obra_Ven OBRA_VEN, 
            Vendas.Empresa_Ven EMPRESA_VEN,
            CAST(Vendas.Empresa_Ven AS VARCHAR) + '_' + Vendas.Obra_Ven + '_' + CAST(Vendas.Num_Ven AS VARCHAR) CHAVE, 
            Vendas.Obra_Ven + ' / ' + CAST(PrdSrv.NumProd_Psc AS VARCHAR) + ' / ' + UnidadePer.Identificador_Unid OBRA_PRODUTO_IDENTIFICADOR,
			CASE Vendas.Status_Ven 
				WHEN 0 THEN '0 - NORMAL' 
				WHEN 1 THEN '1 - CANCELADA' 
				WHEN 2 THEN '2 - ALTERADA' 
				WHEN 3 THEN '3 - QUITADA' 
				WHEN 4 THEN '4 - EM ACERTO' 
			END STATENAME

FROM 
( 
			SELECT		* 
			FROM		ItensVenda 						
			WHERE		CAST(Produto_Itv AS VARCHAR) LIKE @Produto 

			UNION 

			SELECT		* 
			FROM		ItensRecebidas 						
			WHERE		CAST(Produto_Itr AS VARCHAR) LIKE @Produto 
) [ItensVenda] 
			INNER JOIN 
			( 
				SELECT		Empresa_Ven, 
							Obra_Ven, 
							Num_Ven, 
							Cliente_Ven, 
							Data_Ven, 
							Status_Ven, 
							NULL [DataCancel_Ven], 
							DataCessao_Ven, 
							ValorTot_Ven, 
							Desconto_Ven, 
							Acrescimo_Ven, 
							ValProvisaoCurto_Ven, 
							ValProvisaoLongo_Ven, 
							TipoVenda_Ven, 
							Vendedor_Ven [Vendedor], 
							Nome_Pes [NomeVendedor] 
				FROM		Vendas 							
							LEFT JOIN Pessoas 
								ON Vendedor_Ven = Cod_Pes 
				WHERE		Data_Ven BETWEEN '{0}' AND '{1}' 
							AND Status_Ven IN (0,3) 
							AND TipoVenda_Ven IN (0,1,2,3,4) 
							AND CAST(Cliente_Ven AS VARCHAR) LIKE @Cliente

				UNION 

				SELECT		Empresa_VRec, 
							Obra_VRec, 
							Num_VRec, 
							Cliente_VRec, 
							Data_VRec, 
							Status_VRec, 
							DataCancel_VRec, 
							DataCessao_VRec, 
							ValorTot_VRec, 
							Desconto_VRec, 
							Acrescimo_VRec, 
							ValProvisaoCurto_VRec, 
							ValProvisaoLongo_VRec, 
							TipoVenda_VRec, 
							Vendedor_VRec [Vendedor], 
							Nome_Pes [NomeVendedor] 
				FROM		VendasRecebidas 							
							LEFT JOIN Pessoas 
								ON Vendedor_VRec = Cod_Pes 
				WHERE		Data_VRec BETWEEN '{0}' AND '{1}' 
							AND Status_VRec IN (0,1,2,3,4) 
							AND TipoVenda_VRec IN (0,1,2,3,4) 
							AND CAST(Cliente_VRec AS VARCHAR) LIKE @Cliente
			) [Vendas] 
				ON ItensVenda.Empresa_Itv = Vendas.Empresa_Ven 
				AND ItensVenda.Obra_Itv = Vendas.Obra_Ven 
				AND ItensVenda.NumVend_Itv = Vendas.Num_Ven 
			INNER JOIN Obras 
				ON Vendas.Empresa_Ven = Obras.Empresa_Obr 
				AND Vendas.Obra_Ven = Obras.Cod_Obr 
			INNER JOIN 
			( 
				SELECT		PesFis.*, 
							Pessoas.* 
				FROM		Pessoas 
							LEFT JOIN 
							( 
								SELECT		Cod_Pf, 
											EstCiv_Pf, 
											CASE EstCiv_Pf 
												WHEN 0 THEN 'SEPARADO' 
												WHEN 1 THEN 'SOLTEIRO' 
												WHEN 2 THEN 'CASADO' 
												WHEN 3 THEN 'DESQUITADO' 
												WHEN 4 THEN 'VIÚVO' 
												WHEN 5 THEN 'DIVORCIADO' 
												WHEN 6 THEN 'OUTROS' 
											END [DescEstCiv], 
											Sexo_Pf, 
											CASE Sexo_Pf 
												WHEN 0 THEN 'MASCULINO' 
												WHEN 1 THEN 'FEMININO' 
												ELSE '' 
											END [DescSexo], 
											NULL [Contato_Pj], 
											NULL [Contato2_Pj], 
											Descr_Pro [Profis_Pf], 
											Registro_Doc [CI_Pf], 
											OrgaoEmissor_Doc [OrgExp_Pf], 
											UF_Doc [UFCI_Pf], 
											Nacion_Pf 
								FROM		PesFis 
											LEFT JOIN Profissao 
												ON NumPro_Pf = Num_Pro 
											LEFT JOIN PessoasDoc 
												ON Cod_Pf = CodPes_Doc 
												AND Tipo_Doc = 1 

								UNION 

								SELECT		Cod_Pj, 
											NULL [EstCiv_Pf], 
											NULL [DescEstCiv], 
											NULL [Sexo_Pf], 
											NULL [DescSexo], 
											Contato_Pj, 
											Contato2_Pj, 
											NULL [Profis_Pf], 
											NULL [Ci_Pf], 
											NULL [OrgExp_Pf], 
											NULL [UFCi_Pf], 
											NULL [Nacion_Pf] 
								FROM		PesJur 
							) [PesFis] 
								ON Cod_Pes = Cod_Pf 
			) [Pessoas] 
				ON Vendas.Cliente_Ven = Pessoas.Cod_Pes 

				LEFT JOIN (select * from PesEndereco where Tipo_pend = 0) PesEndereco
				ON Pessoas.cod_pes = PesEndereco.CodPes_pend



			LEFT JOIN 
			( 
				SELECT		Pes_Tel, 
							MAX(FoneRes) [FoneRes], 
							MAX(FoneCom) [FoneCom], 
							MAX(FoneCel) [FoneCel] 
				FROM 
				( 
							SELECT		Pes_Tel, 
										CASE Tipo_Tel 
											WHEN 0 THEN '(' + DDD_Tel + ')' + Fone_Tel 
										END [FoneRes], 
										CASE Tipo_Tel 
											WHEN 1 THEN '(' + DDD_Tel + ')' + Fone_Tel 
										END [FoneCom], 
										CASE Tipo_Tel 
											WHEN 2 THEN '(' + DDD_Tel + ')' + Fone_Tel 
										END [FoneCel] 
							FROM		PesTel 
							WHERE		Tipo_Tel < 3 
				) [Tel] 
				GROUP BY	Pes_Tel 
			) [TelCol] 
				ON Vendas.Cliente_Ven = TelCol.Pes_Tel 
			INNER JOIN PrdSrv 
				ON ItensVenda.Produto_Itv = PrdSrv.NumProd_Psc 
			INNER JOIN Empresas 
				ON Obras.Empresa_Obr = Empresas.Codigo_Emp 
			LEFT JOIN UnidadePer 
				ON ItensVenda.Empresa_Itv = UnidadePer.Empresa_Unid 
				AND ItensVenda.Obra_Itv = UnidadePer.Obra_Unid 
				AND ItensVenda.Produto_Itv = UnidadePer.Prod_Unid 
				AND ItensVenda.CodPerson_Itv = UnidadePer.NumPer_Unid 
			LEFT JOIN 
			( 
				SELECT		MAX(DataPror_Prc) [UltimoVencimento], 
							Empresa_Prc [Empresa], 
							Obra_Prc [Obra], 
							NumVend_Prc [NumVenda], 
							COUNT(NumParc_Prc) [QtdeParcelasAberto] 
				FROM		ContasReceber 
				GROUP BY	Empresa_Prc, Obra_Prc, NumVend_Prc 
			) [AReceber] 
				ON Vendas.Empresa_Ven = AReceber.Empresa 
				AND Vendas.Obra_Ven = AReceber.Obra 
				AND Vendas.Num_Ven = AReceber.NumVenda 
			INNER JOIN 
			( 
				SELECT		Empresa_Cven [Empresa], 
							Obra_Cven [Obra], 
							Num_Cven [Venda], 
							Cliente_Cven [Cliente], 
							PorcTitular_Cven [PorcTitular], 
							Tipo_Cven [TipoCliente] 
				FROM		VendaClientes 
				WHERE		Tipo_Cven IN (0,1,2,3,4) 

				UNION 

				SELECT		Empresa_Vrc [Empresa], 
							Obra_Vrc [Obra], 
							Num_Vrc [Venda], 
							Cliente_Vrc [Cliente], 
							PorcTitular_Vrc [PorcTitular], 
							Tipo_Vrc [TipoCliente] 
				FROM		VendaRecClientes 
				WHERE		Tipo_Vrc IN (0,1,2,3,4) 
			) [Clientes] 
				ON Vendas.Empresa_Ven = Clientes.Empresa 
				AND Vendas.Obra_Ven = Clientes.Obra 
				AND Vendas.Num_Ven = Clientes.Venda 
			INNER JOIN Pessoas [PesCli] 
				ON Clientes.Cliente = PesCli.Cod_Pes";


        public const string CONTA_CONTATO_VENDA_PRODUTO_POR_VENDA = @"declare @Produto varchar(20)
set @Produto = '%'

declare @Cliente varchar(20)
set @Cliente = '%'


SELECT		Obras.Descr_Obr EMPREENDIMENTO, 
            PrdSrv.Descricao_Psc BLOCO, 
			UnidadePer.Identificador_Unid UNIDADE, 
			Pessoas.nome_pes NOME, 
            Pessoas.cpf_pes CPF, 
            TelCol.FoneRes FIXO, 
            TelCol.FoneCel CELULAR, 
            TelCol.FoneCom COMERCIAL, 
            Pessoas.Email_pes EMAIL, 
            PesEndereco.CEP_pend CEP,
            Vendas.ValorTot_Ven - Vendas.Desconto_Ven + Vendas.Acrescimo_Ven VALORVENDA, 
            Vendas.Data_Ven DATAVENDA, 
			
            Pessoas.cod_pes CODPES,
            Vendas.Empresa_Ven EMPRESA_VEN,  
            Vendas.Obra_Ven OBRA_VEN, 
            CAST(Vendas.Empresa_Ven AS VARCHAR) + '_' + Vendas.Obra_Ven + '_' + CAST(Vendas.Num_Ven AS VARCHAR) CHAVE, 
            Vendas.Obra_Ven + ' / ' + CAST(PrdSrv.NumProd_Psc AS VARCHAR) + ' / ' + UnidadePer.Identificador_Unid OBRA_PRODUTO_IDENTIFICADOR,
			CASE Vendas.Status_Ven 
				WHEN 0 THEN '0 - NORMAL' 
				WHEN 1 THEN '1 - CANCELADA' 
				WHEN 2 THEN '2 - ALTERADA' 
				WHEN 3 THEN '3 - QUITADA' 
				WHEN 4 THEN '4 - EM ACERTO' 
			END STATENAME
FROM 
( 
			SELECT		* 
			FROM		ItensVenda 						
			WHERE		CAST(Produto_Itv AS VARCHAR) LIKE @Produto 

			UNION 

			SELECT		* 
			FROM		ItensRecebidas 						
			WHERE		CAST(Produto_Itr AS VARCHAR) LIKE @Produto 
) [ItensVenda] 
			INNER JOIN 
			( 
				SELECT		Empresa_Ven, 
							Obra_Ven, 
							Num_Ven, 
							Cliente_Ven, 
							Data_Ven, 
							Status_Ven, 
							NULL [DataCancel_Ven], 
							DataCessao_Ven, 
							ValorTot_Ven, 
							Desconto_Ven, 
							Acrescimo_Ven, 
							ValProvisaoCurto_Ven, 
							ValProvisaoLongo_Ven, 
							TipoVenda_Ven, 
							Vendedor_Ven [Vendedor], 
							Nome_Pes [NomeVendedor] 
				FROM		Vendas 							
							LEFT JOIN Pessoas 
								ON Vendedor_Ven = Cod_Pes 
				WHERE		Data_Ven BETWEEN '1900-01-01' AND '2030-01-01' 
							AND Status_Ven IN (0,3) 
							AND TipoVenda_Ven IN (0,1,2,3,4) 
							AND CAST(Cliente_Ven AS VARCHAR) LIKE @Cliente

				UNION 

				SELECT		Empresa_VRec, 
							Obra_VRec, 
							Num_VRec, 
							Cliente_VRec, 
							Data_VRec, 
							Status_VRec, 
							DataCancel_VRec, 
							DataCessao_VRec, 
							ValorTot_VRec, 
							Desconto_VRec, 
							Acrescimo_VRec, 
							ValProvisaoCurto_VRec, 
							ValProvisaoLongo_VRec, 
							TipoVenda_VRec, 
							Vendedor_VRec [Vendedor], 
							Nome_Pes [NomeVendedor] 
				FROM		VendasRecebidas 							
							LEFT JOIN Pessoas 
								ON Vendedor_VRec = Cod_Pes 
				WHERE		Data_VRec BETWEEN '1900-01-01' AND '2030-01-01' 
							AND Status_VRec IN (0,1,2,3,4) 
							AND TipoVenda_VRec IN (0,1,2,3,4) 
							AND CAST(Cliente_VRec AS VARCHAR) LIKE @Cliente
			) [Vendas] 
				ON ItensVenda.Empresa_Itv = Vendas.Empresa_Ven 
				AND ItensVenda.Obra_Itv = Vendas.Obra_Ven 
				AND ItensVenda.NumVend_Itv = Vendas.Num_Ven 
			INNER JOIN Obras 
				ON Vendas.Empresa_Ven = Obras.Empresa_Obr 
				AND Vendas.Obra_Ven = Obras.Cod_Obr 
			INNER JOIN 
			( 
				SELECT		PesFis.*, 
							Pessoas.* 
				FROM		Pessoas 
							LEFT JOIN 
							( 
								SELECT		Cod_Pf, 
											EstCiv_Pf, 
											CASE EstCiv_Pf 
												WHEN 0 THEN 'SEPARADO' 
												WHEN 1 THEN 'SOLTEIRO' 
												WHEN 2 THEN 'CASADO' 
												WHEN 3 THEN 'DESQUITADO' 
												WHEN 4 THEN 'VIÚVO' 
												WHEN 5 THEN 'DIVORCIADO' 
												WHEN 6 THEN 'OUTROS' 
											END [DescEstCiv], 
											Sexo_Pf, 
											CASE Sexo_Pf 
												WHEN 0 THEN 'MASCULINO' 
												WHEN 1 THEN 'FEMININO' 
												ELSE '' 
											END [DescSexo], 
											NULL [Contato_Pj], 
											NULL [Contato2_Pj], 
											Descr_Pro [Profis_Pf], 
											Registro_Doc [CI_Pf], 
											OrgaoEmissor_Doc [OrgExp_Pf], 
											UF_Doc [UFCI_Pf], 
											Nacion_Pf 
								FROM		PesFis 
											LEFT JOIN Profissao 
												ON NumPro_Pf = Num_Pro 
											LEFT JOIN PessoasDoc 
												ON Cod_Pf = CodPes_Doc 
												AND Tipo_Doc = 1 

								UNION 

								SELECT		Cod_Pj, 
											NULL [EstCiv_Pf], 
											NULL [DescEstCiv], 
											NULL [Sexo_Pf], 
											NULL [DescSexo], 
											Contato_Pj, 
											Contato2_Pj, 
											NULL [Profis_Pf], 
											NULL [Ci_Pf], 
											NULL [OrgExp_Pf], 
											NULL [UFCi_Pf], 
											NULL [Nacion_Pf] 
								FROM		PesJur 
							) [PesFis] 
								ON Cod_Pes = Cod_Pf 
			) [Pessoas] 
				ON Vendas.Cliente_Ven = Pessoas.Cod_Pes 

				LEFT JOIN (select * from PesEndereco where Tipo_pend = 0) PesEndereco
				ON Pessoas.cod_pes = PesEndereco.CodPes_pend



			LEFT JOIN 
			( 
				SELECT		Pes_Tel, 
							MAX(FoneRes) [FoneRes], 
							MAX(FoneCom) [FoneCom], 
							MAX(FoneCel) [FoneCel] 
				FROM 
				( 
							SELECT		Pes_Tel, 
										CASE Tipo_Tel 
											WHEN 0 THEN '(' + DDD_Tel + ')' + Fone_Tel 
										END [FoneRes], 
										CASE Tipo_Tel 
											WHEN 1 THEN '(' + DDD_Tel + ')' + Fone_Tel 
										END [FoneCom], 
										CASE Tipo_Tel 
											WHEN 2 THEN '(' + DDD_Tel + ')' + Fone_Tel 
										END [FoneCel] 
							FROM		PesTel 
							WHERE		Tipo_Tel < 3 
				) [Tel] 
				GROUP BY	Pes_Tel 
			) [TelCol] 
				ON Vendas.Cliente_Ven = TelCol.Pes_Tel 
			INNER JOIN PrdSrv 
				ON ItensVenda.Produto_Itv = PrdSrv.NumProd_Psc 
			INNER JOIN Empresas 
				ON Obras.Empresa_Obr = Empresas.Codigo_Emp 
			LEFT JOIN UnidadePer 
				ON ItensVenda.Empresa_Itv = UnidadePer.Empresa_Unid 
				AND ItensVenda.Obra_Itv = UnidadePer.Obra_Unid 
				AND ItensVenda.Produto_Itv = UnidadePer.Prod_Unid 
				AND ItensVenda.CodPerson_Itv = UnidadePer.NumPer_Unid 
			LEFT JOIN 
			( 
				SELECT		MAX(DataPror_Prc) [UltimoVencimento], 
							Empresa_Prc [Empresa], 
							Obra_Prc [Obra], 
							NumVend_Prc [NumVenda], 
							COUNT(NumParc_Prc) [QtdeParcelasAberto] 
				FROM		ContasReceber 
				GROUP BY	Empresa_Prc, Obra_Prc, NumVend_Prc 
			) [AReceber] 
				ON Vendas.Empresa_Ven = AReceber.Empresa 
				AND Vendas.Obra_Ven = AReceber.Obra 
				AND Vendas.Num_Ven = AReceber.NumVenda 
			INNER JOIN 
			( 
				SELECT		Empresa_Cven [Empresa], 
							Obra_Cven [Obra], 
							Num_Cven [Venda], 
							Cliente_Cven [Cliente], 
							PorcTitular_Cven [PorcTitular], 
							Tipo_Cven [TipoCliente] 
				FROM		VendaClientes 
				WHERE		Tipo_Cven IN (0,1,2,3,4) 

				UNION 

				SELECT		Empresa_Vrc [Empresa], 
							Obra_Vrc [Obra], 
							Num_Vrc [Venda], 
							Cliente_Vrc [Cliente], 
							PorcTitular_Vrc [PorcTitular], 
							Tipo_Vrc [TipoCliente] 
				FROM		VendaRecClientes 
				WHERE		Tipo_Vrc IN (0,1,2,3,4) 
			) [Clientes] 
				ON Vendas.Empresa_Ven = Clientes.Empresa 
				AND Vendas.Obra_Ven = Clientes.Obra 
				AND Vendas.Num_Ven = Clientes.Venda 
			INNER JOIN Pessoas [PesCli] 
				ON Clientes.Cliente = PesCli.Cod_Pes 

where Empresa_ven={0} and Obra_Ven = '{1}' and Num_Ven = {2}";


        public const string CONTATO_VINCULADOS_VENDA = @"

select	P.NOME_PES NOME,
P.CPF_PES CPF,
P.EMAIL_PES EMAIL,
P.COD_PES CODPES,
EMPRESA_vrc EMPRESA,
OBRA_vrc OBRA,
num_VRC VENDA
from	VendaRecClientes V
		INNER JOIN PESSOAS P
			ON V.CLIENTE_VRC = P.COD_PES
where	emiteboleto_vrc = 0 and tipo_vrc = 0

";



        #endregion

        #region Cobranca

        /// <summary>
        /// Retorna os dados da obra no UAU
        /// </summary>
        public const string ConsultarObra = @"
                                            SELECT 
	                                            COD_OBR,DESCR_OBR, ENDER_OBR,SETOR_OBR,CID_OBR,UF_OBR, COD_OBR + ' - ' + DESCR_OBR AS DESCR_COMP_OBR
                                            FROM 
	                                            OBRAS
                                            WHERE  EMPRESA_OBR = {0}";


        /// <summary>
        /// Retorna os dados da obra no UAU
        /// </summary>
        public const string ConsultarEmpresaObra = @"
                                            SELECT 
	                                            COD_OBR,DESCR_OBR, ENDER_OBR,SETOR_OBR,CID_OBR,UF_OBR, COD_OBR + ' - ' + DESCR_OBR AS DESCR_COMP_OBR
                                            FROM 
	                                            OBRAS
                                            WHERE  EMPRESA_OBR = {0} and COD_OBR = '{1}'";

        public const string ConsultarDescricaoTipoCusta = @"SELECT 
	                                                            DESCR_CTP
                                                            FROM 
	                                                            CUSTASTIPO
                                                            WHERE 
	                                                            NUM_CTP = {0}";

        /// <summary>
        /// Retorna os dados da empresa no UAU
        /// </summary>
        public const string ConsultarEmpresa = @"SELECT 
	                                                CODIGO_EMP,DESC_EMP,CGC_EMP,IE_EMP,ENDERECO_EMP,SETOR_EMP,CIDADE_EMP,UF_EMP,CEP_EMP,FONE_EMP,FAX_EMP,REDICMS_EMP,
                                                    IPIISENTA_EMP,ATINAT_EMP,CODEMPRESANET_EMP,ANEXOS_EMP,INSCRMUNIC_EMP,EMPRESAFOLHA_EMP,NUMCID_EMP,EMAIL_EMP,
                                                    TIPOINSC_EMP,NUMEND_EMP,OPTSIMPLES_EMP,QTDESOCIO_EMP,DDDFONE_EMP,DDDFAX_EMP,INCETIVADORCULTURAL_EMP,
                                                    CODIDXCORRPAT_EMP,CODIDXINDPAT_EMP,DATASIMPLES_EMP,INSNIRE_EMP,INSSUFRAMA_EMP,NUMBRR_EMP,NUMLOGR_EMP, CONVERT(VARCHAR(MAX), CODIGO_EMP) + ' - ' + DESC_EMP AS DESC_COMP_EMP
                                                FROM EMPRESAS";

        public const string ConsultarEmpresaPorId = @"SELECT 
	                                                CODIGO_EMP,DESC_EMP,CGC_EMP,IE_EMP,ENDERECO_EMP,SETOR_EMP,CIDADE_EMP,UF_EMP,CEP_EMP,FONE_EMP,FAX_EMP,REDICMS_EMP,
                                                    IPIISENTA_EMP,ATINAT_EMP,CODEMPRESANET_EMP,ANEXOS_EMP,INSCRMUNIC_EMP,EMPRESAFOLHA_EMP,NUMCID_EMP,EMAIL_EMP,
                                                    TIPOINSC_EMP,NUMEND_EMP,OPTSIMPLES_EMP,QTDESOCIO_EMP,DDDFONE_EMP,DDDFAX_EMP,INCETIVADORCULTURAL_EMP,
                                                    CODIDXCORRPAT_EMP,CODIDXINDPAT_EMP,DATASIMPLES_EMP,INSNIRE_EMP,INSSUFRAMA_EMP,NUMBRR_EMP,NUMLOGR_EMP, CONVERT(VARCHAR(MAX), CODIGO_EMP) + ' - ' + DESC_EMP AS DESC_COMP_EMP
                                                FROM EMPRESAS WHERE CODIGO_EMP = {0}";

        public const string ConsultarTipoParcelas = @"SELECT 
	                                                        TIPO_PAR,
	                                                        DESCRICAO_PAR,
	                                                        ATINAT_PAR,
	                                                        DATACAD_PAR,
	                                                        TIPOPARA_PAR,
	                                                        USRCAD_PAR,
	                                                        CATEGPARC_PAR,
	                                                        FORAIRPF_PAR,
	                                                        DESCONSIDERARNODESCQUITACAO_PAR,
	                                                        DESCONSIDERARNOENVIOPOREMAIL_PAR,
                                                            TIPO_PAR + ' - ' + DESCRICAO_PAR AS PAR_COMPLETO
                                                        FROM PARCELAS";

        public static string ConsultarParcelasReceberRecebidasCustas = @"select parcelas.*,c.Descr_Ctp  from
                                                                    (
                                                                    select empresa_rec,obra_rec,numvend_rec,NumParc_Rec,NumParcGer_Rec,Tipo_Rec,NumCtp_Rec from Recebidas
                                                                    where empresa_rec = {0} and obra_rec = '{1}' and numvend_rec={2}
                                                                    union
                                                                    select Empresa_prc,Obra_Prc,NumVend_prc,NumParc_Prc,NumParcGer_Prc,Tipo_Prc,NumCtp_prc from contasreceber
                                                                    where empresa_prc = {0} and obra_prc = '{1}' and numvend_prc={2}) parcelas 
                                                                    left join CustasTipo c on c.Num_Ctp = parcelas.NumCtp_Rec";

        public const string CONSULTA_BOLETOS_POR_VENDA = @"SELECT	RECEBAUTO.*, 
		                    BOLETO.*, 
		                    CONTASRECEBER.DATA_PRC,   
                            EMPRESAS.CODIGO_EMP,             
                            EMPRESAS.DESC_EMP,        
		                    PESSOAS.NOME_PES, 		                    
		                    PESSOAS.CPF_PES, 
		                    PESSOAS.TIPO_PES,        
		                    CONTASRECEBER.DATAPROR_PRC, 
		                    CONTASRECEBER.VALORTAXABOL_PRC,        
		                    ISNULL(PESENDERECO.ENDERECO_PEND, '') + ' ' + ISNULL(PESENDERECO.COMPLENDERECO_PEND, '') AS ENDERECO_PEND, 
		                    PESENDERECO.NUMEND_PEND,
                            PESENDERECO.UF_PEND, 
		                    PESENDERECO.BAIRRO_PEND,         
		                    PESENDERECO.CIDADE_PEND, 
		                    PESENDERECO.CEP_PEND, 
		                    PESSOAS.EMAIL_PES, 
		                    PESSOAS.NOMEFANT_PES, 
		                    CUSTASTIPO.DESCR_CTP, 
		                    CONTASRECEBER.DATAINIPERIODOALUGUEL_PRC,         
		                    CASE WHEN BOLETO.DATAENVIOPOREMAIL_BOL IS NULL THEN 0 ELSE 1 END AS BOLETOENVIADO_BOL,
                            IDENTIFICADOR_UNID,
                            TIPOPRC_REA + ' - ' + DESCRICAO_PAR + ' - ' + CONVERT(VARCHAR, NUMPARCPRC_REA) DESCRICAOPARCELACOMPLETA,
							DIGITO_BANCO,
                            TOTPARCGRUPO_PRC
                    FROM	RECEBAUTO  
		                    INNER JOIN BOLETO     
			                    ON	RECEBAUTO.SEUNUM_REA = BOLETO.SEUNUM_BOL     AND 
				                    RECEBAUTO.BANCO_REA = BOLETO.BANCO_BOL  
		                    INNER JOIN EMPRESAS     
			                    ON RECEBAUTO.EMPRESA_REA = EMPRESAS.CODIGO_EMP 
		                    INNER JOIN PESSOAS     
			                    ON BOLETO.CLIENTEVEN_BOL = PESSOAS.COD_PES 
		                    LEFT JOIN PESENDERECO     
			                    ON	PESSOAS.COD_PES = PESENDERECO.CODPES_PEND     AND 
				                    PESENDERECO.TIPO_PEND = 0 /* ENDEREÇO PRINCIPAL */ 
		                    LEFT OUTER JOIN CONTASRECEBER 
			                    ON	RECEBAUTO.EMPRESA_REA = CONTASRECEBER.EMPRESA_PRC AND                                  
				                    RECEBAUTO.OBRAPRC_REA = CONTASRECEBER.OBRA_PRC AND                                  
				                    RECEBAUTO.NUMVENDPRC_REA = CONTASRECEBER.NUMVEND_PRC AND                                  
				                    RECEBAUTO.TIPOPRC_REA = CONTASRECEBER.TIPO_PRC AND                                  
				                    RECEBAUTO.NUMPARCGERPRC_REA = CONTASRECEBER.NUMPARCGER_PRC AND                                  
				                    RECEBAUTO.NUMPARCPRC_REA = CONTASRECEBER.NUMPARC_PRC  
		                    LEFT JOIN CUSTASTIPO 
			                    ON CUSTASTIPO.NUM_CTP = CONTASRECEBER.NUMCTP_PRC
                            INNER JOIN VENDAS
                                ON  RECEBAUTO.EMPRESA_REA = VENDAS.EMPRESA_VEN AND
				                    RECEBAUTO.OBRAPRC_REA = VENDAS.OBRA_VEN AND                                
				                    RECEBAUTO.NUMVENDPRC_REA = VENDAS.NUM_VEN
                            INNER JOIN ITENSVENDA
                                ON  ITENSVENDA.EMPRESA_ITV = VENDAS.EMPRESA_VEN AND
				                    ITENSVENDA.OBRA_ITV = VENDAS.OBRA_VEN AND                                
				                    ITENSVENDA.NUMVEND_ITV = VENDAS.NUM_VEN
                            LEFT JOIN UNIDADEPER
                                ON	EMPRESA_UNID = EMPRESA_ITV AND
									OBRA_UNID = OBRA_ITV AND
									PROD_UNID = PRODUTO_ITV AND
                                    NUMPER_UNID = CODPERSON_ITV 
                            INNER JOIN PARCELAS
                                ON TIPOPRC_REA = TIPO_PAR
							INNER JOIN BANCOS
								ON BANCO_REA = NUMERO_BANCO
                    WHERE	
                            EMPRESA_VEN = {0} AND VENDAS.OBRA_VEN = '{1}' AND NUM_VEN={2} AND NOSSONUM_BOL != ''
                    ORDER BY NOME_PES";

        public const string PARCELAS_INADIMPLENCIA_CONTAS_RECEBER = @"select * from contasreceber with(nolock) where data_prc < Dateadd(day, -2, Getdate())  and empresa_prc = {0} and obra_prc = '{1}' and numvend_prc = {2}";

        public const string PARCELAS_INADIMPLENCIA_CONTAS_RECEBER_TOP1 = @"select TOP 1 * from contasreceber with(nolock) where data_prc < Dateadd(day, -2, Getdate())  and empresa_prc = {0} and obra_prc = '{1}' and numvend_prc = {2}";
        public const string VERIFICA_EXECUCAO_PROUAU = @"select TOP 1 1 from contasrecebercalc with(nolock) where convert(date,data_prc) = convert(date, getdate())";

        public const string PARCELAS_INADIMPLENCIA_CONTAS_RECEBER_PRORROG_PROUAU = @"select * from contasreceber with(nolock) where data_prc < Dateadd(day, -2, Getdate()) and datapror_prc <= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) and empresa_prc = {0} and obra_prc = '{1}' and numvend_prc = {2}";


        public const string HISTORICO_ATENDIMENTOS_UAU_POR_VENDA = @"SELECT 
   Num_atd as NumeroAtendimento, Descr_atd Descricao,
   CASE Status_atd
   WHEN '0' THEN '0 - ABERTO'
   WHEN '1' THEN '1 - ENCERRADO'
   WHEN '2' THEN '2 - CANCELADO'
   WHEN '3' THEN '3 - A RETORNAR'
   End AS StatusAtendimento,
   UsrRespon_atd UsuarioReponsavel,
   CONVERT(DATETIME, CONVERT(VARCHAR, DataCad_atd, 111), 20) AS DataAtendimento
   FROM Atendimento
INNER JOIN Pessoas 
   ON Atendimento.CodPes_atd = Pessoas.Cod_pes 
INNER JOIN CategoriasDeComentario 
   ON Atendimento.CodCateg_atd = CategoriasDeComentario.Codigo_cger
LEFT JOIN CategoriasDeComentario CDC 
   ON CategoriasDeComentario.CodCategPai_cger = CDC.Codigo_cger
LEFT JOIN Obras 
   ON Obras.Empresa_obr = Atendimento.Empresa_atd 
   AND Obras.Cod_obr =  Atendimento.Obra_atd 
LEFT JOIN Empresas 
   ON Atendimento.Empresa_atd = Empresas.Codigo_emp 
LEFT JOIN PrdSrv 
   ON Atendimento.ProdUnid_atd = PrdSrv.NumProd_psc
LEFT JOIN CanalComunicacao on
NumCcm_atd = Num_Ccm
LEFT JOIN ItensVenda
ON ItensVenda.Empresa_itv = Atendimento.Empresa_atd AND ItensVenda.Obra_Itv = Atendimento.Obra_atd AND ItensVenda.Produto_Itv = Atendimento.ProdUnid_atd AND ItensVenda.CodPerson_Itv = Atendimento.NumPer_atd

WHERE ItensVenda.Empresa_itv = {0} and ItensVenda.Obra_Itv = '{1}' AND ItensVenda.NumVend_Itv = {2}
Order by atendimento.Num_atd desc";


        public const string HISTORICO_ATENDIMENTOS_UAU_POR_CLIENTE = @"SELECT 
   Num_atd as NumeroAtendimento, Descr_atd Descricao,
   CASE Status_atd
   WHEN '0' THEN '0 - ABERTO'
   WHEN '1' THEN '1 - ENCERRADO'
   WHEN '2' THEN '2 - CANCELADO'
   WHEN '3' THEN '3 - A RETORNAR'
   End AS StatusAtendimento,
   UsrRespon_atd UsuarioReponsavel,
   CONVERT(DATETIME, CONVERT(VARCHAR, DataCad_atd, 111), 20) AS DataAtendimento
   FROM Atendimento
INNER JOIN Pessoas 
   ON Atendimento.CodPes_atd = Pessoas.Cod_pes 
INNER JOIN CategoriasDeComentario 
   ON Atendimento.CodCateg_atd = CategoriasDeComentario.Codigo_cger
LEFT JOIN CategoriasDeComentario CDC 
   ON CategoriasDeComentario.CodCategPai_cger = CDC.Codigo_cger
LEFT JOIN Obras 
   ON Obras.Empresa_obr = Atendimento.Empresa_atd 
   AND Obras.Cod_obr =  Atendimento.Obra_atd 
LEFT JOIN Empresas 
   ON Atendimento.Empresa_atd = Empresas.Codigo_emp 
LEFT JOIN PrdSrv 
   ON Atendimento.ProdUnid_atd = PrdSrv.NumProd_psc
LEFT JOIN CanalComunicacao on
NumCcm_atd = Num_Ccm
LEFT JOIN ItensVenda
ON ItensVenda.Empresa_itv = Atendimento.Empresa_atd AND ItensVenda.Obra_Itv = Atendimento.Obra_atd AND ItensVenda.Produto_Itv = Atendimento.ProdUnid_atd AND ItensVenda.CodPerson_Itv = Atendimento.NumPer_atd
WHERE Pessoas.nome_pes = '{0}'
Order by atendimento.Num_atd desc";


        public const string HISTORICO_ATENDIMENTOS_UAU_POR_COD_CLIENTE = @"SELECT 
   Num_atd as NumeroAtendimento, Descr_atd Descricao,
   CASE Status_atd
   WHEN '0' THEN '0 - ABERTO'
   WHEN '1' THEN '1 - ENCERRADO'
   WHEN '2' THEN '2 - CANCELADO'
   WHEN '3' THEN '3 - A RETORNAR'
   End AS StatusAtendimento,
   UsrRespon_atd UsuarioReponsavel,
   CONVERT(DATETIME, CONVERT(VARCHAR, DataCad_atd, 111), 20) AS DataAtendimento,
   ItensVenda.Empresa_itv Empresa,
   ItensVenda.Obra_Itv Obra,
   ItensVenda.NumVend_Itv Venda
   FROM Atendimento
INNER JOIN Pessoas 
   ON Atendimento.CodPes_atd = Pessoas.Cod_pes 
INNER JOIN CategoriasDeComentario 
   ON Atendimento.CodCateg_atd = CategoriasDeComentario.Codigo_cger
LEFT JOIN CategoriasDeComentario CDC 
   ON CategoriasDeComentario.CodCategPai_cger = CDC.Codigo_cger
LEFT JOIN Obras 
   ON Obras.Empresa_obr = Atendimento.Empresa_atd 
   AND Obras.Cod_obr =  Atendimento.Obra_atd 
LEFT JOIN Empresas 
   ON Atendimento.Empresa_atd = Empresas.Codigo_emp 
LEFT JOIN PrdSrv 
   ON Atendimento.ProdUnid_atd = PrdSrv.NumProd_psc
LEFT JOIN CanalComunicacao on
NumCcm_atd = Num_Ccm
LEFT JOIN ItensVenda
ON ItensVenda.Empresa_itv = Atendimento.Empresa_atd AND ItensVenda.Obra_Itv = Atendimento.Obra_atd AND ItensVenda.Produto_Itv = Atendimento.ProdUnid_atd AND ItensVenda.CodPerson_Itv = Atendimento.NumPer_atd
WHERE Pessoas.cod_pes = {0}
Order by atendimento.Num_atd desc";


        public const string HISTORICO_ATENDIMENTOS_UAU_POR_COD_CLIENTE_COMENTARIO = @"SELECT
   Num_atd as NumeroAtendimento, 
   CONVERT(VARCHAR(MAX), Descr_atd) + ' - ' + CONVERT(VARCHAR(MAX), COALESCE(Obs_pdo, '')) Descricao,
   CASE Status_atd
   WHEN '0' THEN '0 - ABERTO'
   WHEN '1' THEN '1 - ENCERRADO'
   WHEN '2' THEN '2 - CANCELADO'
   WHEN '3' THEN '3 - A RETORNAR'
   End AS StatusAtendimento,
   UsrRespon_atd UsuarioReponsavel,
   CONVERT(DATETIME, CONVERT(VARCHAR, DataCad_atd, 111), 20) AS DataAtendimento,
   ItensVenda.Empresa_itv Empresa,
   ItensVenda.Obra_Itv Obra,
   ItensVenda.NumVend_Itv Venda
   FROM Atendimento
INNER JOIN Pessoas 
   ON Atendimento.CodPes_atd = Pessoas.Cod_pes 
INNER JOIN CategoriasDeComentario 
   ON Atendimento.CodCateg_atd = CategoriasDeComentario.Codigo_cger
LEFT JOIN CategoriasDeComentario CDC 
   ON CategoriasDeComentario.CodCategPai_cger = CDC.Codigo_cger
LEFT JOIN Obras 
   ON Obras.Empresa_obr = Atendimento.Empresa_atd 
   AND Obras.Cod_obr =  Atendimento.Obra_atd 
LEFT JOIN Empresas 
   ON Atendimento.Empresa_atd = Empresas.Codigo_emp 
LEFT JOIN PrdSrv 
   ON Atendimento.ProdUnid_atd = PrdSrv.NumProd_psc
LEFT JOIN CanalComunicacao 
	on NumCcm_atd = Num_Ccm
LEFT JOIN ItensVenda
	ON	ItensVenda.Empresa_itv = Atendimento.Empresa_atd AND 
		ItensVenda.Obra_Itv = Atendimento.Obra_atd AND 
		ItensVenda.Produto_Itv = Atendimento.ProdUnid_atd AND 
		ItensVenda.CodPerson_Itv = Atendimento.NumPer_atd
LEFT JOIN ( 
   SELECT *
   FROM PendenciaObs 
   INNER JOIN Pendencia 
      ON Pendencia.QuemR_Pen = PendenciaObs.QuemRPen_pdo 
      AND Pendencia.QdoL_pen = PendenciaObs.QdoLPen_pdo 
      AND Pendencia.Num_pen = PendenciaObs.NumPen_pdo 
   INNER JOIN PassoWorkflowPend 
      ON PassoWorkflowPend.QuemRPen_pwfp = Pendencia.QuemR_Pen 
      AND PassoWorkflowPend.QdoLPen_pwfp = Pendencia.QdoL_pen 
      AND PassoWorkflowPend.NumPen_pwfp = Pendencia.Num_pen 
   INNER JOIN VinculoTabelaWorkFlow 
      ON VinculoTabelaWorkFlow.Num_vtwf = PassoWorkflowPend.NumVtwf_pwfp 
	INNER JOIN CategoriasDeComentario CC
      ON Pendencia.CODCATEG_PEN = CC.Codigo_cger
	WHERE CONVERT(VARCHAR(MAX), COALESCE(Obs_pdo, '')) <> 'TEXTO'
) AS PendenciaObs 
   ON Atendimento.NumVtwf_atd = PendenciaObs.Num_vtwf 
WHERE Pessoas.cod_pes = {0}
Order by atendimento.Num_atd desc";



        public const string ADIMPLENCIA_PREMIADA = @"   select	coalesce(sum(ValParcelaAntec_crc), 0) VL_ADIMPLENCIA_PREMIADA
                                                        from	ContasReceberCalc
                                                        where	Tipo_crc = '14' and
		                                                        Empresa_crc = {0} AND
		                                                        Obra_crc = '{1}' AND
		                                                        NumVend_crc = {2}";


        public const string TOTAL_CONTRATOS_ATIVOS = @"SELECT 

COUNT(*) TOTAL_CONTRATOS_ATIVOS
FROM 
(

SELECT distinct crc.empresa_crc,  crc.obra_crc, crc.numvend_crc, data_ven,  p.nome_pes , up.identificador_unid ,up.qtde_unid ,valortot_ven
FROM   contasrecebercalc crc 
       INNER JOIN contasreceber cr 
               ON cr.empresa_prc = crc.empresa_crc 
                  AND cr.obra_prc = crc.obra_crc 
                  AND cr.numvend_prc = crc.numvend_crc 
                  AND cr.numparc_prc = crc.numparc_crc 
                  AND cr.numparcger_prc = crc.numparcger_crc 
                  AND cr.tipo_prc = crc.tipo_crc 
       INNER JOIN vendas v 
               ON v.empresa_ven = crc.empresa_crc 
                  AND v.obra_ven = crc.obra_crc 
                  AND v.num_ven = crc.numvend_crc 
       INNER JOIN vendaclientes vc 
               ON v.empresa_ven = vc.empresa_cven 
                  AND v.obra_ven = vc.obra_cven 
                  AND v.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 
       INNER JOIN itensvenda iv 
               ON crc.empresa_crc = iv.empresa_itv 
                  AND crc.numvend_crc = iv.numvend_itv 
                  AND crc.obra_crc = iv.obra_itv 
       LEFT JOIN unidadeper up 
              ON iv.empresa_itv = up.empresa_unid 
                 AND iv.obra_itv = up.obra_unid 
                 AND iv.produto_itv = up.prod_unid 
                 AND iv.codperson_itv = up.numper_unid 
			   INNER JOIN obras o
			   on  crc.empresa_crc = o.Empresa_obr and o.cod_obr = crc.obra_crc

				WHERE  crc.valparcela_crc > 1 
	   AND o.status_obr = 0 
       AND cr.data_prc >= '{0}'
       AND iv.codperson_itv NOT IN ( '-1' ) 
	   AND vc.emiteboleto_cven = '1'

       
        ) FatoInadimplencia";


        public const string TOTAL_CONTRATOS_INADIMPLENTES = @"SELECT 

COUNT(*) TOTAL_CONTRATOS_INADIMPLENTES
--(case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) as ClassificacaoContratoMedia,
--(case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end)  as ClassificacaoContratoAssiduidade,
--(case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) ClassificacaoContrato
--(case when (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) = 'E+' and StatusCobranca='203' then 'E-' else (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) end)  ClassificacaoContratoE
--(case when (StatusCobranca = 500 or StatusCobranca = 501 or StatusCobranca = 502) then 'F' when (StatusCobranca = 2051) then 'G' else (case when (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) = 'E+' and StatusCobranca='203' then 'E-' else (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) end)  end) ClassificacaoContrato
FROM 
(SELECT DISTINCT 
				CAST ( v.Empresa_ven AS VARCHAR )+'-'+ CAST ( v.Obra_ven AS VARCHAR ) +'-'+ CAST ( v.Num_Ven AS VARCHAR ) AS EmpObraVen,
				crc.empresa_crc as Empresa, 
                crc.obra_crc as Obra , 
                crc.numvend_crc as Venda, 
                CONVERT(VARCHAR, data_ven, 103) AS [Data do Contrato], 
                p.nome_pes   as                   Cliente, 
                up.identificador_unid           AS [Quadra e Lote],
				up.qtde_unid as [Area do Terreno],
				valortot_ven as [Valor da Unidade],
				                COALESCE(v.statusescritura_ven, '-') AS [Status Escritura], 
                COALESCE(se.desc_ste, '-')            AS [Desc Status Escritura], 
				--'B+' [Classificação Contrato],
                COALESCE(sc.codigo_stc, '-')          AS StatusCobranca, 
                COALESCE(sc.desc_stc, '-')            AS [Desc Status Cobrança],
				(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9') as [Frequencia 9 Meses],
				convert(decimal(18,2),(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9'))/9 as FrequenciaMedia,
				(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '2') as RecebimentoUltimos2Meses,
				(select count(*) from ContasReceber WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(day, Data_prc, GETDATE()) > '2') as [Quantidade Parcelas Aberto],
				(select coalesce(sum(ValParcela_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' ) as [Valor Parcelas Aberto],
				coalesce((select sum((ValorConf_Rec + Valor_Rec)) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc),0) as ValorRecebidoVGV,
				(select coalesce(sum(Valjuroatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' ) as ValorJurosAtraso,
				(select coalesce(sum(Valmultaatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' ) as ValorMultaAtraso,
				(select coalesce(sum(Valcorrecaoatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' ) as ValorCorrecaoAtraso
FROM   contasrecebercalc crc 
       INNER JOIN contasreceber cr 
               ON cr.empresa_prc = crc.empresa_crc 
                  AND cr.obra_prc = crc.obra_crc 
                  AND cr.numvend_prc = crc.numvend_crc 
                  AND cr.numparc_prc = crc.numparc_crc 
                  AND cr.numparcger_prc = crc.numparcger_crc 
                  AND cr.tipo_prc = crc.tipo_crc 
       INNER JOIN vendas v 
               ON v.empresa_ven = crc.empresa_crc 
                  AND v.obra_ven = crc.obra_crc 
                  AND v.num_ven = crc.numvend_crc 
       INNER JOIN (SELECT * 
                   FROM   vendaclientes 
                   WHERE  emiteboleto_cven = '1') vc 
               ON v.empresa_ven = vc.empresa_cven 
                  AND v.obra_ven = vc.obra_cven 
                  AND v.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 
       INNER JOIN itensvenda iv 
               ON crc.empresa_crc = iv.empresa_itv 
                  AND crc.numvend_crc = iv.numvend_itv 
                  AND crc.obra_crc = iv.obra_itv 
       LEFT JOIN unidadeper up 
              ON iv.empresa_itv = up.empresa_unid 
                 AND iv.obra_itv = up.obra_unid 
                 AND iv.produto_itv = up.prod_unid 
                 AND iv.codperson_itv = up.numper_unid 
       INNER JOIN prdsrv prd 
               ON prd.numprod_psc = iv.produto_itv
			   INNER JOIN obras o
			   on  crc.empresa_crc = o.Empresa_obr and o.cod_obr = crc.obra_crc
       LEFT JOIN prdsrvcat prdc 
              ON prdc.codprod_cp = iv.produto_itv 

			  LEFT JOIN statusescritura se
              ON v.statusescritura_ven LIKE '%-' 
                                          + Cast(se.codigo_ste AS 
                                          VARCHAR) 
                                          + '-%' 
       LEFT JOIN statuscobranca sc
              ON v.statuscobranca_ven LIKE '%-' 
                                         + Cast(sc.codigo_stc AS 
                                         VARCHAR) 
                                         + '-%' 
WHERE  crc.valparcela_crc > 1 
       AND crc.tipo_crc NOT IN ( '1' ) 
       AND crc.empresa_crc NOT IN ( '5','29' ) 
       AND crc.obra_crc NOT IN ( 'RJF','RJV','ADMIN' )
	   AND o.status_obr = 0 
       AND Datediff(day, cr.data_prc, '{0}') > '2' 
       AND iv.codperson_itv NOT IN ( '-1' ) 
       AND prdc.codcat_cp IN ( '100', '102' )
       
        ) FatoInadimplencia";


        public const string FATO_INADIMPLENCIA = @"SELECT 

*,
--(case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) as ClassificacaoContratoMedia,
--(case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end)  as ClassificacaoContratoAssiduidade,
--(case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) ClassificacaoContrato
--(case when (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) = 'E+' and StatusCobranca='203' then 'E-' else (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) end)  ClassificacaoContratoE
(case when (StatusCobranca = 500 or StatusCobranca = 501 or StatusCobranca = 502) then 'F' when (StatusCobranca = 2051) then 'G' else (case when (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) = 'E+' and StatusCobranca='203' then 'E-' else (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) end)  end) ClassificacaoContrato
FROM 
(SELECT DISTINCT 
				CAST ( v.Empresa_ven AS VARCHAR )+'-'+ CAST ( v.Obra_ven AS VARCHAR ) +'-'+ CAST ( v.Num_Ven AS VARCHAR ) AS EmpObraVen,
				crc.empresa_crc as Empresa, 
                crc.obra_crc as Obra , 
                crc.numvend_crc as Venda, 
                CONVERT(VARCHAR, data_ven, 103) AS [Data do Contrato], 
                p.nome_pes   as                   Cliente, 
                up.identificador_unid           AS [Quadra e Lote],
				up.qtde_unid as [Area do Terreno],
				valortot_ven as [Valor da Unidade],
				                COALESCE(v.statusescritura_ven, '-') AS [Status Escritura], 
                COALESCE(se.desc_ste, '-')            AS [Desc Status Escritura], 
				--'B+' [Classificação Contrato],
                COALESCE(sc.codigo_stc, '-')          AS StatusCobranca, 
                COALESCE(sc.desc_stc, '-')            AS [Desc Status Cobrança],
				(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9') as [Frequencia 9 Meses],
				convert(decimal(18,2),(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9'))/9 as FrequenciaMedia,
				(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '2') as RecebimentoUltimos2Meses,
				(select count(*) from ContasReceber WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(day, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' )) as [Quantidade Parcelas Aberto],
				(select coalesce(sum(ValParcela_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as [Valor Parcelas Aberto],
				coalesce((select sum((ValorConf_Rec + Valor_Rec)) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc),0) as ValorRecebidoVGV,
				(select coalesce(sum(Valjuroatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as ValorJurosAtraso,
				(select coalesce(sum(Valmultaatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as ValorMultaAtraso,
				(select coalesce(sum(Valcorrecaoatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as ValorCorrecaoAtraso
FROM   contasrecebercalc crc 
       INNER JOIN contasreceber cr 
               ON cr.empresa_prc = crc.empresa_crc 
                  AND cr.obra_prc = crc.obra_crc 
                  AND cr.numvend_prc = crc.numvend_crc 
                  AND cr.numparc_prc = crc.numparc_crc 
                  AND cr.numparcger_prc = crc.numparcger_crc 
                  AND cr.tipo_prc = crc.tipo_crc 
       INNER JOIN vendas v 
               ON v.empresa_ven = crc.empresa_crc 
                  AND v.obra_ven = crc.obra_crc 
                  AND v.num_ven = crc.numvend_crc 
       INNER JOIN (SELECT * 
                   FROM   vendaclientes 
                   WHERE  emiteboleto_cven = '1') vc 
               ON v.empresa_ven = vc.empresa_cven 
                  AND v.obra_ven = vc.obra_cven 
                  AND v.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 
       INNER JOIN itensvenda iv 
               ON crc.empresa_crc = iv.empresa_itv 
                  AND crc.numvend_crc = iv.numvend_itv 
                  AND crc.obra_crc = iv.obra_itv 
       LEFT JOIN unidadeper up 
              ON iv.empresa_itv = up.empresa_unid 
                 AND iv.obra_itv = up.obra_unid 
                 AND iv.produto_itv = up.prod_unid 
                 AND iv.codperson_itv = up.numper_unid 
       INNER JOIN prdsrv prd 
               ON prd.numprod_psc = iv.produto_itv
			   INNER JOIN obras o
			   on  crc.empresa_crc = o.Empresa_obr and o.cod_obr = crc.obra_crc
       LEFT JOIN prdsrvcat prdc 
              ON prdc.codprod_cp = iv.produto_itv 

			  LEFT JOIN statusescritura se
              ON v.statusescritura_ven LIKE '%-' 
                                          + Cast(se.codigo_ste AS 
                                          VARCHAR) 
                                          + '-%' 
       LEFT JOIN statuscobranca sc
              ON v.statuscobranca_ven LIKE '%-' 
                                         + Cast(sc.codigo_stc AS 
                                         VARCHAR) 
                                         + '-%' 
WHERE  crc.valparcela_crc > 1 
       AND crc.tipo_crc NOT IN ( '1' ) 
	   AND o.status_obr = 0 
       AND Datediff(day, cr.data_prc, Getdate()) > '2' 
       AND iv.codperson_itv NOT IN ( '-1' ) 

       
        ) FatoInadimplencia";




        public const string FATO_INADIMPLENCIA_ANO = @"SELECT 

*,
--(case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) as ClassificacaoContratoMedia,
--(case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end)  as ClassificacaoContratoAssiduidade,
--(case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) ClassificacaoContrato
--(case when (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) = 'E+' and StatusCobranca='203' then 'E-' else (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) end)  ClassificacaoContratoE
(case when (StatusCobranca = 500 or StatusCobranca = 501 or StatusCobranca = 502) then 'F' when (StatusCobranca = 2051) then 'G' else (case when (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) = 'E+' and StatusCobranca='203' then 'E-' else (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) end)  end) ClassificacaoContrato
FROM 
(SELECT DISTINCT 
				CAST ( v.Empresa_ven AS VARCHAR )+'-'+ CAST ( v.Obra_ven AS VARCHAR ) +'-'+ CAST ( v.Num_Ven AS VARCHAR ) AS EmpObraVen,
				crc.empresa_crc as Empresa, 
                crc.obra_crc as Obra , 
                crc.numvend_crc as Venda, 
                CONVERT(VARCHAR, data_ven, 103) AS [Data do Contrato], 
                p.nome_pes   as                   Cliente, 
                up.identificador_unid           AS [Quadra e Lote],
				up.qtde_unid as [Area do Terreno],
				valortot_ven as [Valor da Unidade],
				                COALESCE(v.statusescritura_ven, '-') AS [Status Escritura], 
                COALESCE(se.desc_ste, '-')            AS [Desc Status Escritura], 
				--'B+' [Classificação Contrato],
                COALESCE(sc.codigo_stc, '-')          AS StatusCobranca, 
                COALESCE(sc.desc_stc, '-')            AS [Desc Status Cobrança],
				(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9') as [Frequencia 9 Meses],
				convert(decimal(18,2),(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9'))/9 as FrequenciaMedia,
				(select count(*) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '2') as RecebimentoUltimos2Meses,
				(select count(*) from ContasReceber WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(day, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' )) as [Quantidade Parcelas Aberto],
				(select coalesce(sum(ValParcela_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as [Valor Parcelas Aberto],
				coalesce((select sum((ValorConf_Rec + Valor_Rec)) from recebidas where Empresa_rec=crc.empresa_crc and Obra_Rec=crc.obra_crc and NumVend_Rec = crc.numvend_crc),0) as ValorRecebidoVGV,
				(select coalesce(sum(Valjuroatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as ValorJurosAtraso,
				(select coalesce(sum(Valmultaatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as ValorMultaAtraso,
				(select coalesce(sum(Valcorrecaoatraso_crc),0) from ContasReceber INNER JOIN contasrecebercalc ON empresa_prc = empresa_crc AND obra_prc = obra_crc AND numvend_prc = numvend_crc AND numparc_prc = numparc_crc AND numparcger_prc = numparcger_crc AND tipo_prc = tipo_crc  WHERE Empresa_prc=crc.empresa_crc and Obra_Prc=crc.obra_crc and NumVend_prc=crc.numvend_crc and  DATEDIFF(dd, Data_prc, GETDATE()) > '2' AND tipo_prc NOT IN ( '1' ) ) as ValorCorrecaoAtraso
FROM   contasrecebercalc crc 
       INNER JOIN contasreceber cr 
               ON cr.empresa_prc = crc.empresa_crc 
                  AND cr.obra_prc = crc.obra_crc 
                  AND cr.numvend_prc = crc.numvend_crc 
                  AND cr.numparc_prc = crc.numparc_crc 
                  AND cr.numparcger_prc = crc.numparcger_crc 
                  AND cr.tipo_prc = crc.tipo_crc 
       INNER JOIN vendas v 
               ON v.empresa_ven = crc.empresa_crc 
                  AND v.obra_ven = crc.obra_crc 
                  AND v.num_ven = crc.numvend_crc 
       INNER JOIN (SELECT * 
                   FROM   vendaclientes 
                   WHERE  emiteboleto_cven = '1') vc 
               ON v.empresa_ven = vc.empresa_cven 
                  AND v.obra_ven = vc.obra_cven 
                  AND v.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 
       INNER JOIN itensvenda iv 
               ON crc.empresa_crc = iv.empresa_itv 
                  AND crc.numvend_crc = iv.numvend_itv 
                  AND crc.obra_crc = iv.obra_itv 
       LEFT JOIN unidadeper up 
              ON iv.empresa_itv = up.empresa_unid 
                 AND iv.obra_itv = up.obra_unid 
                 AND iv.produto_itv = up.prod_unid 
                 AND iv.codperson_itv = up.numper_unid 
       INNER JOIN prdsrv prd 
               ON prd.numprod_psc = iv.produto_itv
			   INNER JOIN obras o
			   on  crc.empresa_crc = o.Empresa_obr and o.cod_obr = crc.obra_crc
       LEFT JOIN prdsrvcat prdc 
              ON prdc.codprod_cp = iv.produto_itv 

			  LEFT JOIN statusescritura se
              ON v.statusescritura_ven LIKE '%-' 
                                          + Cast(se.codigo_ste AS 
                                          VARCHAR) 
                                          + '-%' 
       LEFT JOIN statuscobranca sc
              ON v.statuscobranca_ven LIKE '%-' 
                                         + Cast(sc.codigo_stc AS 
                                         VARCHAR) 
                                         + '-%' 
WHERE  crc.valparcela_crc > 1 
       --AND crc.tipo_crc NOT IN ( '1' ) 
       --AND crc.empresa_crc NOT IN ( '5','29' ) 
       --AND crc.obra_crc NOT IN ( 'RJF','RJV','ADMIN' )
	   AND o.status_obr = 0 
       AND Datediff(day, cr.data_prc, Getdate()) > '2' 
       AND iv.codperson_itv NOT IN ( '-1' ) 
       --AND prdc.codcat_cp IN ( '100', '102' )
       AND YEAR(V.DATA_VEN) IN('{0}')
        ) FatoInadimplencia";

        public const string PARCELAS_INADIMPLENCIA = @"select distinct
                                                        (pc.Tipo_par + ' - '+ pc.Descricao_par) as TipoParcela,
                                                        crc.NumParc_crc as NumeroParcela,
                                                        crc.NumParcGer_crc as NumeroParcelaGeral,
                                                        crc.ValParcela_crc as ValorParcelaReajustado,
                                                        cr.Valor_Prc as ValorParcelaOriginal,
                                                        convert(varchar,cr.Data_Prc,103) as DataVencimento,
                                                        DATEDIFF(month,cr.Data_Prc,GETDATE()) AgingParcela,
														ValMultaAtraso_crc as ValorMultaAtraso,
														ValJuroAtraso_crc as ValorJurosAtraso,
														IdxReaj_Prc as IndiceReajusteVenda,
														JurosParc_Prc*100 as TaxaJurosVenda,
														convert(varchar,DataCalc_crc,103) as DataCalculo
                                                        FROM   contasrecebercalc crc 
                                                               INNER JOIN contasreceber cr 
                                                                       ON cr.empresa_prc = crc.empresa_crc 
                                                                          AND cr.obra_prc = crc.obra_crc 
                                                                          AND cr.numvend_prc = crc.numvend_crc 
                                                                          AND cr.numparc_prc = crc.numparc_crc 
                                                                          AND cr.numparcger_prc = crc.numparcger_crc 
                                                                          AND cr.tipo_prc = crc.tipo_crc 
                                                               INNER JOIN vendas v 
                                                                       ON v.empresa_ven = crc.empresa_crc 
                                                                          AND v.obra_ven = crc.obra_crc 
                                                                          AND v.num_ven = crc.numvend_crc 
                                                               INNER JOIN (SELECT * 
                                                                           FROM   vendaclientes 
                                                                           WHERE  emiteboleto_cven = '1') vc 
                                                                       ON v.empresa_ven = vc.empresa_cven 
                                                                          AND v.obra_ven = vc.obra_cven 
                                                                          AND v.num_ven = vc.num_cven 
                                                               INNER JOIN pessoas p 
                                                                       ON vc.cliente_cven = p.cod_pes 
                                                               INNER JOIN itensvenda iv 
                                                                       ON crc.empresa_crc = iv.empresa_itv 
                                                                          AND crc.numvend_crc = iv.numvend_itv 
                                                                          AND crc.obra_crc = iv.obra_itv 
                                                               LEFT JOIN unidadeper up 
                                                                      ON iv.empresa_itv = up.empresa_unid 
                                                                         AND iv.obra_itv = up.obra_unid 
                                                                         AND iv.produto_itv = up.prod_unid 
                                                                         AND iv.codperson_itv = up.numper_unid 
                                                               INNER JOIN prdsrv prd 
                                                                       ON prd.numprod_psc = iv.produto_itv 
                                                               LEFT JOIN prdsrvcat prdc 
                                                                      ON prdc.codprod_cp = iv.produto_itv 

			                                                          LEFT JOIN statusescritura se
                                                                      ON v.statusescritura_ven LIKE '%-' 
                                                                                                  + Cast(se.codigo_ste AS 
                                                                                                  VARCHAR) 
                                                                                                  + '-%' 
                                                               LEFT JOIN statuscobranca sc
                                                                      ON v.statuscobranca_ven LIKE '%-' 
                                                                                                 + Cast(sc.codigo_stc AS 
                                                                                                 VARCHAR) 
                                                                                                 + '-%' 
		                                                        JOIN parcelas pc
		                                                        on crc.Tipo_crc = pc.Tipo_par
                                                        WHERE  crc.valparcela_crc > 1 
                                                               AND Datediff(day, cr.data_prc, Getdate()) > '2' 
                                                               AND iv.codperson_itv NOT IN ( '-1' ) 
	                                                           AND crc.Empresa_crc = {0}
	                                                           AND crc.Obra_crc = '{1}'
	                                                           AND crc.NumVend_crc = {2}";

        public const string FECHAMENTO_MENSAL_COBRANCA = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 

                                                                    DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 19 and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(DataVenci_Rec))+ '/' + CONVERT(varchar, MONTH(DataVenci_Rec))+ '/01') = CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01')) 
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where month(Data_Prc) = month('{0}') and year(Data_Prc) = year('{0}')
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     


                                                                    
                                                                    DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 19 and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(DataVenci_Rec))+ '/' + CONVERT(varchar, MONTH(DataVenci_Rec))+ '/01') = CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01')) 

                                                                    and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(Data_Rec))+ '/' + CONVERT(varchar, MONTH(Data_Rec))+ '/01')) < (CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01'))

                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     
                                                                    DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 19 and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(DataVenci_Rec))+ '/' + CONVERT(varchar, MONTH(DataVenci_Rec))+ '/01') = CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01')) 

                                                                    and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(Data_Rec))+ '/' + CONVERT(varchar, MONTH(Data_Rec))+ '/01')) > (CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01'))

                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where Data_Prc < '{0}'
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     
                                                                    DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 19 and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(DataVenci_Rec))+ '/' + CONVERT(varchar, MONTH(DataVenci_Rec))+ '/01') < CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01')) 

                                                                    and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(Data_Rec))+ '/' + CONVERT(varchar, MONTH(Data_Rec))+ '/01')) >= (CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01'))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     
                                                                    DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 19 and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(DataVenci_Rec))+ '/' + CONVERT(varchar, MONTH(DataVenci_Rec))+ '/01') < CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01')) 

                                                                    and
                                                                    (CONVERT(DATETIME, CONVERT(varchar, YEAR(Data_Rec))+ '/' + CONVERT(varchar, MONTH(Data_Rec))+ '/01')) = (CONVERT(DATETIME, CONVERT(varchar, YEAR('{0}'))+ '/' + CONVERT(varchar, MONTH('{0}'))+ '/01'))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";



        public const string LISTA_STATUS_COBRANCA_UAU = @"SELECT 	Codigo_stc ID_STATUS_COBRANCA,
		Convert(varchar,Codigo_stc) + ' - ' + Desc_stc DS_STATUS_COBRANCA
FROM 	StatusCobranca 
WHERE  	Status_stc =  0
ORDER BY 2";


        #endregion

        #region Cobranca_FGR


        public const string HISTORICO_ATENDIMENTOS_UAU_POR_VENDA_FGR = @"SELECT 
   CONVERT(VARCHAR,Num_atd) as NumeroAtendimento, Descr_atd Descricao,
   CASE Status_atd
   WHEN '0' THEN '0 - ABERTO'
   WHEN '1' THEN '1 - ENCERRADO'
   WHEN '2' THEN '2 - CANCELADO'
   WHEN '3' THEN '3 - A RETORNAR'
   End AS StatusAtendimento,
   UsrRespon_atd UsuarioReponsavel,
   CONVERT(DATETIME, CONVERT(VARCHAR, DataCad_atd, 111), 20) AS DataAtendimento
   FROM Atendimento
INNER JOIN Pessoas 
   ON Atendimento.CodPes_atd = Pessoas.Cod_pes 
INNER JOIN CategoriasDeComentario 
   ON Atendimento.CodCateg_atd = CategoriasDeComentario.Codigo_cger
LEFT JOIN CategoriasDeComentario CDC 
   ON CategoriasDeComentario.CodCategPai_cger = CDC.Codigo_cger
LEFT JOIN Obras 
   ON Obras.Empresa_obr = Atendimento.Empresa_atd 
   AND Obras.Cod_obr =  Atendimento.Obra_atd 
LEFT JOIN Empresas 
   ON Atendimento.Empresa_atd = Empresas.Codigo_emp 
LEFT JOIN PrdSrv 
   ON Atendimento.ProdUnid_atd = PrdSrv.NumProd_psc
LEFT JOIN CanalComunicacao on
NumCcm_atd = Num_Ccm
LEFT JOIN ItensVenda
ON ItensVenda.Empresa_itv = Atendimento.Empresa_atd AND ItensVenda.Obra_Itv = Atendimento.Obra_atd AND ItensVenda.Produto_Itv = Atendimento.ProdUnid_atd AND ItensVenda.CodPerson_Itv = Atendimento.NumPer_atd

WHERE categoriasdecomentario.Codigo_cger in ('SQ-COB-03','SQ-COB-08','SQ-COB-02','SQ-COB-07') AND ItensVenda.Empresa_itv = {0} and ItensVenda.Obra_Itv = '{1}' AND ItensVenda.NumVend_Itv = {2}


UNION ALL

select NUMDOC_COM NumeroAtendimento,COMENTARIO_COM Descricao,'N/A' Status_atd,USER_COM UsuarioReponsavel,CONVERT(DATETIME, CONVERT(VARCHAR, DATAHORA_COM   , 111), 20) AS DataAtendimento
from Comentario where NumDoc_com = 'VENDAS {2}-{1}' AND CATEGORIA_COM = 'B15' 
ORDER BY 5
";

        public const string TOTAL_CONTRATOS_ATIVOS_FGR = @"select COUNT(*) CONTADOR FROM

(
SELECT DISTINCT Empresa_ven,Obra_Ven,Num_Ven
from Vendas v
left join StatusCobranca sc
ON v.StatusCobranca_Ven = '-' + Cast(sc.codigo_stc AS VARCHAR) + '-' 
INNER JOIN ItensVenda
ON Empresa_ven = Empresa_itv 
AND Obra_Ven = Obra_Itv 
AND Num_Ven = NumVend_Itv 
INNER JOIN PrdSrv 
ON numprod_psc = Produto_Itv 
where 
	Status_Ven in (0,3)                            
	AND StatusCobranca_Ven NOT IN ( '-800-', '-1000-', '-1100-', '-206-', '-2-','-910-','-900-','-901-','-1200-','-1300-','-1301-' ) 
	AND Obra_Ven NOT IN ('RJF', 'RJV', 'ADMIN')
	AND Empresa_ven NOT IN ( '5', '29', '47','6','3' )
	AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
	AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
	AND descricao_psc NOT LIKE ( '%investi%' ) 
	AND descricao_psc NOT LIKE ( '%despesa%' ) 
	AND descricao_psc NOT LIKE ( '%lucro%' ) 
	AND descricao_psc NOT LIKE ( '%repasse%' ) 
	AND descricao_psc NOT LIKE ( '%transfer%' ) 
	AND descricao_psc NOT LIKE ( '%assess%' ) 
	AND descricao_psc NOT LIKE ( '%administ%' ) 
	AND descricao_psc NOT LIKE ( '%cheque%' ) 
	AND descricao_psc NOT LIKE ( '%compra%' ) 
	AND descricao_psc NOT LIKE ( '%aporte%' ) 
	AND descricao_psc NOT LIKE ( '%financ%' ) 
	AND descricao_psc NOT LIKE ( '%adm%' ) 
	AND descricao_psc NOT LIKE ( '%emprest%' ) 
	AND descricao_psc NOT LIKE ( '%aquisi%' ) 
	AND descricao_psc NOT LIKE ( '%arrenda%' ) 
	AND descricao_psc NOT LIKE ( '%imposto%' ) 
	AND descricao_psc NOT LIKE ( '%retorno%' ) 
	AND descricao_psc NOT LIKE ( '%gest%' ) 
	AND descricao_psc NOT LIKE ( '%tarifa%' ) 
	AND descricao_psc NOT LIKE ( '%honora%' ) 
	AND descricao_psc NOT LIKE ( '%cess%' ) 
	AND descricao_psc NOT LIKE ( '%vended%' ) 
	AND descricao_psc NOT LIKE ( '%result%' ) 
	
) VENDAS";



        public const string TOTAL_CONTRATOS_ATIVOS_FGR_OBRA = @"select COUNT(*) CONTADOR FROM

(
SELECT DISTINCT Empresa_ven,Obra_Ven,Num_Ven
from Vendas v
left join StatusCobranca sc
ON v.StatusCobranca_Ven = '-' + Cast(sc.codigo_stc AS VARCHAR) + '-' 
INNER JOIN ItensVenda
ON Empresa_ven = Empresa_itv 
AND Obra_Ven = Obra_Itv 
AND Num_Ven = NumVend_Itv 
INNER JOIN PrdSrv 
ON numprod_psc = Produto_Itv 
where 
	Status_Ven in (0,3)                            
	AND StatusCobranca_Ven NOT IN ( '-800-', '-1000-', '-1100-', '-206-', '-2-','-910-','-900-','-901-','-1200-','-1300-','-1301-' ) 
	AND Obra_Ven NOT IN ('RJF', 'RJV', 'ADMIN')
    AND Obra_Ven = '{0}'
	AND Empresa_ven NOT IN ( '5', '29', '47','6','3' )
	AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
	AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
	AND descricao_psc NOT LIKE ( '%investi%' ) 
	AND descricao_psc NOT LIKE ( '%despesa%' ) 
	AND descricao_psc NOT LIKE ( '%lucro%' ) 
	AND descricao_psc NOT LIKE ( '%repasse%' ) 
	AND descricao_psc NOT LIKE ( '%transfer%' ) 
	AND descricao_psc NOT LIKE ( '%assess%' ) 
	AND descricao_psc NOT LIKE ( '%administ%' ) 
	AND descricao_psc NOT LIKE ( '%cheque%' ) 
	AND descricao_psc NOT LIKE ( '%compra%' ) 
	AND descricao_psc NOT LIKE ( '%aporte%' ) 
	AND descricao_psc NOT LIKE ( '%financ%' ) 
	AND descricao_psc NOT LIKE ( '%adm%' ) 
	AND descricao_psc NOT LIKE ( '%emprest%' ) 
	AND descricao_psc NOT LIKE ( '%aquisi%' ) 
	AND descricao_psc NOT LIKE ( '%arrenda%' ) 
	AND descricao_psc NOT LIKE ( '%imposto%' ) 
	AND descricao_psc NOT LIKE ( '%retorno%' ) 
	AND descricao_psc NOT LIKE ( '%gest%' ) 
	AND descricao_psc NOT LIKE ( '%tarifa%' ) 
	AND descricao_psc NOT LIKE ( '%honora%' ) 
	AND descricao_psc NOT LIKE ( '%cess%' ) 
	AND descricao_psc NOT LIKE ( '%vended%' ) 
	AND descricao_psc NOT LIKE ( '%result%' ) 
	
) VENDAS



";





        public const string TOTAL_CONTRATOS_INADIMPLENTES_FGR = @"SELECT Count(*) CONTADOR
FROM   (SELECT contasrecebercalc.empresa_crc             AS Empresa, 
               contasrecebercalc.obra_crc                AS Obra, 
               contasrecebercalc.numvend_crc             AS Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103)    AS [Data do Contrato], 
               vendas.valortot_ven                       AS [Valor da Unidade], 
               p.nome_pes                                AS Cliente, 
               COALESCE(vendas.statusescritura_ven, '-') AS [Status Escritura], 
               COALESCE(se.desc_ste, '-')                AS 
               [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-')              AS StatusCobranca, 
               COALESCE(sc.desc_stc, '-')                AS 
               [Desc Status Cobrança] 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN OBRAS 
                       ON COD_OBR = OBRA_CRC 
                          AND EMPRESA_OBR = EMPRESA_CRC 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  produto_itv NOT IN( '30050', '30051', '30052' ) 
                            AND empresa_ven NOT IN( '47', '6' ) 
                            AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
                            AND descricao_psc NOT LIKE ( '%investi%' ) 
                            AND descricao_psc NOT LIKE ( '%despesa%' ) 
                            AND descricao_psc NOT LIKE ( '%lucro%' ) 
                            AND descricao_psc NOT LIKE ( '%repasse%' ) 
                            AND descricao_psc NOT LIKE ( '%transfer%' ) 
                            AND descricao_psc NOT LIKE ( '%assess%' ) 
                            AND descricao_psc NOT LIKE ( '%administ%' ) 
                            AND descricao_psc NOT LIKE ( '%cheque%' ) 
                            AND descricao_psc NOT LIKE ( '%compra%' ) 
                            AND descricao_psc NOT LIKE ( '%aporte%' ) 
                            AND descricao_psc NOT LIKE ( '%financ%' ) 
                            AND descricao_psc NOT LIKE ( '%adm%' ) 
                            AND descricao_psc NOT LIKE ( '%emprest%' ) 
                            AND descricao_psc NOT LIKE ( '%aquisi%' ) 
                            AND descricao_psc NOT LIKE ( '%arrenda%' ) 
                            AND descricao_psc NOT LIKE ( '%imposto%' ) 
                            AND descricao_psc NOT LIKE ( '%retorno%' ) 
                            AND descricao_psc NOT LIKE ( '%gest%' ) 
                            AND descricao_psc NOT LIKE ( '%tarifa%' ) 
                            AND descricao_psc NOT LIKE ( '%honora%' ) 
                            AND descricao_psc NOT LIKE ( '%cess%' ) 
                            AND descricao_psc NOT LIKE ( '%vended%' ) 
                            AND descricao_psc NOT LIKE ( '%result%' ) 
                            AND statuscobranca_ven NOT IN ( 
                                '-800-', '-1000-', '-1100-', 
                                '-206-', 
                                '-203-', '-500-', '-501-', '-2-' ) 
                            AND NOT obra_ven IN ( 'RJF', 'RJV', 'ADMIN' ) 
                            AND empresa_ven NOT IN ( '5', '29', '3' )) 
                    TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE 
		Datediff(day, data_prc, Getdate()) > 0
         and 
		 status_obr = '0' 
         AND statuscobranca_ven NOT IN ( '-800-', '-1000-', '-1100-', '-206-', 
                                         '-2-','-910-','-900-','-901-','-1200-','-1300-','-1301-' ) 
         AND valparcela_crc > '1' 
         AND NOT vendas.obra_ven IN ( 'RJF', 'RJV', 'ADMIN' ) 
         AND vendas.empresa_ven NOT IN ( '5', '29' ) 
         AND vendas.status_ven <> 1
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia";



        public const string TOTAL_CONTRATOS_INADIMPLENTES_FGR_OBRA = @"SELECT Count(*) CONTADOR
FROM   (SELECT contasrecebercalc.empresa_crc             AS Empresa, 
               contasrecebercalc.obra_crc                AS Obra, 
               contasrecebercalc.numvend_crc             AS Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103)    AS [Data do Contrato], 
               vendas.valortot_ven                       AS [Valor da Unidade], 
               p.nome_pes                                AS Cliente, 
               COALESCE(vendas.statusescritura_ven, '-') AS [Status Escritura], 
               COALESCE(se.desc_ste, '-')                AS 
               [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-')              AS StatusCobranca, 
               COALESCE(sc.desc_stc, '-')                AS 
               [Desc Status Cobrança] 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN OBRAS 
                       ON COD_OBR = OBRA_CRC 
                          AND EMPRESA_OBR = EMPRESA_CRC 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  produto_itv NOT IN( '30050', '30051', '30052' ) 
                            AND empresa_ven NOT IN( '47', '6' ) 
                            AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
                            AND descricao_psc NOT LIKE ( '%investi%' ) 
                            AND descricao_psc NOT LIKE ( '%despesa%' ) 
                            AND descricao_psc NOT LIKE ( '%lucro%' ) 
                            AND descricao_psc NOT LIKE ( '%repasse%' ) 
                            AND descricao_psc NOT LIKE ( '%transfer%' ) 
                            AND descricao_psc NOT LIKE ( '%assess%' ) 
                            AND descricao_psc NOT LIKE ( '%administ%' ) 
                            AND descricao_psc NOT LIKE ( '%cheque%' ) 
                            AND descricao_psc NOT LIKE ( '%compra%' ) 
                            AND descricao_psc NOT LIKE ( '%aporte%' ) 
                            AND descricao_psc NOT LIKE ( '%financ%' ) 
                            AND descricao_psc NOT LIKE ( '%adm%' ) 
                            AND descricao_psc NOT LIKE ( '%emprest%' ) 
                            AND descricao_psc NOT LIKE ( '%aquisi%' ) 
                            AND descricao_psc NOT LIKE ( '%arrenda%' ) 
                            AND descricao_psc NOT LIKE ( '%imposto%' ) 
                            AND descricao_psc NOT LIKE ( '%retorno%' ) 
                            AND descricao_psc NOT LIKE ( '%gest%' ) 
                            AND descricao_psc NOT LIKE ( '%tarifa%' ) 
                            AND descricao_psc NOT LIKE ( '%honora%' ) 
                            AND descricao_psc NOT LIKE ( '%cess%' ) 
                            AND descricao_psc NOT LIKE ( '%vended%' ) 
                            AND descricao_psc NOT LIKE ( '%result%' ) 
                            AND statuscobranca_ven NOT IN ( 
                                '-800-', '-1000-', '-1100-', 
                                '-206-', 
                                '-203-', '-500-', '-501-', '-2-' ) 
                            AND NOT obra_ven IN ( 'RJF', 'RJV', 'ADMIN' )
                            AND OBRA_VEN = '{0}' 
                            AND empresa_ven NOT IN ( '5', '29', '3' )) 
                    TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE 
		Datediff(day, data_prc, Getdate()) > 0
         and 
		 status_obr = '0' 
         AND statuscobranca_ven NOT IN ( '-800-', '-1000-', '-1100-', '-206-', 
                                         '-2-','-910-','-900-','-901-','-1200-','-1300-','-1301-' ) 
         AND valparcela_crc > '1' 
         AND NOT vendas.obra_ven IN ( 'RJF', 'RJV', 'ADMIN' ) 
         AND vendas.OBRA_VEN = '{1}'
         AND vendas.empresa_ven NOT IN ( '5', '29' ) 
         AND vendas.status_ven <> 1
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia";

        public const string TOTAL_CONTRATOS_INADIMPLENTES90_FGR = @"SELECT Count(*) CONTADOR
FROM   (SELECT contasrecebercalc.empresa_crc             AS Empresa, 
               contasrecebercalc.obra_crc                AS Obra, 
               contasrecebercalc.numvend_crc             AS Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103)    AS [Data do Contrato], 
               vendas.valortot_ven                       AS [Valor da Unidade], 
               p.nome_pes                                AS Cliente, 
               COALESCE(vendas.statusescritura_ven, '-') AS [Status Escritura], 
               COALESCE(se.desc_ste, '-')                AS 
               [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-')              AS StatusCobranca, 
               COALESCE(sc.desc_stc, '-')                AS 
               [Desc Status Cobrança] 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN OBRAS 
                       ON COD_OBR = OBRA_CRC 
                          AND EMPRESA_OBR = EMPRESA_CRC 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  produto_itv NOT IN( '30050', '30051', '30052' ) 
                            AND empresa_ven NOT IN( '47', '6' ) 
                            AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
                            AND descricao_psc NOT LIKE ( '%investi%' ) 
                            AND descricao_psc NOT LIKE ( '%despesa%' ) 
                            AND descricao_psc NOT LIKE ( '%lucro%' ) 
                            AND descricao_psc NOT LIKE ( '%repasse%' ) 
                            AND descricao_psc NOT LIKE ( '%transfer%' ) 
                            AND descricao_psc NOT LIKE ( '%assess%' ) 
                            AND descricao_psc NOT LIKE ( '%administ%' ) 
                            AND descricao_psc NOT LIKE ( '%cheque%' ) 
                            AND descricao_psc NOT LIKE ( '%compra%' ) 
                            AND descricao_psc NOT LIKE ( '%aporte%' ) 
                            AND descricao_psc NOT LIKE ( '%financ%' ) 
                            AND descricao_psc NOT LIKE ( '%adm%' ) 
                            AND descricao_psc NOT LIKE ( '%emprest%' ) 
                            AND descricao_psc NOT LIKE ( '%aquisi%' ) 
                            AND descricao_psc NOT LIKE ( '%arrenda%' ) 
                            AND descricao_psc NOT LIKE ( '%imposto%' ) 
                            AND descricao_psc NOT LIKE ( '%retorno%' ) 
                            AND descricao_psc NOT LIKE ( '%gest%' ) 
                            AND descricao_psc NOT LIKE ( '%tarifa%' ) 
                            AND descricao_psc NOT LIKE ( '%honora%' ) 
                            AND descricao_psc NOT LIKE ( '%cess%' ) 
                            AND descricao_psc NOT LIKE ( '%vended%' ) 
                            AND descricao_psc NOT LIKE ( '%result%' ) 
                            AND statuscobranca_ven NOT IN ( 
                                '-800-', '-1000-', '-1100-', 
                                '-206-', 
                                '-203-', '-500-', '-501-', '-2-' ) 
                            AND NOT obra_ven IN ( 'RJF', 'RJV', 'ADMIN' ) 
                            AND empresa_ven NOT IN ( '5', '29', '3' )) 
                    TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE 
		Datediff(day, data_prc, Getdate()) > 90
         and 
		 status_obr = '0' 
         AND statuscobranca_ven NOT IN ( '-800-', '-1000-', '-1100-', '-206-', 
                                         '-2-','-910-','-900-','-901-','-1200-','-1300-','-1301-' ) 
         AND valparcela_crc > '1' 
         AND NOT vendas.obra_ven IN ( 'RJF', 'RJV', 'ADMIN' ) 
         AND vendas.empresa_ven NOT IN ( '5', '29' ) 
         AND vendas.status_ven <> 1
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia";

        public const string TOTAL_CONTRATOS_INADIMPLENTES90_FGR_OBRA = @"SELECT Count(*) CONTADOR
FROM   (SELECT contasrecebercalc.empresa_crc             AS Empresa, 
               contasrecebercalc.obra_crc                AS Obra, 
               contasrecebercalc.numvend_crc             AS Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103)    AS [Data do Contrato], 
               vendas.valortot_ven                       AS [Valor da Unidade], 
               p.nome_pes                                AS Cliente, 
               COALESCE(vendas.statusescritura_ven, '-') AS [Status Escritura], 
               COALESCE(se.desc_ste, '-')                AS 
               [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-')              AS StatusCobranca, 
               COALESCE(sc.desc_stc, '-')                AS 
               [Desc Status Cobrança] 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN OBRAS 
                       ON COD_OBR = OBRA_CRC 
                          AND EMPRESA_OBR = EMPRESA_CRC 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  produto_itv NOT IN( '30050', '30051', '30052' ) 
                            AND empresa_ven NOT IN( '47', '6' ) 
                            AND descricao_psc NOT LIKE ( '%REEMBOL%' ) 
                            AND descricao_psc NOT LIKE ( '%investi%' ) 
                            AND descricao_psc NOT LIKE ( '%despesa%' ) 
                            AND descricao_psc NOT LIKE ( '%lucro%' ) 
                            AND descricao_psc NOT LIKE ( '%repasse%' ) 
                            AND descricao_psc NOT LIKE ( '%transfer%' ) 
                            AND descricao_psc NOT LIKE ( '%assess%' ) 
                            AND descricao_psc NOT LIKE ( '%administ%' ) 
                            AND descricao_psc NOT LIKE ( '%cheque%' ) 
                            AND descricao_psc NOT LIKE ( '%compra%' ) 
                            AND descricao_psc NOT LIKE ( '%aporte%' ) 
                            AND descricao_psc NOT LIKE ( '%financ%' ) 
                            AND descricao_psc NOT LIKE ( '%adm%' ) 
                            AND descricao_psc NOT LIKE ( '%emprest%' ) 
                            AND descricao_psc NOT LIKE ( '%aquisi%' ) 
                            AND descricao_psc NOT LIKE ( '%arrenda%' ) 
                            AND descricao_psc NOT LIKE ( '%imposto%' ) 
                            AND descricao_psc NOT LIKE ( '%retorno%' ) 
                            AND descricao_psc NOT LIKE ( '%gest%' ) 
                            AND descricao_psc NOT LIKE ( '%tarifa%' ) 
                            AND descricao_psc NOT LIKE ( '%honora%' ) 
                            AND descricao_psc NOT LIKE ( '%cess%' ) 
                            AND descricao_psc NOT LIKE ( '%vended%' ) 
                            AND descricao_psc NOT LIKE ( '%result%' ) 
                            AND statuscobranca_ven NOT IN ( 
                                '-800-', '-1000-', '-1100-', 
                                '-206-', 
                                '-203-', '-500-', '-501-', '-2-' ) 
                            AND NOT obra_ven IN ( 'RJF', 'RJV', 'ADMIN' )
                            AND OBRA_VEN = '{0}' 
                            AND empresa_ven NOT IN ( '5', '29', '3' )) 
                    TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE 
		Datediff(day, data_prc, Getdate()) > 90
         and 
		 status_obr = '0' 
         AND statuscobranca_ven NOT IN ( '-800-', '-1000-', '-1100-', '-206-', 
                                         '-2-','-910-','-900-','-901-','-1200-','-1300-','-1301-' ) 
         AND valparcela_crc > '1' 
         AND NOT vendas.obra_ven IN ( 'RJF', 'RJV', 'ADMIN' ) 
         AND vendas.OBRA_VEN = '{1}'
         AND vendas.empresa_ven NOT IN ( '5', '29' ) 
        AND vendas.status_ven <> 1
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia";

        public const string FATO_INADIMPLENCIA_FGR = @"select 

*,
(case when (StatusCobranca = 500 or StatusCobranca = 501 or StatusCobranca = 502) then 'F' when (StatusCobranca = 2051) then 'G' else (case when (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) = 'E+' and StatusCobranca='203' then 'E-' else (case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) + (case when ((case when (FrequenciaMedia <0.11) then 'E+' when (FrequenciaMedia >=0.11 and FrequenciaMedia <=0.22 ) then 'D' when (FrequenciaMedia >0.22 and FrequenciaMedia <=0.44 ) then 'C' when (FrequenciaMedia >0.44 and FrequenciaMedia <=0.89 ) then 'B' when (FrequenciaMedia >0.89) then 'A' else 'AJUSTAR' end) = 'B') then (case when RecebimentoUltimos2Meses =0 then '-' else '+' end )  else '' end) end)  end) ClassificacaoContrato 


from 





(select 

CAST ( ContasReceberCalc.empresa_crc AS VARCHAR )+'-'+ CAST (ContasReceberCalc.obra_crc AS VARCHAR ) +'-'+ CAST ( ContasReceberCalc.numvend_crc AS VARCHAR ) AS EmpObraVen,
ContasReceberCalc.empresa_crc as Empresa, 
ContasReceberCalc.obra_crc as Obra , 
ContasReceberCalc.numvend_crc as Venda,
CONVERT(VARCHAR, Vendas.data_ven, 103) AS [Data do Contrato],
vendas.valortot_ven as [Valor da Unidade],
p.nome_pes   as                   Cliente ,
(STUFF((select CAST(', ' + [Identificador_unid] AS VARCHAR(MAX)) from itensvenda iv LEFT JOIN unidadeper up ON iv.empresa_itv = up.empresa_unid AND iv.obra_itv = up.obra_unid AND iv.produto_itv = up.prod_unid AND iv.codperson_itv = up.numper_unid LEFT JOIN prdsrvcat prdc ON prdc.codprod_cp = iv.produto_itv  where  ContasReceberCalc.empresa_crc = iv.empresa_itv  AND ContasReceberCalc.numvend_crc = iv.numvend_itv AND ContasReceberCalc.obra_crc = iv.obra_itv and iv.codperson_itv >0 and prdc.codcat_cp IN ( '100', '102' ) FOR XML PATH ('') ), 1, 2, '')) AS [Quadra e Lote],
(STUFF((select CAST(', ' + convert(varchar,convert(money,[qtde_unid])) AS VARCHAR(MAX)) from itensvenda iv LEFT JOIN unidadeper up ON iv.empresa_itv = up.empresa_unid AND iv.obra_itv = up.obra_unid AND iv.produto_itv = up.prod_unid AND iv.codperson_itv = up.numper_unid LEFT JOIN prdsrvcat prdc ON prdc.codprod_cp = iv.produto_itv  where  ContasReceberCalc.empresa_crc = iv.empresa_itv  AND ContasReceberCalc.numvend_crc = iv.numvend_itv AND ContasReceberCalc.obra_crc = iv.obra_itv and iv.codperson_itv >0 and prdc.codcat_cp IN ( '100', '102' ) FOR XML PATH ('') ), 1, 2, '')) AS [Area do Terreno],
				                COALESCE(vendas.statusescritura_ven, '-') AS [Status Escritura], 
                COALESCE(se.desc_ste, '-')            AS [Desc Status Escritura], 
                COALESCE(sc.codigo_stc, '-')          AS StatusCobranca, 
                COALESCE(sc.desc_stc, '-')            AS [Desc Status Cobrança],
(select count(*) from recebidas where Empresa_rec=ContasReceberCalc.empresa_crc and Obra_Rec=ContasReceberCalc.obra_crc and NumVend_Rec = ContasReceberCalc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9') as [Frequencia 9 Meses],
convert(decimal(18,2),(select count(*) from recebidas where Empresa_rec=ContasReceberCalc.empresa_crc and Obra_Rec=ContasReceberCalc.obra_crc and NumVend_Rec = ContasReceberCalc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '9'))/9 as FrequenciaMedia,
(select count(*) from recebidas where Empresa_rec=ContasReceberCalc.empresa_crc and Obra_Rec=ContasReceberCalc.obra_crc and NumVend_Rec = ContasReceberCalc.numvend_crc and Datediff (month, data_rec, Getdate ()) <= '2') as RecebimentoUltimos2Meses,
count(*) [Quantidade Parcelas Aberto],
sum(ValParcela_crc) [Valor Parcelas Aberto],
coalesce((select sum((ValorConf_Rec + Valor_Rec)) from recebidas where Empresa_rec=ContasReceberCalc.empresa_crc and Obra_Rec=ContasReceberCalc.obra_crc and NumVend_Rec = ContasReceberCalc.numvend_crc),0) as ValorRecebidoVGV,
sum(Valjuroatraso_crc) ValorJurosAtraso,
sum(Valmultaatraso_crc) ValorMultaAtraso,
sum(Valcorrecaoatraso_crc) ValorCorrecaoAtraso








		 
		 
		 
		 		from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

																	       INNER JOIN (SELECT * 
                   FROM   vendaclientes 
                   WHERE  emiteboleto_cven = '1') vc 
               ON vendas.empresa_ven = vc.empresa_cven 
                  AND vendas.obra_ven = vc.obra_cven 
                  AND vendas.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 

			  LEFT JOIN statusescritura se
              ON vendas.statusescritura_ven = '-' 
                                          + Cast(se.codigo_ste AS 
                                          VARCHAR) 
                                          + '-' 
       LEFT JOIN statuscobranca sc
              ON vendas.statuscobranca_ven = '-' 
                                         + Cast(sc.codigo_stc AS 
                                         VARCHAR) 
                                         + '-' 





																	join
																	(SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where Produto_Itv NOT IN('30050','30051','30052') AND Empresa_ven NOT IN('47','6') and
                                                                    Descricao_psc not Like ('%REEMBOL%') and 
                                                                    Descricao_psc not Like ('%investi%')and 
                                                                    Descricao_psc not Like ('%despesa%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                    Descricao_psc not Like ('%repasse%')and
                                                                    Descricao_psc not Like ('%transfer%')and
                                                                    Descricao_psc not Like ('%assess%')and
                                                                    Descricao_psc not Like ('%administ%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%imposto%')and
                                                                    Descricao_psc not Like ('%retorno%')and
                                                                    Descricao_psc not Like ('%gest%')and
                                                                    Descricao_psc not Like ('%tarifa%')and
                                                                    Descricao_psc not Like ('%honora%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') 
                                                                    AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-203-','-500-','-501-','-2-')and not obra_ven in ('RJF','RJV','ADMIN') AND Empresa_ven NOT IN ('5','29','3')) TabRelacaoObras
                                                                    on Empresa_crc = TabRelacaoObras.Empresa_ven and Obra_crc = TabRelacaoObras.Obra_Ven



                                                                    where 
																	--convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,DATEADD(DAY,-2,GETDATE()),103))
																	Data_Prc < convert(datetime,Convert(varchar,DATEADD(DAY,-2,GETDATE()),103))


																	



                                                                    AND Status_obr = '0' AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-2-')
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and not vendas.obra_ven in ('RJF','RJV','ADMIN') AND vendas.Empresa_ven NOT IN ('5','29')


                                                                    group by Empresa_crc,Obra_crc,ContasReceberCalc.numvend_crc,Vendas.data_ven,vendas.valortot_ven,p.nome_pes,vendas.statusescritura_ven,se.desc_ste,sc.codigo_stc,sc.desc_stc


) FatoInadimplecia";

        public const string FECHAMENTO_MENSAL_COBRANCA_FGR = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and
                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and DATEDIFF(month, Data_Rec, getdate()) > -1 and DATEDIFF(month, Data_Rec, getdate()) < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where 
																	
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) = convert(datetime,Convert(varchar,'{0}',103))
																	
                                                                    AND Status_obr = '0' AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-2-')
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and not obra_ven in ('RJF','RJV','ADMIN') AND Empresa_ven NOT IN ('5','29')

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) < convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) > convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where 
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,'{0}',103))
                                                                    AND Status_obr = '0' AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-2-')
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and not obra_ven in ('RJF','RJV','ADMIN') AND Empresa_ven NOT IN ('5','29')

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) >= convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    join

                                                                    (SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where Produto_Itv NOT IN('30050','30051','30052') AND Empresa_ven NOT IN('47','6') and
                                                                    Descricao_psc not Like ('%REEMBOL%') and 
                                                                    Descricao_psc not Like ('%investi%')and 
                                                                    Descricao_psc not Like ('%despesa%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                    Descricao_psc not Like ('%repasse%')and
                                                                    Descricao_psc not Like ('%transfer%')and
                                                                    Descricao_psc not Like ('%assess%')and
                                                                    Descricao_psc not Like ('%administ%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%imposto%')and
                                                                    Descricao_psc not Like ('%retorno%')and
                                                                    Descricao_psc not Like ('%gest%')and
                                                                    Descricao_psc not Like ('%tarifa%')and
                                                                    Descricao_psc not Like ('%honora%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') 
                                                                    AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-203-','-500-','-501-','-2-')and not obra_ven in ('RJF','RJV','ADMIN') AND Empresa_ven NOT IN ('5','29','3')) TabRelacaoObras
                                                                    on Dados.empresa = TabRelacaoObras.Empresa_ven and Dados.obra = TabRelacaoObras.Obra_Ven



                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";
        public const string FECHAMENTO_MENSAL_COBRANCA_FGR_OBRA = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and
                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29')
                                                                    and  obra_rec = '{0}'
                                                                    and DATEDIFF(month, Data_Rec, getdate()) > -1 and DATEDIFF(month, Data_Rec, getdate()) < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{1}',103))
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where 
																	
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) = convert(datetime,Convert(varchar,'{1}',103))
																	
                                                                    AND Status_obr = '0' AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-2-')
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and not obra_ven in ('RJF','RJV','ADMIN') AND Empresa_ven NOT IN ('5','29')
                                                                    and  obra_ven = '{0}'

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and  obra_rec = '{0}'
                                                                    and DATEDIFF(month, Data_Rec, '{1}') > -1 and DATEDIFF(month, Data_Rec, '{1}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{1}',103))

                                                                    and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) < convert(datetime,Convert(varchar,'{1}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and  obra_rec = '{0}'
                                                                    and DATEDIFF(month, Data_Rec, '{1}') > -1 and DATEDIFF(month, Data_Rec, '{1}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{1}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) > convert(datetime,Convert(varchar,'{1}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where 
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,'{1}',103))
                                                                    AND Status_obr = '0' AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-2-')
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and not obra_ven in ('RJF','RJV','ADMIN') AND Empresa_ven NOT IN ('5','29')
                                                                     and  obra_ven = '{0}'

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and  obra_rec = '{0}'
                                                                    and DATEDIFF(month, Data_Rec, '{1}') > -1 and DATEDIFF(month, Data_Rec, '{1}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{1}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) >= convert(datetime,Convert(varchar,'{1}',103))


                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                     Descricao_psc not Like ('%REEMB%') and 
                                                                    Descricao_psc not Like ('%inves%')and 
                                                                    Descricao_psc not Like ('%despes%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                     Descricao_psc not Like ('%repass%')and
                                                                     Descricao_psc not Like ('%transfe%')and
                                                                    Descricao_psc not Like ('%asses%')and
                                                                    Descricao_psc not Like ('%admin%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') and


                                                                    not obra_rec in ('RJF','RJV','ADMIN') AND Empresa_rec NOT IN ('5','29') 
                                                                    and  obra_rec = '{0}'
                                                                    and DATEDIFF(month, Data_Rec, '{1}') > -1 and DATEDIFF(month, Data_Rec, '{1}') < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{1}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) = convert(datetime,Convert(varchar,'{1}',103))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    join

                                                                    (SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where Produto_Itv NOT IN('30050','30051','30052') AND Empresa_ven NOT IN('47','6') and
                                                                    Descricao_psc not Like ('%REEMBOL%') and 
                                                                    Descricao_psc not Like ('%investi%')and 
                                                                    Descricao_psc not Like ('%despesa%')and 
                                                                    Descricao_psc not Like ('%lucro%')and
                                                                    Descricao_psc not Like ('%repasse%')and
                                                                    Descricao_psc not Like ('%transfer%')and
                                                                    Descricao_psc not Like ('%assess%')and
                                                                    Descricao_psc not Like ('%administ%')and
                                                                    Descricao_psc not Like ('%cheque%')and
                                                                    Descricao_psc not Like ('%compra%')and
                                                                    Descricao_psc not Like ('%aporte%')and
                                                                    Descricao_psc not Like ('%financ%')and
                                                                    Descricao_psc not Like ('%adm%') and
                                                                    Descricao_psc not Like ('%emprest%') and
                                                                    Descricao_psc not Like ('%aquisi%')and
                                                                    Descricao_psc not Like ('%arrenda%')and
                                                                    Descricao_psc not Like ('%imposto%')and
                                                                    Descricao_psc not Like ('%retorno%')and
                                                                    Descricao_psc not Like ('%gest%')and
                                                                    Descricao_psc not Like ('%tarifa%')and
                                                                    Descricao_psc not Like ('%honora%')and
                                                                    Descricao_psc not Like ('%cess%')and
                                                                    Descricao_psc not Like ('%vended%')and
                                                                    Descricao_psc not Like ('%result%') 
                                                                    AND StatusCobranca_Ven NOT IN ('-800-','-1000-','-1100-','-206-','-203-','-500-','-501-','-2-')and not obra_ven in ('RJF','RJV','ADMIN') 
                                                                    and  obra_ven = '{0}'
                                                                    AND Empresa_ven NOT IN ('5','29','3')) TabRelacaoObras
                                                                    on Dados.empresa = TabRelacaoObras.Empresa_ven and Dados.obra = TabRelacaoObras.Obra_Ven



                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";


        public const string PARCELAS_INADIMPLENCIA_FGR = @"select distinct
                                                        (CASE WHEN TIPO_CRC='1' THEN COALESCE((SELECT '1 - Custas ('+ Descr_Ctp +')' FROM CustasTipo WHERE Num_Ctp = NumCtp_Prc),(pc.Tipo_par + ' - '+ pc.Descricao_par)) ELSE (pc.Tipo_par + ' - '+ pc.Descricao_par) END)                                      TipoParcela,
                                                        pc.Tipo_par,
                                                        crc.NumParc_crc as NumeroParcela,
                                                        crc.NumParcGer_crc as NumeroParcelaGeral,
                                                        crc.ValParcela_crc as ValorParcelaReajustado,
                                                        cr.Valor_Prc as ValorParcelaOriginal,
                                                        convert(varchar,cr.Data_Prc,103) as DataVencimento,
                                                        convert(varchar,cr.DataPror_Prc,103) as DataProrrogacao,
                                                        DATEDIFF(month,cr.Data_Prc,GETDATE()) AgingParcela,
														ValMultaAtraso_crc as ValorMultaAtraso,
														ValJuroAtraso_crc as ValorJurosAtraso,
														IdxReaj_Prc as IndiceReajusteVenda,
														JurosParc_Prc*100 as TaxaJurosVenda,
														convert(varchar,DataCalc_crc,103) as DataCalculo
                                                        FROM   contasrecebercalc crc 
                                                               INNER JOIN contasreceber cr 
                                                                       ON cr.empresa_prc = crc.empresa_crc 
                                                                          AND cr.obra_prc = crc.obra_crc 
                                                                          AND cr.numvend_prc = crc.numvend_crc 
                                                                          AND cr.numparc_prc = crc.numparc_crc 
                                                                          AND cr.numparcger_prc = crc.numparcger_crc 
                                                                          AND cr.tipo_prc = crc.tipo_crc 
                                                               INNER JOIN vendas v 
                                                                       ON v.empresa_ven = crc.empresa_crc 
                                                                          AND v.obra_ven = crc.obra_crc 
                                                                          AND v.num_ven = crc.numvend_crc 
                                                               INNER JOIN (SELECT * 
                                                                           FROM   vendaclientes 
                                                                           WHERE  emiteboleto_cven = '1') vc 
                                                                       ON v.empresa_ven = vc.empresa_cven 
                                                                          AND v.obra_ven = vc.obra_cven 
                                                                          AND v.num_ven = vc.num_cven 
                                                               INNER JOIN pessoas p 
                                                                       ON vc.cliente_cven = p.cod_pes 
                                                               INNER JOIN itensvenda iv 
                                                                       ON crc.empresa_crc = iv.empresa_itv 
                                                                          AND crc.numvend_crc = iv.numvend_itv 
                                                                          AND crc.obra_crc = iv.obra_itv 
                                                               LEFT JOIN unidadeper up 
                                                                      ON iv.empresa_itv = up.empresa_unid 
                                                                         AND iv.obra_itv = up.obra_unid 
                                                                         AND iv.produto_itv = up.prod_unid 
                                                                         AND iv.codperson_itv = up.numper_unid 
                                                               INNER JOIN prdsrv prd 
                                                                       ON prd.numprod_psc = iv.produto_itv 
                                                               LEFT JOIN prdsrvcat prdc 
                                                                      ON prdc.codprod_cp = iv.produto_itv 

			                                                          LEFT JOIN statusescritura se
                                                                      ON v.statusescritura_ven LIKE '%-' 
                                                                                                  + Cast(se.codigo_ste AS 
                                                                                                  VARCHAR) 
                                                                                                  + '-%' 
                                                               LEFT JOIN statuscobranca sc
                                                                      ON v.statuscobranca_ven LIKE '%-' 
                                                                                                 + Cast(sc.codigo_stc AS 
                                                                                                 VARCHAR) 
                                                                                                 + '-%' 
		                                                        JOIN parcelas pc
		                                                        on crc.Tipo_crc = pc.Tipo_par
                                                        WHERE  crc.valparcela_crc > 1 
                                                               AND Datediff(day, cr.data_prc, Getdate()) >= '2' 
	                                                           AND crc.Empresa_crc = {0}
	                                                           AND crc.Obra_crc = '{1}'
	                                                           AND crc.NumVend_crc = {2}";



        #endregion

        #region Cobranca_GPL

        public const string FATO_INADIMPLENCIA_GPL = @"SELECT *, 
       ( CASE 
           WHEN ( statuscobranca = 500 
                   OR statuscobranca = 501 
                   OR statuscobranca = 502 ) THEN 'F' 
           WHEN ( statuscobranca = 2051 ) THEN 'G' 
           ELSE ( CASE 
                    WHEN ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) = 'E+' 
                         AND statuscobranca = '203' THEN 'E-' 
                    ELSE ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) 
                  END ) 
         END ) ClassificacaoContrato 
FROM   (SELECT Cast ( contasrecebercalc.empresa_crc AS VARCHAR ) 
               + '-' 
               + Cast (contasrecebercalc.obra_crc AS VARCHAR ) 
               + '-' 
               + Cast ( contasrecebercalc.numvend_crc AS VARCHAR ) 
               AS 
                      EmpObraVen, 
               contasrecebercalc.empresa_crc 
               AS 
                      Empresa, 
               contasrecebercalc.obra_crc 
               AS 
                      Obra, 
               contasrecebercalc.numvend_crc 
               AS 
                      Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103) 
               AS 
                      [Data do Contrato], 
               vendas.valortot_ven 
               AS 
                      [Valor da Unidade], 
               p.nome_pes 
               AS 
                      Cliente, 
               ( Stuff((SELECT Cast(', ' + [identificador_unid] AS VARCHAR(max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Quadra e Lote], 
               ( Stuff((SELECT Cast(', ' 
                                    + CONVERT(VARCHAR, CONVERT(MONEY, 
                                    [qtde_unid])) AS 
                                    VARCHAR( 
                                      max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                               AND prdc.codcat_cp IN ( '100', '102' ) 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Area do Terreno], 
               COALESCE(vendas.statusescritura_ven, '-') 
               AS 
                      [Status Escritura], 
               COALESCE(se.desc_ste, '-') 
               AS 
                      [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-') 
               AS 
                      StatusCobranca, 
               COALESCE(sc.desc_stc, '-') 
               AS 
                      [Desc Status Cobrança], 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '9') 
               AS 
               [Frequencia 9 Meses], 
               CONVERT(DECIMAL(18, 2), (SELECT Count(*) 
                                        FROM   recebidas 
                                        WHERE  empresa_rec = 
                                               contasrecebercalc.empresa_crc 
                                               AND obra_rec = 
                                                   contasrecebercalc.obra_crc 
                                               AND numvend_rec = 
                                                   contasrecebercalc.numvend_crc 
                                               AND Datediff (month, data_rec, 
                                                   Getdate ( 
                                                   )) <= 
                                                   '9')) / 9 
               AS 
                      FrequenciaMedia, 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '2') 
               AS 
               RecebimentoUltimos2Meses, 
               Count(*) 
                      [Quantidade Parcelas Aberto], 
               Sum(valparcela_crc) 
                      [Valor Parcelas Aberto], 
               COALESCE((SELECT Sum(( valorconf_rec + valor_rec )) 
                         FROM   recebidas 
                         WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                                AND obra_rec = contasrecebercalc.obra_crc 
                                AND numvend_rec = 
               contasrecebercalc.numvend_crc), 0) AS 
               ValorRecebidoVGV, 
               Sum(valjuroatraso_crc) 
                      ValorJurosAtraso, 
               Sum(valmultaatraso_crc) 
                      ValorMultaAtraso, 
               Sum(valcorrecaoatraso_crc) 
                      ValorCorrecaoAtraso 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN obras 
                       ON cod_obr = obra_crc 
                          AND empresa_obr = empresa_crc 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  
                    
                     (empresa_ven = 5 and obra_ven='RJA') 
                    or (empresa_ven = 8 and obra_ven='RPA')
                    or (empresa_ven = 9 and obra_ven='ROP')
                    or (empresa_ven = 10 and obra_ven='RJG')
                    or (empresa_ven = 13 and obra_ven='RMA')
                    or (empresa_ven = 14 and obra_ven='ADM')
                    or (empresa_ven = 14 and obra_ven='RT9')
                    or (empresa_ven = 15 and obra_ven='ADM')
                    or (empresa_ven = 28 and obra_ven='ADM')

                ) TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE  data_prc < Dateadd(day, -2, Getdate()) 
               AND status_obr = '0' 
               AND Datediff(month, data_prc, Getdate()) > -1 
               AND valparcela_crc > '1' 
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia ";

        public const string FECHAMENTO_MENSAL_COBRANCA_GPL = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 5 and obra_rec='RJA') 
                                                                        or (Empresa_rec = 8 and obra_rec='RPA')
                                                                        or (Empresa_rec = 9 and obra_rec='ROP')
                                                                        or (Empresa_rec = 10 and obra_rec='RJG')
                                                                        or (Empresa_rec = 13 and obra_rec='RMA')
                                                                        or (Empresa_rec = 14 and obra_rec='ADM')
                                                                        or (Empresa_rec = 14 and obra_rec='RT9')
                                                                        or (Empresa_rec = 15 and obra_rec='ADM')
                                                                        or (Empresa_rec = 28 and obra_rec='ADM'))
                                                                    and DATEDIFF(month, Data_Rec, getdate()) > -1 and DATEDIFF(month, Data_Rec, getdate()) < 96 and
																	year(DataVenci_Rec) = year(convert(datetime,'{0}')) and month(DataVenci_Rec) = month(convert(datetime,'{0}'))
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where 
																	
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) = convert(datetime,Convert(varchar,'{0}',103))
																	
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 
                                                                         ((Empresa_ven = 5 and Obra_Ven='RJA') 
                                                                        or (Empresa_ven = 8 and Obra_Ven='RPA')
                                                                        or (Empresa_ven = 9 and Obra_Ven='ROP')
                                                                        or (Empresa_ven = 10 and Obra_Ven='RJG')
                                                                        or (Empresa_ven = 13 and Obra_Ven='RMA')
                                                                        or (Empresa_ven = 14 and Obra_Ven='ADM')
                                                                        or (Empresa_ven = 14 and Obra_Ven='RT9')
                                                                        or (Empresa_ven = 15 and Obra_Ven='ADM')
                                                                        or (Empresa_ven = 28 and Obra_Ven='ADM'))

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                                                                                            ((Empresa_rec = 5 and obra_rec='RJA') 
                                                                        or (Empresa_rec = 8 and obra_rec='RPA')
                                                                        or (Empresa_rec = 9 and obra_rec='ROP')
                                                                        or (Empresa_rec = 10 and obra_rec='RJG')
                                                                        or (Empresa_rec = 13 and obra_rec='RMA')
                                                                        or (Empresa_rec = 14 and obra_rec='ADM')
                                                                        or (Empresa_rec = 14 and obra_rec='RT9')
                                                                        or (Empresa_rec = 15 and obra_rec='ADM')
                                                                        or (Empresa_rec = 28 and obra_rec='ADM'))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) < convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                                                                                            ((Empresa_rec = 5 and obra_rec='RJA') 
                                                                        or (Empresa_rec = 8 and obra_rec='RPA')
                                                                        or (Empresa_rec = 9 and obra_rec='ROP')
                                                                        or (Empresa_rec = 10 and obra_rec='RJG')
                                                                        or (Empresa_rec = 13 and obra_rec='RMA')
                                                                        or (Empresa_rec = 14 and obra_rec='ADM')
                                                                        or (Empresa_rec = 14 and obra_rec='RT9')
                                                                        or (Empresa_rec = 15 and obra_rec='ADM')
                                                                        or (Empresa_rec = 28 and obra_rec='ADM'))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) > convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where 
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,'{0}',103))
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 

                                                                         ((Empresa_ven = 5 and Obra_Ven='RJA') 
                                                                        or (Empresa_ven = 8 and Obra_Ven='RPA')
                                                                        or (Empresa_ven = 9 and Obra_Ven='ROP')
                                                                        or (Empresa_ven = 10 and Obra_Ven='RJG')
                                                                        or (Empresa_ven = 13 and Obra_Ven='RMA')
                                                                        or (Empresa_ven = 14 and Obra_Ven='ADM')
                                                                        or (Empresa_ven = 14 and Obra_Ven='RT9')
                                                                        or (Empresa_ven = 15 and Obra_Ven='ADM')
                                                                        or (Empresa_ven = 28 and Obra_Ven='ADM'))

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                                                                                            ((Empresa_rec = 5 and obra_rec='RJA') 
                                                                        or (Empresa_rec = 8 and obra_rec='RPA')
                                                                        or (Empresa_rec = 9 and obra_rec='ROP')
                                                                        or (Empresa_rec = 10 and obra_rec='RJG')
                                                                        or (Empresa_rec = 13 and obra_rec='RMA')
                                                                        or (Empresa_rec = 14 and obra_rec='ADM')
                                                                        or (Empresa_rec = 14 and obra_rec='RT9')
                                                                        or (Empresa_rec = 15 and obra_rec='ADM')
                                                                        or (Empresa_rec = 28 and obra_rec='ADM'))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) >= convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                                                                                            ((Empresa_rec = 5 and obra_rec='RJA') 
                                                                        or (Empresa_rec = 8 and obra_rec='RPA')
                                                                        or (Empresa_rec = 9 and obra_rec='ROP')
                                                                        or (Empresa_rec = 10 and obra_rec='RJG')
                                                                        or (Empresa_rec = 13 and obra_rec='RMA')
                                                                        or (Empresa_rec = 14 and obra_rec='ADM')
                                                                        or (Empresa_rec = 14 and obra_rec='RT9')
                                                                        or (Empresa_rec = 15 and obra_rec='ADM')
                                                                        or (Empresa_rec = 28 and obra_rec='ADM')) 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    join

                                                                    (SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where   

                                                                         ((Empresa_ven = 5 and Obra_Ven='RJA') 
                                                                        or (Empresa_ven = 8 and Obra_Ven='RPA')
                                                                        or (Empresa_ven = 9 and Obra_Ven='ROP')
                                                                        or (Empresa_ven = 10 and Obra_Ven='RJG')
                                                                        or (Empresa_ven = 13 and Obra_Ven='RMA')
                                                                        or (Empresa_ven = 14 and Obra_Ven='ADM')
                                                                        or (Empresa_ven = 14 and Obra_Ven='RT9')
                                                                        or (Empresa_ven = 15 and Obra_Ven='ADM')
                                                                        or (Empresa_ven = 28 and Obra_Ven='ADM'))

                                                                        ) TabRelacaoObras
                                                                    on Dados.empresa = TabRelacaoObras.Empresa_ven and Dados.obra = TabRelacaoObras.Obra_Ven



                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";


        #endregion

        #region Cobranca_CAC

        public const string FATO_INADIMPLENCIA_CAC = @"SELECT *, 
       ( CASE 
           WHEN ( statuscobranca = 500 
                   OR statuscobranca = 501 
                   OR statuscobranca = 502 ) THEN 'F' 
           WHEN ( statuscobranca = 2051 ) THEN 'G' 
           ELSE ( CASE 
                    WHEN ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) = 'E+' 
                         AND statuscobranca = '203' THEN 'E-' 
                    ELSE ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) 
                  END ) 
         END ) ClassificacaoContrato 
FROM   (SELECT Cast ( contasrecebercalc.empresa_crc AS VARCHAR ) 
               + '-' 
               + Cast (contasrecebercalc.obra_crc AS VARCHAR ) 
               + '-' 
               + Cast ( contasrecebercalc.numvend_crc AS VARCHAR ) 
               AS 
                      EmpObraVen, 
               contasrecebercalc.empresa_crc 
               AS 
                      Empresa, 
               contasrecebercalc.obra_crc 
               AS 
                      Obra, 
               contasrecebercalc.numvend_crc 
               AS 
                      Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103) 
               AS 
                      [Data do Contrato], 
               vendas.valortot_ven 
               AS 
                      [Valor da Unidade], 
               p.nome_pes 
               AS 
                      Cliente, 
               ( Stuff((SELECT Cast(', ' + [identificador_unid] AS VARCHAR(max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Quadra e Lote], 
               ( Stuff((SELECT Cast(', ' 
                                    + CONVERT(VARCHAR, CONVERT(MONEY, 
                                    [qtde_unid])) AS 
                                    VARCHAR( 
                                      max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Area do Terreno], 
               COALESCE(vendas.statusescritura_ven, '-') 
               AS 
                      [Status Escritura], 
               COALESCE(se.desc_ste, '-') 
               AS 
                      [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-') 
               AS 
                      StatusCobranca, 
               COALESCE(sc.desc_stc, '-') 
               AS 
                      [Desc Status Cobrança], 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '9') 
               AS 
               [Frequencia 9 Meses], 
               CONVERT(DECIMAL(18, 2), (SELECT Count(*) 
                                        FROM   recebidas 
                                        WHERE  empresa_rec = 
                                               contasrecebercalc.empresa_crc 
                                               AND obra_rec = 
                                                   contasrecebercalc.obra_crc 
                                               AND numvend_rec = 
                                                   contasrecebercalc.numvend_crc 
                                               AND Datediff (month, data_rec, 
                                                   Getdate ( 
                                                   )) <= 
                                                   '9')) / 9 
               AS 
                      FrequenciaMedia, 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '2') 
               AS 
               RecebimentoUltimos2Meses, 
               Count(*) 
                      [Quantidade Parcelas Aberto], 
               Sum(valparcela_crc) 
                      [Valor Parcelas Aberto], 
               COALESCE((SELECT Sum(( valorconf_rec + valor_rec )) 
                         FROM   recebidas 
                         WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                                AND obra_rec = contasrecebercalc.obra_crc 
                                AND numvend_rec = 
               contasrecebercalc.numvend_crc), 0) AS 
               ValorRecebidoVGV, 
               Sum(valjuroatraso_crc) 
                      ValorJurosAtraso, 
               Sum(valmultaatraso_crc) 
                      ValorMultaAtraso, 
               Sum(valcorrecaoatraso_crc) 
                      ValorCorrecaoAtraso 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN obras 
                       ON cod_obr = obra_crc 
                          AND empresa_obr = empresa_crc 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  NOT obra_ven IN ( 'INVES', 'ADM', 'SEDE', 'LOC', 
                                              'RPA4')) TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE  data_prc < Dateadd(day, -2, Getdate()) 
               AND status_obr = '0' 
               AND Datediff(month, data_prc, Getdate()) > -1 
               AND valparcela_crc > '1' 
               AND Tipo_crc not in ('F', 'SB', 'FGT')
               AND NOT vendas.obra_ven IN ( 'REC01', 'ADM01', 'FIN', '009F2', '0018F', '0019F') 
               -- Barbara pediu para incluir a empresa 10 na consulta
               --AND NOT vendas.empresa_ven IN ( '10' ) 
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia ";

        public const string FECHAMENTO_MENSAL_COBRANCA_CAC = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    not obra_rec in ('INVES','ADM','SEDE','LOC','RPA4') 
                                                                    and DATEDIFF(month, Data_Rec, getdate()) > -1 and DATEDIFF(month, Data_Rec, getdate()) < 96 and
																	year(DataVenci_Rec) = year(convert(datetime,'{0}')) and month(DataVenci_Rec) = month(convert(datetime,'{0}'))
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where 
																	
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) = convert(datetime,Convert(varchar,'{0}',103))
																	
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and not obra_ven in ('INVES','ADM','SEDE','LOC','RPA4')

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    not obra_rec in ('INVES','ADM','SEDE','LOC','RPA4')
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) < convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    not obra_rec in ('INVES','ADM','SEDE','LOC','RPA4') 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) > convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where 
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,'{0}',103))
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and not obra_ven in ('INVES','ADM','SEDE','LOC','RPA4')

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    not obra_rec in ('INVES','ADM','SEDE','LOC','RPA4')
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) >= convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    not obra_rec in ('INVES','ADM','SEDE','LOC','RPA4') 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    join

                                                                    (SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where  not obra_ven in ( 'REC01', 'ADM01', 'FIN', '009F2', '0018F', '0019F') 
                                                                            -- Barbara pediu para incluir a empresa 10 na consulta
                                                                            --and not empresa_ven in ( '10') 
                                                                            ) TabRelacaoObras
                                                                    on Dados.empresa = TabRelacaoObras.Empresa_ven and Dados.obra = TabRelacaoObras.Obra_Ven



                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";


        public const string PARCELAS_INADIMPLENCIA_CAC = @"select distinct
                                                        (pc.Tipo_par + ' - '+ pc.Descricao_par) as TipoParcela,
                                                        crc.NumParc_crc as NumeroParcela,
                                                        crc.NumParcGer_crc as NumeroParcelaGeral,
                                                        crc.ValParcela_crc as ValorParcelaReajustado,
                                                        cr.Valor_Prc as ValorParcelaOriginal,
                                                        convert(varchar,cr.Data_Prc,103) as DataVencimento,
                                                        DATEDIFF(month,cr.Data_Prc,GETDATE()) AgingParcela,
														ValMultaAtraso_crc as ValorMultaAtraso,
														ValJuroAtraso_crc as ValorJurosAtraso,
														IdxReaj_Prc as IndiceReajusteVenda,
														JurosParc_Prc*100 as TaxaJurosVenda,
														convert(varchar,DataCalc_crc,103) as DataCalculo
                                                        FROM   contasrecebercalc crc 
                                                               INNER JOIN contasreceber cr 
                                                                       ON cr.empresa_prc = crc.empresa_crc 
                                                                          AND cr.obra_prc = crc.obra_crc 
                                                                          AND cr.numvend_prc = crc.numvend_crc 
                                                                          AND cr.numparc_prc = crc.numparc_crc 
                                                                          AND cr.numparcger_prc = crc.numparcger_crc 
                                                                          AND cr.tipo_prc = crc.tipo_crc 
                                                               INNER JOIN vendas v 
                                                                       ON v.empresa_ven = crc.empresa_crc 
                                                                          AND v.obra_ven = crc.obra_crc 
                                                                          AND v.num_ven = crc.numvend_crc 
                                                               INNER JOIN (SELECT * 
                                                                           FROM   vendaclientes 
                                                                           WHERE  emiteboleto_cven = '1') vc 
                                                                       ON v.empresa_ven = vc.empresa_cven 
                                                                          AND v.obra_ven = vc.obra_cven 
                                                                          AND v.num_ven = vc.num_cven 
                                                               INNER JOIN pessoas p 
                                                                       ON vc.cliente_cven = p.cod_pes 
                                                               INNER JOIN itensvenda iv 
                                                                       ON crc.empresa_crc = iv.empresa_itv 
                                                                          AND crc.numvend_crc = iv.numvend_itv 
                                                                          AND crc.obra_crc = iv.obra_itv 
                                                               LEFT JOIN unidadeper up 
                                                                      ON iv.empresa_itv = up.empresa_unid 
                                                                         AND iv.obra_itv = up.obra_unid 
                                                                         AND iv.produto_itv = up.prod_unid 
                                                                         AND iv.codperson_itv = up.numper_unid 
                                                               INNER JOIN prdsrv prd 
                                                                       ON prd.numprod_psc = iv.produto_itv 
                                                               LEFT JOIN prdsrvcat prdc 
                                                                      ON prdc.codprod_cp = iv.produto_itv 

			                                                          LEFT JOIN statusescritura se
                                                                      ON v.statusescritura_ven LIKE '%-' 
                                                                                                  + Cast(se.codigo_ste AS 
                                                                                                  VARCHAR) 
                                                                                                  + '-%' 
                                                               LEFT JOIN statuscobranca sc
                                                                      ON v.statuscobranca_ven LIKE '%-' 
                                                                                                 + Cast(sc.codigo_stc AS 
                                                                                                 VARCHAR) 
                                                                                                 + '-%' 
		                                                        JOIN parcelas pc
		                                                        on crc.Tipo_crc = pc.Tipo_par
                                                        WHERE  crc.valparcela_crc > 1 
                                                               AND crc.tipo_crc NOT IN ( 'F', 'SB', 'FGT' ) 
                                                               AND Datediff(day, cr.data_prc, Getdate()) > '2' 
	                                                           AND crc.Empresa_crc = {0}
	                                                           AND crc.Obra_crc = '{1}'
	                                                           AND crc.NumVend_crc = {2}";


        public const string TOTAL_CONTRATOS_ATIVOS_CAC = @"SELECT 

COUNT(*) TOTAL_CONTRATOS_ATIVOS
FROM 
(

SELECT distinct crc.empresa_crc,  crc.obra_crc, crc.numvend_crc, data_ven,  p.nome_pes , up.identificador_unid ,up.qtde_unid ,valortot_ven
FROM   contasrecebercalc crc 
       INNER JOIN contasreceber cr 
               ON cr.empresa_prc = crc.empresa_crc 
                  AND cr.obra_prc = crc.obra_crc 
                  AND cr.numvend_prc = crc.numvend_crc 
                  AND cr.numparc_prc = crc.numparc_crc 
                  AND cr.numparcger_prc = crc.numparcger_crc 
                  AND cr.tipo_prc = crc.tipo_crc 
       INNER JOIN vendas v 
               ON v.empresa_ven = crc.empresa_crc 
                  AND v.obra_ven = crc.obra_crc 
                  AND v.num_ven = crc.numvend_crc 
       INNER JOIN vendaclientes vc 
               ON v.empresa_ven = vc.empresa_cven 
                  AND v.obra_ven = vc.obra_cven 
                  AND v.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 
       INNER JOIN itensvenda iv 
               ON crc.empresa_crc = iv.empresa_itv 
                  AND crc.numvend_crc = iv.numvend_itv 
                  AND crc.obra_crc = iv.obra_itv 
       LEFT JOIN unidadeper up 
              ON iv.empresa_itv = up.empresa_unid 
                 AND iv.obra_itv = up.obra_unid 
                 AND iv.produto_itv = up.prod_unid 
                 AND iv.codperson_itv = up.numper_unid 
			   INNER JOIN obras o
			   on  crc.empresa_crc = o.Empresa_obr and o.cod_obr = crc.obra_crc

				WHERE  
                not obra_ven in ( 'REC01', 'ADM01', 'FIN', '009F2', '0018F', '0019F') 

AND crc.valparcela_crc > 1 
	   AND o.status_obr = 0 
       AND cr.data_prc >= '{0}'
       AND iv.codperson_itv NOT IN ( '-1' ) 
	   AND vc.emiteboleto_cven = '1'

       
        ) FatoInadimplencia";


        #endregion

        #region Cobranca_TERIVA

        public const string FATO_INADIMPLENCIA_TERIVA = @"SELECT *, 
       ( CASE 
           WHEN ( statuscobranca = 500 
                   OR statuscobranca = 501 
                   OR statuscobranca = 502 ) THEN 'F' 
           WHEN ( statuscobranca = 2051 ) THEN 'G' 
           ELSE ( CASE 
                    WHEN ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) = 'E+' 
                         AND statuscobranca = '203' THEN 'E-' 
                    ELSE ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) 
                  END ) 
         END ) ClassificacaoContrato 
FROM   (SELECT Cast ( contasrecebercalc.empresa_crc AS VARCHAR ) 
               + '-' 
               + Cast (contasrecebercalc.obra_crc AS VARCHAR ) 
               + '-' 
               + Cast ( contasrecebercalc.numvend_crc AS VARCHAR ) 
               AS 
                      EmpObraVen, 
               contasrecebercalc.empresa_crc 
               AS 
                      Empresa, 
               contasrecebercalc.obra_crc 
               AS 
                      Obra, 
               contasrecebercalc.numvend_crc 
               AS 
                      Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103) 
               AS 
                      [Data do Contrato], 
               vendas.valortot_ven 
               AS 
                      [Valor da Unidade], 
               p.nome_pes 
               AS 
                      Cliente, 
               ( Stuff((SELECT Cast(', ' + [identificador_unid] AS VARCHAR(max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Quadra e Lote], 
               ( Stuff((SELECT Cast(', ' 
                                    + CONVERT(VARCHAR, CONVERT(MONEY, 
                                    [qtde_unid])) AS 
                                    VARCHAR( 
                                      max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                               AND prdc.codcat_cp IN ( '100', '102' ) 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Area do Terreno], 
               COALESCE(vendas.statusescritura_ven, '-') 
               AS 
                      [Status Escritura], 
               COALESCE(se.desc_ste, '-') 
               AS 
                      [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-') 
               AS 
                      StatusCobranca, 
               COALESCE(sc.desc_stc, '-') 
               AS 
                      [Desc Status Cobrança], 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '9') 
               AS 
               [Frequencia 9 Meses], 
               CONVERT(DECIMAL(18, 2), (SELECT Count(*) 
                                        FROM   recebidas 
                                        WHERE  empresa_rec = 
                                               contasrecebercalc.empresa_crc 
                                               AND obra_rec = 
                                                   contasrecebercalc.obra_crc 
                                               AND numvend_rec = 
                                                   contasrecebercalc.numvend_crc 
                                               AND Datediff (month, data_rec, 
                                                   Getdate ( 
                                                   )) <= 
                                                   '9')) / 9 
               AS 
                      FrequenciaMedia, 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '2') 
               AS 
               RecebimentoUltimos2Meses, 
               Count(*) 
                      [Quantidade Parcelas Aberto], 
               Sum(valparcela_crc) 
                      [Valor Parcelas Aberto], 
               COALESCE((SELECT Sum(( valorconf_rec + valor_rec )) 
                         FROM   recebidas 
                         WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                                AND obra_rec = contasrecebercalc.obra_crc 
                                AND numvend_rec = 
               contasrecebercalc.numvend_crc), 0) AS 
               ValorRecebidoVGV, 
               Sum(valjuroatraso_crc) 
                      ValorJurosAtraso, 
               Sum(valmultaatraso_crc) 
                      ValorMultaAtraso, 
               Sum(valcorrecaoatraso_crc) 
                      ValorCorrecaoAtraso 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN obras 
                       ON cod_obr = obra_crc 
                          AND empresa_obr = empresa_crc 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  
                    
                     ((empresa_ven = 103 and obra_ven='UVA01') 
                    or (empresa_ven = 94 and obra_ven='UIP01')
                    or (empresa_ven = 67 and obra_ven='UDV01'))

                ) TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE  data_prc < Dateadd(day, -7, Getdate()) 
               AND status_obr = '0' 
               AND Datediff(month, data_prc, Getdate()) > -1 
               AND valparcela_crc > '1' 
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia ";

        public const string FECHAMENTO_MENSAL_COBRANCA_TERIVA = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 103 and obra_rec='UVA01') 
                                                                        or (Empresa_rec = 94 and obra_rec='UIP01')
                                                                        or (empresa_rec = 67 and obra_rec='UDV01'))


                                                                    and DATEDIFF(month, Data_Rec, getdate()) > -1 and DATEDIFF(month, Data_Rec, getdate()) < 96 and
																	year(DataVenci_Rec) = year(convert(datetime,'{0}')) and month(DataVenci_Rec) = month(convert(datetime,'{0}'))
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where 
																	
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) = convert(datetime,Convert(varchar,'{0}',103))
																	
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 
                                                                         ((Empresa_ven = 103 and Obra_Ven='UVA01') 
                                                                        or (Empresa_ven = 94 and Obra_Ven='UIP01')
                                                                        or (empresa_ven = 67 and obra_ven='UDV01'))

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 103 and obra_rec='UVA01') 
                                                                        or (Empresa_rec = 94 and obra_rec='UIP01')
                                                                        or (empresa_rec = 67 and obra_rec='UDV01'))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) < convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 103 and obra_rec='UVA01') 
                                                                        or (Empresa_rec = 94 and obra_rec='UIP01')
                                                                        or (empresa_rec = 67 and obra_rec='UDV01'))
                                                                        
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) > convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where 
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,'{0}',103))
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 

                                                                         ((Empresa_ven = 103 and Obra_Ven='UVA01') 
                                                                        or (Empresa_ven = 94 and Obra_Ven='UIP01')
                                                                        or (empresa_ven = 67 and obra_ven='UDV01'))

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 103 and obra_rec='UVA01') 
                                                                        or (Empresa_rec = 94 and obra_rec='UIP01')
                                                                        or (empresa_rec = 67 and obra_rec='UDV01'))

                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) >= convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 103 and obra_rec='UVA01') 
                                                                        or (Empresa_rec = 94 and obra_rec='UIP01')
                                                                        or (empresa_rec = 67 and obra_rec='UDV01')) 
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    join

                                                                    (SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where   

                                                                         ((Empresa_ven = 103 and Obra_Ven='UVA01') 
                                                                        or (Empresa_ven = 94 and Obra_Ven='UIP01')
                                                                        or (empresa_ven = 67 and obra_ven='UDV01'))

                                                                        ) TabRelacaoObras
                                                                    on Dados.empresa = TabRelacaoObras.Empresa_ven and Dados.obra = TabRelacaoObras.Obra_Ven



                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";


        public const string TOTAL_CONTRATOS_ATIVOS_TERIVA = @"SELECT 

COUNT(*) TOTAL_CONTRATOS_ATIVOS
FROM 
(

SELECT distinct crc.empresa_crc,  crc.obra_crc, crc.numvend_crc, data_ven,  p.nome_pes , up.identificador_unid ,up.qtde_unid ,valortot_ven
FROM   contasrecebercalc crc 
       INNER JOIN contasreceber cr 
               ON cr.empresa_prc = crc.empresa_crc 
                  AND cr.obra_prc = crc.obra_crc 
                  AND cr.numvend_prc = crc.numvend_crc 
                  AND cr.numparc_prc = crc.numparc_crc 
                  AND cr.numparcger_prc = crc.numparcger_crc 
                  AND cr.tipo_prc = crc.tipo_crc 
       INNER JOIN vendas v 
               ON v.empresa_ven = crc.empresa_crc 
                  AND v.obra_ven = crc.obra_crc 
                  AND v.num_ven = crc.numvend_crc 
       INNER JOIN vendaclientes vc 
               ON v.empresa_ven = vc.empresa_cven 
                  AND v.obra_ven = vc.obra_cven 
                  AND v.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 
       INNER JOIN itensvenda iv 
               ON crc.empresa_crc = iv.empresa_itv 
                  AND crc.numvend_crc = iv.numvend_itv 
                  AND crc.obra_crc = iv.obra_itv 
       LEFT JOIN unidadeper up 
              ON iv.empresa_itv = up.empresa_unid 
                 AND iv.obra_itv = up.obra_unid 
                 AND iv.produto_itv = up.prod_unid 
                 AND iv.codperson_itv = up.numper_unid 
			   INNER JOIN obras o
			   on  crc.empresa_crc = o.Empresa_obr and o.cod_obr = crc.obra_crc

				WHERE  
            ((Empresa_ven = 103 and Obra_Ven='UVA01') 
                or (Empresa_ven = 94 and Obra_Ven='UIP01')
                or (empresa_ven = 67 and obra_ven='UDV01'))

AND crc.valparcela_crc > 1 
	   AND o.status_obr = 0 
       AND cr.data_prc >= '{0}'
       AND iv.codperson_itv NOT IN ( '-1' ) 
	   AND vc.emiteboleto_cven = '1'

       
        ) FatoInadimplencia";


        #endregion

        #region Cobranca_URBPLAN

        public const string FATO_INADIMPLENCIA_URBPLAN = @"SELECT *, 
       ( CASE 
           WHEN ( statuscobranca = 500 
                   OR statuscobranca = 501 
                   OR statuscobranca = 502 ) THEN 'F' 
           WHEN ( statuscobranca = 2051 ) THEN 'G' 
           ELSE ( CASE 
                    WHEN ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) = 'E+' 
                         AND statuscobranca = '203' THEN 'E-' 
                    ELSE ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) 
                  END ) 
         END ) ClassificacaoContrato 
FROM   (SELECT Cast ( contasrecebercalc.empresa_crc AS VARCHAR ) 
               + '-' 
               + Cast (contasrecebercalc.obra_crc AS VARCHAR ) 
               + '-' 
               + Cast ( contasrecebercalc.numvend_crc AS VARCHAR ) 
               AS 
                      EmpObraVen, 
               contasrecebercalc.empresa_crc 
               AS 
                      Empresa, 
               contasrecebercalc.obra_crc 
               AS 
                      Obra, 
               contasrecebercalc.numvend_crc 
               AS 
                      Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103) 
               AS 
                      [Data do Contrato], 
               vendas.valortot_ven 
               AS 
                      [Valor da Unidade], 
               p.nome_pes 
               AS 
                      Cliente, 
               ( Stuff((SELECT Cast(', ' + [identificador_unid] AS VARCHAR(max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Quadra e Lote], 
               ( Stuff((SELECT Cast(', ' 
                                    + CONVERT(VARCHAR, CONVERT(MONEY, 
                                    [qtde_unid])) AS 
                                    VARCHAR( 
                                      max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Area do Terreno], 
               COALESCE(vendas.statusescritura_ven, '-') 
               AS 
                      [Status Escritura], 
               COALESCE(se.desc_ste, '-') 
               AS 
                      [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-') 
               AS 
                      StatusCobranca, 
               COALESCE(sc.desc_stc, '-') 
               AS 
                      [Desc Status Cobrança], 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '9') 
               AS 
               [Frequencia 9 Meses], 
               CONVERT(DECIMAL(18, 2), (SELECT Count(*) 
                                        FROM   recebidas 
                                        WHERE  empresa_rec = 
                                               contasrecebercalc.empresa_crc 
                                               AND obra_rec = 
                                                   contasrecebercalc.obra_crc 
                                               AND numvend_rec = 
                                                   contasrecebercalc.numvend_crc 
                                               AND Datediff (month, data_rec, 
                                                   Getdate ( 
                                                   )) <= 
                                                   '9')) / 9 
               AS 
                      FrequenciaMedia, 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '2') 
               AS 
               RecebimentoUltimos2Meses, 
               Count(*) 
                      [Quantidade Parcelas Aberto], 
               Sum(valparcela_crc) 
                      [Valor Parcelas Aberto], 
               COALESCE((SELECT Sum(( valorconf_rec + valor_rec )) 
                         FROM   recebidas 
                         WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                                AND obra_rec = contasrecebercalc.obra_crc 
                                AND numvend_rec = 
               contasrecebercalc.numvend_crc), 0) AS 
               ValorRecebidoVGV, 
               Sum(valjuroatraso_crc) 
                      ValorJurosAtraso, 
               Sum(valmultaatraso_crc) 
                      ValorMultaAtraso, 
               Sum(valcorrecaoatraso_crc) 
                      ValorCorrecaoAtraso 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN obras 
                       ON cod_obr = obra_crc 
                          AND empresa_obr = empresa_crc 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 
                     WHERE  
                    
                     empresa_ven = 20000


                ) TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE  data_prc < Dateadd(day, -7, Getdate()) 
               AND status_obr = '0' 
               AND Datediff(month, data_prc, Getdate()) > -1 
               AND valparcela_crc > '1' 
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia ";

        public const string FECHAMENTO_MENSAL_COBRANCA_URBPLAN = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 20000))

                                                                    and DATEDIFF(month, Data_Rec, getdate()) > -1 and DATEDIFF(month, Data_Rec, getdate()) < 96 and
																	year(DataVenci_Rec) = year(convert(datetime,'{0}')) and month(DataVenci_Rec) = month(convert(datetime,'{0}'))
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where 
																	
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) = convert(datetime,Convert(varchar,'{0}',103))
																	
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 
                                                                         ((Empresa_ven = 20000))

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    ((Empresa_rec = 20000))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) < convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    ((Empresa_rec = 20000))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) > convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where 
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,'{0}',103))
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 

                                                                       ((Empresa_ven = 20000))

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    ((Empresa_rec = 20000))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) >= convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    ((Empresa_rec = 20000))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    join

                                                                    (SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where   

                                                                    ((Empresa_ven = 20000))

                                                                        ) TabRelacaoObras
                                                                    on Dados.empresa = TabRelacaoObras.Empresa_ven and Dados.obra = TabRelacaoObras.Obra_Ven



                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";


        #endregion

        #region Cobranca_CAPYS

        public const string FATO_INADIMPLENCIA_CAPYS = @"SELECT *, 
       ( CASE 
           WHEN ( statuscobranca = 500 
                   OR statuscobranca = 501 
                   OR statuscobranca = 502 ) THEN 'F' 
           WHEN ( statuscobranca = 2051 ) THEN 'G' 
           ELSE ( CASE 
                    WHEN ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) = 'E+' 
                         AND statuscobranca = '203' THEN 'E-' 
                    ELSE ( CASE 
                             WHEN ( frequenciamedia < 0.11 ) THEN 'E+' 
                             WHEN ( frequenciamedia >= 0.11 
                                    AND frequenciamedia <= 0.22 ) THEN 'D' 
                             WHEN ( frequenciamedia > 0.22 
                                    AND frequenciamedia <= 0.44 ) THEN 'C' 
                             WHEN ( frequenciamedia > 0.44 
                                    AND frequenciamedia <= 0.89 ) THEN 'B' 
                             WHEN ( frequenciamedia > 0.89 ) THEN 'A' 
                             ELSE 'AJUSTAR' 
                           END ) + ( CASE 
                                       WHEN ( ( CASE 
                                                  WHEN ( frequenciamedia < 0.11 
                                                       ) THEN 
                                                  'E+' 
                                                  WHEN ( frequenciamedia >= 0.11 
                                                         AND frequenciamedia <= 
                                                             0.22 ) 
                                                THEN 'D' 
                                                  WHEN ( frequenciamedia > 0.22 
                                                         AND frequenciamedia <= 
                                                             0.44 ) 
                                                THEN 'C' 
                                                  WHEN ( frequenciamedia > 0.44 
                                                         AND frequenciamedia <= 
                                                             0.89 ) 
                                                THEN 'B' 
                                                  WHEN ( frequenciamedia > 0.89 
                                                       ) THEN 
                                                  'A' 
                                                  ELSE 'AJUSTAR' 
                                                END ) = 'B' ) THEN ( CASE 
                                                                       WHEN 
                                       recebimentoultimos2meses = 0 
                                                                     THEN '-' 
                                                                       ELSE '+' 
                                                                     END ) 
                                       ELSE '' 
                                     END ) 
                  END ) 
         END ) ClassificacaoContrato 
FROM   (SELECT Cast ( contasrecebercalc.empresa_crc AS VARCHAR ) 
               + '-' 
               + Cast (contasrecebercalc.obra_crc AS VARCHAR ) 
               + '-' 
               + Cast ( contasrecebercalc.numvend_crc AS VARCHAR ) 
               AS 
                      EmpObraVen, 
               contasrecebercalc.empresa_crc 
               AS 
                      Empresa, 
               contasrecebercalc.obra_crc 
               AS 
                      Obra, 
               contasrecebercalc.numvend_crc 
               AS 
                      Venda, 
               CONVERT(VARCHAR, vendas.data_ven, 103) 
               AS 
                      [Data do Contrato], 
               vendas.valortot_ven 
               AS 
                      [Valor da Unidade], 
               p.nome_pes 
               AS 
                      Cliente, 
               ( Stuff((SELECT Cast(', ' + [identificador_unid] AS VARCHAR(max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Quadra e Lote], 
               ( Stuff((SELECT Cast(', ' 
                                    + CONVERT(VARCHAR, CONVERT(MONEY, 
                                    [qtde_unid])) AS 
                                    VARCHAR( 
                                      max)) 
                        FROM   itensvenda iv 
                               LEFT JOIN unidadeper up 
                                      ON iv.empresa_itv = up.empresa_unid 
                                         AND iv.obra_itv = up.obra_unid 
                                         AND iv.produto_itv = up.prod_unid 
                                         AND iv.codperson_itv = up.numper_unid 
                               LEFT JOIN prdsrvcat prdc 
                                      ON prdc.codprod_cp = iv.produto_itv 
                        WHERE  contasrecebercalc.empresa_crc = iv.empresa_itv 
                               AND contasrecebercalc.numvend_crc = 
                                   iv.numvend_itv 
                               AND contasrecebercalc.obra_crc = iv.obra_itv 
                               AND iv.codperson_itv > 0 
                               AND prdc.codcat_cp IN ( '100', '102' ) 
                        FOR xml path ('')), 1, 2, '') ) 
               AS 
                      [Area do Terreno], 
               COALESCE(vendas.statusescritura_ven, '-') 
               AS 
                      [Status Escritura], 
               COALESCE(se.desc_ste, '-') 
               AS 
                      [Desc Status Escritura], 
               COALESCE(sc.codigo_stc, '-') 
               AS 
                      StatusCobranca, 
               COALESCE(sc.desc_stc, '-') 
               AS 
                      [Desc Status Cobrança], 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '9') 
               AS 
               [Frequencia 9 Meses], 
               CONVERT(DECIMAL(18, 2), (SELECT Count(*) 
                                        FROM   recebidas 
                                        WHERE  empresa_rec = 
                                               contasrecebercalc.empresa_crc 
                                               AND obra_rec = 
                                                   contasrecebercalc.obra_crc 
                                               AND numvend_rec = 
                                                   contasrecebercalc.numvend_crc 
                                               AND Datediff (month, data_rec, 
                                                   Getdate ( 
                                                   )) <= 
                                                   '9')) / 9 
               AS 
                      FrequenciaMedia, 
               (SELECT Count(*) 
                FROM   recebidas 
                WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                       AND obra_rec = contasrecebercalc.obra_crc 
                       AND numvend_rec = contasrecebercalc.numvend_crc 
                       AND Datediff (month, data_rec, Getdate ()) <= '2') 
               AS 
               RecebimentoUltimos2Meses, 
               Count(*) 
                      [Quantidade Parcelas Aberto], 
               Sum(valparcela_crc) 
                      [Valor Parcelas Aberto], 
               COALESCE((SELECT Sum(( valorconf_rec + valor_rec )) 
                         FROM   recebidas 
                         WHERE  empresa_rec = contasrecebercalc.empresa_crc 
                                AND obra_rec = contasrecebercalc.obra_crc 
                                AND numvend_rec = 
               contasrecebercalc.numvend_crc), 0) AS 
               ValorRecebidoVGV, 
               Sum(valjuroatraso_crc) 
                      ValorJurosAtraso, 
               Sum(valmultaatraso_crc) 
                      ValorMultaAtraso, 
               Sum(valcorrecaoatraso_crc) 
                      ValorCorrecaoAtraso 
        FROM   contasrecebercalc 
               INNER JOIN contasreceber 
                       ON contasreceber.empresa_prc = 
                          contasrecebercalc.empresa_crc 
                          AND contasreceber.obra_prc = 
                              contasrecebercalc.obra_crc 
                          AND contasreceber.numvend_prc = 
                              contasrecebercalc.numvend_crc 
                          AND contasreceber.numparc_prc = 
                              contasrecebercalc.numparc_crc 
                          AND contasreceber.numparcger_prc = 
                              contasrecebercalc.numparcger_crc 
                          AND contasreceber.tipo_prc = 
                              contasrecebercalc.tipo_crc 
               INNER JOIN vendas 
                       ON vendas.empresa_ven = contasrecebercalc.empresa_crc 
                          AND vendas.obra_ven = contasrecebercalc.obra_crc 
                          AND vendas.num_ven = contasrecebercalc.numvend_crc 
               INNER JOIN parametrocobranca 
                       ON contasreceber.empresa_prc = 
                          parametrocobranca.empresa_pcb 
                          AND contasreceber.numpcb_prc = 
                              parametrocobranca.num_pcb 
               INNER JOIN obras 
                       ON cod_obr = obra_crc 
                          AND empresa_obr = empresa_crc 
               INNER JOIN (SELECT * 
                           FROM   vendaclientes 
                           WHERE  emiteboleto_cven = '1') vc 
                       ON vendas.empresa_ven = vc.empresa_cven 
                          AND vendas.obra_ven = vc.obra_cven 
                          AND vendas.num_ven = vc.num_cven 
               INNER JOIN pessoas p 
                       ON vc.cliente_cven = p.cod_pes 
               LEFT JOIN statusescritura se 
                      ON vendas.statusescritura_ven = 
                         '-' + Cast(se.codigo_ste AS VARCHAR) + 
                         '-' 
               LEFT JOIN statuscobranca sc 
                      ON vendas.statuscobranca_ven = '-' + Cast(sc.codigo_stc AS 
                                                     VARCHAR) + '-' 
               JOIN (SELECT DISTINCT empresa_ven, 
                                     obra_ven 
                     FROM   vendas 
                            INNER JOIN itensvenda 
                                    ON empresa_ven = empresa_itv 
                                       AND obra_ven = obra_itv 
                                       AND num_ven = numvend_itv 
                            INNER JOIN prdsrv 
                                    ON numprod_psc = produto_itv 

                     WHERE  
                    
                     ((empresa_ven = 1 and obra_ven='CAPYS'))


                ) TabRelacaoObras 
                 ON empresa_crc = TabRelacaoObras.empresa_ven 
                    AND obra_crc = TabRelacaoObras.obra_ven 
        WHERE  data_prc < Dateadd(day, -1, Getdate()) 
               AND status_obr = '0' 
               AND Datediff(month, data_prc, Getdate()) > -1 
               AND valparcela_crc > '1' 
        GROUP  BY empresa_crc, 
                  obra_crc, 
                  contasrecebercalc.numvend_crc, 
                  vendas.data_ven, 
                  vendas.valortot_ven, 
                  p.nome_pes, 
                  vendas.statusescritura_ven, 
                  se.desc_ste, 
                  sc.codigo_stc, 
                  sc.desc_stc) FatoInadimplecia ";

        public const string FECHAMENTO_MENSAL_COBRANCA_CAPYS = @"select empresa,obra,sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento) VlrFaturadoMes
                                                                    ,sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento) VlrRecebidoMes,
                                                                    sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento) VlrInadimplenciaMes,


                                                                    case when (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) > 0 then
                                                                    100-((sum(VlrRecebidasDataVencimento)-sum(VlrRecebidasDataRecebimento))*100) /
                                                                    (sum(VlrRecebidasDataVencimento) +sum(VlrReceberDataVencimento) - sum(VlrRecebidasDataRecebimento)) else 0 end  VlrPercInadimplenciaMes,

                                                                    sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque) VlrEstoqueAnterior,
                                                                    sum(VlrRecebidasRecuperacao) VlrRecebidasRecuperacao,


                                                                    case when (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) >0 then (sum(VlrRecebidasRecuperacao)*100)/(sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) else 0 end VlrPercRecuperacao,

                                                                    (sum(VlrRecebidasAposDataRecebimento) + sum(VlrReceberDataVencimento)) + (sum(VlrReceberAcumulado) + sum(VlrRecebidasEstoque)) - (sum(VlrRecebidasRecuperacao)) VlrEstoqueAcumulado

                                                                    from

                                                                    (Select 
                                                                    Empresa_rec as empresa,Obra_Rec as obra,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataVencimento
				                                                                    ,0 VlrReceberDataVencimento
				                                                                    ,0 VlrRecebidasDataRecebimento
				                                                                    ,0 VlrRecebidasAposDataRecebimento
				                                                                    ,0 VlrReceberAcumulado
				                                                                    ,0 VlrRecebidasEstoque
				                                                                    ,0 VlrRecebidasRecuperacao
				                                                                    from 

                                                                    Recebidas

                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    ((Empresa_rec = 1 and Obra_rec='CAPYS'))


                                                                    and DATEDIFF(month, Data_Rec, getdate()) > -1 and DATEDIFF(month, Data_Rec, getdate()) < 96 and
																	year(DataVenci_Rec) = year(convert(datetime,'{0}')) and month(DataVenci_Rec) = month(convert(datetime,'{0}'))
                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all



                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, sum(ValParcela_crc) VlrReceberDataVencimento,0,0,0,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc
                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc


                                                                    where 
																	
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) = convert(datetime,Convert(varchar,'{0}',103))
																	
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 
                                                                    ((Empresa_ven = 1 and Obra_Ven='CAPYS'))

                                                                    group by Empresa_crc,Obra_crc

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0 ,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasDataRecebimento,0,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    ((Empresa_rec = 1 and Obra_rec='CAPYS'))
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) < convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasAposDataRecebimento,0,0,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                    ((Empresa_rec = 1 and Obra_rec='CAPYS'))
                                                                        
                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) > convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec

                                                                    union all
                                                                    select Empresa_crc as empresa,Obra_crc as obra,0, 0,0,0,sum(ValParcela_crc) VlrReceberAcumulado,0,0 from ContasReceberCalc
                                                                    Inner Join ContasReceber ON
                                                                    ContasReceber.Empresa_prc = ContasReceberCalc.Empresa_crc AND
                                                                    ContasReceber.Obra_Prc = ContasReceberCalc.Obra_crc AND
                                                                    ContasReceber.NumVend_prc = ContasReceberCalc.NumVend_crc AND
                                                                    ContasReceber.NumParc_Prc = ContasReceberCalc.NumParc_crc AND
                                                                    ContasReceber.NumParcGer_Prc = ContasReceberCalc.NumParcGer_crc And
                                                                    ContasReceber.Tipo_Prc = ContasReceberCalc.Tipo_crc

                                                                    Inner Join Vendas ON
                                                                    Vendas.Empresa_Ven = ContasReceberCalc.Empresa_crc AND
                                                                    Vendas.Obra_Ven = ContasReceberCalc.Obra_crc AND
                                                                    Vendas.Num_Ven = ContasReceberCalc.NumVend_crc
                                                                    Inner Join ParametroCobranca ON
                                                                    ContasReceber.Empresa_prc = ParametroCobranca.Empresa_pcb and
                                                                    ContasReceber.NumPcb_prc = ParametroCobranca.Num_pcb
                                                                    INNER JOIN Obras ON
                                                                    cod_obr = Obra_crc and
                                                                    Empresa_obr = Empresa_crc

                                                                    where 
																	convert(datetime,'01/' + convert(varchar,MONTH(Data_Prc)) + '/' + convert(varchar,YEAR(Data_Prc))) < convert(datetime,Convert(varchar,'{0}',103))
                                                                    AND Status_obr = '0' 
                                                                    and DATEDIFF(month, Data_prc, GETDATE()) > -1 and ValParcela_crc > '1'
                                                                     and 

                                                                    ((Empresa_ven = 1 and Obra_Ven='CAPYS'))

                                                                    group by Empresa_crc,Obra_crc


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasEstoque,0

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 1 and Obra_rec='CAPYS'))

                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) >= convert(datetime,Convert(varchar,'{0}',103))


                                                                    group by Empresa_rec,Obra_Rec


                                                                    union all

                                                                    Select 

                                                                    Empresa_rec,Obra_Rec,0 ,0,0,0,0,0,SUM ((((ValorConf_Rec + Valor_Rec + VlCorrecao_Rec + VlCorrecaoAtr_Rec + VlTaxaBol_Rec 
		 		                                                                    + VlJurosParc_Rec + VlJurosParcConf_Rec + VlMulta_Rec + VlJuros_Rec 
		 		                                                                    + VlAcres_Rec + VlCorrecaoConf_Rec  + VlCorrecaoAtrConf_Rec + VlTaxaBolConf_Rec 
		 		                                                                    + VlMultaConf_Rec + VlJurosConf_Rec + VlAcresConf_Rec) 
				                                                                    - (VlDescontoConf_Rec + VlDesconto_Rec)) *
			                                                                     ((ItensRecebidas.Qtde_Itr * ItensRecebidas.PrecoProc_Itr - ItensRecebidas.ValComissaoDir_itr) 
			                                                                     / VendasRecebidas.ValorTot_VRec))) VlrRecebidasRecuperacao

				
				                                                                    from 

                                                                    Recebidas
                                                                    INNER Join VendasRecebidas ON
                                                                    Empresa_rec = Empresa_vrec AND
                                                                    Obra_rec = Obra_vrec AND
                                                                    NumVend_rec = Num_vrec
                                                                    INNER Join ItensRecebidas ON
                                                                    Empresa_vrec = Empresa_itr AND
                                                                    Obra_vrec = Obra_Itr AND
                                                                    Num_vrec = NumVend_Itr
                                                                    INNER Join PrdSrv ON
                                                                    NumProd_psc = Produto_Itr
                                                                    where 
                                                                        ((Empresa_rec = 1 and Obra_rec='CAPYS'))

                                                                    and DATEDIFF(month, Data_Rec, '{0}') > -1 and DATEDIFF(month, Data_Rec, '{0}') < 96 and
                                                                    convert(datetime,'01/' + convert(varchar,MONTH(DataVenci_Rec)) + '/' + convert(varchar,YEAR(DataVenci_Rec))) < convert(datetime,Convert(varchar,'{0}',103))

                                                                    and

                                                                    convert(datetime,'01/' + convert(varchar,MONTH(Data_Rec)) + '/' + convert(varchar,YEAR(Data_Rec))) = convert(datetime,Convert(varchar,'{0}',103))

                                                                    group by Empresa_rec,Obra_Rec


                                                                    ) Dados

                                                                    join

                                                                    (SELECT Distinct Empresa_ven, Obra_ven
                                                                    FROM Vendas
                                                                    INNER JOIN ItensVenda On
                                                                    Empresa_ven = Empresa_itv and
                                                                    Obra_Ven = Obra_Itv and
                                                                    Num_Ven = NumVend_Itv
                                                                    INNER JOIN PrdSrv ON
                                                                    NumProd_psc = Produto_Itv
                                                                    Where   

                                                                         ((Empresa_ven = 1 and Obra_Ven='CAPYS'))

                                                                        ) TabRelacaoObras
                                                                    on Dados.empresa = TabRelacaoObras.Empresa_ven and Dados.obra = TabRelacaoObras.Obra_Ven



                                                                    group by empresa,obra

                                                                    order by VlrEstoqueAcumulado desc";


        public const string TOTAL_CONTRATOS_ATIVOS_CAPYS = @"SELECT 

COUNT(*) TOTAL_CONTRATOS_ATIVOS
FROM 
(

SELECT distinct crc.empresa_crc,  crc.obra_crc, crc.numvend_crc, data_ven,  p.nome_pes , up.identificador_unid ,up.qtde_unid ,valortot_ven
FROM   contasrecebercalc crc 
       INNER JOIN contasreceber cr 
               ON cr.empresa_prc = crc.empresa_crc 
                  AND cr.obra_prc = crc.obra_crc 
                  AND cr.numvend_prc = crc.numvend_crc 
                  AND cr.numparc_prc = crc.numparc_crc 
                  AND cr.numparcger_prc = crc.numparcger_crc 
                  AND cr.tipo_prc = crc.tipo_crc 
       INNER JOIN vendas v 
               ON v.empresa_ven = crc.empresa_crc 
                  AND v.obra_ven = crc.obra_crc 
                  AND v.num_ven = crc.numvend_crc 
       INNER JOIN vendaclientes vc 
               ON v.empresa_ven = vc.empresa_cven 
                  AND v.obra_ven = vc.obra_cven 
                  AND v.num_ven = vc.num_cven 
       INNER JOIN pessoas p 
               ON vc.cliente_cven = p.cod_pes 
       INNER JOIN itensvenda iv 
               ON crc.empresa_crc = iv.empresa_itv 
                  AND crc.numvend_crc = iv.numvend_itv 
                  AND crc.obra_crc = iv.obra_itv 
       LEFT JOIN unidadeper up 
              ON iv.empresa_itv = up.empresa_unid 
                 AND iv.obra_itv = up.obra_unid 
                 AND iv.produto_itv = up.prod_unid 
                 AND iv.codperson_itv = up.numper_unid 
			   INNER JOIN obras o
			   on  crc.empresa_crc = o.Empresa_obr and o.cod_obr = crc.obra_crc

				WHERE  
            ((Empresa_ven = 103 and Obra_Ven='UVA01') 
                or (Empresa_ven = 94 and Obra_Ven='UIP01')
                or (empresa_ven = 67 and obra_ven='UDV01'))

AND crc.valparcela_crc > 1 
	   AND o.status_obr = 0 
       AND cr.data_prc >= '{0}'
       AND iv.codperson_itv NOT IN ( '-1' ) 
	   AND vc.emiteboleto_cven = '1'

       
        ) FatoInadimplencia";


        #endregion

        #region Cobranca_VILABRASIL

        public const string VENDAS_CONTRATO_ASSOCIATIVO = @"select distinct  Empresa_ven,Obra_Ven,Num_Ven,ContratoCEF_ven from 
(select Empresa_ven,Obra_Ven,Num_Ven,ContratoCEF_ven from Vendas where ContratoCEF_ven is not null
union all 
select Empresa_vrec,Obra_VRec,Num_VRec,ContratoCEF_vrec from VendasRecebidas where ContratoCEF_vrec is not null) Vendas";

        public const string RECEBER_CONTRATO_ASSOCIATIVO = @"select Empresa_prc,Obra_Prc,NumVend_prc,convert(varchar,Data_Prc,103) Data_Prc,Valor_Prc from ContasReceber where NumCtp_Prc = 8";

        public const string RECEBIDAS_CONTRATO_ASSOCIATIVO = @"select Empresa_rec,Obra_Rec,NumVend_Rec,convert(varchar,DataVenci_Rec,103) DataVenci_Rec,ValorConf_rec from Recebidas where NumCtp_Rec = 8";

        public const string VALOR_RECEBIDO_PARCELA_FINAC = @"select 
	                                                            empresa_prc,obra_prc,numvend_prc,sum(valor_prc)valor_prc,Tipo_Prc
                                                            from
                                                            (
                                                                select empresa_prc,obra_prc,numvend_prc,valor_prc,Tipo_Prc from contasreceber
                                                                where 
	                                                                empresa_prc = {0} and obra_prc='{1}' and numvend_prc={2} and Tipo_Prc in ({3})
                                                                union
                                                                select empresa_rec,obra_rec,numvend_rec,numreceb_rec,Tipo_Rec from Recebidas
                                                                where 
	                                                                empresa_rec = {0} and obra_rec='{1}' and numvend_rec={2} and Tipo_Rec in ({3})
                                                            ) Parcelas
                                                            group by empresa_prc,obra_prc,numvend_prc,Tipo_Prc";

        #endregion

        #region Atendimentos

        public const string ATENDIMENTOS = @"SELECT 	Codigo_cger,
		A.NUM_ATD,
        A.DESCR_ATD,
        A.CODCATEG_ATD,
        CC.DESC_CGER,
        A.DATACAD_ATD,
        A.DATAFIM_ATD,
        A.CODPES_ATD,
        CONVERT(VARCHAR,A.Obra_atd) + ' / ' + convert(VARCHAR,A.ProdUnid_atd) + ' / ' + CONVERT(VARCHAR,UP.IDENTIFICADOR_UNID) ID_CHAVE_ERP,
        COM.DESCR_CCM,
		A.NUMVTWF_ATD,

	ID_CHAVE_ERP_ETAPA = (
		
		SELECT --*
		TOP 1 CONVERT(VARCHAR, Codigo_cger) + '-' + CONVERT(VARCHAR, NumPasso_pwfp)
		FROM Pendencia WITH (NOLOCK) 
			INNER JOIN PassoWorkflowPend WITH (NOLOCK) ON QuemR_Pen = QuemRPen_pwfp AND QdoL_pen = QdoLPen_pwfp AND Num_pen = NumPen_pwfp 
			LEFT JOIN PassoWorkflowPendRespostas WITH (NOLOCK) ON NumVtwf_pen = NumVtwf_pwpr AND NumPasso_pen = NumPasso_pwpr AND NumResp_pen = NumResp_pwpr AND TipoResp_pen = TipoResp_pwpr 
			WHERE NumVtwf_pwfp = A.NumVtwf_atd AND Status_pen = 0
		ORDER BY NumPasso_pwfp)

FROM 	ATENDIMENTO A
	INNER JOIN CATEGORIASDECOMENTARIO CC
        	ON A.CODCATEG_ATD = CC.CODIGO_CGER 
	LEFT JOIN UNIDADEPER UP
        	ON A.EMPRESA_ATD = UP.EMPRESA_UNID 
		AND A.PRODUNID_ATD = UP.PROD_UNID 
                AND A.NUMPER_ATD = UP.NUMPER_UNID 
	INNER JOIN CANALCOMUNICACAO COM
        	ON A.NUMCCM_ATD = COM.NUM_CCM 

WHERE 	
--YEAR(DATACAD_ATD) > 2019 AND 
A.DATAFIM_ATD IS NULL
AND Codigo_cger LIKE 'REC-13%'

ORDER BY DATACAD_ATD
";

        public const string ATENDIMENTOS_AT_ABERTOS = @"SELECT 
                                        A.NUM_ATD,
                                        A.DESCR_ATD,
                                        A.CODCATEG_ATD,
                                        CC.DESC_CGER,
                                        A.DATACAD_ATD,
                                        A.DATAFIM_ATD,
                                        A.CODPES_ATD,
                                        CONVERT(VARCHAR,A.Obra_atd) + ' / ' + convert(VARCHAR,A.ProdUnid_atd) + ' / ' + CONVERT(VARCHAR,UP.IDENTIFICADOR_UNID) ID_CHAVE_ERP,
                                        COM.DESCR_CCM

                                        FROM ATENDIMENTO A
                                        INNER JOIN CATEGORIASDECOMENTARIO CC
                                        ON A.CODCATEG_ATD = CC.CODIGO_CGER 



                                        LEFT JOIN UNIDADEPER UP
                                        ON A.EMPRESA_ATD = UP.EMPRESA_UNID 
                                        AND A.PRODUNID_ATD = UP.PROD_UNID 
                                        AND A.NUMPER_ATD = UP.NUMPER_UNID 


                                        INNER JOIN CANALCOMUNICACAO COM
                                           ON A.NUMCCM_ATD = COM.NUM_CCM 
                                        
                                                                                WHERE A.NUM_ATD IN (163482, 163475, 164040, 164803) and
						A.DATAFIM_ATD IS NULL

";

        public const string ATENDIMENTOS_AT_FECHADOS = @"SELECT 
                                        A.NUM_ATD,
                                        A.DESCR_ATD,
                                        A.CODCATEG_ATD,
                                        CC.DESC_CGER,
                                        A.DATACAD_ATD,
                                        A.DATAFIM_ATD,
                                        A.CODPES_ATD,
                                        CONVERT(VARCHAR,A.Obra_atd) + ' / ' + convert(VARCHAR,A.ProdUnid_atd) + ' / ' + CONVERT(VARCHAR,UP.IDENTIFICADOR_UNID) ID_CHAVE_ERP,
                                        COM.DESCR_CCM

                                        FROM ATENDIMENTO A
                                        INNER JOIN CATEGORIASDECOMENTARIO CC
                                        ON A.CODCATEG_ATD = CC.CODIGO_CGER 



                                        LEFT JOIN UNIDADEPER UP
                                        ON A.EMPRESA_ATD = UP.EMPRESA_UNID 
                                        AND A.PRODUNID_ATD = UP.PROD_UNID 
                                        AND A.NUMPER_ATD = UP.NUMPER_UNID 


                                        INNER JOIN CANALCOMUNICACAO COM
                                           ON A.NUMCCM_ATD = COM.NUM_CCM 
                                        
WHERE A.NUM_ATD IN (163482, 163475, 164040, 164803) and
A.DATAFIM_ATD IS NOT NULL


";

        public const string ATENDIMENTOS_HISTORICO = @"SELECT *
                        FROM PendenciaObs 
                        INNER JOIN Pendencia 
                            ON Pendencia.QuemR_Pen = PendenciaObs.QuemRPen_pdo 
                            AND Pendencia.QdoL_pen = PendenciaObs.QdoLPen_pdo 
                            AND Pendencia.Num_pen = PendenciaObs.NumPen_pdo 
                        INNER JOIN PassoWorkflowPend 
                            ON PassoWorkflowPend.QuemRPen_pwfp = Pendencia.QuemR_Pen 
                            AND PassoWorkflowPend.QdoLPen_pwfp = Pendencia.QdoL_pen 
                            AND PassoWorkflowPend.NumPen_pwfp = Pendencia.Num_pen 
                        INNER JOIN VinculoTabelaWorkFlow 
                            ON VinculoTabelaWorkFlow.Num_vtwf = PassoWorkflowPend.NumVtwf_pwfp 
   
                        WHERE VinculoTabelaWorkFlow.Num_vtwf = {0}
                        ORDER BY DATACAD_PDO";

        #endregion

        #region ParcelasRecebidasConciliadasBoletos
        public const string PARCELAS_RECEBIDAS_CONCILIADAS_BOLETOS = @"SELECT *
                            FROM BoletoConfirmado
                            INNER JOIN Empresas
                               ON BoletoConfirmado.Empresa_Bol = Empresas.Codigo_emp
                            LEFT JOIN Pessoas
                               ON Cod_Pes = ClienteVen_Bol
                            INNER JOIN RecebAutoConfirmado
                               ON RecebAutoConfirmado.NumBol_Rea = Num_Bol
                               AND RecebAutoConfirmado.SeuNum_Rea = SeuNum_Bol
                               AND RecebAutoConfirmado.Banco_Rea = Banco_Bol
                            INNER JOIN Recebidas
                            on  Recebidas.Empresa_rec = RecebAutoConfirmado.Empresa_Rea 
                            and Recebidas.Obra_Rec = RecebAutoConfirmado.ObraPrc_Rea 
                            and  Recebidas.NumVend_Rec = RecebAutoConfirmado.NumVendPrc_Rea
                            and Recebidas.NumParc_Rec = RecebAutoConfirmado.NumParcPrc_Rea
                            and Recebidas.NumParcGer_Rec = RecebAutoConfirmado.NumParcGerPrc_Rea
                            and Recebidas.Tipo_Rec = RecebAutoConfirmado.TipoPrc_Rea
                            WHERE 
							((status_rea = 2 and OcorrenciaExclusao_Rea=1) or (status_rea=1 and OcorrenciaExclusao_Rea=2) or (status_rea=1 and OcorrenciaExclusao_Rea=6))
							and (Data_Rec >= convert(datetime, '2017-12-01') and Data_Rec <= convert(datetime, '2018-01-01'))
                            ORDER BY Empresa_Bol, NumArq_Bol, Banco_Bol, SeuNum_Bol";
        #endregion

        #region Dados Usuário

        public const string ConsultaDadosUsuarioUAU = @"select Login_usr,Senha_usr,Status_usr,UsuarioAD_usr from usuarios where Login_usr='{0}' and Status_usr=0";

        public const string ConsultaDadosUsuarioUAUAd = @"select Login_usr,Senha_usr,Status_usr,UsuarioAD_usr from usuarios where UsuarioAD_usr='{0}' and Status_usr=0";

        #endregion

        #region Venda - Custa

        public static string ListaPlanoIndexador = @"
            SELECT DISTINCT
                GrupoIdx_pidx, 
                Data_pidx, 
                IdxReaj_pidx 
            FROM 
                PlanoIndexador 
            WHERE 
                Empresa_pidx = {0} 
                AND NumVen_pidx = {1} 
                AND ObraVen_pidx = '{2}'
            ORDER BY 
                GrupoIdx_pidx, 
                Data_pidx
";
        public const string BuscaTiposDeCustas = @"SELECT 
	                                                    NUM_CTP,
	                                                    DESCR_CTP,
	                                                    DATACAD_CTP,
	                                                    USRCAD_CTP,
	                                                    COBRARTXADM_CTP,
	                                                    COBRARJUROS_CTP,
	                                                    COBRARMULTA_CTP,
	                                                    COBRARIMPOSTO_CTP,
	                                                    ATINAT_CTP,
	                                                    COBRARCORRECAO_CTP,
	                                                    COBRARCPMF_CTP,
	                                                    REPASSARLOCADOR_CTP 
                                                    FROM CUSTASTIPO WHERE ATINAT_CTP = 0";

        public static string ListaFrequenciaVencimento = @"
            SELECT 
                * 
            FROM 
                TipoVenc 
            ORDER BY 
                Cod_Tv
";

        public static string ListaIndiceReajusteParcela = @"
            SELECT 
                * 
            FROM 
                Indices 
            WHERE 
                AtInat_idx = 0 
            ORDER BY 
                cod_idx
";

        public static string GetIdPadraoCobranca = @"
            SELECT 
                NumPcbObra_obr, 
                NumeroBanco_pcb, 
                ContaBanco_pcb
            FROM
                Obras
            LEFT JOIN   
                ParametroCobranca ON  
                    ParametroCobranca.Empresa_pcb = Obras.Empresa_obr 
                    AND ParametroCobranca.Num_pcb = Obras.NumPcbObra_obr
            WHERE 
                obras.Empresa_obr = {0}
                AND Obras.Cod_obr = '{1}'
                AND Obras.NumPcbObra_obr IS NOT NULL     
                AND ParametroCobranca.AtInat_pcb = 0
";

        public static string ListaPadraoCobranca = @"
            SELECT 
                Bancos.Numero_banco, 
                Bancos.Nome_banco, 
                CCorrente.Conta_banco, 
                CCorrente.Agencia_banco,  
                ParametroCobranca.CarteiraCbc_pcb, 
                ParametroCobranca.Num_pcb, 
                ParametroCobranca.Descr_pcb,  
                ParametroCobranca.Empresa_pcb, 
                ParametroCobranca.CedenteRemessa_pcb 
            FROM   
                ParametroCobranca 
            INNER JOIN   
                Bancos ON  
                    bancos.Numero_banco = ParametroCobranca.NumeroBanco_pcb 
            INNER JOIN   
                CCorrente ON  
                    CCorrente.Empresa_banco = ParametroCobranca.Empresa_pcb 
                    AND CCorrente.Numero_banco = ParametroCobranca.NumeroBanco_pcb 
                    AND CCorrente.Conta_banco = ParametroCobranca.ContaBanco_pcb 
            WHERE 
                ParametroCobranca.Empresa_pcb = {0}
                AND AtInat_pcb = 0 
";

        public static string ListaIndicePlanoIndexador = @"
            SELECT 
	            COD_IDX, 
	            DESCR_IDX 
            FROM 
	            INDICES 
            WHERE  
	            ATINAT_IDX = 0";

        public static string ListaCap = @"
            SELECT
                *
            FROM
                CAP";

        public const string VW_CAPYS_DADOS_PRODUTO_VENDA = @"select * from VW_CAPYS_DADOS_PRODUTO_VENDA 
                                                             where Empresa={0} and Obra='{1}' and Venda={2}";

        #endregion

        public const string ListarPessoa = @"SELECT * FROM PESSOAS WHERE NOME_PES LIKE '%{0}%'";
    }
}
