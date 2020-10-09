using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public bool HasKey1 { get; set; }
    public bool HasKey2 { get; set; }
    public float Health { get; set; }
    public GameObject gameWon;
    public GameObject youDied;
    public GameObject keyLogo1;
    public GameObject keyLogo2;
    public GameObject key1;
    public GameObject key2;
    public GameObject crossHair;


    void Start()
    {
        Health = 100f;
    }

    private void OnTriggerEnter(Collider other)
    {
        keyLogo1.SetActive(false);
        keyLogo2.SetActive(false);
        crossHair.SetActive(false);
        gameWon.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playerDied()
    {
        if(!youDied.activeSelf)
        {
            youDied.SetActive(true);
        }
    }

    public void SetKey1Active()
    {
        HasKey1 = true;
        Destroy(key1);
        keyLogo1.SetActive(true);
    }

    public void SetKey2Active()
    {
        HasKey2 = true;
        Destroy(key2);
        keyLogo2.SetActive(true);
    }
}
