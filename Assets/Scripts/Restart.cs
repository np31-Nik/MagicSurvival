using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
	void TaskOnClick()
	{
		restartLevel();
	}

    private void Awake()
    {
        //PlayerDamageHandler player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamageHandler>();
        //player.setGameOver(gameObject);
        //gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void restartLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
