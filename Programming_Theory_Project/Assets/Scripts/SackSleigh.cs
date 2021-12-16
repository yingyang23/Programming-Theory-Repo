using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackSleigh : Production
{
    public int toyCount;

    public override string Inventory()
    {
        string toysinSack = "Toys in sack = " + toyCount;
        return toysinSack;
    }

}
