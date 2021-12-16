using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElfControl : Staff
{

    /*public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }*/

    // Update is called once per frame

    public GameObject[] waypoints;
    int currentWP = 0;

    private float m_speed = 10.0f;
    public float speed
    {
        get { return m_speed; }
        set
        {
            m_speed = value;
            if (m_speed <  0)
            {
                m_speed = 0;
            }
            if(m_speed > 60)
            {
                m_speed = 60;
            }
        }
    }

    public float rotSpeed = 10.0f;
    public bool elfIsWorking = false;

    private ToyPile toyPile;

    private void Start()
    {
        toyPile = GameObject.FindWithTag("Toy Pile").GetComponent<ToyPile>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            elfIsWorking = true;
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            elfIsWorking = false;
        }
            
        if(elfIsWorking)
        {
            GiftsToSleigh();
        }

        GetProductivity();
        Debug.Log(GetProductivity());

    }

    void GiftsToSleigh ()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 2)
            currentWP++;
        if (currentWP >= waypoints.Length)
            currentWP = 0;

        this.transform.LookAt(waypoints[currentWP].transform);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public override string GetStatus()
    {
        return gameObject.name;
    }

    public override string GetProductivity()
    {
        string Productivity = "Working speed = " + m_speed;
        return Productivity;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy Pile"))
        {
            other.gameObject.GetComponent<ToyPile>().toyCount -= 1;
            Debug.Log("Elf touched Toy Pile");
        }

        if (other.gameObject.CompareTag("Sleigh Sack"))
        {
            other.gameObject.GetComponent<SackSleigh>().toyCount += 1;
            Debug.Log("Sack touched by Elf");
        }
    }

    

}
