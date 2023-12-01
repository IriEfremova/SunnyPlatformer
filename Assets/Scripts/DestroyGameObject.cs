using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public bool ByAnimationTime;
    public float TimeUntilDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        if (ByAnimationTime)
        {
            Animator animator = GetComponent<Animator>();
            if (animator)
            {
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
        else
        {
            Destroy(gameObject, TimeUntilDestroy);
        }
    }
}
