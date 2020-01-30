using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour{
	
	public float offMin = 5.0f;
	public float offMax = 30.0f;
	public float onMin = 0.05f;
	public float onMax = 0.1f;
	public GameObject lightning;
	public AudioClip[] Thunder;
	
	void OnEnable()
	{
		StartCoroutine(lighter());
	}

	IEnumerator lighter(){
		while (true)
		{
		yield return new WaitForSeconds(Random.Range(offMin, offMax));
		lightning.SetActive(true);
		yield return new WaitForSeconds(Random.Range(0.25f, 2.0f));
		GetComponent<AudioSource>().PlayOneShot(Thunder[Random.Range(0, Thunder.Length)]);
		yield return new WaitForSeconds(Random.Range(onMin, onMax));
		lightning.SetActive(false);
		}
	}
}