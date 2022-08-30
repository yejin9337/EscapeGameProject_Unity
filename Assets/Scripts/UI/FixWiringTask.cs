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

    private LeftWire _selectedWire;

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
                    _selectedWire = left;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_selectedWire != null)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponentInParent<RightWire>();

                        if (right != null)
                        {
                            _selectedWire.SetTarget(hit.transform.position, 50f);
                            _selectedWire.ConnectWire(right);
                            right.ConnectWire(_selectedWire);
                            _selectedWire = null;
                            return;
                        }
                    }
                }
                _selectedWire.ResetTarget();
                _selectedWire.DisconnectWire();
                _selectedWire = null;
            }
        }

        if (_selectedWire != null)
        {
            _selectedWire.SetTarget(Input.mousePosition, 10f);
        }
    }
}
