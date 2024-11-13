using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1.0f;
    public float moveDirection = 0;
    public bool parentOnTrigger = true;
    public bool hitBoxOnTrigger = false;
    public GameObject moverObject = null;

    public bool fallIntoWaterOnTrigger = false;
    public bool onLog = false;

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
                onLog = true;
            }

            if (hitBoxOnTrigger)
            {
                other.GetComponent<IHit>().GetHit();
            }

            if (fallIntoWaterOnTrigger)
            {
                if (!onLog)
                {
                    other.GetComponent<IHit>().GetHit();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (parentOnTrigger)
            {
                other.transform.parent = null;
                onLog = false;
            }
        }
    }
}
