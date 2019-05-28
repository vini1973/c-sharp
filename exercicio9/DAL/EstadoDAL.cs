using System;
using System.Data.Common;
using Smart.Database;
using Smart.Model;
using System.Collections.Generic;
using TGSmartControls.Model;

namespace TGSmartControls.DAL
{
	public class EstadoDAL : Smart.Model.DataAccessObject
	{
		#region Automaticaly generated by Smart.AutoModeling 2.0
		public EstadoDAL(DbConn pDbHnd) : base (pDbHnd) { }

		public EstadoInfo Get(Int32 pCdEstado)
		{
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdEstado", pCdEstado));
			String sql = "SELECT cd_estado, ds_sigla, ds_nome FROM ESTADO WHERE cd_estado = @cdEstado";
			DbDataReader dr = DbHnd.ExecuteReader(sql);
			try
			{
				if (dr.Read())
				{
					EstadoInfo info = new EstadoInfo();
					if(dr["cd_estado"] != System.DBNull.Value)
						info.CdEstado.Value = Convert.ToInt32(dr["cd_estado"]);
					else
					{
						if (info.CdEstado.AllowsNull)
							info.CdEstado.IsNullValue = true;
					}
					if(dr["ds_sigla"] != System.DBNull.Value)
						info.DsSigla.Value = (Char)dr["ds_sigla"];
					else
					{
						if (info.DsSigla.AllowsNull)
							info.DsSigla.IsNullValue = true;
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

		public Int32 Inserir(EstadoInfo pInfo)
		{
			String insertCols = String.Empty;
			String insertValues = String.Empty;
			if (pInfo.DsSigla.ValueIsSet)
			{
				if (!pInfo.DsSigla.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsSigla", pInfo.DsSigla.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsSigla", System.DBNull.Value));
				}
				insertCols += ", " + pInfo.DsSigla.Name;
				insertValues += ", @dsSigla";
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
			return DbHnd.InsertGetInt32Key("INSERT INTO ESTADO (" + insertCols + ") VALUES (" + insertValues + ")", "cd_estado");
		}

		public void Atualizar(Int32 pCdEstado, EstadoInfo pInfo)
		{
			String upVars = String.Empty;
			if (pInfo.DsSigla.ValueIsSet)
			{
				if (!pInfo.DsSigla.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsSigla", pInfo.DsSigla.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsSigla", System.DBNull.Value));
				}
				upVars += ", " + pInfo.DsSigla.Name + " = @dsSigla";
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
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdEstado", pCdEstado));
			sqlWhere += "cd_estado = @cdEstado";
			sqlWhere = " WHERE " + sqlWhere;

			DbHnd.ExecuteNonQuery("UPDATE ESTADO SET " + upVars + sqlWhere);
		}

		public void Deletar(Int32 pCdEstado)
		{
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdEstado", pCdEstado));
			DbHnd.ExecuteNonQuery("DELETE FROM ESTADO WHERE cd_estado = @cdEstado");
		}

		public List<EstadoInfo> Listar()
		{
			List<EstadoInfo> lstReturn = new List<EstadoInfo>();

			String sqlSelect = "cd_estado, ds_sigla, ds_nome";
			String sqlFrom = "ESTADO";
			String sqlWhere = BuildFilters();
			String sqlOrderBy = BuildOrderBy();
			String sql = "SELECT " + sqlSelect + " FROM " + sqlFrom + sqlWhere + sqlOrderBy;
			using (DbDataReader dr = DbHnd.ExecuteReader(sql))
			{
				while (dr.Read())
				{
					EstadoInfo info = new EstadoInfo();
					if(dr["cd_estado"] != System.DBNull.Value)
						info.CdEstado.Value = Convert.ToInt32(dr["cd_estado"]);
					else
					{
						if (info.CdEstado.AllowsNull)
							info.CdEstado.IsNullValue = true;
					}
					if(dr["ds_sigla"] != System.DBNull.Value)
						info.DsSigla.Value = (Char)dr["ds_sigla"];
					else
					{
						if (info.DsSigla.AllowsNull)
							info.DsSigla.IsNullValue = true;
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

		public List<EstadoInfo> ListarPaginado()
		{
			List<EstadoInfo> lstReturn = new List<EstadoInfo>();

			String sqlSelect = "cd_estado, ds_sigla, ds_nome";
			String sqlFrom = "ESTADO";
			String sqlWhere = BuildPagedFilters();
			String sqlOrderBy = BuildPagedOrderBy();
			String sql = new Smart.Database.SQL.Translator(DbHnd.ProviderName).MontarSqlPaginado(sqlSelect, sqlFrom, sqlWhere, sqlOrderBy, this.Filters.PageNumber, this.Filters.EntriesPerPage);
			using (DbDataReader dr = DbHnd.ExecuteReader(sql))
			{
				while (dr.Read())
				{
					EstadoInfo info = new EstadoInfo();
					if(dr["cd_estado"] != System.DBNull.Value)
						info.CdEstado.Value = Convert.ToInt32(dr["cd_estado"]);
					else
					{
						if (info.CdEstado.AllowsNull)
							info.CdEstado.IsNullValue = true;
					}
					if(dr["ds_sigla"] != System.DBNull.Value)
						info.DsSigla.Value = (Char)dr["ds_sigla"];
					else
					{
						if (info.DsSigla.AllowsNull)
							info.DsSigla.IsNullValue = true;
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
			String sqlSelect = "COUNT(cd_estado)";
			String sqlWhere = BuildFilters();
			object obj = DbHnd.ExecuteScalar("SELECT " + sqlSelect + " FROM ESTADO " + sqlWhere);
			return Convert.ToInt32(obj);
		}
		#endregion
	}
}
