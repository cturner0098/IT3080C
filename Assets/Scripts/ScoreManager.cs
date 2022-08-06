using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ScoreItem"))
        {
            float scoreVal = float.Parse(scoreText.text) + other.gameObject.GetComponent<ScoreScript>().scoreValue;
            scoreText.text = "" + scoreVal;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("canTakeDamage"))
        {
            other.gameObject.GetComponent<HealthBarManager>().currentHP -= 10;
            if(other.gameObject.GetComponent<HealthBarManager>().currentHP <= 0)
            {
                Destroy(other.gameObject);
                scoreText.text = "1000000000";
            }
        }
    }


}
