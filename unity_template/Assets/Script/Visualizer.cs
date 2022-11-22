using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    public DataReceiver _receiver;
    public Text action;
    public Text position;
    public Text gamemode;
    public Text Raw;

    // # code for unity request
    // positions = {
    //     "left": -1,
    //     "center": 0,
    //     "right": 1
    // }
    // actions = {
    //     "standing": 0,
    //     "slide": 1,
    //     "jump": 2
    // }
    // gamemodes = {
    //     "mainmenu": 0,
    //     "ingame": 1,
    //     "gameover": 2,
    //     "pause": 3
    // }
    // we set this variable for transfer code from web socker to Unity game control or whatever you want
    Dictionary<string, string> ActionsDict = new Dictionary<string, string>(){
        {"0","Standing"}, {"1","Slide"}, {"2","Jump"}
    };
    Dictionary<string, string> PositionsDict = new Dictionary<string, string>(){
        {"-1","Left"}, {"0","center"}, {"1","Right"}
    };
    Dictionary<string, string> GamemodesDict = new Dictionary<string, string>(){
        {"0","mainmenu"}, {"1","ingame"}, {"2","game over"}, {"3","pause"}
    };


    // Start is called before the first frame update
    void Start()
    {
        // well in the context the in put is already the text not gameobject so these line is no need
        // action = GetComponent<Text>();
        // position = GetComponent<Text>();
        // gamemode = GetComponent<Text>();
        // Raw = GetComponent<Text>();     
    }
    // Update is called once per frame
    void Update()
    {
        try{
            // try read data from web sockets
            string data = _receiver.data;
            // check raw data
            Raw.text = data;
            // unpack the command
            string[] controls = data.Split(",");
            // decrypt using dictionary
            action.text = ActionsDict[controls[0]];
            position.text = PositionsDict[controls[1]];
            gamemode.text = GamemodesDict[controls[2]];
        }catch(Exception err)
        {
            // print(err.ToString());
        }
    
    }
}
