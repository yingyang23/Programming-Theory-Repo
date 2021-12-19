using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class SackSleigh : Production
{
    public int toyCount;

    // POLYMORPHISM
    public override string Inventory()
    {
        string toysinSack = "Toys in sack: " + toyCount;
        return toysinSack;
    }
}
