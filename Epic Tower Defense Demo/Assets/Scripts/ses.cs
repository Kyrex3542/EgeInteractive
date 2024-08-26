using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class ses : MonoBehaviour
{
    public Slider sesbari;
    public AudioListener audioListener;

    void Start()
    {
        AudioListener.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        AudioListener.volume = sesbari.value;
    }
}
