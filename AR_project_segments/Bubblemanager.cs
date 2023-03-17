using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class Bubblemanager : MonoBehaviour
{
    // 오디오 관련
    private AudioSource bubbleSound;
    public AudioClip bubblePopSound;
    public AudioClip explodeSound;

    // Raycast 결과를 저장하는 data
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    ARRaycastManager RaycastManager;
    [SerializeField] private Camera arCamera;
    private GameObject SelectedObj;
    //public TextMeshPro showText;


    // Start is called before the first frame update
    void Start()
    {
        // ARRaycastManager 초기화
        RaycastManager = GetComponent<ARRaycastManager>();
        // 오디오 컴포넌트
        bubbleSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // touch가 일어난 경우에만 object를 배치
        if (Input.touchCount == 0)
            return;
        // touch가 시작될 때만 object를 배치
        Touch touch = Input.GetTouch(0);
        //if (touch.phase != TouchPhase.Began)            return;

        //터치 시작시
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hitObj;
            //Ray를 통한 오브젝트 인식
            if (Physics.Raycast(ray, out hitObj))
            {
                //터치한 곳에 오브젝트 이름이 Cube를 포함하면
                //if (hitObj.collider.gameObject.tag == "Bubble")
                //if (hitObj.collider.gameObject.name.Contains("BubObj"))
                if (hitObj.collider.gameObject.name.Contains("BubbleDia"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;

                    bubbleSound.PlayOneShot(bubblePopSound);
                    // Destroy(hitObj.collider.gameObject);
                    // 버블 터치된 액션 콜
                    hitObj.collider.gameObject.GetComponent<BubbleDia>().OnTouch();


                }
                else if (hitObj.collider.gameObject.name.Contains("BubbleCoin"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;

                    bubbleSound.PlayOneShot(bubblePopSound);
                    // Destroy(hitObj.collider.gameObject);
                    // 버블 터치된 액션 콜
                    hitObj.collider.gameObject.GetComponent<BubbleCoin>().OnTouch();


                }
                else if (hitObj.collider.gameObject.name.Contains("BubbleCrystal"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;

                    bubbleSound.PlayOneShot(bubblePopSound);
                    // Destroy(hitObj.collider.gameObject);
                    // 버블 터치된 액션 콜
                    hitObj.collider.gameObject.GetComponent<BubbleCrystal>().OnTouch();

                }
                else if (hitObj.collider.gameObject.name.Contains("BubbleBomb"))
                {
                    //showText.text = "Success\n" + hitObj.collider.name;
                    bubbleSound.PlayOneShot(explodeSound);
                    // Destroy(hitObj.collider.gameObject);
                    // 버블 터치된 액션 콜
                    hitObj.collider.gameObject.GetComponent<BubbleBomb>().OnTouch();
                }
            }
        }
    }
}