using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToHideOnFinish;
    [SerializeField] Timer _timer;
    [SerializeField] TextMeshProUGUI _label;

    public void Activate()
    {
        gameObject.SetActive(true);
        _label.text = "Your time\n" + _timer.getTime();

        foreach(GameObject obj in objectsToHideOnFinish)
        {
            obj.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
