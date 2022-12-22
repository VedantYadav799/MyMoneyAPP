
using System.Runtime.InteropServices;
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
    
    public static Account Get(int accId)
    {
        Account account = null;
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * from account WHERE ID ="+ accId;
        try
        {
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds= new DataSet();
            da.Fill(ds);
            DataTable accountTable = ds.Tables[0];
            DataRowCollection accrow = accountTable.Rows;
            DataRow row = accrow[0];
            {
             account = new Account();
            account.Id =int.Parse(row["id"].ToString());
            account.FirstName =row["firstname"].ToString();
            account.LastName =row["lastname"].ToString();
            account.CreditBalance =int.Parse(row["creditbalance"].ToString());
            account.DebitBalance =int.Parse(row["debitbalance"].ToString());
            }
            
        }
   catch(MySqlException ex)
        {
            string msg = ex.Message;

        }
        return account;
    }
      
    public static bool Update(Account account)
    {
        bool status = false;
        
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * from account";
        try
        {
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable Acctable = ds.Tables[0];
            DataColumn[] columns = new DataColumn[1];
            columns[0] = Acctable.Columns["id"];
            Acctable.PrimaryKey = columns;
            DataRowCollection rowCollection = Acctable.Rows;

            DataRow foundRow = rowCollection.Find(account.Id);
            foundRow["firstname"] = account.FirstName;
            foundRow["lastname"] = account.LastName;
            foundRow["debitbalance"] = account.DebitBalance;
            foundRow["creditbalance"] = account.CreditBalance; 
            da.Update(ds);
            status = true;

        }
        catch(MySqlException ex)
        {
            string msg = ex.Message;
        }

        return status;

    }


}



