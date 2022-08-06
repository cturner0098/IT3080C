using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP = 50f;

    public Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 0)
        {
            currentHP = 0f;
        }

        hpBar.value = currentHP;
    }
}
