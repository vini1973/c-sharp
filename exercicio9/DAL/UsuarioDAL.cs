using System;
using System.Data.Common;
using Smart.Database;
using Smart.Model;
using System.Collections.Generic;
using TGSmartControls.Model;

namespace TGSmartControls.DAL
{
	public class UsuarioDAL : Smart.Model.DataAccessObject
	{
		#region Automaticaly generated by Smart.AutoModeling 2.0
		public UsuarioDAL(DbConn pDbHnd) : base (pDbHnd) { }

		public UsuarioInfo Get(Int32 pCdUsuario)
		{
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdUsuario", pCdUsuario));
			String sql = "SELECT dt_nasc, st_ativo, cd_cidadenasc, cd_usuario, ds_nome, ds_email FROM USUARIO WHERE cd_usuario = @cdUsuario";
			DbDataReader dr = DbHnd.ExecuteReader(sql);
			try
			{
				if (dr.Read())
				{
					UsuarioInfo info = new UsuarioInfo();
					if(dr["dt_nasc"] != System.DBNull.Value)
						info.DtNasc.Value = (DateTime)dr["dt_nasc"];
					else
					{
						if (info.DtNasc.AllowsNull)
							info.DtNasc.IsNullValue = true;
					}
					if(dr["st_ativo"] != System.DBNull.Value)
						info.StAtivo.Value = Convert.ToByte(dr["st_ativo"]);
					else
					{
						if (info.StAtivo.AllowsNull)
							info.StAtivo.IsNullValue = true;
					}
					if(dr["cd_cidadenasc"] != System.DBNull.Value)
						info.CdCidadenasc.Value = Convert.ToInt32(dr["cd_cidadenasc"]);
					else
					{
						if (info.CdCidadenasc.AllowsNull)
							info.CdCidadenasc.IsNullValue = true;
					}
					if(dr["cd_usuario"] != System.DBNull.Value)
						info.CdUsuario.Value = Convert.ToInt32(dr["cd_usuario"]);
					else
					{
						if (info.CdUsuario.AllowsNull)
							info.CdUsuario.IsNullValue = true;
					}
					if(dr["ds_nome"] != System.DBNull.Value)
						info.DsNome.Value = dr["ds_nome"].ToString();
					else
					{
						if (info.DsNome.AllowsNull)
							info.DsNome.IsNullValue = true;
					}
					if(dr["ds_email"] != System.DBNull.Value)
						info.DsEmail.Value = dr["ds_email"].ToString();
					else
					{
						if (info.DsEmail.AllowsNull)
							info.DsEmail.IsNullValue = true;
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

		public Int32 Inserir(UsuarioInfo pInfo)
		{
			String insertCols = String.Empty;
			String insertValues = String.Empty;
			if (pInfo.DtNasc.ValueIsSet)
			{
				if (!pInfo.DtNasc.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dtNasc", pInfo.DtNasc.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dtNasc", System.DBNull.Value));
				}
				insertCols += ", " + pInfo.DtNasc.Name;
				insertValues += ", @dtNasc";
			}
			if (pInfo.StAtivo.ValueIsSet)
			{
				if (!pInfo.StAtivo.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@stAtivo", pInfo.StAtivo.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@stAtivo", System.DBNull.Value));
				}
				insertCols += ", " + pInfo.StAtivo.Name;
				insertValues += ", @stAtivo";
			}
			if (pInfo.CdCidadenasc.ValueIsSet)
			{
				if (!pInfo.CdCidadenasc.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdCidadenasc", pInfo.CdCidadenasc.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdCidadenasc", System.DBNull.Value));
				}
				insertCols += ", " + pInfo.CdCidadenasc.Name;
				insertValues += ", @cdCidadenasc";
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
			if (pInfo.DsEmail.ValueIsSet)
			{
				if (!pInfo.DsEmail.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsEmail", pInfo.DsEmail.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsEmail", System.DBNull.Value));
				}
				insertCols += ", " + pInfo.DsEmail.Name;
				insertValues += ", @dsEmail";
			}
			insertCols = insertCols.Substring(2, insertCols.Length - 2);
			insertValues = insertValues.Substring(2, insertValues.Length - 2);
			return DbHnd.InsertGetInt32Key("INSERT INTO USUARIO (" + insertCols + ") VALUES (" + insertValues + ")", "cd_usuario");
		}

		public void Atualizar(Int32 pCdUsuario, UsuarioInfo pInfo)
		{
			String upVars = String.Empty;
			if (pInfo.DtNasc.ValueIsSet)
			{
				if (!pInfo.DtNasc.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dtNasc", pInfo.DtNasc.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dtNasc", System.DBNull.Value));
				}
				upVars += ", " + pInfo.DtNasc.Name + " = @dtNasc";
			}
			if (pInfo.StAtivo.ValueIsSet)
			{
				if (!pInfo.StAtivo.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@stAtivo", pInfo.StAtivo.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@stAtivo", System.DBNull.Value));
				}
				upVars += ", " + pInfo.StAtivo.Name + " = @stAtivo";
			}
			if (pInfo.CdCidadenasc.ValueIsSet)
			{
				if (!pInfo.CdCidadenasc.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdCidadenasc", pInfo.CdCidadenasc.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdCidadenasc", System.DBNull.Value));
				}
				upVars += ", " + pInfo.CdCidadenasc.Name + " = @cdCidadenasc";
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
			if (pInfo.DsEmail.ValueIsSet)
			{
				if (!pInfo.DsEmail.IsNullValue)
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsEmail", pInfo.DsEmail.Value));
				}
				else
				{
					DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@dsEmail", System.DBNull.Value));
				}
				upVars += ", " + pInfo.DsEmail.Name + " = @dsEmail";
			}
			upVars = upVars.Substring(2, upVars.Length - 2);

			String sqlWhere = String.Empty;
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdUsuario", pCdUsuario));
			sqlWhere += "cd_usuario = @cdUsuario";
			sqlWhere = " WHERE " + sqlWhere;

			DbHnd.ExecuteNonQuery("UPDATE USUARIO SET " + upVars + sqlWhere);
		}

		public void Deletar(Int32 pCdUsuario)
		{
			DbHnd.Parametros.Add(new System.Data.SqlClient.SqlParameter("@cdUsuario", pCdUsuario));
			DbHnd.ExecuteNonQuery("DELETE FROM USUARIO WHERE cd_usuario = @cdUsuario");
		}

		public List<UsuarioInfo> Listar()
		{
			List<UsuarioInfo> lstReturn = new List<UsuarioInfo>();

			String sqlSelect = "dt_nasc, st_ativo, cd_cidadenasc, cd_usuario, ds_nome, ds_email";
			String sqlFrom = "USUARIO";
			String sqlWhere = BuildFilters();
			String sqlOrderBy = BuildOrderBy();
			String sql = "SELECT " + sqlSelect + " FROM " + sqlFrom + sqlWhere + sqlOrderBy;
			using (DbDataReader dr = DbHnd.ExecuteReader(sql))
			{
				while (dr.Read())
				{
					UsuarioInfo info = new UsuarioInfo();
					if(dr["dt_nasc"] != System.DBNull.Value)
						info.DtNasc.Value = (DateTime)dr["dt_nasc"];
					else
					{
						if (info.DtNasc.AllowsNull)
							info.DtNasc.IsNullValue = true;
					}
					if(dr["st_ativo"] != System.DBNull.Value)
						info.StAtivo.Value = Convert.ToByte(dr["st_ativo"]);
					else
					{
						if (info.StAtivo.AllowsNull)
							info.StAtivo.IsNullValue = true;
					}
					if(dr["cd_cidadenasc"] != System.DBNull.Value)
						info.CdCidadenasc.Value = Convert.ToInt32(dr["cd_cidadenasc"]);
					else
					{
						if (info.CdCidadenasc.AllowsNull)
							info.CdCidadenasc.IsNullValue = true;
					}
					if(dr["cd_usuario"] != System.DBNull.Value)
						info.CdUsuario.Value = Convert.ToInt32(dr["cd_usuario"]);
					else
					{
						if (info.CdUsuario.AllowsNull)
							info.CdUsuario.IsNullValue = true;
					}
					if(dr["ds_nome"] != System.DBNull.Value)
						info.DsNome.Value = dr["ds_nome"].ToString();
					else
					{
						if (info.DsNome.AllowsNull)
							info.DsNome.IsNullValue = true;
					}
					if(dr["ds_email"] != System.DBNull.Value)
						info.DsEmail.Value = dr["ds_email"].ToString();
					else
					{
						if (info.DsEmail.AllowsNull)
							info.DsEmail.IsNullValue = true;
					}
					lstReturn.Add(info);
				}
			}
			return lstReturn;
		}

		public List<UsuarioInfo> ListarPaginado()
		{
			List<UsuarioInfo> lstReturn = new List<UsuarioInfo>();

			String sqlSelect = "dt_nasc, st_ativo, cd_cidadenasc, cd_usuario, ds_nome, ds_email";
			String sqlFrom = "USUARIO";
			String sqlWhere = BuildPagedFilters();
			String sqlOrderBy = BuildPagedOrderBy();
			String sql = new Smart.Database.SQL.Translator(DbHnd.ProviderName).MontarSqlPaginado(sqlSelect, sqlFrom, sqlWhere, sqlOrderBy, this.Filters.PageNumber, this.Filters.EntriesPerPage);
			using (DbDataReader dr = DbHnd.ExecuteReader(sql))
			{
				while (dr.Read())
				{
					UsuarioInfo info = new UsuarioInfo();
					if(dr["dt_nasc"] != System.DBNull.Value)
						info.DtNasc.Value = (DateTime)dr["dt_nasc"];
					else
					{
						if (info.DtNasc.AllowsNull)
							info.DtNasc.IsNullValue = true;
					}
					if(dr["st_ativo"] != System.DBNull.Value)
						info.StAtivo.Value = Convert.ToByte(dr["st_ativo"]);
					else
					{
						if (info.StAtivo.AllowsNull)
							info.StAtivo.IsNullValue = true;
					}
					if(dr["cd_cidadenasc"] != System.DBNull.Value)
						info.CdCidadenasc.Value = Convert.ToInt32(dr["cd_cidadenasc"]);
					else
					{
						if (info.CdCidadenasc.AllowsNull)
							info.CdCidadenasc.IsNullValue = true;
					}
					if(dr["cd_usuario"] != System.DBNull.Value)
						info.CdUsuario.Value = Convert.ToInt32(dr["cd_usuario"]);
					else
					{
						if (info.CdUsuario.AllowsNull)
							info.CdUsuario.IsNullValue = true;
					}
					if(dr["ds_nome"] != System.DBNull.Value)
						info.DsNome.Value = dr["ds_nome"].ToString();
					else
					{
						if (info.DsNome.AllowsNull)
							info.DsNome.IsNullValue = true;
					}
					if(dr["ds_email"] != System.DBNull.Value)
						info.DsEmail.Value = dr["ds_email"].ToString();
					else
					{
						if (info.DsEmail.AllowsNull)
							info.DsEmail.IsNullValue = true;
					}
					lstReturn.Add(info);
				}
			}
			return lstReturn;
		}

		public Int32 GetTotalRegistros()
		{
			String sqlSelect = "COUNT(cd_usuario)";
			String sqlWhere = BuildFilters();
			object obj = DbHnd.ExecuteScalar("SELECT " + sqlSelect + " FROM USUARIO " + sqlWhere);
			return Convert.ToInt32(obj);
		}
		#endregion
	}
}
