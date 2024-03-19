using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoEntreE : MonoBehaviour
{
    private SonidoEntreE instance;
    public SonidoEntreE Instance



    {
        get
        {
            return instance;
        }
    }

    public static bool gamePanel;
    public GameObject SonidoP;

    private AudioSource audioS;
    public Slider VSlider;


    private void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        SonidoP.SetActive(false);
        audioS = GetComponent<AudioSource>();
        VSlider.value = PlayerPrefs.GetFloat("sonidoVolumen", 0.5f);
    }

    private void Update()
    {
        audioS.volume = VSlider.value;
    }

    public void SwitchSonido()
    {
        if (gamePanel)
        {
            bntResume();
        }
        else
        {
            btnPause();
        }
    }
    void bntResume()
    {
        SonidoP.SetActive(false);
        Time.timeScale = 1;
        gamePanel = false;
        PlayerPrefs.SetFloat("sonidoVolumen", audioS.volume);
    }

    void btnPause()
    {
        SonidoP.SetActive(true);
        Time.timeScale = 0;
        gamePanel = true;
    }
}
