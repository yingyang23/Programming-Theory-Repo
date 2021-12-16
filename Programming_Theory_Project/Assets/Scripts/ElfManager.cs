using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfManager : MonoBehaviour
{

    /*GameObject[] agents;

    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("Elf");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                foreach (GameObject a in agents)
                    a.GetComponent<ElfControl>().agent.SetDestination(hit.point);
            }
        }
    }*/

    public float speedModifier = 10f;
    private ElfControl elfControl;
    private bool shiftOver = false;

    private void Start()
    {

        elfControl = GameObject.Find("Elf").GetComponent<ElfControl>();
    }

    public void GetToWork()
    {
        elfControl.timeToRest = false;
        elfControl.elfIsWorking = true;
    }

    public void IncreaseSpeed()
    {
        elfControl.speed += speedModifier;
    }

    public void DecreaseSpeed()
    {
        elfControl.speed -= speedModifier;
    }

    public void TimeToRest()
    {
        elfControl.elfIsWorking = false;
        elfControl.timeToRest = true;
    }
}
