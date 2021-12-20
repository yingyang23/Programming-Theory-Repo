using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UISantaWorkshop : MonoBehaviour
{
    private ElfControl elfControl;
    private SackSleigh sackSleigh;
    private ToyPile toyPile;

    [SerializeField] private TextMeshProUGUI elfManagerName;
    [SerializeField] private TextMeshProUGUI subordinateSpeed;
    [SerializeField] private TextMeshProUGUI presentsInSleigh;
    [SerializeField] private TextMeshProUGUI toyPileCount;
    [SerializeField] private TextMeshProUGUI burnOutWarning;
    [SerializeField] private TextMeshProUGUI burnOutLeave;
    

    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject shiftWorkCanvas;
    [SerializeField] private GameObject restartButton;

    void Start()
    {
        elfControl = GameObject.Find("Elf").GetComponent<ElfControl>();
        sackSleigh = GameObject.Find("SleighSack").GetComponent<SackSleigh>();
        toyPile = GameObject.Find("Toy Pile").GetComponent<ToyPile>();

        if(ElfManagerName.Instance != null)
        {
            elfManagerName.SetText("Elf Manager: " + ElfManagerName.Instance.managerNameText);
        }
        
    }

    void Update()
    {
        if (elfControl.speed == 60)
        {
            burnOutWarning.gameObject.SetActive(true);
            StartCoroutine(BurnOutLeave());
        }
        else
        {
            burnOutWarning.gameObject.SetActive(false);
        }

        if(elfControl.elfIsWorking == true)
        { 
        subordinateSpeed.SetText(elfControl.GetProductivity());
        }
        else
        {
            subordinateSpeed.SetText("Subordinate resting");
        }

        presentsInSleigh.SetText(sackSleigh.Inventory());
        toyPileCount.SetText(toyPile.Inventory());
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator BurnOutLeave()
    {
        yield return new WaitForSeconds(6);
        if (elfControl.speed == 60 && !elfControl.timeToRest)
        {
            elf.SetActive(false);
            shiftWorkCanvas.SetActive(false);
            restartButton.SetActive(true);
            burnOutWarning.text = "";
            burnOutLeave.gameObject.SetActive(true);
        }
        else
        {
            burnOutWarning.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}
