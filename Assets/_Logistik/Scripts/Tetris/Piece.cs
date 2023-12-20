using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board board { get; private set; }
    public TetrominoData data { get; private set; }
    public Vector3Int position { get; private set; }
    public Vector3Int[] cells { get; private set; }
    public int rotationIndex { get; private set; }
    private float stepDelay;
    public float lockDelay = 0.5f;

    private float stepTime;
    private float lockTime;

    private void Start()
    {
        stepDelay = QuestActiveController.ActiveQuest.Level switch
        {
            <= 2 => 1f,
            > 2 and <= 4 => 0.8f,
            > 4 and <= 6 => 0.6f,
            > 6 and <= 8 => 0.4f,
            > 8 and <= 10 => 0.2f,
            _ => 1f,
        };

        print(stepDelay);
    }

    public void Initialize(Board board, Vector3Int position, TetrominoData data)
    {
        this.board = board;
        this.position = position;
        this.data = data;
        this.rotationIndex = 0;
        this.stepTime = Time.time + this.stepDelay;
        this.lockTime = 0f;

        if (this.cells == null)
        {
            this.cells = new Vector3Int[data.cells.Length];
        }

        for (int i = 0; i < this.cells.Length; i++)
        {
            this.cells[i] = (Vector3Int)data.cells[i];
        }
    }

    private void Update()
    {
        if (!LevelManager.instance.isPlaying)
            return;

        this.board.Clear(this);
        this.lockTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Rotate(-1);
            Rotate(1);
        }
        // else if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     Rotate(1);
        // }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector2Int.right);
        }

        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     Move(Vector2Int.down);
        // }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HardDrop();
        }

        if (Time.time >= this.stepTime)
        {
            Step();
        }

        this.board.Set(this);
    }

    private void Step()
    {
        this.stepTime = Time.time + this.stepDelay;

        Move(Vector2Int.down);

        // if (this.lockTime >= this.lockDelay)
        // {
        //     Lock();
        // }
    }

    private void Lock()
    {
        this.board.Set(this);
        this.board.ClearLine();
        //Nanti Check ini
        this.board.SpawnPiece();
    }

    private bool Move(Vector2Int translation)
    {
        Vector3Int newPosition = this.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;

        bool valid = this.board.IsValidPosition(this, newPosition);

        if (valid)
        {
            this.position = newPosition;
            this.lockTime = 0f;
            if (!CheckBottom())
                Lock();


        }



        return valid;
    }

    private bool MoveHD(Vector2Int translation)
    {
        Vector3Int newPosition = this.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;

        bool valid = this.board.IsValidPosition(this, newPosition);

        if (valid)
        {
            this.position = newPosition;
            this.lockTime = 0f;
        }
        return valid;
    }

    private bool CheckBottom()
    {
        Vector3Int newPosition = this.position;
        newPosition.x += Vector2Int.down.x;
        newPosition.y += Vector2Int.down.y;


        return this.board.IsValidPosition(this, newPosition);
    }

    private void HardDrop()
    {
        while (MoveHD(Vector2Int.down))
        {
            continue;
        }
        Lock();
    }

    void Rotate(int dir)
    {
        int originRotation = this.rotationIndex;
        this.rotationIndex = Wrap(this.rotationIndex + dir, 0, 4);

        ApplyRotationMatrix(dir);
        if (!TestWallKick(this.rotationIndex, dir))
        {
            this.rotationIndex = originRotation;
            ApplyRotationMatrix(-dir);
        }
    }

    void ApplyRotationMatrix(int dir)
    {
        for (int i = 0; i < this.cells.Length; i++)
        {
            Vector3 cell = this.cells[i];
            int x, y;
            switch (this.data.tetromino)
            {
                case Tetromino.I:
                case Tetromino.O:
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;
                    x = Mathf.CeilToInt((cell.x * Data.RotationMatrix[0] * dir) + (cell.y * Data.RotationMatrix[1] * dir));
                    y = Mathf.CeilToInt((cell.x * Data.RotationMatrix[2] * dir) + (cell.y * Data.RotationMatrix[3] * dir));
                    break;
                default:
                    x = Mathf.RoundToInt((cell.x * Data.RotationMatrix[0] * dir) + (cell.y * Data.RotationMatrix[1] * dir));
                    y = Mathf.RoundToInt((cell.x * Data.RotationMatrix[2] * dir) + (cell.y * Data.RotationMatrix[3] * dir));
                    break;
            }
            this.cells[i] = new Vector3Int(x, y, 0);
        }
    }

    private bool TestWallKick(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = GetWallkickIndex(rotationIndex, rotationDirection);
        for (int i = 0; i < this.data.wallKicks.GetLength(1); i++)
        {
            Vector2Int translation = this.data.wallKicks[wallKickIndex, i];
            if (Move(translation))
            {
                return true;
            }
        }

        return false;
    }

    private int GetWallkickIndex(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = rotationIndex * 2;

        if (rotationDirection < 0)
        {
            wallKickIndex--;
        }

        return Wrap(wallKickIndex, 0, this.data.wallKicks.GetLength(0));
    }

    private int Wrap(int input, int min, int max)
    {
        if (input < min)
        {
            return max - (min - input) % (max - min);
        }
        else
        {
            return min + (input - min) % (max - min);
        }
    }
}
