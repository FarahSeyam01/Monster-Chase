using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GAMEPLAYUICONTROLLER : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReStart()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
