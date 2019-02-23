using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    [System.Serializable] //this use for convert below class to single element as I think
    private class RotationElement{
        #pragma warning disable 0649
        public float speed;
        public float duration;
        #pragma warning restore 0649
    }

    [SerializeField]
    private RotationElement[] rotationPattern;

    private WheelJoint2D wheelJoint;
    private JointMotor2D moter;

    private void Awake(){
        wheelJoint = GetComponent<WheelJoint2D>();
        moter = new JointMotor2D();
        StartCoroutine("PlayRotationPattern");
    }

    private IEnumerator PlayRotationPattern()
    {
        int rotationIndex=0;
        while(true){
            yield return new WaitForFixedUpdate();
            moter.motorSpeed = rotationPattern[rotationIndex].speed;
            moter.maxMotorTorque = 1000;
            wheelJoint.motor = moter;

            yield return new WaitForSecondsRealtime(rotationPattern[rotationIndex].duration);
            rotationIndex ++;
            rotationIndex = rotationIndex < rotationPattern.Length ? rotationIndex : 0;
        }
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
