using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftWire : MonoBehaviour
{
    [SerializeField]
    private RectTransform mWireBody;

    private LeftWire mSelectedWire;

    [SerializeField]
    private float offset = 15f;

    private Canvas mCanvas;
    void Start()
    {
        mCanvas = FindObjectOfType<Canvas>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);
            if(hit.collider != null)
            {
                var left = hit.collider.GetComponentInParent<LeftWire>();
                if(left != null)
                {
                    mSelectedWire = left;
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {            
            if (mSelectedWire != null)
            {
                mWireBody.localRotation = Quaternion.Euler(Vector3.zero);
                mWireBody.sizeDelta = new Vector2(0f, mWireBody.sizeDelta.y);
                mSelectedWire = null;
            }
        }

        if (mSelectedWire != null)
        {
            Debug.Log("마우스 들어옴");
            float angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position, 
                Input.mousePosition - transform.position);
            float distance = Vector2.Distance(mWireBody.transform.position, Input.mousePosition) - offset;

            Debug.Log("앵글 :" + angle);
            Debug.Log("거리 :" + distance);

            mWireBody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            mWireBody.sizeDelta = new Vector2(distance * (2 / mCanvas.transform.localScale.x), mWireBody.sizeDelta.y);
            // 캔버스 해상도 때문에 캔버스 크기의 역수를 곱한다는데 어우 어렵네;
        }
    }
}
