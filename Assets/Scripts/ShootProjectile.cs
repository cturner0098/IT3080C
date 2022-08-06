using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject projObj = Instantiate(projPrefab);

            projObj.transform.forward = projSpawnPoint.forward;

            projObj.transform.position = transform.position + transform.up * 2;
        }
    }
}
