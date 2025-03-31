using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    public RuntimeAnimatorController maleController;
    public RuntimeAnimatorController femaleController;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (MainMenu.SelectedCharacter == "Male")
        {
            animator.runtimeAnimatorController = maleController;
        }
        else if (MainMenu.SelectedCharacter == "Female")
        {
            animator.runtimeAnimatorController = femaleController;
        }
    }
}
