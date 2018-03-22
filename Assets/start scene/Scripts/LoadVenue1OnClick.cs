using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadVenue1OnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}
}

