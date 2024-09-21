using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetect : MonoBehaviour
{
    public BossScript bossScript;
    public enum Range { Long = 1, Mid = 2, Short = 3 };
    public Range range;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            switch (range)
            {
                case (Range)1:bossScript.longRange = true; break;
                case (Range)2: bossScript.midRange = true; break;
                case (Range)3: bossScript.shortRange = true; break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            switch (range)
            {
                case (Range)1: bossScript.longRange = false; break;
                case (Range)2: bossScript.midRange = false; break;
                case (Range)3: bossScript.shortRange = false; break;
            }
        }
    }
}
