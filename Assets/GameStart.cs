using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SceneManager.LoadSceneAsync(sceneIndex);
    }
}
