using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; 
    public static int PlayerScore2 = 0; 
    public GUISkin layout;              
    GameObject theBall;                 
    void Start () {
        theBall = GameObject.FindGameObjectWithTag("Ball"); 
    }
    public static void Score (string wallID) {
        if (wallID == "GoalTop")
        {
            PlayerScore1++;
        } else if(wallID == "GoalBottom")
        {
            PlayerScore2++;
        }
    }
    void OnGUI () {
        GUI.skin = layout;
        GUI.skin.label.normal.textColor = Color.red;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
