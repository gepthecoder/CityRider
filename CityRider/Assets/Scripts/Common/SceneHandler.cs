/*
 TO:DO =>
            -> Smooth transition via animator
                    -> Fade In / Fade Out
 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class SceneHandler : MonoBehaviour
{
   
    public void SwitchToMainScene()
    {
        if (!SceneExists(Consts.Scene_Main)) {
            Debug.LogError("SceneHandler --> Scene named: " + Consts.Scene_Main + " is not an active scene. Please add it to open scenes in build settings :)");
            return;
        }
        SceneManager.LoadScene(Consts.Scene_Main);
    }

    public void SwitchToMenuScene()
    {
        if (!SceneExists(Consts.Scene_Menu))
        {
            Debug.LogError("SceneHandler --> Scene named: " + Consts.Scene_Menu + " is not an active scene. Please add it to open scenes in build settings :)");
            return;
        }
        SceneManager.LoadScene(Consts.Scene_Menu);
    }

    private bool SceneExists(string scene_name)
    {
        return SceneManager.GetSceneByName(scene_name) != null;
    }
}
