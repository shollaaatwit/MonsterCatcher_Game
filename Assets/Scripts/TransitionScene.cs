using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public void NextScene(string sceneN)
    {

        SceneManager.LoadScene(sceneN);

    }
}
