using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCount : MonoBehaviour
{
    public TMP_Text coinCountText;
    public Text coinShowText;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = count.ToString();
        coinShowText.text = "Coins :" + count.ToString();
    }
    public void AddCount()
    {
        count++;
    }
}
