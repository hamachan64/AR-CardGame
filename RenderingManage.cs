using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingManage : MonoBehaviour
{
    public float renderScale = 0.7f;
    void Start()
    {
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = renderScale;
    }
}
