using Layers.Views;
Menu.MainMenu();

//basic must rent at least 7 days
//basic 25% discount on one rental /year
//track if discount has been used

//prime 1 bonus point for every krona 


//todo if lawnmover is not in rentals their available = true


// MVC (Model, View, Controller)

// Views: Provide alternatives to the user (ReadLines & WriteLines)
// Controllers: Handling the communication/data between the "Views" and the "DB" 
// Services: Adding properties that is requires userInputs to models
// Repos: CRUD operations that handle the database & adds non-userinput data to models
// Models: structures the objects that go into the database

// FLOW Program.cs => Menu.cs => (new menues with further alternatives) => Controllers => Services => Repos => Models