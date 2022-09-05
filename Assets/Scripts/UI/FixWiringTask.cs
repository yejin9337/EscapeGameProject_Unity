using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWireColor
{
    None = -1,
    Red,
    Yellow,
    Green,
    Blue
}

public class FixWiringTask : MonoBehaviour
{
    [SerializeField]
    private List<LeftWire> _leftWires;
    [SerializeField]
    private List<RightWire> _rightWires;

    private LeftWire _selectedLeftWire;
    private RightWire _selectedRightWire;
    public GameObject _light;


    public void OnEnable()
    {
        List<int> numberPool = new List<int>();

        for (int i = 0; i < _leftWires.Count; i++)
        {
            numberPool.Add(i);
        }

        int index = 0;
        while(numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            _leftWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }

        for (int i = 0; i < _rightWires.Count; i++)
        {
            numberPool.Add(i);
        }

        index = 0;
        while (numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            _rightWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);
            if (hit.collider != null)
            {
                var left = hit.collider.GetComponentInParent<LeftWire>();
                if (left != null)
                {
                    _selectedLeftWire = left;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_selectedLeftWire != null)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponentInParent<RightWire>();

                        if (right != null)
                        {
                            _selectedLeftWire.SetTarget(hit.transform.position, 50f);
                            _selectedLeftWire.ConnectWire(right);
                            right.ConnectWire(_selectedLeftWire);
                            _selectedLeftWire = null;
                            return;
                        }
                    }
                }
                _selectedLeftWire.ResetTarget();
                _selectedLeftWire.DisconnectWire();
                _selectedLeftWire = null;
            }

            if (_selectedRightWire.isConnected)
            {
                Debug.Log("들어오긴하지?");
                _light.gameObject.SetActive(true);
            }
        }

        if (_selectedLeftWire != null)
        {
            _selectedLeftWire.SetTarget(Input.mousePosition, 10f);
        }


    }
}
