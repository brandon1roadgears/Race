using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text TxtMultiplier = null;
    private Text TxtScore = null;
    private Animator MultiplierAnimator = null;
    private int CurrentMultiplier = 0;
    private float WhenKilled = 0.0f;

    private void Awake()
    {
        MultiplierAnimator = GameObject.Find("Text(Multiplier)").GetComponent<Animator>();
        TxtScore = GameObject.Find("Text(Points)").GetComponent<Text>();
        TxtMultiplier = GameObject.Find("Text(Multiplier)").GetComponent<Text>();
    }
    private void Update()
    {
        if(Time.timeSinceLevelLoad - WhenKilled > 2f)
        {
            CurrentMultiplier = 0;
            TxtMultiplier.enabled = false;
        }
    }

    internal void SetScore(int Reward, int Mult)
    {
        int Score = int.Parse(TxtScore.text);
        Score += Reward * Mult;
        TxtScore.text = Score.ToString();
    }

    internal void AddMultiplier(int Reward)
    {
        WhenKilled = Time.timeSinceLevelLoad;
        if(CurrentMultiplier <= 9)
        {
            ++CurrentMultiplier;
        }
        if(CurrentMultiplier > 1)
        {
            TxtMultiplier.enabled = true;
            MultiplierAnimator.SetBool("isStartMuiltiplierAnimation", true);
            TxtMultiplier.text = CurrentMultiplier.ToString() + "x";
            SetScore(Reward, CurrentMultiplier);
        }else
        {
            SetScore(Reward, 1);
        }
    }
}
