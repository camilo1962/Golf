using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHole : MonoBehaviour
{
    public string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "ball")
        {
            SceneManager.LoadSceneAsync(levelName);
        }
    }
}
