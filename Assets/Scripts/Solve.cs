using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;

public class Solve : MonoBehaviour
{
    public ReadCube readCube;
    public CubeState cubeState;
    private bool doOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CubeState.started && doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    public void Solver()
    {
        string moveString;
        string info = "";
        string solution;
        List<string> solutionList;

        // Prendo lo stato del cubo come una stringa
        readCube.ReadState();
        moveString = cubeState.GetStateString();
        print(moveString);

        // risoluzione del cubo

        // Riga 39 usare la prima volta che si utilizza l'applicazione per generare
        // le tabelle risolutive del cubo
        //solution = SearchRunTime.solution(moveString, out info, buildTables: true);

        // In tutti gli altri casi usare riga 42
        solution = Search.solution(moveString, out info);
        solutionList = StringToList(solution);

        // Automatizzare lista
        Automate.movementList = solutionList;

        print(info);
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));

        return solutionList;
    } 
}
