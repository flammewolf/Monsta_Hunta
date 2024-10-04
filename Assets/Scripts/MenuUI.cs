using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI username;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickOnPlay()
    {
        if (username.text.Length > 1)
        {
            MainManager.instance.username = username.text;
            //SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Please enter a username first !");
        }
    }

    public void ClickOnExit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
