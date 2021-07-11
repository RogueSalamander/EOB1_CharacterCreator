using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class MainMenuManager : MonoBehaviour
{
    public Image startMenuPanel;
    public Image characterCreatorPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {

    }

    public void NewCharacter()
    {
        startMenuPanel.gameObject.SetActive(false);
        characterCreatorPanel.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
