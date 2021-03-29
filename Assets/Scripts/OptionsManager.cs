using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour
{
	public Sound menuSound;
    public Sound buttonSound;

    void Start()
    {
       AudioManager.Instance.PlaySound(menuSound);
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

    public void ResetTopScore()
	{
		PlayerPrefs.SetInt("TopScore", 0);
        AudioManager.Instance.PlaySound(buttonSound);
    }
}
