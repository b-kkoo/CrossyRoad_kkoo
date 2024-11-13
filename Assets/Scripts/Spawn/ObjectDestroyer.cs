using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void Update()
    {
        DestroyObject();
    }

    private void DestroyObject() //currentDistance ���� 20f���� �ڿ� �ִ� ������Ʈ ����
    {
        if (Manager.instance.currentDistance - this.transform.position.z > 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
