using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hadles and sets everything for the game, the main crossroad to all actions that will take place
/// </summary>
public class GameMaster : MonoBehaviour
{
    [Header("---------- Managers -----------")]
    [SerializeField] Minigame minigame;
    [SerializeField] PlayerGrid playerGrid;
    [SerializeField] GeneratingAlgo generatingAlgo;
    [SerializeField] UnitManager unitManager;
    [SerializeField] FillingLogic fillingLogic;
    [SerializeField] PipesAudioManager pipesAudioManager;
    [Header("---------- Game Settings -----------")]
    public GameState gameState;
    [SerializeField] int numberOfBombs = 3;
    [SerializeField] int fieldSize = 6;
    public int FieldSize{
        get {return fieldSize;}
    }
    [SerializeField] int scaler = 5;
    public int Scaler{
        get {return scaler;}
    }
    [SerializeField] bool useSeed = false;

    private Dictionary<Vector2, string> board;
    private List<PathTile> path;
    private BaseUnit start;
    private BaseUnit end;
    private int seed;

    void Start()
    {
        ChangeState(GameState.Instantiate);
    }

    private void StartUp(){
        if(useSeed){
            seed = minigame.seed;
        }
        else{
            seed = Random.Range(0, int.MaxValue);
        }
    }

    private void FailedFunction(){
        pipesAudioManager.PlaySFX(pipesAudioManager.fail);
        minigame.isFinished = true;
    }

    private void SuccessedFunction(){
        pipesAudioManager.PlaySFX(pipesAudioManager.success);
        minigame.score = (int) ((minigame.endTime - Time.time)*20);
        minigame.isFinished = true;
    }

    /// <summary>
    /// Controls the code of the minigame, runs the code depending on the state given as method argument
    /// </summary>
    /// <param name="newState">New state of the game that will take the place and start the concrete code</param>
    public void ChangeState(GameState newState){
        gameState = newState;
        switch(newState){
            case GameState.Instantiate:
                StartUp();
                ChangeState(GameState.GenerateGrid);
                break;
            case GameState.GenerateGrid:
                playerGrid.GenerateGrid(fieldSize, scaler, seed);
                ChangeState(GameState.Algorithm);
                break;
            case GameState.Algorithm:
                (board, path) = generatingAlgo.GenerateMap(fieldSize, numberOfBombs, seed);
                ChangeState(GameState.SpawnTiles);
                break;
            case GameState.SpawnTiles:
                (start, end) = unitManager.spawnUnits(board, path, playerGrid, fieldSize, seed);
                ChangeState(GameState.Gameplay);
                break;
            case GameState.Gameplay:
                fillingLogic.startFilling(start, end);
                break;
            case GameState.FailEnd:
                FailedFunction();
                break;
            case GameState.GoodEnd:
                SuccessedFunction();
                break;
        }
        
    }

    public enum GameState{
        Instantiate = 0,
        GenerateGrid = 1,
        Algorithm = 2,
        SpawnTiles = 3,
        Gameplay = 4,
        FailEnd = 5,
        GoodEnd = 6
    }

}
