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
    // 키가 있으면 충돌했을 때 열리고 그렇지 않으면 안 열리기 _ 인벤토리만 체크 
    private void OnTriggerEnter(Collider other)
    {
        // 금고 키랑 부딪쳤을 때 금고문 열림
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
