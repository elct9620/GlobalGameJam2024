using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    const string WalkParameter = "Walk";
    public float speed = 150.0f;
    public Vector3 targetPosition;
    public Animator Animator;

    public GameObject closeObject;          // 新增的 GameObject
    public float      closeDistance = 100f; // 靠近的距離

    private bool isMoving = true; // 新增的變量，用於控制角色是否移動

    private void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        CaptureMovement();
        Move();
        Animate();
    }

    private void CaptureMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            float   distance      = Vector3.Distance(closeObject.transform.position, mousePosition);
            Debug.Log("pos"+distance);
            if (distance < closeDistance)
            {
                isMoving = false; // 如果鼠標位置靠近 closeObject，則停止移動
            }
            else
            {
                targetPosition = mousePosition;
                isMoving       = true; // 如果鼠標位置不靠近 closeObject，則繼續移動
            }
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }

    void Animate()
    {
        Vector3 initScale = transform.localScale;
        Vector3 direction = targetPosition - transform.position;
        transform.localScale = direction.x switch
        {
            < 0 => new Vector3(Mathf.Abs(initScale.x) * -1, initScale.y, initScale.z),
            > 0 => new Vector3(Mathf.Abs(initScale.x), initScale.y, initScale.z),
            _ => transform.localScale
        };
        Animator.SetBool(WalkParameter, direction.magnitude > 0.1f);
    }
}