using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBomb : MonoBehaviour
{
    // 버블 색깔을 위한 머티리얼 배열
    public Material[] colorMats = new Material[2];
    // 버블 수명
    private float bubbleLifetime = 5.0f;
    // 삭제할 오브젝트
    public GameObject[] TobeRemovedsets;
    // 폭발 섬광이펙트 오브젝트
    public GameObject expEffectObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // 버블이 터치 되었을 때 폭발액션
    public void OnTouch()
    {
        // 안의 내용물 오브젝트 생성하고 버블은 파괴되기
        Instantiate(expEffectObj, this.transform.position, Quaternion.LookRotation(this.transform.position));
        RemoveBubbles();
        Destroy(gameObject);
    }
    private void RemoveBubbles()
    {
        // 필드 위 좀비 다 제거
        TobeRemovedsets = GameObject.FindGameObjectsWithTag("Bubble");

        foreach (GameObject toberemoved in TobeRemovedsets)
        {
            Destroy(toberemoved);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 버블 수명 시간에 따른 머티리얼 색깔 업데이트 및 파괴
        if (bubbleLifetime >= 0)
            bubbleLifetime -= Time.deltaTime;
        if (bubbleLifetime >= 1.0f && bubbleLifetime < 2.5f)
            this.transform.Find("Sphere").gameObject.GetComponent<MeshRenderer>().material = colorMats[0];
        if (bubbleLifetime < 1.0f)
            this.transform.Find("Sphere").gameObject.GetComponent<MeshRenderer>().material = colorMats[1];

        if (bubbleLifetime < 0)
            Destroy(gameObject);
    }
}
