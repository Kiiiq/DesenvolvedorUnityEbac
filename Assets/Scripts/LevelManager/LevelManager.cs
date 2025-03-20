using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform levelContainer;

    [SerializeField] List<LevelPiece> levels = new List<LevelPiece>();
    [SerializeField] LevelPiece finishingLinePrefab;
    [SerializeField] LevelPiece startingPoint;

    [SerializeField] Color[] colors = new Color[10];
    [SerializeField] Material[] materials = new Material[4]; 
    LevelPiece lastSpawnedPiece;

    public int piecesPerlevel;

    // Start is called before the first frame update
    void Start()
    {
        piecesPerlevel = 6;
        createRandomLevel();
        colorLevel();
    }

    private void createRandomLevel()
    {
        
        Instantiate(levelContainer);
        Instantiate(startingPoint, levelContainer);
        lastSpawnedPiece = startingPoint;
        for (int i = 0; i < piecesPerlevel; i++) {
            createLevelPiece();
        }
        var lastpiece = Instantiate(finishingLinePrefab, levelContainer);
        lastpiece.transform.position = lastSpawnedPiece.pieceEnd.position;


    }

    private void createLevelPiece() {

        var piece = levels[Random.Range(0, levels.Count - 1)];
        var spawedPiece = Instantiate(piece,levelContainer);
        spawedPiece.transform.position = lastSpawnedPiece.pieceEnd.position;
        lastSpawnedPiece= spawedPiece;
    }

    private void colorLevel()
    {
        int[] takenColors = new int[materials.Length];
        for(int i = 0;i< materials.Length;i++)
        {
            var material = materials[i];
            takenColors[i] = randomColor(takenColors);
            
            material.SetColor("_Color",  colors[takenColors[i]]);
        }
    }

    private int randomColor(int[] takenColors)
    {
        int color = Random.Range(0, colors.Length-1);
        if (takenColors.Contains(color))
        {
            return randomColor(takenColors);
        }
        else
        {
            return color;
        }
    }
}
