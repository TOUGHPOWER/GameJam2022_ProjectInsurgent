using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_follow : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y+0.5f, gameObject.transform.position.z);
    }
}
