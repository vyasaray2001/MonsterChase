using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameMangerScript : MonoBehaviour
{
    [SerializeField] GameObject[] characters;
    public static GameMangerScript instance;

    private int _charIndex;

    public int CharIdex
    {
        get{
            return _charIndex;
        }

        set
        {
            _charIndex = value;
        }

    }

    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += onLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onLevelFinishedLoading;
    }

    void onLevelFinishedLoading(Scene scene,LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
          Instantiate(characters[CharIdex]);
        }
    }
}
