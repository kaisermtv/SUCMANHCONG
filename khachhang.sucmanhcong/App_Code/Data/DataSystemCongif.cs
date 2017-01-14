using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataSystemCongif
/// </summary>
public class DataSystemCongif
{
	public DataSystemCongif()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    #region Method setSystemCongif
    public int setSystemCongif(int Id, string PartnerAccount, string CustomerAccount, string CustomerAccount1, string CustomerAccount2, string MemberAccount, float PartnerDiscount, float CustomerDiscount)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblSystemCongif WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblSystemCongif(PartnerAccount,CustomerAccount,CustomerAccount1,CustomerAccount2,MemberAccount,PartnerDiscount,CustomerDiscount) VALUES(@PartnerAccount,@CustomerAccount,@CustomerAccount1, @CustomerAccount2, @MemberAccount,@PartnerDiscount,@CustomerDiscount) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblSystemCongif SET PartnerAccount = @PartnerAccount,CustomerAccount = @CustomerAccount,CustomerAccount1 = @CustomerAccount1,CustomerAccount2 = @CustomerAccount2,MemberAccount = @MemberAccount,PartnerDiscount = @PartnerDiscount,CustomerDiscount = @CustomerDiscount WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccount;
            Cmd.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            Cmd.Parameters.Add("CustomerAccount1", SqlDbType.NVarChar).Value = CustomerAccount1;
            Cmd.Parameters.Add("CustomerAccount2", SqlDbType.NVarChar).Value = CustomerAccount2;
            Cmd.Parameters.Add("MemberAccount", SqlDbType.NVarChar).Value = MemberAccount;
            Cmd.Parameters.Add("PartnerDiscount", SqlDbType.Float).Value = PartnerDiscount;
            Cmd.Parameters.Add("CustomerDiscount", SqlDbType.Float).Value = CustomerDiscount;
            int ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        }
        catch
        {
            return 0;
        }
    }

    #endregion

    #region method getCustomerById
    public DataTable getCustomerById(int Id)
    {
        DataTable objData = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM tblSystemCongif WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();

            objData = ds.Tables[0];
        }
        catch
        {

        }
        return objData;
        
    }
    #endregion
}