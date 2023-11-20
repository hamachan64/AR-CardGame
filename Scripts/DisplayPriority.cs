using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPriority : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;

    private MeshRenderer card1_mesh;
    private MeshRenderer card2_mesh;
    private MeshRenderer card3_mesh;
    private MeshRenderer card4_mesh;

    // Start is called before the first frame update
    void Start()
    {
        card1_mesh = card1.GetComponent<MeshRenderer>();
        card2_mesh = card2.GetComponent<MeshRenderer>();
        card3_mesh = card3.GetComponent<MeshRenderer>();
        card4_mesh = card4.GetComponent<MeshRenderer>();

        card1_mesh.enabled = true;
        card2_mesh.enabled = false;
        card3_mesh.enabled = false;
        card4_mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (card1_mesh.isVisible)
        {
            card1_mesh.enabled = true;
            card2_mesh.enabled = false;
            card3_mesh.enabled = false;
            card4_mesh.enabled = false;
        }
        else
        {
            if (card2_mesh.isVisible)
            {
                card2_mesh.enabled = true;
                card3_mesh.enabled = false;
                card4_mesh.enabled = false;
            }
            else
            {
                if (card3_mesh.isVisible)
                {
                    card3_mesh.enabled = true;
                    card4_mesh.enabled = false;
                }
                else
                {
                    card4_mesh.enabled = true;
                }
            }
        }
    }
}
