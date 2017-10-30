using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour
{
    private static int uiNumber = 0;
    private static int uiMaxNumber = 1;

    void Start()
    {
        if (uiNumber < uiMaxNumber)
        {
            uiNumber += 1;
            //Causes UI object not to be destroyed when loading a new scene. If you want it to be destroyed, destroy it manually via script.
            DontDestroyOnLoad(this.gameObject);
        }
    }
}