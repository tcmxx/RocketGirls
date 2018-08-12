using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamyEyes : MonoBehaviour {
    
    public float filupAmount = 40;
    public float showUpTime = 0.9f;
    public float laserTime = 0.4f;
    public float disapearTime = 0.9f;
    public LineRenderer line1;
    public LineRenderer line2;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        StartCoroutine(LaserEyeCoroutine());
        spriteRenderer.color = new Color(1, 1, 1, 0);
    }


 

    IEnumerator LaserEyeCoroutine()
    {
        MathUtils.Shuffle(SpaceShipGroup.Instance.AllRocket, new System.Random());

        Rocket r1 = SpaceShipGroup.Instance.AllRocket[0];
        Rocket r2 = SpaceShipGroup.Instance.AllRocket[1];
        if(r1.gameObject.name == "SpaceshipYamy")
        {
            r1 = SpaceShipGroup.Instance.AllRocket[2];
        }else if(r2.gameObject.name == "SpaceshipYamy")
        {
            r2 = SpaceShipGroup.Instance.AllRocket[2];
        }
        float t = 0;
        while(t < showUpTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, t / showUpTime);
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
        }
        spriteRenderer.color = new Color(1, 1, 1, 1);

        line1.SetPositions(new Vector3[] { line1.transform.position, r1.transform.position });
        line2.SetPositions(new Vector3[] { line2.transform.position, r2.transform.position });
        r1.GetResource(filupAmount); r2.GetResource(filupAmount);
        yield return new WaitForSeconds(laserTime);
        line1.enabled = false;
        line2.enabled = false;

        t = 0;
        while (t < disapearTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1- t / disapearTime);
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
        }

        Destroy(gameObject);

    }

}
