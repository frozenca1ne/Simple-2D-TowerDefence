using UnityEngine;


public class Tutorial : MonoBehaviour
{
    private static readonly int DisplayTutorial1 = Animator.StringToHash("displayTutorial");

    public void DisplayTutorial()
    {
        gameObject.GetComponent<Animator>().SetTrigger(DisplayTutorial1);
    }
}
