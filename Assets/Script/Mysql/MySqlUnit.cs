using MySql.Data.MySqlClient;
using System;
using System.Data;

public class MySqlUnit
{
    protected  MySqlConnection mySqlConnection;
    //IP地址
    protected string _host;
    //端口号
    protected string _port;
    //用户名
    protected string _userName;
    //密码
    protected string _password;
    //数据库名称
    protected string _databaseName;

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="_host">ip地址</param>
    /// <param name="_userName">用户名</param>
    /// <param name="_password">密码</param>
    /// <param name="_databaseName">数据库名称</param>
    public MySqlUnit(string _host, string _port, string _userName, string _password, string _databaseName)
    {
        this._host = _host;
        this._port = _port;
        this._userName = _userName;
        this._password = _password;
        this._databaseName = _databaseName;
        OpenSQL();
    }


    public void OpenSQL()
    {
        try
        {
            string mySqlString = string.Format("Database={0};Data Source={1};User Id={2};Password={3};port={4};CharSet=utf8", _databaseName, _host, _userName, _password, _port);

            mySqlConnection = new MySqlConnection(mySqlString);

            mySqlConnection.Open();


        }
        catch (Exception e)
        {
            throw new Exception( e.Message.ToString());
        }

    }

    /// <summary>
    /// 关闭数据库
    /// </summary>
    public void CloseSQL()
    {
        if (mySqlConnection != null)
        {
            mySqlConnection.Close();
            mySqlConnection.Dispose();
            mySqlConnection = null;
        }
    }

  
    /// <summary>
    /// 执行SQL语句
    /// </summary>
    /// <param name="sqlString">sql语句</param>
    /// <returns></returns>
    public DataSet ExecuteString(string sqlString)
    {
        if (mySqlConnection.State == ConnectionState.Open)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(sqlString, mySqlConnection);
                mySqlAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("SQL:" + sqlString + "/n" + e.Message.ToString());
            }
            return ds;
        }
        return null;
    }
}