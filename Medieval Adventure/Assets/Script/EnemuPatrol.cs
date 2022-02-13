using UnityEngine;
public class EnemuPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Move Paramets")]
    private float speed=6;
    private Vector3 initScale;
    private bool movigLeft;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void Update()
    {
        if (movigLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange ()
    {
        movigLeft = !movigLeft;
    }
    private void MoveInDirection (int _direction)
    {
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x)* _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x+Time.deltaTime* _direction* speed, enemy.position.y, enemy.position.z);
    }
}
