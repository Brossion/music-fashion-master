using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    public float fillSpeed = 1;
    private float targetProgress = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > targetProgress)
        {
            slider.value -= fillSpeed * Time.deltaTime;
        }
    }

    //Add progress to the bar
    public void IncrementProgress(float newProgress) 
    {
        targetProgress = slider.value -= newProgress;
    }
}
