using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoFrame : MonoBehaviour
{
    private Outline outline;
    void Awake()
    {
        outline = gameObject.GetComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.red;
        outline.OutlineWidth = 5f;
    }

    void Update()
    {
        
    }
}
