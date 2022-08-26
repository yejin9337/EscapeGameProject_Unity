using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DoorState
{
    open,
    close
}

public class DoorMovement : MonoBehaviour
{
    public Animator anim;
    private GameObject player;

    private bool playerEntered = false;
    private bool open = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerEntered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isOpen_Obj_1", open);
                open = !open;
            }
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

