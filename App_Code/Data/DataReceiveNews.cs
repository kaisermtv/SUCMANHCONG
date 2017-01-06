using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DataReceiveNews
{
	public int addEmail(string email)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM [tblReceiveNews] WHERE UPPER([Email]) = UPPER(@email))";
            Cmd.CommandText += "BEGIN INSERT INTO [tblReceiveNews]([Email]) VALUES(@email) END";
            Cmd.Parameters.Add("email", SqlDbType.NVarChar).Value = email.Trim();

            int ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        } catch
        {
            return 0;
        }
    }
}