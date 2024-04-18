using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image bar;
    public void SetAmount(float amount)
    {
        bar.fillAmount = amount;
        
    }
}
