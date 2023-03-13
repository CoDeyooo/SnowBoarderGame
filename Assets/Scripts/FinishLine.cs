using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float sceneReloadDelay = 0.5f;
    [SerializeField] ParticleSystem finishEffect;

    private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();

            this.playerController = FindObjectOfType<PlayerController>();
            this.playerController.DisableControls();

            this.GetComponent<AudioSource>().Play();
            Invoke(nameof(this.ReloadScene), this.sceneReloadDelay);
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
