using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickOnPlay()
    {

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
