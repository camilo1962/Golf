using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("Referencias")]
    [SerializeField] private TextMeshProUGUI strokeUI;
    [SerializeField] private TextMeshProUGUI ParUI;
    [Space(10)]
    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private TextMeshProUGUI levelCompletedStrokeUI;
    [SerializeField] private TextMeshProUGUI resultadoUI;
    [Space(10)]
    [SerializeField] private GameObject gameOverUI;

    [Header("Atributos")]
    [SerializeField] private int maxStrokes;
    [SerializeField] private int nnivel;
    [SerializeField] private int topeStrokes;
    [SerializeField] public TextMeshProUGUI totalStrokesText;

    public SummaryPanel summaryPanel;
    // Nueva variable para el total de strokes acumulados
    private static int totalStrokes;
   
    private int currentLevel = 1;
    private bool levelCompletedFlag = false;
   
    private Dictionary<int, int> strokesByLevel = new Dictionary<int, int>();

    private int strokes;
    [HideInInspector] public bool outOfStrokes;
    [HideInInspector] public bool levelCompleted;
    private object levelManager;

    private void Awake()
    {
        main = this;
        // Inicializa el total de strokes acumulados al inicio del juego
        //totalStrokes = 0;
    }
    private void Start()
    {
        UpdateStrokeUI();
        
       
    }
   

    
    public void ResetLevelData()
    {
        strokesByLevel.Clear();
        currentLevel = 1;
        PlayerPrefs.DeleteAll();
    }
    public void IncreaseStroke()
    {

        strokes++;
        UpdateStrokeUI();

        if(strokes >= maxStrokes)
        {
            outOfStrokes = true;
        }
    }

    //public void LevelComplete()
    //{
    //    levelCompleted = true;    
    //         
    //    
    //    
    //    levelCompletedStrokeUI.text = strokes > //1 ?"Lametiste en " + strokes + "golpes" : "¡Tienes //unhoyoen uno!";
    //    
    //    levelCompleteUI.SetActive(true);
    //}
    public void CompleteCurrentLevel()
    {
        LevelComplete();
        levelCompletedFlag = true;
        currentLevel++;
        // Guarda los strokes del nivel actual en el diccionario
        int strokesForCurrentLevel = strokesByLevel[currentLevel]; // Ajusta según tu lógica de juego
        strokesByLevel[currentLevel] = strokesForCurrentLevel;
      
    }

    public int GetStrokesForLevel(int level)
    {
        // Obtiene los strokes del nivel desde el diccionario
        if (strokesByLevel.ContainsKey(level))
        {
            return strokesByLevel[level];
        }
        else
        {
            return 0;
        }
    }
    public void LevelComplete()
    {
        levelCompleted = true;
        

        //totalStrokes += strokes;
       
        strokesByLevel[currentLevel] = strokes;
        
        PlayerPrefs.SetInt("toques" + nnivel, strokes);
        
       
        totalStrokes = PlayerPrefs.GetInt("toques" + 1) + PlayerPrefs.GetInt("toques" + 2) + PlayerPrefs.GetInt("toques" + 3) + PlayerPrefs.GetInt("toques" + 4) + PlayerPrefs.GetInt("toques" + 5) + PlayerPrefs.GetInt("toques" + 6) + PlayerPrefs.GetInt("toques" + 7) + PlayerPrefs.GetInt("toques" + 8) + PlayerPrefs.GetInt("toques" + 9) + PlayerPrefs.GetInt("toques" + 10) + PlayerPrefs.GetInt("toques" + 11) + PlayerPrefs.GetInt("toques" + 12) + PlayerPrefs.GetInt("toques" + 13) + PlayerPrefs.GetInt("toques" + 14) + PlayerPrefs.GetInt("toques" + 15) + PlayerPrefs.GetInt("toques" + 16) + PlayerPrefs.GetInt("toques" + 17) + PlayerPrefs.GetInt("toques" + 18);
        totalStrokesText.text =  totalStrokes.ToString();
        currentLevel++;
        Debug.Log("Current Level: " + currentLevel);
        levelCompletedFlag = true; // Establece la bandera cuando el nivel se ha completado
                                   // Suma los strokes de este nivel al total


        string message;

        switch (strokes)
        {
            case int n when n == maxStrokes - 4:
                message = "¡Condor!";
                break;
            case int n when n == maxStrokes - 3:
                message = "¡Albatros!";
                break;
            case int n when n == maxStrokes - 2:
                message = "¡Eagle!";
                break;
            case int n when n == maxStrokes - 1:
                message = "¡Birdie!";
                break;
            case int n when n == maxStrokes:
                message = "Par";
                break;
            case int n when n == maxStrokes + 1:
                message = "Bogey";
                break;
            case int n when n == maxStrokes + 2:
                message = "Doble Bogey";
                break;
            case int n when n == maxStrokes + 3:
                message = "Triple Bogey";
                break;
            default:
                message = "¡Entrenaaaa!";
                break;
        }

        resultadoUI.text = message;
        levelCompletedStrokeUI.text = strokes > 1 ? "La metiste en " + strokes + " golpes" : "¡Tienes un hoyo en uno!";

        levelCompleteUI.SetActive(true);
    }
    public bool IsLevelCompleted()
    {
        return levelCompletedFlag;
    }
    public void ResetLevelCompletedFlag()
    {
        levelCompletedFlag = false;
    }
   

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    private void UpdateStrokeUI()
    {
        strokeUI.text = "Nº Toques: " + strokes;
        ParUI.text = "Par: " + maxStrokes;
    }

    // Método para obtener el total de strokes acumulados
    public  int GetTotalStrokes()
    {
        return totalStrokes;
    }

    // Método para reiniciar las variables al cambiar de escena
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reinicia las variables del nivel al cargar una nueva escena
        strokes = 0;
        outOfStrokes = false;
        levelCompleted = false;
       // currentLevel = 1; // Reinicia al nivel 1
        UpdateStrokeUI();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
       if (strokes > topeStrokes)
       {
            gameOverUI.SetActive(true);

       }
    }

    internal void SaveStrokesForCurrentLevel(int strokesForCurrentLevel)
    {
        throw new NotImplementedException();
    }
}
