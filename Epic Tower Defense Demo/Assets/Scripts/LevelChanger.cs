using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public void levelone() { level1.SetActive(true); level2.SetActive(false); level3.SetActive(false); }
    public void leveltwo() { level1.SetActive(false);  level2.SetActive(true);  level3.SetActive(false);}
    public void levelthree() { level1.SetActive(false); level2.SetActive(false); level3.SetActive(true);}
}
