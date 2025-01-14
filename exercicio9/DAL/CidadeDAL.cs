using System;
using System.Data.Common;
using Smart.Database;
using Smart.Model;
using System.Collections.Generic;
using TGSmartControls.Model;

namespace TGSmartControls.DAL
{
	public class CidadeDAL : Smart.Model.DataAccessObject
	{
		#region Automaticaly generated by Smart.AutoModeling 2.0
		public CidadeDAL(DbConn pDbHnd) : base (pDbHnd) { }

		public CidadeInfo Get(Int32 pCdCidade)
		{
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdCidade", pCdCidade));
			String sql = "SELECT cd_cidade, cd_estado, ds_nome FROM CIDADE WHERE cd_cidade = @cdCidade";
			DbDataReader dr = DbHnd.ExecuteReader(sql);
			try
			{
				if (dr.Read())
				{
					CidadeInfo info = new CidadeInfo();
					if(dr["cd_cidade"] != System.DBNull.Value)
						info.CdCidade.Value = Convert.ToInt32(dr["cd_cidade"]);
					else
					{
						if (info.CdCidade.AllowsNull)
							info.CdCidade.IsNullValue = true;
					}
					if(dr["cd_estado"] != System.DBNull.Value)
						info.CdEstado.Value = Convert.ToInt32(dr["cd_estado"]);
					else
					{
						if (info.CdEstado.AllowsNull)
							info.CdEstado.IsNullValue = true;
					}
					if(dr["ds_nome"] != System.DBNull.Value)
						info.DsNome.Value = dr["ds_nome"].ToString();
					else
					{
						if (info.DsNome.AllowsNull)
							info.DsNome.IsNullValue = true;
					}

					return info;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				dr.Dispose();
			}
		}

		public Int32 Inserir(CidadeInfo pInfo)
		{
			String insertCols = String.Empty;
			String insertValues = String.Empty;
			if (pInfo.CdEstado.ValueIsSet)
			{
				if (!pInfo.CdEstado.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdEstado", pInfo.CdEstado.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdEstado", System.DBNull.Value));
				}
				insertCols += ", " + pInfo.CdEstado.Name;
				insertValues += ", @cdEstado";
			}
			if (pInfo.DsNome.ValueIsSet)
			{
				if (!pInfo.DsNome.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsNome", pInfo.DsNome.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsNome", System.DBNull.Value));
				}
				insertCols += ", " + pInfo.DsNome.Name;
				insertValues += ", @dsNome";
			}
			insertCols = insertCols.Substring(2, insertCols.Length - 2);
			insertValues = insertValues.Substring(2, insertValues.Length - 2);
			return DbHnd.InsertGetInt32Key("INSERT INTO CIDADE (" + insertCols + ") VALUES (" + insertValues + ")", "cd_cidade");
		}

		public void Atualizar(Int32 pCdCidade, CidadeInfo pInfo)
		{
			String upVars = String.Empty;
			if (pInfo.CdEstado.ValueIsSet)
			{
				if (!pInfo.CdEstado.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdEstado", pInfo.CdEstado.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdEstado", System.DBNull.Value));
				}
				upVars += ", " + pInfo.CdEstado.Name + " = @cdEstado";
			}
			if (pInfo.DsNome.ValueIsSet)
			{
				if (!pInfo.DsNome.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsNome", pInfo.DsNome.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsNome", System.DBNull.Value));
				}
				upVars += ", " + pInfo.DsNome.Name + " = @dsNome";
			}
			upVars = upVars.Substring(2, upVars.Length - 2);

			String sqlWhere = String.Empty;
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdCidade", pCdCidade));
			sqlWhere += "cd_cidade = @cdCidade";
			sqlWhere = " WHERE " + sqlWhere;

			DbHnd.ExecuteNonQuery("UPDATE CIDADE SET " + upVars + sqlWhere);
		}

		public void Deletar(Int32 pCdCidade)
		{
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdCidade", pCdCidade));
			DbHnd.ExecuteNonQuery("DELETE FROM CIDADE WHERE cd_cidade = @cdCidade");
		}

		public List<CidadeInfo> Listar()
		{
			List<CidadeInfo> lstReturn = new List<CidadeInfo>();

			String sqlSelect = "cd_cidade, cd_estado, ds_nome";
			String sqlFrom = "CIDADE";
			String sqlWhere = BuildFilters();
			String sqlOrderBy = BuildOrderBy();
			String sql = "SELECT " + sqlSelect + " FROM " + sqlFrom + sqlWhere + sqlOrderBy;
			using (DbDataReader dr = DbHnd.ExecuteReader(sql))
			{
				while (dr.Read())
				{
					CidadeInfo info = new CidadeInfo();
					if(dr["cd_cidade"] != System.DBNull.Value)
						info.CdCidade.Value = Convert.ToInt32(dr["cd_cidade"]);
					else
					{
						if (info.CdCidade.AllowsNull)
							info.CdCidade.IsNullValue = true;
					}
					if(dr["cd_estado"] != System.DBNull.Value)
						info.CdEstado.Value = Convert.ToInt32(dr["cd_estado"]);
					else
					{
						if (info.CdEstado.AllowsNull)
							info.CdEstado.IsNullValue = true;
					}
					if(dr["ds_nome"] != System.DBNull.Value)
						info.DsNome.Value = dr["ds_nome"].ToString();
					else
					{
						if (info.DsNome.AllowsNull)
							info.DsNome.IsNullValue = true;
					}
					lstReturn.Add(info);
				}
			}
			return lstReturn;
		}

		public List<CidadeInfo> ListarPaginado()
		{
			List<CidadeInfo> lstReturn = new List<CidadeInfo>();

			String sqlSelect = "cd_cidade, cd_estado, ds_nome";
			String sqlFrom = "CIDADE";
			String sqlWhere = BuildPagedFilters();
			String sqlOrderBy = BuildPagedOrderBy();
			String sql = new Smart.Database.SQL.Translator(DbHnd.ProviderName).MontarSqlPaginado(sqlSelect, sqlFrom, sqlWhere, sqlOrderBy, this.Filters.PageNumber, this.Filters.EntriesPerPage);
			using (DbDataReader dr = DbHnd.ExecuteReader(sql))
			{
				while (dr.Read())
				{
					CidadeInfo info = new CidadeInfo();
					if(dr["cd_cidade"] != System.DBNull.Value)
						info.CdCidade.Value = Convert.ToInt32(dr["cd_cidade"]);
					else
					{
						if (info.CdCidade.AllowsNull)
							info.CdCidade.IsNullValue = true;
					}
					if(dr["cd_estado"] != System.DBNull.Value)
						info.CdEstado.Value = Convert.ToInt32(dr["cd_estado"]);
					else
					{
						if (info.CdEstado.AllowsNull)
							info.CdEstado.IsNullValue = true;
					}
					if(dr["ds_nome"] != System.DBNull.Value)
						info.DsNome.Value = dr["ds_nome"].ToString();
					else
					{
						if (info.DsNome.AllowsNull)
							info.DsNome.IsNullValue = true;
					}
					lstReturn.Add(info);
				}
			}
			return lstReturn;
		}

		public Int32 GetTotalRegistros()
		{
			String sqlSelect = "COUNT(cd_cidade)";
			String sqlWhere = BuildFilters();
			object obj = DbHnd.ExecuteScalar("SELECT " + sqlSelect + " FROM CIDADE " + sqlWhere);
			return Convert.ToInt32(obj);
		}
		#endregion
	}
}
