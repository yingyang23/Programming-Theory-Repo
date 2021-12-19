using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// INHERITANCE
public class ElfControl : Staff
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject restingSpot;
    public int currentWP = 0;

    // ENCAPSULATION
    [SerializeField]
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

    [SerializeField] private float windDownSpeed = 4.0f;
    public bool elfIsWorking = false;
    public bool timeToRest = false;

    private ToyPile toyPile;

    private void Start()
    {
        toyPile = GameObject.FindWithTag("Toy Pile").GetComponent<ToyPile>();
    }

    void Update()
    {
            
        if(elfIsWorking)
        {
            GiftsToSleigh();
        }

        if(timeToRest == true)
        {
            speed = 10f;
        }

        if(!elfIsWorking && timeToRest == true)
        {
            TimeToRest();
        }

        GetProductivity();

    }

    // ABSTRACTION
    void GiftsToSleigh ()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 2)
            currentWP++;
        if (currentWP >= waypoints.Length)
            currentWP = 0;

        this.transform.LookAt(waypoints[currentWP].transform);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    // ABSTRACTION
    void TimeToRest()
    {
        this.transform.LookAt(restingSpot.transform);
        this.transform.Translate(0, 0, windDownSpeed * Time.deltaTime);
    }

    // POLYMORPHISM
    public override string GetStatus()
    {
        return gameObject.name;
    }

    // POLYMORPHISM
    public override string GetProductivity()
    {
        string Productivity = "Subordinate's speed: " + m_speed + " u/s";
        return Productivity;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy Pile"))
        {
            other.gameObject.GetComponent<ToyPile>().toyCount -= 1;
        }

        if (other.gameObject.CompareTag("Sleigh Sack"))
        {
            other.gameObject.GetComponent<SackSleigh>().toyCount = 1000 - toyPile.toyCount;
        }
    }
}
