using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPile : Production
{

    public int toyCount = 1000;

    private void Update()
    {
        Inventory();
        Debug.Log(Inventory());
    }

    public override string Inventory()
    {
        string toyPileInventory = "Toy Count" + toyCount;
        return toyPileInventory;
    }

}
