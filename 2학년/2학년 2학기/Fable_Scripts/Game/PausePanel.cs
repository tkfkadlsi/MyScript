using TMPro;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI resumeText;
    [SerializeField] private TextMeshProUGUI restartText;
    [SerializeField] private TextMeshProUGUI exitText;

    private void OnEnable()
    {
        if(Information.Instance.IsKorean)
        {
            pauseText.text = "일시정지";
            descriptionText.text = "모험을 잠시 멈췄어요.\n다시 모험으로 돌아갈까요?";
            resumeText.text = "돌아가기";
            restartText.text = "다시하기";
            exitText.text = "메인 화면";
        }
        else
        {
            pauseText.text = "Pause";
            descriptionText.text = "You've paused your adventure for a moment.\nShall we return to the adventure?";
            resumeText.text = "Resume";
            restartText.text = "Restart";
            exitText.text = "Exit Game";
        }
    }
}