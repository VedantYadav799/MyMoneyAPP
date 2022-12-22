namespace BLL;
using BOL;
using DAL;
public class Manager
{
    public static List<Account> GetAll()
    {
        List<Account> accounts = DisconnectedDataAccess.GetAll();
        return accounts;
    }

    public static Account GetById(int id)
    {
        Account account = DisconnectedDataAccess.Get(id);
        return account;
    }

}
