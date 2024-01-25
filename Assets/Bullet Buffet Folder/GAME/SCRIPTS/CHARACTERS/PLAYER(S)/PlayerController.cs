using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }



    #region Movement
    [Header("Movement stats")]
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    //private float jumpHeight = 1.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 movementInput = Vector2.zero;


    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        BulletShoot();

        cont -= Time.deltaTime;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    #endregion

    #region Skills

    #endregion

    #region Handgun

    [Header("Handgun stats")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float cooldown;

    [SerializeField] private Transform bulletprefab;
    [SerializeField] private Transform bulletSpawn;

    [SerializeField] private bool isShooting = false;

    private float cont = 0;

    public void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = context.ReadValue<bool>();
        isShooting = context.action.triggered;
        //BulletShoot();
    }

    void BulletShoot()
    {
        if (Input.GetMouseButtonDown(0) && cont <= 0)
        {
            isShooting = true;
            Transform clon = Instantiate(bulletprefab, bulletSpawn.position, bulletSpawn.rotation);
            clon.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            Destroy(clon.gameObject, 3);
            cont = cooldown;
        }
    }

    #endregion
}
