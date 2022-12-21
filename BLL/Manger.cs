namespace BLL;
using BOL;
using DAL;
public class Manager
{
    public static List<Account> getAll()
        {
            List<Account> accounts = DisconnectedDataAccess.GetAll();
           
            return accounts;
        }

}
