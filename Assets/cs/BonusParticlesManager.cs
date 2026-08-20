using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class BonusParticlesManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject bonusParticlePrefabs;
    [SerializeField] private FruitManager fruitManager;

    [Header("Pool")]
    private ObjectPool<GameObject> bonusParticlesPool;


    private void Awake()
    {
        InputManager.onFruitClickedPosition += FruitClickedCallback;
    }
    private void OnDestroy()
    {
        InputManager.onFruitClickedPosition -= FruitClickedCallback;
    }

    private void Start()
    {
        bonusParticlesPool = new ObjectPool<GameObject>(CreatFunction, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }


    private GameObject CreatFunction()
    {
        return Instantiate(bonusParticlePrefabs, transform);
    }

    private void ActionOnGet(GameObject bonusParticle)
    {
        bonusParticle.SetActive(true);
    }


    private void ActionOnRelease(GameObject bonusParticle)
    {
        bonusParticle.SetActive(false);
    }


    private void ActionOnDestroy(GameObject bonusParticle)
    {
        Destroy(bonusParticle);
    }


    private void FruitClickedCallback(Vector2 clickedPosition)
    {
        GameObject bonusParticleInstance = bonusParticlesPool.Get();

        //Get Multiplier number from FruitManager and configure the BonusParticles script
        bonusParticleInstance.GetComponent<BonusParticles>().Configure(fruitManager.getCurrentMultiplier()); 

        bonusParticleInstance.transform.position = clickedPosition;
        

        LeanTween.delayedCall(1, () => bonusParticlesPool.Release(bonusParticleInstance));


        // Debug
        //Animator anim = bonusParticleInstance.GetComponent<Animator>();
        //Debug.Log("Animator found: " + (anim != null));
        //Debug.Log("Controller assigned: " + (anim != null && anim.runtimeAnimatorController != null));
        //Debug.Log("Spawn position: " + bonusParticleInstance.transform.position);

    }
}
