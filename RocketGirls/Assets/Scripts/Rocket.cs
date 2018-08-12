using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float currentResource = 50;

    public float maxResource = 100;

    public AnimationCurve healthCurve;

    public Ability specialAbilityPref;
    protected Ability abilityInstance = null;

    public SpriteRenderer healthBarRendererRef;
    public Color dangerousColor;
    public Color okColor;
    public Color goodColor;
    public float showAbilityThreshold = 0.85f;

    public SpaceShipGroup Group { get; set; }

    public RocketStatus status = RocketStatus.Running;

    public enum RocketStatus
    {
        Running,
        Dead,
        Disabled
    }

    private void Awake()
    {
    }

    private void Update()
    {
        if (status == RocketStatus.Running)
        {
            CheckWhetherShowAbility();
            UpdateHealthBar();
            currentResource -= Time.deltaTime * Group.resourceBurningRate;
            currentResource = Mathf.Clamp(currentResource, 0, maxResource);
            if (currentResource <= 0)
            {
                Die();
            }
        }
    }

    protected void Die()
    {
        Group.OnRocketDie(this,true);
        status = RocketStatus.Dead;
        StartCoroutine(DieAnimation());
    }

    public void DieWithoutLoss()
    {
        Group.OnRocketDie(this, false);
        status = RocketStatus.Dead;
        StartCoroutine(DieAnimation());
    }


    IEnumerator DieAnimation()
    {
        transform.GetComponent<Collider2D>().enabled = false;
        transform.SetParent(null);
        float t = 0;
        while(t < 5)
        {
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
            transform.Translate(Vector3.down * 0.75f * Time.deltaTime,Space.World);
        }
    }

    public void TakeDamage(float damage, bool showAnimation = true)
    {
        if (status == RocketStatus.Running)
        {
            currentResource -= damage;
            currentResource = Mathf.Clamp(currentResource, 0, maxResource);
        }
    }

    public void GetResource(float resource)
    {
        if (status == RocketStatus.Running)
        {
            currentResource += resource;
            currentResource = Mathf.Clamp(currentResource, 0, maxResource);
        }
    }

    protected void CheckWhetherShowAbility()
    {
        if(Mathf.Clamp01(currentResource / maxResource) >= showAbilityThreshold && abilityInstance == null)
        {
            abilityInstance = Instantiate(specialAbilityPref, transform.position, Quaternion.identity,transform.parent);
            abilityInstance.GetComponent<Ability>().ParentPlayer = this;
        }
        else if(Mathf.Clamp01(currentResource / maxResource) < showAbilityThreshold && abilityInstance != null)
        {
            abilityInstance.AbilityFailed();
            abilityInstance = null;
        }
    }

    protected void UpdateHealthBar()
    {
        float ratio = healthCurve.Evaluate(Mathf.Clamp01(currentResource / maxResource));
        var scale = healthBarRendererRef.transform.localScale;
        scale.x = ratio;
        healthBarRendererRef.transform.localScale = scale;

        if(ratio < 0.33f)
        {
            healthBarRendererRef.color = dangerousColor;
        }else if(ratio < 0.76f)
        {
            healthBarRendererRef.color = okColor;
        }
        else
        {
            healthBarRendererRef.color = goodColor;
        }
    }

}
