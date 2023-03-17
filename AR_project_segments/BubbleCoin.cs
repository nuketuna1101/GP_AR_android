using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCoin : MonoBehaviour
{
    // 버블 색깔을 위한 머티리얼 배열
    public Material[] colorMats = new Material[2];
    // 버블 수명
    private float bubbleLifetime = 5.0f;
    // 스폰 오브젝트
    public GameObject spawnObj;


    // Start is called before the first frame update
    void Start()
    {

    }

    // 버블이 터치 되었을 때
    public void OnTouch()
    {
        // 안의 내용물 오브젝트 생성하고 버블은 파괴되기
        Instantiate(spawnObj, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
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
