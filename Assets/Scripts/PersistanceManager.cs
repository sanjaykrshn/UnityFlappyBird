using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public int score;
    public GameManager gameManager;


    public void SaveScore(int score){
        // Save the data in the player prefs 
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    public int LoadScore(){
        // Default score is going to be zero
        return PlayerPrefs.GetInt("score", 0);
    }
        
    


}
