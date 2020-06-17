using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour {

private float mSize = 0.0f;
public float frequency;
    void Start() {
        InvokeRepeating("ScaleUp",0.0f,frequency);
    }

    void ScaleUp() {
        if(mSize >= 100.0f) {
            CancelInvoke("ScaleUp");
            InvokeRepeating("ScaleDown",0.0f,frequency);
        }
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1,mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(2,mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3,mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(4,mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(5,mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(6,mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(7,mSize++);
    }
    void ScaleDown() {
        if(mSize <= 0.0f) {
            CancelInvoke("ScaleDown");
            InvokeRepeating("ScaleUp",0.0f,frequency);
        }
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,mSize--);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1,mSize--);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(2,mSize--);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3,mSize--);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(4,mSize--);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(5,mSize--);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(6,mSize--);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(7,mSize--);
    }

}
