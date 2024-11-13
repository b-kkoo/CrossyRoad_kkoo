using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void Update()
    {
        DestroyObject();
    }

    private void DestroyObject() //currentDistance 기준 20f보다 뒤에 있는 오브젝트 삭제
    {
        if (Manager.instance.currentDistance - this.transform.position.z > 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
