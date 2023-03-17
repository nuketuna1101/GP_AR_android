using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBubble : MonoBehaviour
{
    // ����� ����
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
        // �ʱ� Ÿ�� ����
        timeQuantum = timePeriod;
        // ����� ������Ʈ
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
        // �� ������ �ð� ����
        timeQuantum -= Time.deltaTime;

        if (timeQuantum < 0.0f)
        {
            // Ÿ�̸� ����
            timeQuantum = timePeriod;
            // ȿ����
            makeSound.PlayOneShot(MakeSoundClip);
            // make bubble
            shootBubble();
        }

    }
}
