using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1f;
    private Rigidbody2D enemyRb;

    private bool walking;

    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;

    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;
    public Vector2 lastMovement = new Vector2(0f, 0f);

    private Animator enemyAnimator;

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps + Random.Range(0.5f, 2f);
        timeToMakeStepCounter = timeToMakeStep + Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRb.velocity = directionToMakeStep;

            if (timeToMakeStepCounter <= 0)
            {
                walking = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                lastMovement = new Vector2(directionToMakeStep.x, directionToMakeStep.y);
                enemyRb.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter <= 0)
            {
                timeToMakeStepCounter = timeToMakeStep;
                directionToMakeStep = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * enemySpeed;

                if (directionToMakeStep.x != 0 || directionToMakeStep.y != 0)
                    walking = true;
            }
        }

        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);

        enemyAnimator.SetBool(walkingState, walking);

        enemyAnimator.SetFloat(lastHorizontal, lastMovement.x);
        enemyAnimator.SetFloat(lastVertical, lastMovement.y);
    }
}
