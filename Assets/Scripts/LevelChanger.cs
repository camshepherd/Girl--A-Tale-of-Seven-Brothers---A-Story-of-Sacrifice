using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour{

    public Animator animator;

    public string leveltoload;

    public void Start()
    {
        GameStores.changeScene();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D person)
    {
        if (person.CompareTag("Player")){
            FadeToLevel();
        } 
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(leveltoload);
    }
}
