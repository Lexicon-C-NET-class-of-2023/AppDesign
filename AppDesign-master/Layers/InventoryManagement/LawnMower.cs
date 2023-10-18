using System;
using System.Collections.Generic;

public class LawnMower
{
    public int Id { get; set; }      // Unique identifier for the lawn mower.
    public string Model { get; set; }  // Model of the lawn mower.
    public string Condition { get; set; }  // Condition of the lawn mower (e.g., good, like new).
    public bool IsRented { get; set; }  // Indicates whether the mower is currently rented.
}

public class LawnMowerInventory
{
    private List<LawnMower> mowers;  // List to store lawn mowers.

    public LawnMowerInventory()
    {
        mowers = new List<LawnMower>();  // Initialize the list.
    }

    public void AddNewMower(string model, string condition)
    {
        var newMower = new LawnMower
        {
            Id = mowers.Count + 1,  // Assign a unique ID to the new mower.
            Model = model,  // Set the model of the mower.
            Condition = condition,  // Set the condition of the mower.
            IsRented = false  // Initially, the mower is not rented.
        };
        mowers.Add(newMower);  // Add the new mower to the inventory.
    }

    public void UpdateMower(int mowerId, string condition)
    {
        var mower = mowers.Find(m => m.Id == mowerId);  // Find the mower by ID.
        if (mower != null)
        {
            mower.Condition = condition;  // Update the condition of the mower.
        }
    }

    public void MarkMowerAsRented(int mowerId)
    {
        var mower = mowers.Find(m => m.Id == mowerId);  // Find the mower by ID.
        if (mower != null && !mower.IsRented)
        {
            mower.IsRented = true;  // Mark the mower as rented if it's available.
        }
    }

    public int GetAvailableMowerCount()
    {
        return mowers.Count(m => !m.IsRented);  // Count the available (not rented) mowers.
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LawnMowerInventory inventory = new LawnMowerInventory();

        // Example usage:
        inventory.AddNewMower("Husqvarna LB448S", "Good condition");  // Add a new mower to the inventory.
        inventory.AddNewMower("Honda HRR216", "Excellent condition");  // Add another new mower.
        inventory.MarkMowerAsRented(1);  // Mark the first mower as rented.
        inventory.UpdateMower(2, "Like new");  // Update the condition of the second mower.

        Console.WriteLine($"Available mowers: {inventory.GetAvailableMowerCount()}");  // Display the count of available mowers.
    }
}
