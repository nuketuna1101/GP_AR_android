using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBubble : MonoBehaviour
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

    private int randNo = -1;

    // Start is called before the first frame update
    void Start()
    {
        // 초기 타임 설정
        timeQuantum = timePeriod;
        // 오디오 컴포넌트
        makeSound = GetComponent<AudioSource>();
    }

    void shootBubble()
    {
        randNo = Random.Range(0, 100);

        if (randNo >= 75)
        {
            Instantiate(bubbleBomb, this.transform.position + new Vector3(0.0f, 0.5f, 0.0f), this.transform.rotation);
        }
        else if (randNo >= 50)
        {
            Instantiate(bubbleDia, this.transform.position + new Vector3(0.0f, 0.5f, 0.0f), this.transform.rotation);
        }
        else if (randNo >= 25)
        {
            Instantiate(bubbleCoin, this.transform.position + new Vector3(0.0f, 0.5f, 0.0f), this.transform.rotation);
        }
        else
        {
            Instantiate(bubbleCrystal, this.transform.position + new Vector3(0.0f, 0.5f, 0.0f), this.transform.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 매 프레임 시간 갱신
        timeQuantum -= Time.deltaTime;

        if (timeQuantum < 0.0f)
        {
            // 타이머 리셋
            timeQuantum = timePeriod;
            // 효과음
            makeSound.PlayOneShot(MakeSoundClip);
            // make bubble
            shootBubble();
        }

    }
}
