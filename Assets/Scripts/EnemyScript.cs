using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyScript : MonoBehaviour
{
    public bool isGameStarted;
    private float walkingSpeed = 2;
    public GameObject[] hairs, tops, bottoms, shoes;
    //public Transform model;
    public static int scoreToConcert;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isGameStarted == true)
        {
            transform.Translate(0, 0, walkingSpeed * Time.deltaTime);
        }
        //Score();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TopSection")
        {
            tops[0].SetActive(false);
            tops[Random.Range(0, tops.Length)].SetActive(true);
            Destroy(other);
        }
        if (other.gameObject.tag == "BottomSection")
        {
            bottoms[0].SetActive(false);
            bottoms[Random.Range(0, bottoms.Length)].SetActive(true);
            Destroy(other);
        }
        if (other.gameObject.tag == "HairSection")
        {
            hairs[0].SetActive(false);
            hairs[Random.Range(0, hairs.Length)].SetActive(true);
            Destroy(other);
        }
        if (other.gameObject.tag == "ShoeSection")
        {
            shoes[0].SetActive(false);
            shoes[Random.Range(0, shoes.Length)].SetActive(true);
            Destroy(other);
        }
        if (other.gameObject.tag == "FinishSection")
        {
            
        }
    }
    /*void Score()
    {
        concertScoreText.text = "Concert Score \n" + scoreToConcert;
    }*/
}
