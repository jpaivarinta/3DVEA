using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    Light flickeringLight;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        flickeringLight = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        if (i % 8 == 0)
            flickeringLight.intensity = Random.Range(0.5f, 1.0f);

        i++;
    }
}
