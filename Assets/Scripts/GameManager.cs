using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	public BoxSpawner boxSpawner;

	public Sound gameOverSound;

	private int score;
	public TMP_Text textScore;
	public TMP_Text textScoreGameOver;
	public TMP_Text textTopScoreGameOver;

	public GameObject panelGamePlay;
	public GameObject panelGameOver;

	public bool isGameActive;

	public int Score
	{
		get { return score; }
	}


	private void Awake()
	{
		Instance = this;
		isGameActive = true;
		
		
	}

	public void SetScore()
	{
		if (isGameActive)
		{
			AddScore();
			UpdateScore();
			CheckGameState();
		}
		
	}

	private void CheckGameState()
	{
		
			StartCoroutine(SpawnBoxCoroutine());
		
	}

	public void GameOver()
	{
		if (isGameActive)
		{
			isGameActive = false;
			CheckHighScore();
			CameraManager.Instance.ResetCameraPosition();
			AudioManager.Instance.PlaySound(gameOverSound);
			StartCoroutine(ShowGameoverPanelCoroutine());
		}
		

		
	}

	private void CheckHighScore()
	{
		if (score > PlayerPrefs.GetInt("TopScore"))
		{
			PlayerPrefs.SetInt("TopScore", score);

		}

	}

	private void AddScore()
	{
		score++;
	}

	private void UpdateScore()
	{
		textScore.text = score.ToString();
	}

	private IEnumerator SpawnBoxCoroutine()
	{
		yield return new WaitForSeconds(0.7f);
		boxSpawner.SpawnBox();
	}

	private IEnumerator ShowGameoverPanelCoroutine()
	{
		yield return new WaitForSeconds(0.5f);
		textScoreGameOver.text = score.ToString();
		textTopScoreGameOver.text = PlayerPrefs.GetInt("TopScore").ToString();
		panelGamePlay.SetActive(false);
		panelGameOver.SetActive(true);
		
	}
}
