using System.Runtime.InteropServices;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using DAL;
using BOL;
using BLL;




 List<Account> allaccounts =Manager.GetAll();

    foreach(Account account in allaccounts)
    {
        Console.WriteLine(account.Id+" "+ account.FirstName + " " + account.LastName);
    }

int id =2;
    Account  acc = DisconnectedDataAccess.Get(id);
   
  Console.WriteLine("by given id"+ acc.FirstName + " " + acc.LastName);

// Account account1 = new Account();
// account1.Id = 1;
// account1.FirstName = "vivek";
// account1.LastName = "sharma";

// DisconnectedDataAccess.Update(account1);


//  Console.WriteLine("after updation");
//  List<Account> allaccountss =Manager.GetAll();

//     foreach(Account acc in allaccountss)
//     {
//         Console.WriteLine(acc.Id+" "+ acc.FirstName + " " + acc.LastName);
//     }