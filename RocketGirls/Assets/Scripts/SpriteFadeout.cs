using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFadeout : MonoBehaviour {
    public float fadeSpeed = 0.65f;

    public float target = 1;
    public bool disableWhenTransparent = true;

    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update () {
        Color currentColor = spriteRenderer.color;
        if(currentColor.a < target)
        {
            currentColor.a += fadeSpeed * Time.deltaTime;
            if(currentColor.a >= target)
            {
                currentColor.a = target;
            }
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
            spriteRenderer.color = currentColor;
        }else if(currentColor.a > target)
        {
            currentColor.a -= fadeSpeed * Time.deltaTime;
            if (currentColor.a <= target)
            {
                currentColor.a = target;
                if (disableWhenTransparent)
                {
                    gameObject.SetActive(false);
                }
            }
            spriteRenderer.color = currentColor;
        }

    }
}
