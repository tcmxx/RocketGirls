using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(Animator))]
[ExecuteInEditMode()]
public class AbilityKey : MonoBehaviour {

    public char letter;

    protected TextMesh textMesh;
    protected Animator keyAnimator;
    private void Awake()
    {
        keyAnimator = GetComponent<Animator>();
        textMesh = GetComponent<TextMesh>();
        textMesh.text = letter.ToString();
    }


    public void OnReadyNext()
    {
        keyAnimator.SetTrigger("Ready");
    }

    public void OnPlayedCorrect()
    {
        keyAnimator.SetTrigger("Succeed");
    }

    public void OnPlayedWrong()
    {
        keyAnimator.SetTrigger("Fail");
    }

    public void ResetGraphic()
    {
        keyAnimator.SetTrigger("Reset");
        keyAnimator.ResetTrigger("Fail");
        keyAnimator.ResetTrigger("Succeed");
        keyAnimator.ResetTrigger("Ready");
    }
}
