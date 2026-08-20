using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Cube : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform CubesRendererTransform;
    [SerializeField] private Image CubeFill;

    [SerializeField] private bool isFrenzyMode;



    [Header("Settings")]

    [SerializeField] private float fillRate;

    [Header("Actions")]
    public static Action onFrenzyModeStart;
    public static Action onFrenzyModeStop;



    [Tooltip("The amount the Cube will scale when clicked, default is 1")]
    public float LocalscaleAmount = 1;         //default 1
    [Tooltip("The amount the Cube will scale when clicked with LeanTween, default is 2.6f, Leantween scale always")]
    public float LeanTweenScaleAmount = 2.6f; //default 2.6f



    // [SerializeField] private float scaleAmount = 1;
    private void Awake()
    {
        InputManager.onFruitClicked += FruitClickedCallback;
    }
    private void OnDestroy()
    {
        InputManager.onFruitClicked -= FruitClickedCallback;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FruitClickedCallback()
    {
        Animate();

        if(!isFrenzyMode)
            Fill(); 
    }

    private void Animate()
    {
        CubesRendererTransform.localScale = Vector3.one*LocalscaleAmount;
        LeanTween.cancel(CubesRendererTransform.gameObject);
        LeanTween.scale(CubesRendererTransform.gameObject, Vector3.one * LeanTweenScaleAmount, .15f).setLoopPingPong(1);
    }


    private void Fill()
    {
        CubeFill.fillAmount += fillRate;

        if (CubeFill.fillAmount >= 1f)
        {
            StartFrenzyMode();
        }
    }

    private void StartFrenzyMode()
    {
        // Implement the logic to start frenzy mode here
        Debug.Log("Frenzy Mode Activated!");
        isFrenzyMode = true;    
        LeanTween.value(1, 0 ,5) .setOnUpdate((value)=>CubeFill.fillAmount = value).setOnComplete(StopFrenzyMode);
        onFrenzyModeStart?.Invoke();
    }

    private void StopFrenzyMode()
    {
        isFrenzyMode = false;
        onFrenzyModeStop?.Invoke();
    }

}
