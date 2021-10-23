using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //RobertoNiciforo
    [Header("Valori")]
    public float MoveSpeed = 4f;
    [SerializeField]
    public float roatitionSpeed = 0f;
    [Header("Camera")]
    [SerializeField]
    private Camera CameraPrincipale;
    [Header("Cursor")]
    [SerializeField]
    private GameObject cursore;
    [Header("Altro")]
    [SerializeField]
    Vector3 forward, right;
    public GameObject testo;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Ray cameraRay = CameraPrincipale.ScreenPointToRay(Input.mousePosition); //traccio un punto tramite Ray nella posizione del mouse
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;
        if(groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght); //il punto da guardare è nel punto calcolato del Ray
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            cursore.transform.position = pointToLook; //il mouse avrà posizione del PuntoGuardato

            if (Input.GetMouseButton(1)) //Se premo mouse destro allora il personaggio guerderà in posizione del mouse
            {
                testo.SetActive(true);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
            else
            {
                testo.SetActive(false);
            }

        }
        if(Input.anyKey)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * MoveSpeed * Time.fixedDeltaTime * Input.GetAxis("Horizontal"); 
        Vector3 upMovement = forward * MoveSpeed * Time.fixedDeltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        if(!Input.GetMouseButton(1))
        {
            transform.forward = Vector3.Lerp(transform.forward, heading * roatitionSpeed, 0.1f);
        }
       

        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
