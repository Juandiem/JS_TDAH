using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float x, y;

    public Renderer BgRenderer;

    void Update()
    {
        BgRenderer.material.mainTextureOffset += new Vector2(x * Time.deltaTime, y * Time.deltaTime);
    }
}
