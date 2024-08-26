using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static Player Instance { get; set; }
    

    public int mapNumber=0;
    private void Awake()
    {
        Instance = this;
    }
    
}
