using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperForm
{    
    class SqlHelper
    {
        SqlConnection conn;
        public SqlHelper()
        {
            conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["仓库管理.Properties.Settings.db_con_str"].ConnectionString;
        }
        /// <summary>
        /// 打开SqlConnection，并返回布尔值
        /// </summary>
        /// <param name="msg">返回日志信息</param>
        /// <returns></returns>
        private bool openConn(out string msg)
        {
            bool result = false;
            msg = "";
            try
            {
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    msg = "连接已打开！";
                    result = true;
                }
                else
                {
                    msg = "不能打开未关闭的连接！";
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return result;
        }
        /// <summary>
        /// Select语句返回一个SqlDataReader
        /// </summary>
        /// <param name="sqlText">Sql语句</param>
        /// <param name="pars">Sql参数</param>
        /// <param name="type">Sql命令类型</param>
        /// <returns></returns>
        public SqlDataReader selectReturnDataReader(string sqlText, SqlParameter[] pars, CommandType type)
        {
            string connResult;
            if(!openConn(out connResult))
            {
                //***连接失败时的操作
                return null;
            }
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
        /// <summary>
        /// Select语句返回一个String值
        /// </summary>
        /// <param name="sqlText">Sql语句</param>
        /// <param name="pars">Sql参数</param>
        /// <param name="type">Sql命令类型</param>
        /// <returns></returns>
        public string selectReturnString(string sqlText, SqlParameter[] pars, CommandType type)
        {
            string connResult;
            if (!openConn(out connResult))
            {
                //***连接失败时的操作
                return null;
            }
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            if (pars != null)
            {
                foreach (SqlParameter p in pars)
                {
                    cmd.Parameters.Add(p);
                }
            }
            string result= Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        /// <summary>
        /// Select语句返回一个int值
        /// </summary>
        /// <param name="sqlText">Sql语句</param>
        /// <param name="pars">Sql参数</param>
        /// <param name="type">Sql命令类型</param>
        /// <returns></returns>
        public int selectReturnInt(string sqlText, SqlParameter[] pars, CommandType type)
        {
            string connResult;
            if (!openConn(out connResult))
            {
                //***连接失败时的操作
                return -1;
            }
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            if (pars != null)
            {
                foreach (SqlParameter p in pars)
                {
                    cmd.Parameters.Add(p);
                }
            }
            if (cmd.ExecuteScalar() == null)
            {
                conn.Close();
                return -2;
            }
            else
            {
                int result= Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return result;
            }

        }
        /// <summary>
        /// Select语句返回一个DataSet
        /// </summary>
        /// <param name="sqlText">Sql语句</param>
        /// <param name="pars">Sql参数</param>
        /// <param name="type">Sql命令类型</param>
        /// <returns></returns>
        public DataSet selectReturnDataSet(string sqlText, SqlParameter[] pars, CommandType type)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlText, conn);
            if (pars!=null)
            {
                foreach (SqlParameter p in pars)
                {
                    sda.SelectCommand.Parameters.Add(p);
                }
            }
             DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
        /// <summary>
        /// Insert、Update、Delete语句返回int值
        /// </summary>
        /// <param name="sqlText">Sql语句</param>
        /// <param name="pars">Sql参数</param>
        /// <param name="type">Sql命令类型</param>
        /// <returns></returns>
        public int? IUDReturnInt(string sqlText, SqlParameter[] pars, CommandType type,SqlInfoMessageEventHandler simeh=null)
        {
            string connResult;
            if (simeh != null)
            {
                conn.InfoMessage += simeh;
            }
            if (!openConn(out connResult))
            {
                //***连接失败时的操作
                return null;
            }
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            if (pars != null)
            {
                foreach (SqlParameter p in pars)
                {
                    cmd.Parameters.Add(p);
                }
            }
            int? result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int? IUDbyDataTableReturnInt(string sqlText,DataTable dt,SqlParameter[] pars,CommandType type)
        {
            //string sqlText = "select * from dbo.权限表";
            SqlDataAdapter sda = new SqlDataAdapter(sqlText, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            scb.ConflictOption = ConflictOption.OverwriteChanges; //生成的sql语句就会以主键值来作为where条件，而不是所有键值都来做条件
            try
            {
                //(DataTable)dataGridView1.DataSource
                sda.Update(dt);
                //SqlCommand cmd = scb.GetUpdateCommand();
                return 1;
            }
            catch (SqlException e)
            {
                return -1;
            }
        }
    }
}
