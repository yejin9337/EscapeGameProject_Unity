using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightWire : MonoBehaviour
{
    public EWireColor _wireColor { get; private set; }

    [SerializeField]
    private List<Image> wireColorImage;

    public void SetWireColor(EWireColor wireColor)
    {
        _wireColor = wireColor;
        Color color = Color.black;
        switch (wireColor)
        {
            case EWireColor.Red:
                color = Color.red;
                break;

            case EWireColor.Yellow:
                color = Color.yellow;
                break;

            case EWireColor.Green:
                color = Color.green;
                break;

            case EWireColor.Blue:
                color = Color.blue;
                break;
        }

        foreach (var image in wireColorImage)
        {
            image.color = color;
        }

    }
}
