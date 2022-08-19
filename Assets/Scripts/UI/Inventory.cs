using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;
    // true가 되면 마우스가 움직여도 게임 배경이 움직이지 않음
    // false일때 i 누르면 인벤토리 on / true일때 i 누르면 인벤토리 off

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject _inventoryBase;
    [SerializeField]
    private GameObject _slotsParent;  // slot들의 부모 객체 - grid인가?

    // 슬롯들
    private Slot[] slots;
    void Start()
    {
        slots = _slotsParent.GetComponentsInChildren<Slot>(); // slot들이 slots 배열 안에 들어가게 된다 - 어렵네;;
    }

    
    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {

            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OpenInventory()
    {
        GameManager.isOpenIventory = true;
        _inventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        GameManager.isOpenIventory = false;
        _inventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }
}
