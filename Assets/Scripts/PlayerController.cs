using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool PlayerCreated;

    public float speed = 450.0f;
    public Vector2 lastMovement = new Vector2(0f, 0f);
    public string nextPlaceName;

    private bool walking = false;
    private Animator animator;
    private Rigidbody2D playerRg;

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";

    void Start()
    {
        animator = GetComponent<Animator>();
        playerRg = GetComponent<Rigidbody2D>();

        if (!PlayerCreated)
        {
            PlayerCreated = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        walking = false;

        float horizontalRaw = Input.GetAxisRaw(horizontal);
        if (Mathf.Abs(horizontalRaw) > 0.5f)
        {
            playerRg.velocity = new Vector2(horizontalRaw * speed * Time.deltaTime, playerRg.velocity.y);
            walking = true;
            lastMovement = new Vector2(horizontalRaw, 0);
        }
        else
        {
            playerRg.velocity = new Vector2(0, playerRg.velocity.y);
        }

        float verticalRaw = Input.GetAxisRaw(vertical);
        if (Mathf.Abs(verticalRaw) > 0.5f)
        {
            playerRg.velocity = new Vector2(playerRg.velocity.x, verticalRaw * speed * Time.deltaTime);
            walking = true;
            lastMovement = new Vector2(0, verticalRaw);
        }
        else
        {
            playerRg.velocity = new Vector2(playerRg.velocity.x, 0);
        }

        if (!walking)
            playerRg.velocity = Vector2.zero;


        animator.SetFloat(horizontal, horizontalRaw);
        animator.SetFloat(vertical, verticalRaw);

        animator.SetBool(walkingState, walking);

        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
