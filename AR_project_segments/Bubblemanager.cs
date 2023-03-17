using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class Bubblemanager : MonoBehaviour
{
    // ����� ����
    private AudioSource bubbleSound;
    public AudioClip bubblePopSound;
    public AudioClip explodeSound;

    // Raycast ����� �����ϴ� data
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    ARRaycastManager RaycastManager;
    [SerializeField] private Camera arCamera;
    private GameObject SelectedObj;
    //public TextMeshPro showText;


    // Start is called before the first frame update
    void Start()
    {
        // ARRaycastManager �ʱ�ȭ
        RaycastManager = GetComponent<ARRaycastManager>();
        // ����� ������Ʈ
        bubbleSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // touch�� �Ͼ ��쿡�� object�� ��ġ
        if (Input.touchCount == 0)
            return;
        // touch�� ���۵� ���� object�� ��ġ
        Touch touch = Input.GetTouch(0);
        //if (touch.phase != TouchPhase.Began)            return;

        //��ġ ���۽�
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hitObj;
            //Ray�� ���� ������Ʈ �ν�
            if (Physics.Raycast(ray, out hitObj))
            {
                //��ġ�� ���� ������Ʈ �̸��� Cube�� �����ϸ�
                //if (hitObj.collider.gameObject.tag == "Bubble")
                //if (hitObj.collider.gameObject.name.Contains("BubObj"))
                if (hitObj.collider.gameObject.name.Contains("BubbleDia"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;

                    bubbleSound.PlayOneShot(bubblePopSound);
                    // Destroy(hitObj.collider.gameObject);
                    // ���� ��ġ�� �׼� ��
                    hitObj.collider.gameObject.GetComponent<BubbleDia>().OnTouch();


                }
                else if (hitObj.collider.gameObject.name.Contains("BubbleCoin"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;

                    bubbleSound.PlayOneShot(bubblePopSound);
                    // Destroy(hitObj.collider.gameObject);
                    // ���� ��ġ�� �׼� ��
                    hitObj.collider.gameObject.GetComponent<BubbleCoin>().OnTouch();


                }
                else if (hitObj.collider.gameObject.name.Contains("BubbleCrystal"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;

                    bubbleSound.PlayOneShot(bubblePopSound);
                    // Destroy(hitObj.collider.gameObject);
                    // ���� ��ġ�� �׼� ��
                    hitObj.collider.gameObject.GetComponent<BubbleCrystal>().OnTouch();

                }
                else if (hitObj.collider.gameObject.name.Contains("BubbleBomb"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;
                    bubbleSound.PlayOneShot(explodeSound);
                    // Destroy(hitObj.collider.gameObject);
                    // ���� ��ġ�� �׼� ��
                    hitObj.collider.gameObject.GetComponent<BubbleBomb>().OnTouch();
                }
            }
        }
    }
}