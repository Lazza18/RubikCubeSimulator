using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{
    public static List<string> movementList = new List<string>() { };
    private readonly List<string> allMoves = new List<string>()
    {
        "U", "D", "F", "B", "R", "L",
        "U2", "D2", "F2", "B2", "R2", "L2",
        "U'", "D'", "F'", "B'", "R'", "L'"
    };  

    private CubeState cubeState;
    private ReadCube readCube;

    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        readCube = FindObjectOfType<ReadCube>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementList.Count > 0 && !CubeState.autoRotating && CubeState.started)
        {
            DoMove(movementList[0]);

            movementList.Remove(movementList[0]);
        }
    }

    // Genere una stringa casuale di mosse da min 10 a max 30 
    public void Shuffle()
    {
        List<string> moves = new List<string>();
        int shuffleLenght = Random.Range(10, 30);

        for (int i = 0; i < shuffleLenght; i++)
        {
            int randomMove = Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMove]);
        }

        movementList = moves;
    }

    // Possibili mosse per la rotazione degli strati del cubo:
    //   U = Up      90°
    //   D = Down    90°
    //   F = Front   90°
    //   B = Back    90°
    //   R = Right   90°
    //   L = Left    90°
    //   U' = Up    -90°
    //   U2 = 2Up   180°

    void DoMove(string move)
    {
        readCube.ReadState();
        CubeState.autoRotating = true;
        
        // Up
        if(move == "U")
        {
            RotateSide(cubeState.up, -90);
        }
        if (move == "U'")
        {
            RotateSide(cubeState.up, 90);
        }
        if (move == "U2")
        {
            RotateSide(cubeState.up, -180);
        }

        // Down
        if (move == "D")
        {
            RotateSide(cubeState.down, -90);
        }
        if (move == "D'")
        {
            RotateSide(cubeState.down, 90);
        }
        if (move == "D2")
        {
            RotateSide(cubeState.down, -180);
        }

        // Front
        if (move == "F")
        {
            RotateSide(cubeState.front, -90);
        }
        if (move == "F'")
        {
            RotateSide(cubeState.front, 90);
        }
        if (move == "F2")
        {
            RotateSide(cubeState.front, -180);
        }

        // Back
        if (move == "B")
        {
            RotateSide(cubeState.back, -90);
        }
        if (move == "B'")
        {
            RotateSide(cubeState.back, 90);
        }
        if (move == "B2")
        {
            RotateSide(cubeState.back, -180);
        }

        // Right
        if (move == "R")
        {
            RotateSide(cubeState.right, -90);
        }
        if (move == "R'")
        {
            RotateSide(cubeState.right, 90);
        }
        if (move == "R2")
        {
            RotateSide(cubeState.right, -180);
        }

        // Left
        if (move == "L")
        {
            RotateSide(cubeState.left, -90);
        }
        if (move == "L'")
        {
            RotateSide(cubeState.left, 90);
        }
        if (move == "L2")
        {
            RotateSide(cubeState.left, -180);
        }
    }

    void RotateSide(List<GameObject> side, float angle)
    {
        PivotRotation pr = side[4].transform.parent.GetComponent<PivotRotation>();

        pr.StartAutoRotate(side, angle);
    }
}
