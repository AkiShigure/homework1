using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPUI : MonoBehaviour
{
    public GameObject healthUI;
    public Transform batPoint;
    Image healthSlider;
    Transform uiBar;
    public GameObject player;
    Transform cam;
    FPEnemyController fP;
    

    private void Awake()
    {
        fP = GetComponent<FPEnemyController>();
        fP.UpdateHealthBarOnAttack += UpdateHealthBar;
    }
    private void OnEnable()
    {
        cam = Camera.main.transform;
        foreach(Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.renderMode == RenderMode.WorldSpace)
            {
               uiBar=Instantiate(healthUI, canvas.transform).transform;
                healthSlider = uiBar.GetChild(0).GetComponent<Image>();
                uiBar.gameObject.SetActive(true);
            }
        }
    }

    private void UpdateHealthBar(int blood,int maxhealth)
    {
        if (blood <= 0)
        {
            Destroy(uiBar.gameObject);
        }

        uiBar.gameObject.SetActive(true);

        float sliderPercent = (float)blood / maxhealth;
        healthSlider.fillAmount = sliderPercent;
    }

    private void LateUpdate()
    {
        if (uiBar != null)
        {
            uiBar.position = batPoint.position;

            uiBar.LookAt(Camera.main.transform.position);

            //uiBar.forward = - player.transform.forward;
            //uiBar.forward = -cam.forward;
        }
    }
}
