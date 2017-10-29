using UnityEngine;
using System.Collections;

public class QuitApplication : MonoBehaviour
{
    public void Quit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE || UNITY_WEBPLAYER 
Application.Quit();

#elif UNITY_ANDROID
        AndroidJavaObject activity =
            new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);

        //If we are running in the editor
#elif UNITY_EDITOR //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}