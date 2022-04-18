using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float walkingSpeed = 2;

    public Animator animator;
    public Animator animatorEnemy;

    public static bool isGameStarted, tap;
    public GameObject startPanel, finishPanel, enemy;
    public GameObject[] text, hairs, tops, bottoms, shoes, panels, buttons;

    public Text concertScoreText;

    private float scoreToConcert;

    public Slider slider, score, scoreMary;
    private bool timeStarted, isFinished, isFinishedMary;
    private float currentTime = 1.25f;
    private float zero = 0f;
    public float scoreToConcertMary = 100;

    public Button[] head, top, bottom, shoe;

    public AudioSource awesome, applause;

    // Start is called before the first frame update
    void Start()
    {
        isFinishedMary = false;
        isFinished = false;
        timeStarted = false;
        isGameStarted = false;
        startPanel.SetActive(true);
        tap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted == true)
        {
            transform.Translate(0, 0, walkingSpeed * Time.deltaTime);
        }
        if (timeStarted == true)
        {
            currentTime -= 1 * Time.deltaTime;
            slider.value = currentTime;
        }
        if (isFinished == true)
        {
            zero += 200 * Time.deltaTime;
            score.value = zero;
            if (zero == scoreToConcert)
            {
                isFinished = false;
            }
        }
        if (isFinishedMary == true)
        {
            scoreMary.value = scoreToConcertMary;
        }
    }
    public void StartGame() 
    {
        isGameStarted = true;
        animator.SetBool("isStarted", true);
        animatorEnemy.SetBool("isWalking", true);
        Destroy(startPanel);
        text[0].SetActive(true);
        text[1].SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TopSection")
        {
            StartCoroutine(TopPanel());
            Destroy(other);
        }
        if (other.gameObject.tag == "BottomSection")
        {
            StartCoroutine(BottomPanel());
            Destroy(other);
        }
        if (other.gameObject.tag == "HairSection")
        {
            StartCoroutine(HairPanel());
            Destroy(other);
        }
        if (other.gameObject.tag == "ShoeSection")
        {
            StartCoroutine(ShoePanel());
            Destroy(other);
        }
        if (other.gameObject.tag == "FinishSection")
        {
            isGameStarted = false;
            animator.SetBool("isStarted", false);
            animatorEnemy.SetBool("isWalking", false);
            //animator.SetBool("isFinished",true);
            StartCoroutine(FinishPanel());
            walkingSpeed = 0;
            Destroy(other);
        }
    }
    private IEnumerator TopPanel()
    {
        Time.timeScale = 0.25f;
        timeStarted = true;
        slider.gameObject.SetActive(true);
        panels[1].SetActive(true);
        yield return new WaitForSeconds(1.25f);
        panels[1].SetActive(false);
        timeStarted = false;
        slider.gameObject.SetActive(false);
        currentTime = 1.25f;
        Time.timeScale = 1f;
    }
    private IEnumerator BottomPanel()
    {
        Time.timeScale = 0.25f;
        timeStarted = true;
        slider.gameObject.SetActive(true);
        panels[2].SetActive(true);
        yield return new WaitForSeconds(1.25f);
        panels[2].SetActive(false);
        timeStarted = false;
        slider.gameObject.SetActive(false);
        currentTime = 1.25f;
        Time.timeScale = 1f;
    }
    private IEnumerator HairPanel()
    {
        Time.timeScale = 0.25f;
        timeStarted = true;
        slider.gameObject.SetActive(true);
        panels[0].SetActive(true);
        yield return new WaitForSeconds(1.25f);
        Destroy(text[0]);
        Destroy(text[1]);
        panels[0].SetActive(false);
        timeStarted = false;
        slider.gameObject.SetActive(false);
        currentTime = 1.25f;
        Time.timeScale = 1f;
    }
    private IEnumerator ShoePanel()
    {
        Time.timeScale = 0.25f;
        timeStarted = true;
        slider.gameObject.SetActive(true);
        panels[3].SetActive(true);
        yield return new WaitForSeconds(1.25f);
        panels[3].SetActive(false);
        timeStarted = false;
        slider.gameObject.SetActive(false);
        currentTime = 1.25f;
        Time.timeScale = 1f;
    }
    private IEnumerator FinishPanel()
    {
        isFinished = true;
        isFinishedMary = true;
        scoreMary.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
        finishPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        Finish();
    }
    public void Head1() 
    {
        scoreToConcert += 10;
        hairs[0].SetActive(false);
        hairs[1].SetActive(true);
        hairs[2].SetActive(false);
        hairs[3].SetActive(false);
    }
    public void Head2()
    { 
        scoreToConcert += 5;
        hairs[0].SetActive(false);
        hairs[1].SetActive(false);
        hairs[2].SetActive(true);
        hairs[3].SetActive(false);
    }
    public void Head3()
    {
        scoreToConcert += 100;
        hairs[0].SetActive(false);
        hairs[1].SetActive(false);
        hairs[2].SetActive(false);
        hairs[3].SetActive(true);
        awesome.Play();
    }
    public void Top1()
    {
        scoreToConcert += 10;
        tops[0].SetActive(false);
        tops[1].SetActive(true);
        tops[2].SetActive(false);
        tops[3].SetActive(false);
    }
    public void Top2()
    {
        scoreToConcert += 100;
        tops[0].SetActive(false);
        tops[1].SetActive(false);
        tops[2].SetActive(true);
        tops[3].SetActive(false);
        awesome.Play();
    }
    public void Top3()
    {
        scoreToConcert += 5;
        tops[0].SetActive(false);
        tops[1].SetActive(false);
        tops[2].SetActive(false);
        tops[3].SetActive(true);
    }
    public void Bottom1()
    {
        scoreToConcert += 100;
        bottoms[0].SetActive(false);
        bottoms[1].SetActive(true);
        bottoms[2].SetActive(false);
        bottoms[3].SetActive(false);
        awesome.Play();
    }
    public void Bottom2()
    {
        scoreToConcert += 10;
        bottoms[0].SetActive(false);
        bottoms[1].SetActive(false);
        bottoms[2].SetActive(true);
        bottoms[3].SetActive(false);
    }
    public void Bottom3()
    {
        scoreToConcert += 5;
        bottoms[0].SetActive(false);
        bottoms[1].SetActive(false);
        bottoms[2].SetActive(false);
        bottoms[3].SetActive(true);
    }
    public void Shoe1()
    {
        scoreToConcert += 5;
        shoes[0].SetActive(false);
        shoes[1].SetActive(true);
        shoes[2].SetActive(false);
        shoes[3].SetActive(false);
    }
    public void Shoe2()
    {
        scoreToConcert += 10;
        shoes[0].SetActive(false);
        shoes[1].SetActive(false);
        shoes[2].SetActive(true);
        shoes[3].SetActive(false);
    }
    public void Shoe3()
    {
        scoreToConcert += 100;
        shoes[0].SetActive(false);
        shoes[1].SetActive(false);
        shoes[2].SetActive(false);
        shoes[3].SetActive(true);
        awesome.Play();
    }
    void Score() 
    {
        concertScoreText.text = "Concert Score";
    }
    void Finish() 
    {
        if (scoreToConcert > scoreToConcertMary)
        {
            scoreMary.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
            Destroy(enemy);
            Destroy(text[2]);
            Destroy(text[3]);
            buttons[0].SetActive(true);
            buttons[1].SetActive(true);
            buttons[2].SetActive(true);
            concertScoreText.text = "You win!";
            animator.SetBool("isSinging", true);
            applause.Play();
        }
        else
        {
            scoreMary.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(text[2]);
            Destroy(text[3]);
            concertScoreText.text = "Mary wins!";
            animatorEnemy.SetBool("isDancing", true);
            applause.Play();
        }
    }
}
