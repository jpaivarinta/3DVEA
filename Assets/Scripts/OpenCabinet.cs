﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCabinet : MonoBehaviour
{
    public Animator animation;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float playerDistance = Vector3.Distance(player.transform.position, transform.position);
            if(playerDistance < 3f)
            {
                CabinetAnimation();
            }
        }
    }

    void CabinetAnimation()
    {
        animation.Play("CabinetAnimation");
    }
}