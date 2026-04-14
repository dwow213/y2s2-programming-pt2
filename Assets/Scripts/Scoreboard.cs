using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public EggCollection playerScore;
    public EggCollection opponentScore;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = $"Player Score: {playerScore.score.ToString()}";
        opponentScoreText.text = $"Opponent Score: {opponentScore.score.ToString()}";
    }
}
