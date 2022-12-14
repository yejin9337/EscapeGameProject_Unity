using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMovement : MonoBehaviour
{
    public Animator anim;
    private GameObject player;

    public bool playerEntered = false;
    private bool open = true;
    public bool onKeyPad = true;
    [SerializeField]
    private Image keyPad;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerEntered && onKeyPad && Input.GetKeyDown(KeyCode.E))
        {
            keyPad.gameObject.SetActive(true);
            GameManager.isOpenUI = true;
        }

        if (playerEntered && !onKeyPad && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isOpen_Obj_1", open);
            open = !open;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerEntered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerEntered = false;
        }
    }
}

