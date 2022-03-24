using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    enum EnemyStates {Idle, Hunting, Damaged, Telegraph, Attack, WaitingTurn}

    [SerializeField]
    EnemyStates CurrentState = EnemyStates.Hunting;
    
    //Parameters
    public float WalkingSpeed = 1f;
    [Range(0f , 0.25f)] public float Momentum = 0.1f;
    public float AttackDistance = 0.5f;
    public List<AttackHitbox_Gen> Attacks;

    public float waitingTime;
    public float waitingTime2;

    [SerializeField]
    private Animator animator;

    //Data
    private Transform Player;
    private Vector2 Directions;
    private Vector2 Facing;
    private Vector2 CurrentVel;
    private Vector2 CurrentAccel;
    [SerializeField]
    private float timeLeft;
    private AttackHitbox_Gen CurrentAttack;

    // Start is called before the first frame update
    void Start()
    {
        Player = ArenaManager.GetPlayerObject().transform;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            CurrentState = EnemyStates.Idle;
        }

        switch (CurrentState)
        {
            case EnemyStates.Hunting:
                animator.SetInteger("Stage", 1);
                //Follow the player
                Vector3 PlayerDirection = Player.localPosition - transform.localPosition;
                Directions = new Vector2(PlayerDirection.x, PlayerDirection.z);
                //Stop before attack zone
                if (Directions.magnitude > AttackDistance)
                    Directions *= (Directions.magnitude - AttackDistance) / Directions.magnitude;
                //Smooth movement
                CurrentVel = Vector2.SmoothDamp(CurrentVel, Directions, ref CurrentAccel, Momentum);
                //Move enemy
                transform.localPosition += new Vector3(CurrentVel.x , 0, CurrentVel.y) * WalkingSpeed * Time.deltaTime;

                //Making sure the it's looking the right way
                if (CurrentVel.magnitude > 0.01f)
                {
                    Facing = CurrentVel.normalized;
                    //Apply rotation
                    transform.localRotation = Quaternion.LookRotation(new Vector3(Facing.x, 0, Facing.y));
                }

                if (PlayerDirection.magnitude < AttackDistance + 0.5f)
                {
                    SetRandomAttack();

                    CurrentState = EnemyStates.Telegraph;
                }

                if(waitingTime2 <= 0)
                {
                    waitingTime2 = 2f;
                    if (Random.Range(0, 3) == 1)
                    {
                        Debug.Log("waiting " + gameObject.name);
                        waitingTime = Random.Range(4, 5);
                        CurrentState = EnemyStates.WaitingTurn;
                    }
                }
                else
                {
                    waitingTime2 -= Time.deltaTime;
                }
                break;

            case EnemyStates.Telegraph:
                
                animator.SetInteger("Stage", 2);
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    CurrentState = EnemyStates.Attack;
                    timeLeft = CurrentAttack.RecoveryTime;
                    //Activate hitbox
                    CurrentAttack.gameObject.SetActive(true);
                }
            break;

            case EnemyStates.Attack:
                animator.SetInteger("Stage", 3);
                timeLeft -= Time.deltaTime;
                //Add forward force
                transform.localPosition += new Vector3(Facing.x, 0, Facing.y) * timeLeft * Time.deltaTime * CurrentAttack.MoveForward * 10;

                if (timeLeft <= 0)
                {
                    waitingTime = Random.Range(4, 5);
                    CurrentState = EnemyStates.WaitingTurn;
                    CurrentAttack.gameObject.SetActive(false);
                }
            break;

            case EnemyStates.Damaged:
                timeLeft -= Time.deltaTime;
                animator.SetInteger("Stage", 4);

                if (timeLeft > 0)
                {
                    transform.localPosition += new Vector3(Directions.x , 0, Directions.y) * timeLeft * Time.deltaTime * 10;
                }
                else
                {
                    CurrentState = EnemyStates.WaitingTurn;
                }
            break;

            case EnemyStates.WaitingTurn://TODO: decompress
                animator.SetInteger("Stage", 0);
                //Making sure the it's looking the right way
                //Follow the player
                PlayerDirection = Player.localPosition - transform.localPosition;
                Directions = new Vector2(PlayerDirection.x, PlayerDirection.z);
                //Stop before attack zone
                if (Directions.magnitude > AttackDistance)
                    Directions *= (Directions.magnitude - AttackDistance) / Directions.magnitude;
                //Smooth movement
                CurrentVel = Vector2.SmoothDamp(CurrentVel, Directions, ref CurrentAccel, Momentum);

                //Making sure it's looking the right way
                if (CurrentVel.magnitude > 0.01f)
                {
                    Facing = CurrentVel.normalized;
                    //Apply rotation
                    transform.localRotation = Quaternion.LookRotation(new Vector3(Facing.x, 0, Facing.y));
                }

                waitingTime -= Time.deltaTime;
                if(waitingTime <= 0)
                {
                    CurrentState = EnemyStates.Hunting;
                }
                PlayerDirection = Player.localPosition - transform.localPosition;
                Directions = new Vector2(PlayerDirection.x, PlayerDirection.z);
                if (PlayerDirection.magnitude < AttackDistance + 0.5f)
                {
                    SetRandomAttack();

                    CurrentState = EnemyStates.Telegraph;
                }
                break;
            default:
            break;
        }
    }
    public void Knockback(AttackHitbox_Gen attack)
    {
        animator.SetInteger("Stage", 4);
        CurrentState = EnemyStates.Damaged;
        timeLeft = attack.StunTime;
        //turn
        Vector3 facin = (attack.gameObject.transform.position - transform.position).normalized;
        Facing = new Vector2(facin.x, facin.z);
    }

    private void SetRandomAttack()
    {
        //Random Attack
        int randomAttack = ((int)(Random.value * Attacks.Count + 1));
        //Avoid overflow
        randomAttack = (Mathf.Clamp(randomAttack, 0, Attacks.Count - 1));

        CurrentAttack = Attacks[randomAttack];

        timeLeft = CurrentAttack.TelegraphTime;
    }

    public void SetState(int state)
    {
        Debug.Log("-" + state);
        CurrentState = (EnemyStates)state;
    }
}
