using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ReusableScripts;
using UnityEngine.SceneManagement;

public class GameManager : ReusableScripts.Singleton<GameManager>
{

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
