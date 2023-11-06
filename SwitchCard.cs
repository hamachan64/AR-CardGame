using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCard : MonoBehaviour
{
    public GameObject card04;
    public GameObject card01;

    // Start is called before the first frame update
    void Start()
    {
        card04.SetActive(false);
        card01.SetActive(false);
    }

    public void switch4to1()
    {
        card04.SetActive(false);
        card01.SetActive(true);
    }

    public void switch1to4()
    {
        card04.SetActive(true);
        card01.SetActive(false);
    }
}
