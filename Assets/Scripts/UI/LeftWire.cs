using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftWire : MonoBehaviour
{
    [SerializeField]
    private RectTransform _wireBody;

    //[SerializeField]
    //private float offset = 0f;

    public EWireColor _wireColor { get; private set; }
    [SerializeField]
    private List<Image> wireColorImage;

    private Canvas _canvas;
    void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
    }

    public void SetTarget(Vector3 targetPosition, float offset)
    {
        float angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position,
                targetPosition - transform.position);
        float distance = Vector2.Distance(_wireBody.transform.position, targetPosition) - offset;

        _wireBody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        _wireBody.sizeDelta = new Vector2(distance * (1 / _canvas.transform.localScale.x), _wireBody.sizeDelta.y);
        // 캔버스 해상도 때문에 캔버스 크기의 역수를 곱한다는데 어우 어렵네;
    }

    public void ResetTarget()
    {
        _wireBody.localRotation = Quaternion.Euler(Vector3.zero);
        _wireBody.sizeDelta = new Vector2(0f, _wireBody.sizeDelta.y);
    }

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
        //어우 하기싫엉(ㅇ<-<)
    }
}
