using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Preview {
    public Sprite sprite;
    public Tetromino tetromino;
}

[CreateAssetMenu(menuName = "Preview Piece")]
public class SO_DataPreview : ScriptableObject
{
    public List<Preview> previews;

    public Sprite GetPreview(Tetromino tetrimino){
        for(int i = 0; i < previews.Count; i++){
            if(previews[i].tetromino == tetrimino){
                return previews[i].sprite;
            }
        }

        return null;
    }
}
