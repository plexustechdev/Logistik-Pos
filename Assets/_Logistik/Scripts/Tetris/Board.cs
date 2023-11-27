using System.Linq;
using Codice.Client.BaseCommands.BranchExplorer;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public TetrominoData[] tetrominoes;
    public Piece activePiece { get; private set; }
    public Tilemap tilemap { get; private set; }
    public Vector3Int spawnPos;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2);
            return new RectInt(position, this.boardSize);
        }
    }

    public TetrominoData nextPiece;

    private void Awake()
    {

        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();
        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        this.nextPiece = this.tetrominoes[0];
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        this.activePiece.Initialize(this, this.spawnPos, nextPiece);
        if (IsValidPosition(this.activePiece, this.spawnPos))
        {
            Set(this.activePiece);
            GenerateNextPiece();
        }
        else
        {
            GameOver();
        }
    }

    private void GenerateNextPiece()
    {
        int random = Random.Range(0, this.tetrominoes.Length);
        TetrominoData data = this.tetrominoes[(int)random];

        nextPiece = data;
        LevelManager.instance.SetNextPiecePreview(nextPiece.tetromino);
        Debug.Log(nextPiece.tetromino);
    }

    private void GameOver()
    {
        this.tilemap.ClearAllTiles();
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePos = piece.cells[i] + piece.position;
            for(int pattern = 0; pattern < piece.data.tile.Length; pattern++){
                this.tilemap.SetTile(tilePos, piece.data.tile[pattern]);
            }
            
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePos = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePos, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = this.Bounds;
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

    public void ClearLine()
    {
        RectInt bounds = this.Bounds;
        int row = bounds.yMin;

        while (row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                LineClear(row);
                LevelManager.instance.SetScore(10);
                Debug.Log("Hancur");
            }
            else
            {
                row++;
            }
        }
    }

    private bool IsLineFull(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            if (!this.tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;
    }

    private void LineClear(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            this.tilemap.SetTile(position, null);
        }

        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = this.tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, above);

            }
            row++;
        }
    }

}
