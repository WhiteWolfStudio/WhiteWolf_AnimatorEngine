using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Collections.Generic;

using NaughtyAttributes;

[CreateAssetMenu( menuName = "White Wolf/Animator/Settings" )]
public class WW_AnimatorSettings : ScriptableObject {

    [Label( "Fixed" )][ResizableTextArea] public string message;
    
    [Space]

    [HorizontalLine( color: EColor.Green )] [SerializeField] private IsKeyDown[] isKeyDown;
    // [Space]
    // [HorizontalLine( color: EColor.Red )] [SerializeField] private IsKey[] isKey;
    [Space]
    [HorizontalLine( color: EColor.Blue )] [SerializeField] private IsKeyUp[] isKeyUp;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public Dictionary<KeyCode, string[]> GetDown(){
        
        var toReturn = new Dictionary<KeyCode, string[]>();
        
        for ( var i = 0; i < isKeyDown.Length; i++ ){

            var values = new string[ isKeyDown[ i ].parameters.Length ];

            for ( var j = 0; j < values.Length; j++ )
                values[ j ] = isKeyDown[ i ].parameters[ j ].value;
            
            toReturn.TryAdd( isKeyDown[ i ].key, values );
            
        }
    
        return toReturn;
            
    }
    
    public Dictionary<KeyCode, string[]> GetUp(){
        
        var toReturn = new Dictionary<KeyCode, string[]>();
        
        for ( var i = 0; i < isKeyUp.Length; i++ ){

            var values = new string[ isKeyUp[ i ].parameters.Length ];

            for ( var j = 0; j < values.Length; j++ )
                values[ j ] = isKeyUp[ i ].parameters[ j ].value;
            
            toReturn.TryAdd( isKeyUp[ i ].key, values );
            
        }
    
        return toReturn;
            
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
    public Dictionary<KeyCode, bool[]> GetActiveDown(){
        
        var toReturn = new Dictionary<KeyCode, bool[]>();
        
        for ( var i = 0; i < isKeyDown.Length; i++ ){

            var values = new bool[ isKeyDown[ i ].parameters.Length ];

            for ( var j = 0; j < values.Length; j++ )
                values[ j ] = isKeyDown[ i ].parameters[ j ].active;
            
            toReturn.TryAdd( isKeyDown[ i ].key, values );
            
        }
    
        return toReturn;
            
    }

    public Dictionary<KeyCode, bool[]> GetActiveUp(){
        
        var toReturn = new Dictionary<KeyCode, bool[]>();
        
        for ( var i = 0; i < isKeyUp.Length; i++ ){

            var values = new bool[ isKeyUp[ i ].parameters.Length ];

            for ( var j = 0; j < values.Length; j++ )
                values[ j ] = isKeyUp[ i ].parameters[ j ].active;
            
            toReturn.TryAdd( isKeyUp[ i ].key, values );
            
        }
    
        return toReturn;
            
    }

}

/*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

[Serializable]
public class Parameters {
    
    [HorizontalLine]
    
    public string value;
    [Space]
    public bool active;
    
}

/*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

[Serializable]
public struct IsKeyDown {

    public string name;
    
    [Space]
    
    public KeyCode key;
    
    [Space]
    
    public Parameters[] parameters;

}

[Serializable]
public struct IsKeyUp {

    public string name;
    
    [Space]
    
    public KeyCode key;
    
    [Space]
    
    public Parameters[] parameters;
    
}