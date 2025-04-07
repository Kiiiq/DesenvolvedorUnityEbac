using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour
{ 

    [UnityEditor.MenuItem("Carro/Spawnar Carro %g")]
    public static void spawnCarro()
    {
        GameObject gameObject = Instantiate(Resources.Load<GameObject>("Prefab/Cube"));
    }
}
