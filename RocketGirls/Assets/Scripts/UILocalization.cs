using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILocalization : MonoBehaviour
{


    public GameObject[] disableForEnglishUI;
    public GameObject[] enableForEnglishUI;

    public Text[] localizationTexts;
    private string[] textIds;
    
    public static readonly string English = "EN";
    public static readonly string Chinese = "CH";




    // Use this for initialization
    void Start()
    {

        //store the ids
        textIds = new string[localizationTexts.Length];
        for (int i = 0; i < localizationTexts.Length; ++i)
        {
            textIds[i] = localizationTexts[i].text;
        }

        InitializeLanguage(GetSystemLanguageString());
        //InitializeLanguage(Chinese);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitializeLanguage(string language)
    {
        LocalizationText.SetLanguage(language);

        foreach (var o in disableForEnglishUI)
        {
            o.SetActive(!language.Equals(English));
        }
        foreach (var o in enableForEnglishUI)
        {
            o.SetActive(language.Equals(English));
        }
        for (int i = 0; i < localizationTexts.Length; ++i)
        {
            localizationTexts[i].text = LocalizationText.GetText(textIds[i]);
        }

    }

    public void NextLanguage()
    {
        string currentLanguage = LocalizationText.GetLanguage();
        if (currentLanguage.Equals(Chinese))
        {
            InitializeLanguage(English);
        }
        else
        {
            InitializeLanguage(Chinese);
        }
    }

    public static string GetSystemLanguageString()
    {
        SystemLanguage lang = Application.systemLanguage;
        if (lang == SystemLanguage.Chinese || lang == SystemLanguage.ChineseTraditional || lang == SystemLanguage.ChineseSimplified)
        {
            return Chinese;
        }
        else
        {
            return English;
        }
    }
}
