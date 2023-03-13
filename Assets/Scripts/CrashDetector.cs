using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float sceneReloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSoundEffect;

    private PlayerController playerController;
    private bool hasCrashed = false;

    private void Start()
    {
        this.playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !this.hasCrashed)
        {
            crashEffect.Play();

            this.playerController.DisableControls();
            this.hasCrashed = true;

            this.GetComponent<AudioSource>().PlayOneShot(this.crashSoundEffect);
            Invoke(nameof(ReloadScene), this.sceneReloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
        if (this.playerController != null)
        {
            this.playerController.EnableControls();
        }
    }
}
