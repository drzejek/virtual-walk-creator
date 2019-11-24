using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Loading : MonoBehaviour
{
    public UnityEngine.UI.Image _radialCircle;

    // Start is called before the first frame update
    void Start()
    {
        _radialCircle.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(float amount)
    {
        _radialCircle.fillAmount = amount;
    }
}
