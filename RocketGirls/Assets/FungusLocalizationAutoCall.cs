using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Localization))]
public class FungusLocalizationAutoCall : MonoBehaviour {

    protected Localization localizationScript;

    private void Awake()
    {
        localizationScript = GetComponent<Localization>();
    }
    // Use this for initialization
    void Start()
    {
        localizationScript.SetActiveLanguage(UILocalization.GetSystemLanguageString(), true);
        //localizationScript.SetActiveLanguage("CH", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
