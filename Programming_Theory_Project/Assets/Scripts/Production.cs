using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    public virtual string UnitName()
    {
        return gameObject.name;
    }

    public virtual string Inventory()
    {
        return "";
    }
}
