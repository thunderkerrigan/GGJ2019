using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    public void ManageScene(string scenename)
        {
            SceneManager.LoadScene(scenename, LoadSceneMode.Single);
        }

}
