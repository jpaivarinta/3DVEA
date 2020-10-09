using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public Player player;
    public PlayerLook playerLook;
    public AudioSource beep;
    public GameObject damageVisual;
    public GameObject gameMenu;
    public List<GameObject> enemies;
    private GameObject fpsCamera;
    public float damageDistance;
    public float damage;
    private bool gameMenuOn;
    private int counter;
    

    private void Start()
    {
        fpsCamera = GameObject.FindWithTag("MainCamera");
        gameMenuOn = false;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gameMenuOn)
            {
                gameMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gameMenuOn = true;
            }
            else
            {
                gameMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameMenuOn = false;
            }
        }
        

        if (player.Health <= 0f)
        {
            player.playerDied();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = fpsCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Key1 objectKey = hit.collider.GetComponent<Key1>();
                if (objectKey != null)
                {
                    player.SetKey1Active();
                    beep.Play(0);
                }
                Key2 objectKey2 = hit.collider.GetComponent<Key2>();
                if (objectKey2 != null)
                {
                    player.SetKey2Active();
                    beep.Play(0);
                }
            }

        }

        counter = 0;
        for(int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(enemies[i].transform.position, player.transform.position);

            if (distance < damageDistance && player.Health >= 0f)
            {
                damageVisual.SetActive(true);
                player.Health -= damage * Time.deltaTime;
                counter++;
            }
            else if (counter == 0) // Sets visual to false if no ghosts near
            {
                damageVisual.SetActive(false);
            }
        }
    }
}
