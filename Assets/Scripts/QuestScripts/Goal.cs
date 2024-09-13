using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Goal 
{
    [TextArea(2,4)]
    public string description; 
    public bool isComplete;
    public Text texto;
    public Transform goalActT;
    public GoalSM goalAct;
    public Transform[] objects;
    private GameManager gm;

    public void Init() {
        goalAct = goalActT.GetComponent<GoalSM>();

        goalAct.PrepareGoal(objects);
    }

    public void Gupdate() {
        
        if( goalAct.GoalUpdate(objects) ){
            
            goalAct.QuitGoal(objects);
            isComplete = true;
        }
    }
}