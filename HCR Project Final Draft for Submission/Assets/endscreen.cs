using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endscreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Start Menu"); // Load the scene with index 0 (Start Menu)
    }
}
