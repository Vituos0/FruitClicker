using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusParticlesManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject bonusParticlePrefabs;

    private void Awake()
    {
        InputManager.onFruitClickedPosition += FruitClickedCallback;
    }
    private void OnDestroy()
    {
        InputManager.onFruitClickedPosition -= FruitClickedCallback;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FruitClickedCallback(Vector2 clickedPosition)
    {
       GameObject bonusParticleInstance = Instantiate(bonusParticlePrefabs, clickedPosition, Quaternion.identity,transform);
         Destroy(bonusParticleInstance, 1f);
    }
}
