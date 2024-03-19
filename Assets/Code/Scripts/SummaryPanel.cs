using UnityEngine;
using TMPro;

public class SummaryPanel : MonoBehaviour
{
    public TextMeshProUGUI summaryText;
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = LevelManager.main;

        if (levelManager != null)
        {
            // Verifica si el nivel se ha completado antes de iniciar el resumen
            if (levelManager.IsLevelCompleted())
            {
                Debug.Log("Nivel completado. Actualizando resumen.");

                // Actualiza el texto del resumen si el nivel se ha completado
                UpdateSummaryText();

                // Restablece la bandera para el próximo nivel
                levelManager.ResetLevelCompletedFlag();
            }
            else
            {
                Debug.Log("Nivel no completado aún.");
            }
        }
        else
        {
            Debug.LogError("LevelManager no encontrado. Asegúrate de que haya un objeto LevelManager en la escena.");
        }
    }

    // Método para actualizar el resumen cuando el jugador completa el nivel
    public void OnLevelCompleted()
    {
        Debug.Log("Nivel completado. Actualizando resumen.");

        // Actualiza el texto del resumen si el nivel se ha completado
        UpdateSummaryText();
    }

    public void UpdateSummaryText()
    {
        if (levelManager != null)
        {
            int totalStrokes = levelManager.GetTotalStrokes();
    
            // Puedes formatear el texto de resumen como desees
            summaryText.text = "Resumen:\n" +
                              "Hoyo 1:  " + PlayerPrefs.GetInt("toques" + 1).ToString() + "  golpes\n" +
                              "Hoyo 2:  " + PlayerPrefs.GetInt("toques" + 2).ToString() + "  golpes\n" +
                              "Hoyo 3:  " + PlayerPrefs.GetInt("toques" + 3).ToString() + "  golpes\n" +
                              "Hoyo 4:  " + PlayerPrefs.GetInt("toques" + 4).ToString() + "  golpes\n" +
                              "Hoyo 5:  " + PlayerPrefs.GetInt("toques" + 5).ToString() + "  golpes\n" +
                              "Hoyo 6:  " + PlayerPrefs.GetInt("toques" + 6).ToString() + "  golpes\n" +
                              "Hoyo 7:  " + PlayerPrefs.GetInt("toques" + 7).ToString() + "  golpes\n" +
                              "Hoyo 8:  " + PlayerPrefs.GetInt("toques" + 8).ToString() + "  golpes\n" +
                              "Hoyo 9:  " + PlayerPrefs.GetInt("toques" + 9).ToString() + "  golpes\n" +
                              "Hoyo 10: " + PlayerPrefs.GetInt("toques" + 10).ToString() + " golpes\n" +
                              "Hoyo 11: " + PlayerPrefs.GetInt("toques" + 11).ToString() + " golpes\n" +
                              "Hoyo 12: " + PlayerPrefs.GetInt("toques" + 12).ToString() + " golpes\n" +
                              "Hoyo 13: " + PlayerPrefs.GetInt("toques" + 13).ToString() + " golpes\n" +
                              "Hoyo 14: " + PlayerPrefs.GetInt("toques" + 14).ToString() + " golpes\n" +
                              "Hoyo 15: " + PlayerPrefs.GetInt("toques" + 15).ToString() + " golpes\n" +
                              "Hoyo 16: " + PlayerPrefs.GetInt("toques" + 16).ToString() + " golpes\n" +
                              "Hoyo 17: " + PlayerPrefs.GetInt("toques" + 17).ToString() + " golpes\n" +
                              "Hoyo 18: " + PlayerPrefs.GetInt("toques" + 18).ToString() + " golpes\n" +
                              
                              "\nTotal de golpes: " + totalStrokes;
        }
    }
    //public void UpdateSummaryText()
    //{
    //    if (levelManager != null)
    //    {
    //       
    //        int totalStrokes = levelManager.GetTotalStrokes();
    //
    //        // Puedes formatear el texto de resumen como desees
    //        string summary = "Resumen:\n\n";
    //
    //        // Itera sobre los 18 niveles y muestra los strokes
    //        for (int level = 1; level <= 18; level++)
    //        {
    //            summary += "Nivel " + level + ": " + levelManager.GetStrokesForLevel(level) + " strokes\n";
    //        }
    //
    //        summary += "\nTotal de Strokes: " + totalStrokes;
    //
    //        summaryText.text = summary;
    //    }
    //}



}

