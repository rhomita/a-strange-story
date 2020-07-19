using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void GoToScene(string scene)
    {
        Time.timeScale = 1;
        StartCoroutine(GoScene(scene));
    }

    IEnumerator GoScene(string scene)
    {
        animator.SetTrigger("ChangeScene");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public static void GoToSceneName(string text)
    {
        SceneManager.LoadScene(text, LoadSceneMode.Single);
    }
}