using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneMangerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        int selectedChar= int.Parse(EventSystem.current.currentSelectedGameObject.name);
        GameMangerScript.instance.CharIdex= selectedChar;
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToHomeScreen()
    {
        SceneManager.LoadScene(0);
    } 
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }
}
