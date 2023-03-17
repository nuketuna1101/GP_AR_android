using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnBubbles : MonoBehaviour
{
    // 오디오 관련
    private AudioSource makeSound;
    public AudioClip MakeSoundClip;
    //
    public GameObject bubbleBomb;
    public GameObject bubbleDia;
    public GameObject bubbleCoin;
    public GameObject bubbleCrystal;

    private float timeQuantum = 0.0f;
    private float timePeriod = 5.0f;

    private int randNo1 = -1;
    private int randNo2 = -1;
    private int randNo = -1;

    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //
        randNo2 = Random.Range(1, 5);
        timePeriod = 0.5f * randNo2;

        // 초기 타임 설정
        timeQuantum = timePeriod;
        // 오디오 컴포넌트
        makeSound = GetComponent<AudioSource>();
    }

    void shootBubble()
    {
        randNo1 = Random.Range(1, 11);
        spawnPoint = this.transform.position + new Vector3(0.025f * Mathf.Pow(-1, randNo1) * randNo1, 0.03f * randNo1, 0.025f * (-1) * Mathf.Pow(-1, randNo1) * randNo1);

        randNo = Random.Range(0, 100);

        if (randNo >= 75)
        {
            Instantiate(bubbleBomb, spawnPoint, this.transform.rotation);
        }
        else if (randNo >= 50)
        {
            Instantiate(bubbleDia, spawnPoint, this.transform.rotation);
        }
        else if (randNo >= 25)
        {
            Instantiate(bubbleCoin, spawnPoint, this.transform.rotation);
        }
        else
        {
            Instantiate(bubbleCrystal, spawnPoint, this.transform.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 매 프레임 시간 갱신
        timeQuantum -= Time.deltaTime;

        if (timeQuantum < 0.0f)
        {
            randNo2 = Random.Range(1, 5);
            timePeriod = 1.25f + 0.33f * randNo2;
            // 타이머 리셋
            timeQuantum = timePeriod;
            // 효과음
            makeSound.PlayOneShot(MakeSoundClip);
            // make bubble
            shootBubble();
        }

    }
}
