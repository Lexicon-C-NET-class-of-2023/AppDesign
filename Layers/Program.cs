using Layers.Views;
Menu.MainMenu();


//TODO
//basic 25% discount on one rental /year
//track if discount has been used

//prime 1 bonus point for every krona 

//if lawnmover is not in rentals available = true (method that checks automatically since i just delete them in the rental file while working on the project)

//account.Create needs to be string since there is more than 9 alternatives now


// MVC (Model, View, Controller)

// Views: Provide alternatives to the user (ReadLines & WriteLines)
// Controllers: Handling the communication/data between the "Views" and the "DB" 
// Services: Adding properties that is requires userInputs to models
// Repos: CRUD operations that handle the database & adds non-userinput data to models
// Models: structures the objects that go into the database

// FLOW Program.cs => Menu.cs => (new menues with further alternatives) => Controllers => Services => Repos => Models