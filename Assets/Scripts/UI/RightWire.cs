using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightWire : MonoBehaviour
{
    public EWireColor _wireColor { get; private set; }
    public bool isConnected { get; private set; }

    [SerializeField]
    private List<LeftWire> connectedWire = new List<LeftWire>();

    [SerializeField]
    private Image lightImage;

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

    public void ConnectWire(LeftWire leftWire)
    {
        if (connectedWire.Contains(leftWire))
        {
            return;
        }

        connectedWire.Add(leftWire);
        if(connectedWire.Count == 1 && leftWire._wireColor == _wireColor)
        {
            lightImage.color = Color.yellow;
            isConnected = true;
        }
        else
        {
            lightImage.color = Color.gray;
            isConnected = false;
        }
    }

    public void DisconnectWire(LeftWire leftWire)
    {
        connectedWire.Remove(leftWire);

        if(connectedWire.Count == 1 && connectedWire[0]._wireColor == _wireColor)
        {
            lightImage.color = Color.yellow;
            isConnected = true;
        }
        else
        {
            lightImage.color = Color.gray;
            isConnected = false;
        }
    }
}
