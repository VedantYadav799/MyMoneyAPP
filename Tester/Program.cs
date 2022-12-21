using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using DAL;
using BOL;
using BLL;




List<Account> allaccounts =Manager.getAll();

foreach(Account account in allaccounts)
{
    Console.WriteLine(account.FirstName + " " + account.LastName);
}