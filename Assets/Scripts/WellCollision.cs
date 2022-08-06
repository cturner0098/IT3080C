using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WellCollision : MonoBehaviour
{
    public Light lightObject;

    public float moveSpeed = 5f;

    Vector3 startPosition;




    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lightObject.intensity = lightObject.intensity / 4;
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            lightObject.intensity = lightObject.intensity * 4;

        }
    }
}
