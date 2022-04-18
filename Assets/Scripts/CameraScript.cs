using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;

    private float transition = 0;
    private float animationDuration = 1;
    private Vector3 animationOffset = new Vector3(0, 2, 2);


    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.Find("Model").transform;
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lookAt.position + startOffset;
        if (PlayerController.isGameStarted == true)
        {
            if (transition > 1)
            {
                transform.position = lookAt.position + startOffset;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position + animationOffset, transform.position, transition);
                transition += Time.deltaTime * 1 / animationDuration;
            }
        }
    }
}
