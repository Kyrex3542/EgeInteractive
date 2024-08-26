using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public GameObject kuleler;
    bool kulelerdurumu = true;
    
    public void kulelern()
    {
        if (kulelerdurumu) { kuleler.SetActive(false);  kulelerdurumu = false; print("okey");
        }
        else
        {
            kuleler.SetActive(true); kulelerdurumu = true; print("okeyno");
        }
    }
    
}
