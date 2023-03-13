using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrailEffect;
    [SerializeField] AudioClip snowGlideSFX;

    private PlayerController playerController;

    private void Start()
    {
        this.playerController = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (this.playerController.CanMove())
            {
                this.snowTrailEffect.Play();
                this.GetComponent<AudioSource>().PlayOneShot(this.snowGlideSFX);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            this.snowTrailEffect.Stop();
            if (this.playerController.CanMove())
            {
                this.GetComponent<AudioSource>().Stop();
            }
        }
    }
}
