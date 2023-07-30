using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1.5f * Time.deltaTime, 0));
    }
}
