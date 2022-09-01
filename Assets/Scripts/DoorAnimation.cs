using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator anim;
    private GameObject player;

    public bool playerEntered = false;
    private bool open = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerEntered && Input.GetKeyDown(KeyCode.E))
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
