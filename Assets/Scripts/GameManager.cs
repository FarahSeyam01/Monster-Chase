using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject[] characters;

    private int _charindex;
    public int charIndex
    {
        get { return _charindex; }
        set { _charindex = value; }
    }


    private void Awake()
    {
        if (!instance)
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
        SceneManager.sceneLoaded += OnLevelFiniedLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFiniedLoading;
    }

    // Update is called once per frame
    void OnLevelFiniedLoading(Scene scene,LoadSceneMode mode)
    {
   if (scene.name== "GamePlay"){
            Instantiate(characters[charIndex]);
        }
    }
}//class














