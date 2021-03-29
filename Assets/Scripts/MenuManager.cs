using UnityEngine;
using TMPro;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public TMP_Text topScoreText;
    public Sound menuSound;
    public Sound buttonSound;
    
    void Start()
    {
        topScoreText.text = PlayerPrefs.GetInt("TopScore").ToString();
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
}
