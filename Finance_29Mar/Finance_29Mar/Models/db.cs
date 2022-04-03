using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance_29Mar.Models;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;


namespace Finance_29Mar.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial catalog=Finance;Integrated Security=True;");
        public int LoginCheck(valLogin login)
        {
            SqlCommand cmd = new SqlCommand("sp_login",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usrname",login.lUN);
            cmd.Parameters.AddWithValue("@pswd", login.lpwd);
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@isValid";
            p.SqlDbType = SqlDbType.Bit;
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            con.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(p.Value);
            con.Close();
            return res;
        }
    }
}

