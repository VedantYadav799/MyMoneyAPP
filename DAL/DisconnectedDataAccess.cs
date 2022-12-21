
using MySql.Data.MySqlClient;
using System.Data;

using BOL;

namespace DAL;
public class DisconnectedDataAccess
{
    public  static string conString = "server=localhost; port=3306; user=root; database=mydb; password='1234512345' ";
    public static List<Account> GetAll()
    {
        List<Account> allAccounts = new List<Account>();
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select * from account" ;
        try
        {
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable AccountTable = ds.Tables[0];
            DataRowCollection AccRow = AccountTable.Rows;
            foreach(DataRow row in AccRow)
            {
                Account acc = new Account();
                acc.Id =int.Parse(row["id"].ToString());
                acc.FirstName =row["firstname"].ToString();
                acc.LastName =row["lastname"].ToString();
                acc.CreditBalance =int.Parse(row["creditbalance"].ToString());
                acc.DebitBalance =int.Parse(row["debitbalance"].ToString());
                allAccounts.Add(acc);
            }


        }
        catch(MySqlException ex)
        {
            string msg = ex.Message;

        }
        
        return allAccounts;
    }



}
