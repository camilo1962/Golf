using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StateManager : MonoBehaviour
{
    public void LoadLevel(string nombreNivel)
    {
        SceneManager.LoadSceneAsync(nombreNivel, LoadSceneMode.Single);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Salir()
    {
        Application.Quit();
    }
}
