using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void Load(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void Load(string sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
