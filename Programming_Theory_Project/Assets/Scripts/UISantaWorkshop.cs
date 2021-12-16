using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UISantaWorkshop : MonoBehaviour
{
    private ElfControl elfControl;
    private SackSleigh sackSleigh;

    public TextMeshProUGUI elftManagerName;
    public TextMeshProUGUI presentsInSleigh;
    public TextMeshProUGUI burnOutWarning;
    public TextMeshProUGUI burnOutLeave;
    

    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject shiftWorkCanvas;
    [SerializeField] private GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        elfControl = GameObject.Find("Elf").GetComponent<ElfControl>();
        sackSleigh = GameObject.Find("SleighSack").GetComponent<SackSleigh>();
        if(ElfManagerName.Instance != null)
        {
            elftManagerName.SetText("Elf Manager: " + ElfManagerName.Instance.managerNameText);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (elfControl.speed == 60)
        {
            StartCoroutine(BurnOutLeave());
            //Invoke("LostToBurnOut", 6);
        }

        presentsInSleigh.SetText("Presents in Sleigh: " + sackSleigh.toyCount);
    }

    void LostToBurnOut()
    {
        //GameObject.FindWithTag("Elf").GetComponent<MeshRenderer>().enabled = false;     
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    IEnumerator BurnOutLeave()
    {
        burnOutWarning.gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        if (elfControl.speed == 60)
        {
            elf.SetActive(false);
            shiftWorkCanvas.SetActive(false);
            restartButton.SetActive(true);
            burnOutWarning.text = "";
            burnOutLeave.gameObject.SetActive(true);
        }
        else
        {
            StopCoroutine(BurnOutLeave());
        }
        
    }

}
