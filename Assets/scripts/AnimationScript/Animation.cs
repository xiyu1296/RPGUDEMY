using UnityEngine;

public class Animation :MonoBehaviour
{
    private player Player => GetComponentInParent<player>();

    public void AnimationTrigger()
    {
        Player.AnimationTrigger();
    }
    
    

}
