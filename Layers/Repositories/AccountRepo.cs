using Layers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Layers.Repositories
{
    internal class AccountRepo
    {

        private string path;

        public AccountRepo()
        {
            try
            {
                path = Directory.GetCurrentDirectory().Split("\\bin")[0] + "\\DataBase\\account.json";
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //  CREATE
        public Account.AccountBasic Create(Account.AccountBasic account)
        {
            //Fetching the List from the DB
            List<dynamic> accounts = FileRead();
            //Appending data
            account.Id = accounts.OrderBy(a => a.Id).Last().Id + 1;
            account.Registered = DateTime.Now.ToString();


            //ADD DISCOUNT -----------------------------------NOT DONE YET
            account.Discount = 25;


            accounts.Add(account);
            //Saving the new List to DB

            FileMutations(accounts);
            return account;
        }
        public Account.AccountPrime Create(Account.AccountPrime account)
        {
            //Fetching the List from the DB
            List<dynamic> accounts = FileRead();
            //Appending data
            account.Id = accounts.OrderBy(a => a.Id).Last().Id + 1;
            account.Registered = DateTime.Now.ToString();


            //ADD BONUS ------------------------------------- NOT DONE YET
            account.Bonus = account.Bonus + 10;


            accounts.Add(account);

            //Saving the new List to DB
            FileMutations(accounts);
            return account;
        }


        //  GET ALL
        public List<dynamic> ReadAll() => FileRead();

        //  GET ONE
        public Account.AccountBasic ReadOneBasic(int id)
        {
            List<dynamic> accounts = FileRead();

            Account.AccountBasic account = accounts.Where(a => a.Id == id).ToList()[0];
            return account;
        }
        public Account.AccountPrime ReadOnePrime(int id)
        {
            List<dynamic> accounts = FileRead();

            Account.AccountPrime account = accounts.Where(a => a.Id == id).ToList()[0];
            return account;
        }

        //  UPDATE
        public Account.AccountBasic Update(Account.AccountBasic account, char keyToModify, string newValue)
        {
            Console.WriteLine("Update AccountBasic " + newValue);
            int age = 0;

            if (keyToModify == '3')
            {
                age = int.Parse(newValue);
                account.Age = age; //didn't work in the switch statement for some reason
            }

            string key = keyToModify switch
            {
                '1' => account.FirstName = newValue,
                '2' => account.LastName = newValue,
                '4' => account.City = newValue,
                '5' => account.ZipCode = newValue,
                '6' => account.Street = newValue,
                '7' => account.Phonenumber = newValue,
                '8' => account.Email = newValue,
                '9' => account.Type = newValue,
                _ => ""
            };

            List<dynamic> accounts = FileRead();
            List<dynamic> newList = accounts.Where(a => a.Id != account.Id).ToList();
            newList.Add(account);
            FileMutations(newList);

            return account;
        }
        public Account.AccountPrime Update(Account.AccountPrime account, char keyToModify, string newValue)
        {
            Console.WriteLine("Update AccountPrime " + newValue);

            int age = 0;

            if (keyToModify == '3')
            {
                age = int.Parse(newValue);
                account.Age = age; //didn't work in the switch statement for some reason
            }

            string key = keyToModify switch
            {
                '1' => account.FirstName = newValue,
                '2' => account.LastName = newValue,
                '4' => account.City = newValue,
                '5' => account.ZipCode = newValue,
                '6' => account.Street = newValue,
                '7' => account.Phonenumber = newValue,
                '8' => account.Email = newValue,
                '9' => account.Type = newValue,
                _ => ""
            };

            List<dynamic> accounts = FileRead();
            List<dynamic> newList = accounts.Where(a => a.Id != account.Id).ToList();
            newList.Add(account);
            FileMutations(newList);

            return account;
        }

        //  DELETE
        public bool Delete(Account.AccountBasic account)
        {
            List<dynamic> accounts = FileRead();
            List<dynamic> newList = accounts.Where(a => a.Id != account.Id).ToList();

            FileMutations(newList);
            return true;
        }
        public bool Delete(Account.AccountPrime account)
        {
            List<dynamic> accounts = FileRead();
            List<dynamic> newList = accounts.Where(a => a.Id != account.Id).ToList();

            FileMutations(newList);
            return true;
        }




        //  FILE MUTATIONS
        public bool FileMutations(List<dynamic> accounts)
        {
            List<dynamic> sortedAccountList = accounts.OrderBy(q => q.Id).ToList();
            string value = JsonSerializer.Serialize(sortedAccountList);
            File.WriteAllText(path, value);
            return true;
        }




        //  FILE READ
        public List<dynamic> FileRead()
        {
            string values = File.ReadAllText(path);
            //Console.WriteLine("The original JSON" + values);

            try
            {
                //TODO, NEEDS TO HANDLE EXCEPTIONS (RIGHT NOW IF PUT IN HERE IT WILL NOT BE ABLE TO RETURN A NEW LIST OF ACCOUNTS)
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<dynamic> listOfDynamicObjects = JsonSerializer.Deserialize<List<dynamic>>(values);
            List<dynamic> listOfAccountTypes = new List<dynamic>();

            foreach (var item in listOfDynamicObjects)
            {
                var temporaryObject = JsonSerializer.Deserialize<Account.Temp>(item);


                if (temporaryObject.Type == "basic")
                {
                    Account.AccountBasic basicAccount = new Account.AccountBasic()
                    {
                        Id = temporaryObject.Id,
                        Registered = temporaryObject.Registered,
                        FirstName = temporaryObject.FirstName,
                        LastName = temporaryObject.LastName,
                        Age = temporaryObject.Age,
                        City = temporaryObject.City,
                        ZipCode = temporaryObject.ZipCode,
                        Street = temporaryObject.Street,
                        Phonenumber = temporaryObject.Phonenumber,
                        Email = temporaryObject.Email,
                        Type = temporaryObject.Type,
                        Discount = temporaryObject?.Discount,
                    };

                    listOfAccountTypes.Add(basicAccount);
                }

                if (temporaryObject.Type == "prime")
                {
                    Account.AccountPrime primeAccount = new Account.AccountPrime()
                    {
                        Id = temporaryObject.Id,
                        Registered = temporaryObject.Registered,
                        FirstName = temporaryObject.FirstName,
                        LastName = temporaryObject.LastName,
                        Age = temporaryObject.Age,
                        City = temporaryObject.City,
                        ZipCode = temporaryObject.ZipCode,
                        Street = temporaryObject.Street,
                        Phonenumber = temporaryObject.Phonenumber,
                        Email = temporaryObject.Email,
                        Type = temporaryObject.Type,
                        Bonus = temporaryObject?.Bonus,
                    };

                    listOfAccountTypes.Add(primeAccount);
                }
            }

            return listOfAccountTypes;
        }
    }
}