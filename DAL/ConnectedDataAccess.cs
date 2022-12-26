using MySql.Data.MySqlClient;
using System.Data;

using BOL;
namespace DAL;


public class ConnectedDataAccess
{
        public  static string connectionString = "server=localhost; port=3306; user=root; database=mydb; password='1234512345' ";

        public static List<Account> AllAccounts()
        {
                  //first , it will be empty list
        List<Account> accounts = new List<Account>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;
        try
        {
            string query = "SELECT * FROM account";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string firstname = reader["firstname"].ToString();
                string lastname = reader["lastname"].ToString();
                int creditbalance = int.Parse(reader["creditbalance"].ToString());
                int debitbalance = int.Parse(reader["debitbalance"].ToString());
                Account account = new Account
                {
                    Id = id,
                    FirstName = firstname,
                    LastName = lastname,
                    CreditBalance = creditbalance,
                    DebitBalance = debitbalance
                };
                accounts.Add(account);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }

        finally
        {
            con.Close();
        }
        return accounts;
        }

        public static Account Get(int accid)
        {

         Account account = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;
        try
        {
            string query = "SELECT * FROM account WHERE id=" + accid;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string firstname = reader["firstname"].ToString();
                string lastname = reader["lastname"].ToString();
                int creditbalance = int.Parse(reader["creditbalance"].ToString());
                int debitbalance = int.Parse(reader["debitbalance"].ToString());
                account = new Account
                {
                    Id = id,
                    FirstName = firstname,
                    LastName = lastname,
                    CreditBalance = creditbalance,
                    DebitBalance = debitbalance
                };
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return account;
        }

        public static bool Insert(Account account)
        {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;
        try
        {
            string query = "INSERT INTO departments(name,location)" +
                            "VALUES('" + account.FirstName + "','" + account.LastName + account.CreditBalance + "','" + account.DebitBalance +  "')";

            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return status;
        }

        public static bool Update(Account account)
        {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;
        try
        {
            string query = "UPDATE departments SET firstname='" + account.FirstName + "', lastname='" + account.LastName + "', creditbalance='" + account.CreditBalance +"', debitbalance='" + account.DebitBalance + "' WHERE id=" + account.Id;

            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return status;   

        }

        public static void delete(int id)
        {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;
        try
        {
            string query = "DELETE FROM account WHERE id=" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        }
}

