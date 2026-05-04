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
    [SerializeField] private int FruitIncrement;
    private void Awake()
    {   
        LoadData();
        InputManager.onFruitClicked += FruitClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onFruitClicked -= FruitClickedCallback;
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
    private void SaveData()
    {
        PlayerPrefs.SetString("TotalFruitNumber", totalFruitNumber.ToString());
    }

    private void LoadData()
    {
       double.TryParse(PlayerPrefs.GetString("TotalFruitNumber", "0"), out totalFruitNumber);

        UpdateFruitText();
    }
}
