using UnityEngine;
using System.Collections;

public class lightUp : MonoBehaviour {
	public Material lightUpMaterial;
	public GameObject gameLogic;
	private Material defaultMaterial;
    public bool correctanswer;

    public AudioClip extraaudio;
    


    private AudioClip sourceClip = null;
    private AudioClip defaultClip = null;
    private AudioSource audioSource = null;

    // Use this for initialization
    void Start () {
		defaultMaterial = this.GetComponent<MeshRenderer> ().material; //Save our initial material as the default
        //this.GetComponentInChildren<ParticleSystem>().enableEmission = false; //Start without emitting particles
        if (audioSource == null)
        {
            // Ensure the audio source gets created once.
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        defaultClip = this.GetComponent<AudioSource>().clip;
        gameLogic = GameObject.Find ("GameLogic");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void patternLightUp(float duration) { //The lightup behavior when displaying the pattern
		StartCoroutine(lightFor(duration));
	}


	public void gazeLightUp() {
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
        //this.GetComponentInChildren<ParticleSystem>().enableEmission = true; //Turn on particle emmission

        this.GetComponent<AudioSource>().clip = defaultClip;
        this.GetComponent<AudioSource>().Play();

		//gameLogic.GetComponent<gameLogic>().playerSelection(this.gameObject);


	}
	public void playerSelection() {
        //GameLogic.GetComponent<gameLogic>().playerSelection(this.gameObject);
        this.GetComponent<AudioSource>().clip = extraaudio;
        this.GetComponent<AudioSource>().Play();
        if (correctanswer)
        {
            gameLogic.GetComponent<GameLogic>().puzzleSuccess();
            
        }
        

    }
	public void aestheticReset() {
		this.GetComponent<MeshRenderer>().material = defaultMaterial; //Revert to the default material
		//this.GetComponentInChildren<ParticleSystem>().enableEmission = false; //Turn off particle emission
	}

	public void patternLightUp() { //Lightup behavior when the pattern shows.
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		//this.GetComponentInChildren<ParticleSystem>().enableEmission = true; //Turn on particle emmission
		this.GetComponent<AudioSource> ().Play (); //Play the audio attached
	}


	IEnumerator lightFor(float duration) { //Light us up for a duration.  Used during the pattern display
		patternLightUp ();
		yield return new WaitForSeconds(duration-.1f);
		aestheticReset ();
	}
}
