﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void playGame()
    {

        int clickedObj = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.charIndex = clickedObj;
        SceneManager.LoadScene("GamePlay");
    }
}
