using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform noms;
    public GameObject pacman;
    public GameObject ghost;
    public GameObject youWon, youDied, panel;
    public EnemyController eControl;
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {

        NewRound();
    }

    private void NewRound()
    {
        foreach (Transform nom in this.noms)
        {
            noms.gameObject.SetActive(true);
        }
        ResetState();
    }
    private void ResetState()
    {
        this.pacman.gameObject.SetActive(true);
        this.ghost.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        this.pacman.gameObject.SetActive(false);
        this.ghost.gameObject.SetActive(false);
        panel.SetActive(true);
        youDied.SetActive(true);
    }
    private void GameWin()
    {
        Debug.Log("WIN");
        this.pacman.gameObject.SetActive(false);
        this.ghost.gameObject.SetActive(false);
        panel.SetActive(true);
        youWon.SetActive(true);
    }

    public void GhostEaten()
    {
        this.ghost.SetActive(false);
        GameOver();
    }
    public void PacmanEaten()
    {
        this.pacman.SetActive(false);
        GameWin();
    }


    public void NomEat(NomsController nom)
    {
        nom.gameObject.SetActive(false);
        if (!RemainingNoms())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(GameOver), 3.0f);
        }
    }
    public void ResetPlayerAttack()
    {
        eControl.playerAttackable = false;
    }
    public void PowerNomEat(PowerNomsController nom)
    {
        eControl.playerAttackable = true;
        
        NomEat(nom);
        Debug.Log("NOMNOM");
   
        Invoke(nameof(ResetPlayerAttack), 8f);
    }

    private bool RemainingNoms()
    {
        foreach (Transform nom in this.noms)
        {
            if (nom.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
