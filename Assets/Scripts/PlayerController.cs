using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool PlayerCreated;

    public float speed = 190.0f;

    public Vector2 lastMovement = new Vector2(0f, 0f);
    [HideInInspector]
    public string nextPlaceName;

    private bool walking = false;
    public bool talking;

    private Animator animator;
    private Rigidbody2D playerRg;
    private DialogManager manager;

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";
    const string attakingState = "Attaking";

    private bool attaking;
    public float attackTime;
    public float attackTimeCounter;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerRg = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<DialogManager>();

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
        talking = manager.dialogActive;
        if (talking)
        {
            playerRg.velocity = Vector2.zero;
            return;
        }

        walking = false;

        if (Input.GetMouseButtonDown(0))
        {
            attaking = true;
            attackTimeCounter = attackTime;
            playerRg.velocity = Vector2.zero;
            animator.SetBool(attakingState, true);
        }

        if (attaking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                attaking = false;
                animator.SetBool(attakingState, false);
            }
        }
        else
        {
            float horizontalRaw = Input.GetAxisRaw(horizontal);
            float verticalRaw = Input.GetAxisRaw(vertical);
            if (Mathf.Abs(horizontalRaw) >= 0.5f || Mathf.Abs(verticalRaw) >= 0.5f)
            {
                walking = true;
                lastMovement = new Vector2(horizontalRaw, verticalRaw);
                playerRg.velocity = lastMovement.normalized * speed * Time.deltaTime;
                lastMovement = new Vector2(horizontalRaw, verticalRaw);
            }

            animator.SetFloat(horizontal, horizontalRaw);
            animator.SetFloat(vertical, verticalRaw);

            animator.SetBool(walkingState, walking);

            animator.SetFloat(lastHorizontal, lastMovement.x);
            animator.SetFloat(lastVertical, lastMovement.y);
        }

        if (!walking)
            playerRg.velocity = Vector2.zero;
    }
}
