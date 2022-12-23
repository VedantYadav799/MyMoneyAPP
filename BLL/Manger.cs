namespace BLL;
using BOL;
using DAL;
public class Manager
{
    public static void GetAll()
    {
        
    }

    public static Account GetById(int id)
    {
        Account account = DisconnectedDataAccess.Get(id);
        return account;
    }
    

}
