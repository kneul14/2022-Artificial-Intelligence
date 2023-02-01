using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor (typeof (FOV_Cone_Script))]

//public class FOV_Editor_Script : Editor
//{
//    private void OnSceneGUI()
//    {
//        //Draws a cirlce around the target(enemy) in red
//        FOV_Cone_Script fov = (FOV_Cone_Script)target;
//        Handles.color = Color.red;
//        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
        
//        // draws two lines to show an angle in the circle
//        Vector3 viewAngleOne = fov.DirectionFromAngle(-fov.viewAngle / 2, false);
//        Vector3 viewAngleTwo = fov.DirectionFromAngle(fov.viewAngle / 2, false);
//        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleOne * fov.viewRadius);
//        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleTwo * fov.viewRadius);

//        //Handles.color = Color.green;
//        //foreach (Transform player in fov.playerLayer)
//        //{
//        //    Handles.DrawLine(fov.transform.position, player.transform.position);
//        //}
//    } 
//}
