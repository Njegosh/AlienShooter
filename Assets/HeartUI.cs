using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{

    public GameObject effect;
    public GameObject heart;

    public void Reset()
    {
        heart.SetActive(true);
    }

    public void HpDown()
    {
        heart.SetActive(false);
    }
    
}
