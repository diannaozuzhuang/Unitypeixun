using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using biaolei;
using System.Data;


public class SqlAccess {

	//static void Main(string[] args) { }
	public static MySqlConnection dbConnection;
	//如果只是在本地的话，写localhost就可以。
	// static string host = "localhost";  
	//如果是局域网，那么写上本机的局域网IP
	static string host = "cdb-m0onnjut.gz.tencentcdb.com";//ip地址，如果是本机则写localhost，如果不是本机，则写安装数据库电脑的ip
	static string id = "root";//数据库的用户名
	static string pwd = "mz1997920521@";//数据库的密码
	static string database = "zyh";//数据库的名称  这里我的数据库名称为：examsystem

	public SqlAccess()
	{
		OpenSql();
	}
    public static void OpenSql()
    {

        try
        {
            string connectionString = string.Format("Server = {0};port={4};Database = {1}; User ID = {2}; Password = {3};", host, database, id, pwd, "10125");
            dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
        }
        catch (Exception e)
        {
            throw new Exception("服务器连接失败，请重新检查是否打开MySql服务。" + e.Message.ToString());

        }

    }
	public DataSet InsertInto(string tableName, string value1,string value2,float defen,string fenshu_date)
	{

		string query = "INSERT INTO " + tableName + " VALUES (" + "Null" +"," + "'" + value1 + "'" + ", " + "'" + value2 + "'" + ", " + "'" + defen + "'" + ","+ "'" + fenshu_date +"'";

		query += ")";

		Debug.Log(query);
		return ExecuteQuery(query);

	}
	public static DataSet ExecuteQuery(string sqlString)
	{
		if (dbConnection.State == ConnectionState.Open)
		{
			DataSet ds = new DataSet();
			try
			{

				MySqlDataAdapter da = new MySqlDataAdapter(sqlString, dbConnection);
				da.Fill(ds);

			}
			catch (Exception ee)
			{
				throw new Exception("SQL:" + sqlString + "/n" + ee.Message.ToString());

			}
			finally
			{
			}
			return ds;
		}
		return null;
	}
	public void Close()
	{

		if (dbConnection != null)
		{
			dbConnection.Close();
			dbConnection.Dispose();
			dbConnection = null;
		}

	}
}
