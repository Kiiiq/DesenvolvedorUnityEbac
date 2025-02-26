using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public List<AnimatorSetup> animations = new List<AnimatorSetup>();
    public Animator animator;
    public enum animationClip
    {
        run,
        idle,
        death
    }

    public void play(animationClip clip)
    {
        foreach (var animation in animations)
        {
            if(animation.clip == clip)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }


}
[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.animationClip clip;
    public string trigger;
}