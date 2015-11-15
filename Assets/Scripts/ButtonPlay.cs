using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class ButtonPlay : MonoBehaviour
{
    // Use this for initialization
    public string NameScene, ButtonName;
    public AudioClip Sound;
    AudioSource audio;
    
    void Start()
    {
        ButtonName = gameObject.name;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == ButtonName)
                {
                    StartCoroutine(Wait());
                };
            };
        };
    }
    
    IEnumerator Wait()
    {
        // suspend execution for 5 seconds
        audio.PlayOneShot(Sound, 0.7F);
        yield return new WaitForSeconds(.5f);
        Application.LoadLevel(NameScene);
    }
}