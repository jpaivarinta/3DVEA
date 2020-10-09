using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator animation;
    private AudioSource audio;
    public GameObject player;
    public GameObject enemy;
    private bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        isOpen = false;
 
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && playerDistance < 3)
        {
            if (isOpen)
            {
                DoorCloseAnimation();
                isOpen = false;
            }
            else
            {
                DoorOpenAnimation();
                isOpen = true;
            }

        }
    }

    void DoorOpenAnimation()
    {
        animation.Play("DoorOpenAnimation");

        //Play audio only when animation runs
        if (!animation.GetCurrentAnimatorStateInfo(0).IsName("DoorOpenAnimation"))
            audio.Play();
    }

    void DoorCloseAnimation()
    {
        animation.Play("DoorCloseAnimation");

        //Play audio only when animation runs
        if (!animation.GetCurrentAnimatorStateInfo(0).IsName("DoorCloseAnimation"))
            audio.Play();
    }
}
