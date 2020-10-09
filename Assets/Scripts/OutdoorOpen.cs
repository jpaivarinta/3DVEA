using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutdoorOpen : MonoBehaviour
{
    public Animator animation;
    private AudioSource audio;
    public Player player;
    public Text lockedText;
    private float timer;
  


    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(lockedText.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                lockedText.enabled = false;
            }
        }

        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && playerDistance < 3 && player.HasKey2)
        {
            DoorOpenAnimation();
        }
        else if(Input.GetKeyDown(KeyCode.E) && playerDistance < 3 && !player.HasKey2)
        {
            lockedText.enabled = true;
            timer = 0f;
        }
    }


    void DoorOpenAnimation()
    {
        animation.Play("OutdoorAnimation");

        //Play audio only when animation runs
        if (!animation.GetCurrentAnimatorStateInfo(0).IsName("OutdoorAnimation"))
            audio.Play();
    }


}
