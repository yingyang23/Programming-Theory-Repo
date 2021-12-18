using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfManager : MonoBehaviour
{

    [SerializeField] private float speedModifier = 10f;
    private ElfControl elfControl;

    private void Start()
    {

        elfControl = GameObject.Find("Elf").GetComponent<ElfControl>();
    }

    // ABSTRACTION
    public void GetToWork()
    {
        elfControl.currentWP = 0;
        elfControl.timeToRest = false;
        elfControl.elfIsWorking = true;
    }

    // ABSTRACTION
    public void IncreaseSpeed()
    {
        elfControl.speed += speedModifier;
    }

    // ABSTRACTION
    public void DecreaseSpeed()
    {
        elfControl.speed -= speedModifier;
    }

    // ABSTRACTION
    public void TimeToRest()
    {
        elfControl.elfIsWorking = false;
        elfControl.timeToRest = true;
    }
}
