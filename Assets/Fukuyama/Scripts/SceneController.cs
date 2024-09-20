using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject fadeObject;
    public string sceneName;

    public AudioClip sound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //// Aƒ{ƒ^ƒ“‚Å‘JˆÚ
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    audioSource.PlayOneShot(sound);
        //    fadeObject.GetComponent<FadeController>().PlayFadeOut();
        //}

        if (fadeObject.GetComponent<FadeController>().IsPlayFadeOut())
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
