using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDoubleAnimation : MonoBehaviour
{
    private Inventory _inventory;
    private Animator animator;
    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        animator = GetComponent<Animator>();
    }
    private void openDoor()
    {
        animator.SetTrigger("isOpen_Obj_1");
    }
    // Ű�� ������ �浹���� �� ������ �׷��� ������ �� ������ _ �κ��丮�� üũ 
    private void OnTriggerEnter(Collider other)
    {
        // �ݰ� Ű�� �ε����� �� �ݰ� ����
        if (other.tag == "Player")
        {
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (_inventory.slots[i] == null)
                { continue; }
                if (_inventory.slots[i].item.itemType == Item.ItemType.Used)
                {
                    openDoor();
                    break;
                }
            }
        }
    }
}
