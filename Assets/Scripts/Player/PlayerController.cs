using UnityEngine;
using UnityEngine.InputSystem;

public interface IHit
{
    public void GetHit();
}

public class PlayerController : MonoBehaviour, IHit
{
    public float moveDistance = 1;
    private Vector3 curPos;
    private Vector3 moveValue;
    public float moveTime = 0.4f;
    public float colliderDistCheck = 1.1f;

    public ParticleSystem particle = null;
    public Transform chick = null;
    public bool isDead = false;

    void Start()
    {
        moveValue = Vector3.zero;
        curPos = transform.position;
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector3 input = context.ReadValue<Vector3>();

        if (input.magnitude > 1f) return;

        if (context.performed)
        {
            if (input.magnitude == 0f)
            {
                Rotate(moveValue);
                CheckIfCanMove(context);
            }
            else
            {
                moveValue = input * moveDistance;
            }
        }
    }

    void CheckIfCanMove(InputAction.CallbackContext context) //앞에 장애물이 있는지 체크 후 없을 시에만 이동
    {
        Physics.Raycast(this.transform.position, -chick.transform.up, out RaycastHit hit, colliderDistCheck);
        Debug.DrawRay(this.transform.position, -chick.transform.up * colliderDistCheck, Color.red, 2);

        if (hit.collider == null || (hit.collider != null && hit.collider.tag != "collider"))
        {
            Moving(transform.position + moveValue);
            moveValue = Vector3.zero;
        }
    }

    void Moving(Vector3 pos)
    {
        LeanTween.move(this.gameObject, pos, moveTime).setOnComplete(() => { if (pos.z > curPos.z) SetMoveForwardState(); });
    }

    void Rotate(Vector3 pos)
    {
        if (pos.z < 0f) //후방이동시 뒤돌아보기 추가
        {
            chick.rotation = Quaternion.Euler(270, pos.z * 180, 0);
        }
        else //후방이동 아닐 시 기존 코드 실행
        {
            chick.rotation = Quaternion.Euler(270, pos.x * 90, 0);
        }
    }

    void SetMoveForwardState()
    {
        Manager.instance.UpdateDistanceCount();
        curPos = transform.position;
    }

    public void GetHit()
    {
        Manager.instance.GameOver();
        isDead = true;
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;
    }
}
