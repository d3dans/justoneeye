using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RevealShaderSetter : MonoBehaviour
{
    public float Radius = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", Radius);
    }
}
