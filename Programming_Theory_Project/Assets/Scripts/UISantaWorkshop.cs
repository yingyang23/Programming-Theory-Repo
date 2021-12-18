using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UISantaWorkshop : MonoBehaviour
{
    private ElfControl elfControl;
    private SackSleigh sackSleigh;

    [SerializeField] private TextMeshProUGUI elfManagerName;
    [SerializeField] private TextMeshProUGUI presentsInSleigh;
    [SerializeField] private TextMeshProUGUI burnOutWarning;
    [SerializeField] private TextMeshProUGUI burnOutLeave;
    

    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject shiftWorkCanvas;
    [SerializeField] private GameObject restartButton;

    void Start()
    {
        elfControl = GameObject.Find("Elf").GetComponent<ElfControl>();
        sackSleigh = GameObject.Find("SleighSack").GetComponent<SackSleigh>();
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

        presentsInSleigh.SetText("Presents in Sleigh: " + sackSleigh.toyCount);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
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
