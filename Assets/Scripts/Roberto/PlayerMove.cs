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
    public float attForce = 0f;
    public float StandardMoveSpeed;
    public float rollDistance = 0.3f;
    public float timeRoll;
    public float attDistance;
    public float frenataRoll;
    public float frenataAtt;
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
    Ray cameraRay;
    Plane groundPlane;
    float rayLenght;
    [SerializeField] PlayerStateManager playerStatemanager;

    [SerializeField] SchivataUI schivataUI;

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
        //Attack();


    }


    private void FixedUpdate()
    {
        cameraRay = CameraPrincipale.ScreenPointToRay(Input.mousePosition); //traccio un punto tramite Ray nella posizione del mouse
        groundPlane = new Plane(Vector3.up, transform.position);

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
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Move();
            siMuove = true;
        }
        else { siMuove = false; }

    }

    public void Attack()
    {
        //if (groundPlane.Raycast(cameraRay, out rayLenght))
        //{
            //Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            if (Input.GetMouseButton(0) && anim.GetBool("attacca") == false)
            {
                //transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
                StartCoroutine(AttDash());
                playerStatemanager.SwitchState(playerStatemanager.attackState);
            }
        //}
           
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

        if (!Input.GetMouseButton(1)) //se non premo il mouseDX il giocatore guarda nella direzione in cui si muove
        {
            transform.forward = Vector3.Lerp(transform.forward, heading * roatitionSpeed, 0.1f);
        }

        if (Input.GetKey(KeyCode.Space) && rolling == false && puoiRotolare) //se premo SPACE rotolo (chiamo la coroutine della rotolata e il blocco della rotolata)
        {
            anim.SetTrigger("rollAnim");
            StartCoroutine(Rolling());
            StartCoroutine(CanRoll());
        }

        transform.position += rightMovement;
        transform.position += upMovement;
    }

    IEnumerator CanRoll() //dopo una schivata/rotolata, blocco la rotolata e poi la sblocco..per non farla spammare
    {
        rolling = true;
        yield return new WaitForSeconds(timeRoll);
        rolling = false;
    }

    IEnumerator Rolling() //il giocatore schiva/rolla... vieni applicata una forza in avanti e poi una forza minore nella parte opposta
    {
        schivataUI.StartCoroutine(schivataUI.SchivataCo());
        GameManager.instance.audioManager.PlaySound("schivata");
        rb.AddForce(transform.forward * rollForce, ForceMode.Impulse);
        yield return new WaitForSeconds(rollDistance);
        rb.AddForce(-transform.forward * frenataRoll, ForceMode.Impulse);
    }

    IEnumerator AttDash() //quando il giocatore attacca fà uno scattino in avanti: vieni applicata una forza in avanti e poi una forza minore nella parte opposta
    {
        rb.AddForce(transform.forward * attForce, ForceMode.Impulse);
        yield return new WaitForSeconds(attDistance);
        rb.AddForce(-transform.forward * frenataAtt, ForceMode.Impulse);
    }
}
