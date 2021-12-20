using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class ToyPile : Production
{
    public int toyCount = 1000;

    private void Update()
    {
        Inventory();
    }

    // POLYMORPHISM
    public override string Inventory()
    {
        string toyPileInventory = "Wrapped presents: " + toyCount;
        return toyPileInventory;
    }
}
