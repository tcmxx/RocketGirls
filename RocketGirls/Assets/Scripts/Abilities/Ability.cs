using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability : MonoBehaviour {

    public AbilityKey[] keysToPlay;
    public float cost = 0.2f;
    public float playKeysMaxInterval = 0.5f;
    public float maxTotalTime = 5;
    public float disappearWarningTime = 5;
    public UnityEvent onSuccess;
    
    [ReadOnly]
    [SerializeField]
    protected int currentToPlayIndex = 0;
    [ReadOnly]
    [SerializeField]
    protected float keyTimerCountingDown;
    protected float totalTimer = 0;

    public bool Done { get; private set; } = false;
    public float destroyTimeAfterDone;
    public bool initializeOnStart = true;
    protected Animator animator;

    public Rocket ParentPlayer { get; set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        Done = true;
        if (initializeOnStart)
        {
            
            InitializeKeys(); 
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (!Done)
        {
            totalTimer += Time.deltaTime;
            if (currentToPlayIndex != 0 && keyTimerCountingDown > 0)
            {
                keyTimerCountingDown -= Time.deltaTime;
            }
            else if (currentToPlayIndex != 0 && keyTimerCountingDown <= 0)
            {
                OnPlayKeyWrong();
            }
            if(maxTotalTime - totalTimer > disappearWarningTime)
            {
                animator.SetBool("Warning", false);
            }
            else
            {
                animator.SetBool("Warning", true);
            }
            CheckCurrentKey();
            if(totalTimer >= maxTotalTime && !Done)
            {
                AbilityFailed();
            }

            if(ParentPlayer != null)
            {
                transform.position = ParentPlayer.transform.position;
            }
        }

    }

    public void ResetTimer()
    {
        totalTimer = 0;
    }

    protected void CheckCurrentKey()
    {
        foreach(var c in Input.inputString)
        {
            bool success = (c == keysToPlay[currentToPlayIndex].letter);

            if(currentToPlayIndex != 0 && !success)
            {
                
                OnPlayKeyWrong();
            }else if (success)
            {
                var allSuccess = OnSuccessCurrentKey();
                if (allSuccess)
                {
                    AbilitySucceed();
                    return;
                }
            }
        }
    }


    protected bool OnSuccessCurrentKey()
    {
        Debug.Log("Key " + keysToPlay[currentToPlayIndex].letter + " succeed~");
        keysToPlay[currentToPlayIndex].OnPlayedCorrect();
        currentToPlayIndex++;
        keyTimerCountingDown = playKeysMaxInterval;
        if (currentToPlayIndex < keysToPlay.Length)
        {
            keysToPlay[currentToPlayIndex].OnReadyNext();
        }
        return currentToPlayIndex >= keysToPlay.Length;
    }

    public void InitializeKeys()
    {
        Done = false;
        currentToPlayIndex = 0;
        foreach (var k in keysToPlay)
        {
            k.ResetGraphic();
        }
        keysToPlay[currentToPlayIndex].OnReadyNext();
    }

    protected void OnPlayKeyWrong()
    {
        keysToPlay[currentToPlayIndex].OnPlayedWrong();
        InitializeKeys();
    }

    protected void AbilitySucceed()
    {
        Done = true;
        if(ParentPlayer)
            ParentPlayer.TakeDamage(cost,false);
        onSuccess.Invoke();
        Debug.Log("Ability " + gameObject.name + " succeed~");
        animator.SetTrigger("Succeed");
        Destroy(gameObject, destroyTimeAfterDone);

    }

    public void AbilityFailed()
    {
        Done = true;
        Debug.Log("Ability " + gameObject.name + " failed~");
        animator.SetTrigger("Fail");
        Destroy(gameObject, destroyTimeAfterDone);
    }

}
