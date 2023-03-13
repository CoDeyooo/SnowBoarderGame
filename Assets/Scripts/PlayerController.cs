using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float boostSpeed = 40f;
    SurfaceEffector2D surfaceEffector2d;
    new Rigidbody2D rigidbody2D;
    private bool canMove = true;

    public void EnableControls()
    {
        this.canMove = true;
    }

    public void DisableControls()
    {
        this.canMove = false;
    }

    public bool CanMove()
    {
        return this.canMove;
    }

    private void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (this.canMove)
        {
            this.RotatePlayer();
            this.BoostPlayer();
        }
    }

    private void RotatePlayer()
    {
        var torqueToAdd = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            torqueToAdd = this.torqueAmount;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            torqueToAdd = -this.torqueAmount;
        }

        this.rigidbody2D.AddTorque(torqueToAdd);
    }

    private void BoostPlayer()
    {
        var speedToAdd = 20f; 
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedToAdd = this.boostSpeed;
        }

        this.surfaceEffector2d.speed = speedToAdd;
    }
}
