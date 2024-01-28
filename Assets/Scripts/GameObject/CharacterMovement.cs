using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    const string WalkParameter = "Walk";
    public float speed = 150.0f;
    public Vector3 targetPosition;
    public Animator Animator;

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
            targetPosition = Input.mousePosition;
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
        Vector3 direction = targetPosition - transform.position;
        transform.localScale = direction.x switch
        {
            < 0 => new Vector3(-1, 1, 1),
            > 0 => new Vector3(1, 1, 1),
            _ => transform.localScale
        };
        Animator.SetBool(WalkParameter, direction.magnitude > 0.1f);
    }
}