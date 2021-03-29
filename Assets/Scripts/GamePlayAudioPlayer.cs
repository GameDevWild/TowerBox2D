using UnityEngine;
using System.Collections;

public class GamePlayAudioPlayer : MonoBehaviour
{
    public Sound[] gamePlayMusicSounds;
	public Sound buttonSound;

	private void Start()
	{
		AudioManager.Instance.PlaySound(gamePlayMusicSounds[Random.Range(0, gamePlayMusicSounds.Length)]);
	}

    public void ChangeSceneAfterButtonPress(string sceneToLoad)
    {
        AudioManager.Instance.PlaySound(buttonSound);
        StartCoroutine(ChangeSceneAfterButtonPressCoroutine(sceneToLoad));
    }


    private IEnumerator ChangeSceneAfterButtonPressCoroutine(string sceneToLoad)
    {
        yield return new WaitForSeconds(buttonSound.clip.length);
        GameSceneManager.Instance.ChangeScene(sceneToLoad);
    }
}
