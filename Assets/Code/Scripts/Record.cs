using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Record : MonoBehaviour
{
    public TMP_Text hoyo1Text;
    public TMP_Text hoyo2Text;
    public TMP_Text hoyo3Text;
    public TMP_Text hoyo4Text;
    public TMP_Text hoyo5Text;
    public TMP_Text hoyo6Text;
    public TMP_Text hoyo7Text;
    public TMP_Text hoyo8Text;
    public TMP_Text hoyo9Text;
    public TMP_Text hoyo10Text;
    public TMP_Text hoyo11Text;
    public TMP_Text hoyo12Text;
    public TMP_Text hoyo13Text;
    public TMP_Text hoyo14Text;
    public TMP_Text hoyo15Text;
    public TMP_Text hoyo16Text;
    public TMP_Text hoyo17Text;
    public TMP_Text hoyo18Text;

    void Start()
    {
        
    }

   
    void Update()
    {
        hoyo1Text.text = PlayerPrefs.GetInt("toques" + 1).ToString();
        hoyo2Text.text = PlayerPrefs.GetInt("toques" + 2).ToString();
        hoyo3Text.text = PlayerPrefs.GetInt("toques" + 3).ToString();
        hoyo4Text.text = PlayerPrefs.GetInt("toques" + 4).ToString();
        hoyo5Text.text = PlayerPrefs.GetInt("toques" + 5).ToString();
        hoyo6Text.text = PlayerPrefs.GetInt("toques" + 6).ToString();
        hoyo7Text.text = PlayerPrefs.GetInt("toques" + 7).ToString();
        hoyo8Text.text = PlayerPrefs.GetInt("toques" + 8).ToString();
        hoyo9Text.text = PlayerPrefs.GetInt("toques" + 9).ToString();
        hoyo10Text.text = PlayerPrefs.GetInt("toques" + 10).ToString();
        hoyo11Text.text = PlayerPrefs.GetInt("toques" + 11).ToString();
        hoyo12Text.text = PlayerPrefs.GetInt("toques" + 12).ToString();
        hoyo13Text.text = PlayerPrefs.GetInt("toques" + 13).ToString();
        hoyo14Text.text = PlayerPrefs.GetInt("toques" + 14).ToString();
        hoyo15Text.text = PlayerPrefs.GetInt("toques" + 15).ToString();
        hoyo16Text.text = PlayerPrefs.GetInt("toques" + 16).ToString();
        hoyo17Text.text = PlayerPrefs.GetInt("toques" + 17).ToString();
        hoyo18Text.text = PlayerPrefs.GetInt("toques" + 18).ToString();
        
    }
}
