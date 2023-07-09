using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform noms;
    public GameObject pacman;
    public GameObject ghost;

    private EnemyController eControl;
    public int score { get; private set; } // public get, private set
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
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
    }

    public void GhostEaten()
    {
        this.ghost.SetActive(false);
    }
    public void PacmanEaten()
    {

    }
    private void SetScore(int score)
    {
        this.score = score;
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
    public void PowerNomEat(NomsController nom)
    {
        NomEat(nom);
        eControl.playerAttackable = true;
        Invoke(nameof(ResetPlayerAttack), 8f);
    }

    private bool RemainingNoms()
    {
        foreach(Transform nom in this.noms){
            if (nom.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
