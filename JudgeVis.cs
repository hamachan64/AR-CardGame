using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeVis : MonoBehaviour
{
    //public GameObject card;
    public GameObject no;

    // Start is called before the first frame update
    void Start()
    {
        //card.SetActive(true);
        no.SetActive(false);
    }

    // Update is called once per frame
    public void VisDisplay()
    {
        //card.SetActive(true);
        no.SetActive(false);
    }

    public void ImvisDisplay()
    {
        //card.SetActive(false);
        no.SetActive(true);
    }
}
