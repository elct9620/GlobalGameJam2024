
using Command;
using Entity;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton:MonoBehaviour
{
    [Inject] private readonly UnlockCommand _unlockCommand;

    public Animator Animator;
    public AudioSource audioSource;
    public GameObject turnOn;
    public GameObject turnOff;
    public void Start()
    {
        var button = turnOn.GetComponent<Button>();
        button.onClick.AddListener(Switch);
        
        var button2 = turnOff.GetComponent<Button>();
        button2.onClick.AddListener(Switch);
        
        audioSource.Play();
    }

    private void Switch()
    {
         
        _unlockCommand.Unlock(LockType.MusicPlaying, Time.time);
        if (!turnOff.activeSelf)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }

        Animator.enabled = !turnOff.activeSelf;
        turnOff.SetActive(!turnOff.activeSelf);
        turnOn.SetActive(!turnOn.activeSelf);
    }

}
