using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Peach : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform peachesRendererTransform;
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
        peachesRendererTransform.localScale = Vector3.one*3;
        LeanTween.cancel(peachesRendererTransform.gameObject);
        LeanTween.scale(peachesRendererTransform.gameObject, Vector3.one * 2.6f, .15f).setLoopPingPong(1);
    }
}
