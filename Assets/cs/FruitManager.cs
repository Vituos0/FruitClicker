using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FruitManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI amountText;

    [Header("Data")]
    [SerializeField] private double totalFruitNumber;
    [SerializeField] private int frenzyModeMultiplier;
    [SerializeField] private int FruitIncrement;

    
    /*Delegate assignments*/
    private void Awake()
    {   
        LoadData();
        FruitIncrement = 1;
        InputManager.onFruitClicked += FruitClickedCallback;
        Cube.onFrenzyModeStart += StartFrenzyModeCallback;
        Cube.onFrenzyModeStop += StopFrenzyModeCallback;
    }

    private void OnDestroy()
    {
        InputManager.onFruitClicked -= FruitClickedCallback;
        Cube.onFrenzyModeStart -= StartFrenzyModeCallback;
        Cube.onFrenzyModeStop -= StopFrenzyModeCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FruitClickedCallback()
    {
        totalFruitNumber+= FruitIncrement;
        //Debug.Log("Total fruit number: " + totalFruitNumber);

        UpdateFruitText();
        SaveData();


    }
    //--------UI Update----------------
    private void UpdateFruitText()
    {   
        if(totalFruitNumber<=1)
        {
            amountText.text = totalFruitNumber + " Peach!";
        }
        else
        {
        amountText.text = totalFruitNumber + " Peaches!";  
        }
    }
    //-----------------Save and Load data -------
    private void SaveData()
    {
        PlayerPrefs.SetString("TotalFruitNumber", totalFruitNumber.ToString());
    }

    private void LoadData()
    {
       double.TryParse(PlayerPrefs.GetString("TotalFruitNumber", "0"), out totalFruitNumber);

        UpdateFruitText();
    }

    //---------Change the multiplier of cube in frenzy mode-----
    private void StartFrenzyModeCallback()
    {
        FruitIncrement = frenzyModeMultiplier;
    }
    private void StopFrenzyModeCallback()
    {
        FruitIncrement = 1;
    }

    public int getCurrentMultiplier()
    {
        return FruitIncrement;
    }
}
