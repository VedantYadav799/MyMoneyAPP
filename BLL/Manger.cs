namespace BLL;
using BOL;
using DAL;
public class Manager
{
    public static void GetAll()
    {
        List<Account> allAccounts = ConnectedDataAccess.AllAccounts();
        //List<Account> allAccounts = DisconnectedDataAccess.GetAll();
        foreach(Account acc in allAccounts)
       {
        Console.WriteLine(acc.Id+" "+ acc.FirstName + " " + acc.LastName+ " " + acc.CreditBalance + " " + acc.DebitBalance);
       }   
    }

    public static void GetById(int id)
    {
        Account account = ConnectedDataAccess.Get(id);
        //Account account = DisconnectedDataAccess.Get(id);
        Console.WriteLine(account.Id+" "+ account.FirstName + " " + account.LastName+ " " + account.CreditBalance + " " + account.DebitBalance);
    }

    public static void Insert(Account account)
    {
       bool status = ConnectedDataAccess.Insert(account);
       //bool status = DisconnectedDataAccess.Insert(account);
       if(status)
       {
        Console.WriteLine("Inserted successfully...");
       }
    }
    
    public static void Update(Account account)
    {
        bool status = ConnectedDataAccess.Update(account);
       //bool status = DisconnectedDataAccess.Update(account);
        if(status)
        {
            Console.WriteLine("Updated successfully...");
        }
    }
   
    public static void Delete(int id)
    {
        bool status =ConnectedDataAccess.delete(id);
        //bool status =DisconnectedDataAccess.Delete(id);
        if(status)
        {
            Console.WriteLine("Deleted successfully...");
        }
    }

}

