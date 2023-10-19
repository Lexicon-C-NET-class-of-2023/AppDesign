using Layers.Repositories;
using Layers.Services;
using Layers.Views;
Menu.MainMenu();


//var accounts = myAccountRepo.FileRead();

//foreach (var item in accounts) Console.WriteLine("In Program.cs " + item.FirstName);



// MVC (Model, View, Controller)

// Model: DTOs (Data Transfer Objects) structures the objects (only props)
// Views: readLines, writeLines (alternatives)
// Controllers: Business logic for handling the data

// Views: Provide alternatives to the user
// Controllers: Determines what to do with the userInput
// Repos: CRUD operations that handle the database
// Services: human-near aliases for calling the CRUD operations
// Models: structures the objects that go into the database 

// FLOW Program.cs => Menu.cs => (new menues with further ( ... ) alternatives) => Controllers => Services => Repos => Models
// ( ... ) AccountControllers.cs => public void ViewAllAccounts()
//    {
//    var response = accountService.GetAll();
//    ShowAccounts.ShowAllAccounts(response);
//    }