using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1.0f;
    public float moveDirection = 0;
    public bool parentOnTrigger = true;
    public bool hitBoxOnTrigger = false;
    public GameObject moverObject = null;

    //물에 빠졌을 시 게임오버되는 기능을 추가해 보았지만 통나무 위에서도 게임 오버되는 문제로 인해 보류
    //public bool fallIntoWaterOnTrigger = false;
    //public bool onLog = false;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (parentOnTrigger)
            {
                other.transform.parent = this.transform;
                //onLog = true;
            }

            if (hitBoxOnTrigger)
            {
                other.GetComponent<IHit>().GetHit();
            }

            //if (fallIntoWaterOnTrigger)
            //{
            //    if (!onLog)
            //    {
            //        other.GetComponent<IHit>().GetHit();
            //    }
            //}
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (parentOnTrigger)
            {
                other.transform.parent = null;
                //onLog = false;
            }
        }
    }
}
