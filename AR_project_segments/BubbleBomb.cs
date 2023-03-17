using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBomb : MonoBehaviour
{
    // ���� ������ ���� ��Ƽ���� �迭
    public Material[] colorMats = new Material[2];
    // ���� ����
    private float bubbleLifetime = 5.0f;
    // ������ ������Ʈ
    public GameObject[] TobeRemovedsets;
    // ���� ��������Ʈ ������Ʈ
    public GameObject expEffectObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // ������ ��ġ �Ǿ��� �� ���߾׼�
    public void OnTouch()
    {
        // ���� ���빰 ������Ʈ �����ϰ� ������ �ı��Ǳ�
        Instantiate(expEffectObj, this.transform.position, Quaternion.LookRotation(this.transform.position));
        RemoveBubbles();
        Destroy(gameObject);
    }
    private void RemoveBubbles()
    {
        // �ʵ� �� ���� �� ����
        TobeRemovedsets = GameObject.FindGameObjectsWithTag("Bubble");

        foreach (GameObject toberemoved in TobeRemovedsets)
        {
            Destroy(toberemoved);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� �ð��� ���� ��Ƽ���� ���� ������Ʈ �� �ı�
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
