using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif 

public class MenuTitleScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI elfManagerName;

    private void Update()
    {
        ElfManagerName.Instance.managerNameText = elfManagerName.text;
    }

    public void StartShift()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
