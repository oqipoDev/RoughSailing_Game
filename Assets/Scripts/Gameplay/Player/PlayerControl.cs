using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("References")]

    public List<GameObject> PunchHitBoxes;
    public Animator PlayerAnimator;

    [Header("Parameters")]

    public float WalkingSpeed = 5f;
    public float RunMultiplier = 2f;
    [Range(0f , 0.1f)] public float Momentum = 0.03f;
    [Range(0, 1f)] public float TurnSmoothing = 0.8f;

    [Space]
    public float PunchTime = 0.4f;
    public float PunchLean = 0.5f;
    public float GracePeriod  = 0.3f;

    //Variables
        //States
    enum PlayerState {Moving, Punching, Stunlocked ,PlayAnim}
    PlayerState CurrentState = PlayerState.Moving;
        //Locomotion
    private Vector2 Facing; //Stores object player direction
    private Vector2 Directions; //Stores controller direction
    private Vector2 CurrentVel; //Stores velocity, used for movement smoothing
    private Vector2 CurrentAccel; //Referenced by SmoothDamp function
        //Action
    private float ActionTimer = 0; //Stores time since last state change
    private int PunchNum = 0; //Stores last player punch for combos
    private AttackHitbox_Gen LastAttack; //Stores last attack, used for damage, animation and stunlock effects

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PunchHitBoxes.Count; i++)
        {
            PunchHitBoxes[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case PlayerState.Moving:
                //Write input to vector
                Directions = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                Directions = new Vector2(Directions.x * Mathf.Cos(Directions.y), Directions.y * Mathf.Cos(Directions.x));

                //Run
                if(Input.GetKey(KeyCode.LeftShift))
                    Directions *= RunMultiplier;
                //Apply magnitude to animator
                PlayerAnimator.SetFloat("Speed", Directions.magnitude / RunMultiplier);
                //Smooth movement
                CurrentVel = Vector2.SmoothDamp(CurrentVel, Directions, ref CurrentAccel, Momentum);
                //Move Player
                transform.localPosition += new Vector3(CurrentVel.x , 0, CurrentVel.y) * WalkingSpeed * Time.deltaTime;

                //Making sure the player is looking the right way
                if (CurrentVel.magnitude > 0.01f)
                {
                    //Store in component
                    Facing = CurrentVel.normalized;
                    //Apply rotation
                    Quaternion newRot = Quaternion.LookRotation(new Vector3(Facing.x, 0, Facing.y));
                    transform.localRotation = Quaternion.Lerp(newRot, transform.localRotation, TurnSmoothing);
                }

                //Punch if pressed punch button
                if (Input.GetMouseButtonDown(0))
                {
                    CurrentState = PlayerState.Punching;
                    //transform.LookAt(LookAtMouse());
                    //Activate first hitbox
                    PunchHitBoxes[0].SetActive(true);
                    //Animate
                    PlayerAnimator.SetInteger("AttackNum", 1);
                    PlayerAnimator.SetFloat("Speed", 0);
                }
                break;
            case PlayerState.Punching:
                ActionTimer += Time.deltaTime;
                //Add forward force
                transform.localPosition += new Vector3(Facing.x, 0, Facing.y) * (PunchTime - ActionTimer) * Time.deltaTime * PunchLean;

                //ToDo: make a better, consult friendly, attack rythm system
                //Grace period before next punch
                if(ActionTimer < GracePeriod && Input.GetMouseButtonDown(0) && PunchNum + 1 < PunchHitBoxes.Count)
                {
                    //Deactivate previous hitbox
                    PunchHitBoxes[PunchNum].SetActive(false);
                    //Stuff happenin
                    PunchNum++;
                    ActionTimer = 0;
                    //transform.LookAt(LookAtMouse());
                    PlayerAnimator.SetInteger("AttackNum", PunchNum + 1);
                    PunchHitBoxes[PunchNum].SetActive(true);
                }
                
                //End when time runs out
                if (ActionTimer >= PunchTime)
                {
                    //Reset hitboxes
                    PunchHitBoxes[PunchNum].SetActive(false);
                    //Reset timer
                    ActionTimer = 0;
                    //Reset counter
                    PunchNum = 0;     

                    CurrentState = PlayerState.Moving;
                    //Animate
                    PlayerAnimator.SetInteger("AttackNum", 0);
                }
                break;
            
            case PlayerState.Stunlocked:
                ActionTimer += Time.deltaTime;

                if (ActionTimer >= LastAttack.StunTime)
                {
                    CurrentState = PlayerState.Moving;
                    ActionTimer = 0;
                }

                transform.localPosition += new Vector3(-Facing.x, 0, -Facing.y) * (LastAttack.StunTime - ActionTimer) * Time.deltaTime * LastAttack.MoveForward * 100;
            break;

            default:
                break;
        }
    }

    public void StunlockPlayer(AttackHitbox_Gen attack)
    {
        LastAttack = attack;
        
        Vector3 facin = (LastAttack.gameObject.transform.position - transform.position).normalized;
        Facing = new Vector2(facin.x, facin.z);
        transform.localRotation = Quaternion.LookRotation(new Vector3(Facing.x, 0, Facing.y));

        CurrentState = PlayerState.Stunlocked;
    }

    private Vector3 LookAtMouse() //Devuelve la posicion del mouse en el mundo con un ray cast
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Hacemos una variable de tipo ray(rayo) que se crea desde la camara en la posicion del mouse.
        Vector3 worldPosition;  //Variable del tipo vector 3 para guardar la posicion a donde se va a apuntar
        RaycastHit hit; //Variable de tipo RaycastHit que guarda la informacion colision del rayo y el otro objeto con el que choco
        if (Physics.Raycast(ray, out hit, 500))  //Hacemos nuestro raycast desde la posicion del mouse y guardamos la informacion en hit, y le damos una distancia maxima de 500
        {
            worldPosition = hit.point; //tomamos la posicon donde colisiono el rayo
            worldPosition.y = transform.position.y; //Sobreescribimos esta posicion con la posicion del jugador para que no rote en direcciones que no queremos
            return worldPosition;
        }
        return transform.position; //Si no encontro nada, devolver la posicion actual, para que no gire a lo idiota
    }
}
