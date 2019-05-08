using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject canvas;
    public float segundos;
	void Start () {

        StartCoroutine(begin());
	}
	
	public IEnumerator begin()
    {
        yield return new WaitForSeconds(segundos);
        canvas.SetActive(true);
    }
	
    public void play()
    {
        SceneManager.LoadScene("LevelGameplay");
    }

    public void shop()
    {
        SceneManager.LoadScene("Loja");
    }
}
