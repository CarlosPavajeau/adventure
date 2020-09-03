using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";

    public float speed = 1.5f;
    private Rigidbody2D npcRigidbody;
    private Animator npcAnimator;

    public bool isWalking, isTalking;

    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 3.0f;
    private float waitCounter;
    private DialogManager manager;

    private readonly Vector2[] walkingDirections =
    {
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(-1, 0),
        new Vector2(0, -1)
    };

    private int currentDirection;

    public BoxCollider2D villagerZone;

    // Start is called before the first frame update
    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody2D>();
        npcAnimator = GetComponent<Animator>();

        walkCounter = walkTime + Random.Range(0.5f, 2f);
        waitCounter = waitTime + Random.Range(0f, 3f);

        manager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isTalking = manager.dialogActive;

        if (isTalking)
        {
            StopWalking();
            return;
        }

        if (isWalking)
        {
            if (villagerZone != null)
            {
                if (transform.position.x < villagerZone.bounds.min.x ||
                    transform.position.x > villagerZone.bounds.max.x ||
                    transform.position.y < villagerZone.bounds.min.y ||
                    transform.position.y > villagerZone.bounds.max.y)
                    StopWalking();

            }

            npcRigidbody.velocity = walkingDirections[currentDirection] * speed;

            walkCounter -= Time.deltaTime;
            if (walkCounter <= 0)
                StopWalking();
        }
        else
        {
            waitCounter -= Time.deltaTime;
            npcRigidbody.velocity = Vector2.zero;
            if (waitCounter <= 0)
                StartWalking();
        }
    }

    private void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkCounter = walkTime;

        npcAnimator.SetFloat(horizontal, walkingDirections[currentDirection].x);
        npcAnimator.SetFloat(vertical, walkingDirections[currentDirection].y);
        npcAnimator.SetBool(walkingState, isWalking);
    }

    private void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        npcRigidbody.velocity = Vector2.zero;

        npcAnimator.SetFloat(lastHorizontal, walkingDirections[currentDirection].x);
        npcAnimator.SetFloat(lastVertical, walkingDirections[currentDirection].y);

        npcAnimator.SetBool(walkingState, isWalking);
    }
}
