using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusParticles : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshPro bonusText;



    public void Configure(int incrementNumber)
    {
        bonusText.text = "+" + incrementNumber;
    }

}
