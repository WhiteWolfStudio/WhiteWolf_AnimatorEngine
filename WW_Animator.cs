using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace WhiteWolf.Animator {
    
    public class WW_Animator : MonoBehaviour {
        
        [SerializeField] WW_AnimatorSettings animatorSettings;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
        
        [SerializeField] private UnityEngine.Animator _animator;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
        private void Start(){
            
            // _animator = this.gameObject.GetComponent<UnityEngine.Animator>();
        
        }

        private void Update(){
            
            foreach( KeyCode vKey in System.Enum.GetValues( typeof( KeyCode ) ) ){

                KeyDown( vKey );
                KeyUp( vKey );

            }
        
        }
        
        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        private void KeyDown( KeyCode key ){
        
            // Main
            if ( !Input.GetKeyDown( key ) ) return;
            
            // Check KeyCode in Dictionary
            if ( !animatorSettings.GetDown().ContainsKey( key ) ) return;
                
            // Get cache and animator parameter name
            var parameters = animatorSettings.GetDown()[ key ];

            // Info
            string fixedMessage = null;
        
            for ( var i = 0; i < parameters.Length; i++ ){
                
                // Get from Animator Parameter Bool
                var animStatus = _animator.GetBool( parameters[ i ] );

                // Need bool status
                var status = animatorSettings.GetActiveDown()[ key ];
                var needStatus = status[ i ];

                // Check if parameter status != need status
                if ( animStatus == needStatus ) return;
                
                // Set correct bool
                _animator.SetBool( parameters[ i ], needStatus );
                
                fixedMessage += $"⊙ |  { parameters[ i ] }\n"; 

            }
            
            // Info about this
            animatorSettings.message = fixedMessage;

        }
        
        private void KeyUp( KeyCode key ){
        
            // Main
            if ( !Input.GetKeyUp( key ) ) return;
            
            // Check KeyCode in Dictionary
            if ( !animatorSettings.GetUp().ContainsKey( key ) ) return;
                
            // Get cache and animator parameter name
            var parameters = animatorSettings.GetUp()[ key ];

            // Info
            string fixedMessage = null;
        
            for ( var i = 0; i < parameters.Length; i++ ){
                
                // Get from Animator Parameter Bool
                var animStatus = _animator.GetBool( parameters[ i ] );

                // Need bool status
                var status = animatorSettings.GetActiveUp()[ key ];
                var needStatus = status[ i ];

                // Check if parameter status != need status
                if ( animStatus == needStatus ) return;
                
                // Set correct bool
                _animator.SetBool( parameters[ i ], needStatus );
                
                fixedMessage += $"⊙ |  { parameters[ i ] }\n"; 

            }
            
            // Info about this
            animatorSettings.message = fixedMessage;

        }

    }
   
}