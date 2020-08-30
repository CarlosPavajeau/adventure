using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public Vector2 lastMovement = new Vector2(0f, 0f);

    private bool walking = false;
    private Animator animator;

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;

        float horizontalRaw = Input.GetAxisRaw(horizontal);
        if (Mathf.Abs(horizontalRaw) > 0.5f)
        {
            transform.Translate(new Vector3(horizontalRaw * speed * Time.deltaTime, 0, 0));
            walking = true;
            lastMovement = new Vector2(horizontalRaw, 0);
        }

        float verticalRaw = Input.GetAxisRaw(vertical);
        if (Mathf.Abs(verticalRaw) > 0.5f)
        {
            transform.Translate(new Vector3(0, verticalRaw * speed * Time.deltaTime, 0));
            walking = true;
            lastMovement = new Vector2(0, verticalRaw);
        }

        animator.SetFloat(horizontal, horizontalRaw);
        animator.SetFloat(vertical, verticalRaw);

        animator.SetBool(walkingState, walking);

        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
