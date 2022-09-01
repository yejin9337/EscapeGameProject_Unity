using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; // ���� ������ �ִ� �Ÿ�
    private bool pickupActivated = false; // ���� ������ �� true;

    private RaycastHit hitInfo; // �浹ü ���� ����

    // ������ ���̾�� �����ϵ��� ���̾� ����ũ�� ����
    [SerializeField]
    private LayerMask layerMask;

    // �ʿ��� ������Ʈ
    [SerializeField]
    private TextMeshProUGUI actionText;
    [SerializeField]
    private Inventory inventory;

    public Image panel,breakerPanel;


    void Update()
    {
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CheckItem();
            CanPickUp();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();           
        }
    }

    private void CheckItem()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if(hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
            if(hitInfo.transform.tag == "DetailItem")
            {
                UIAppear();
            }
        }
        else
        {
            InfoDisappear();
        }
    }

    private void UIAppear()
    {
        if (hitInfo.transform.name =="Photoframe")
        {
            panel.gameObject.SetActive(true);
        }
        if (hitInfo.transform.name =="3PCktBreaker")
        {
            breakerPanel.gameObject.SetActive(true);
        }
        GameManager.isOpenUI = true;
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ��" + "<color=yellow>" + "(G)" + "</color>";
    }

    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }

}
