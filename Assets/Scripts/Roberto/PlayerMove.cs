using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //RobertoNiciforo
    [Header("Valori")]
    public float MoveSpeed = 4f;
    public float roatitionSpeed = 0f;
    public float rollForce = 0f;
    public float StandardMoveSpeed;
    public float rollDistance = 0.3f;
    public float timeRoll;
    [Header("Camera")]
    [SerializeField]
    private Camera CameraPrincipale;
    [Header("Cursor")]
    [SerializeField]
    private GameObject cursore;
    [Header("Altro")]
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    Vector3 forward;
    Vector3 direction;
    Vector3 rightMovement;
    Vector3 upMovement;
    Vector3 heading;
    Vector3 Fermati;
    [SerializeField]
    Vector3 right;
    bool rolling;
    public bool puoiMuoverti = true;
    bool puoiRotolare = true;

    [SerializeField] PlayerStateManager playerStatemanager;


    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = StandardMoveSpeed;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    /// <summary>
    ///  emanuele
    public bool passaAttaccoDue = false;
    public bool siMuove;
    /// </summary>

    // Update is called once per frame
    void Update()
    {
        Debug.Log("si muov " + siMuove);
        Debug.Log("movespeed " + MoveSpeed);
        Attack();


    }

    private void FixedUpdate()
    {
        Ray cameraRay = CameraPrincipale.ScreenPointToRay(Input.mousePosition); //traccio un punto tramite Ray nella posizione del mouse
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayLenght;
        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght); //il punto da guardare è nel punto calcolato del Ray
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            cursore.transform.position = pointToLook; //il mouse avrà posizione del PuntoGuardato

            if (Input.GetMouseButton(1)) //Se premo mouse destro allora il personaggio guerderà in posizione del mouse
            {
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
                puoiMuoverti = false;
            }
            else
            {
                puoiMuoverti = true;
            }


        }
        if (Input.anyKey)
        {
            Move();
            siMuove = true;
        }
        else { siMuove = false; }

    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.M) && anim.GetBool("attacca") == false)
        {
            playerStatemanager.SwitchState(playerStatemanager.attackState);
        }
    }

    private void Move()
    {

        if (puoiMuoverti) //se posso muoverti allora il player cammina, prende i varii input ecc.
        {
            ////playerStatemanager.SwitchState(playerStatemanager.walkState);//////////

            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rightMovement = right * MoveSpeed * Time.fixedDeltaTime * Input.GetAxis("Horizontal");
            upMovement = forward * MoveSpeed * Time.fixedDeltaTime * Input.GetAxis("Vertical");
            MoveSpeed = StandardMoveSpeed;
            puoiRotolare = true;
        }
        else //se non posso muovermi il player non cammina. La velocità è a 0.
        {
            MoveSpeed = 0f;
            rightMovement = right * MoveSpeed * Time.fixedDeltaTime * Input.GetAxis("Horizontal");
            upMovement = forward * MoveSpeed * Time.fixedDeltaTime * Input.GetAxis("Vertical");
            puoiRotolare = false;
        }
        //direziono il giocatore
        heading = Vector3.Normalize(rightMovement + upMovement);
        Fermati = Vector3.Normalize(gameObject.transform.position + gameObject.transform.position);

        if (!Input.GetMouseButton(1))
        {
            transform.forward = Vector3.Lerp(transform.forward, heading * roatitionSpeed, 0.1f);
        }

        if (Input.GetKey(KeyCode.Space) && rolling == false)
        {
            anim.SetTrigger("rollAnim");
            StartCoroutine(Rolling());
            StartCoroutine(CanRoll());
        }

        transform.position += rightMovement;
        transform.position += upMovement;
    }

    IEnumerator CanRoll()
    {
        rolling = true;
        yield return new WaitForSeconds(timeRoll);
        rolling = false;
    }

    IEnumerator Rolling()
    {
        rb.AddForce(heading * rollForce, ForceMode.Impulse);
        yield return new WaitForSeconds(rollDistance);
        rb.AddForce(-Fermati * rollForce, ForceMode.Impulse);
    }
}
