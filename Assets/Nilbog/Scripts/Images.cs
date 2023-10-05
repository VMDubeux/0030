using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ImagesState { Empty, Filled }
public class Images : MonoBehaviour
{
    public Icon[] ObjImages;

    private ImagesState _state;

    public void SetImage() 
    {
        _state = ImagesState.Empty;
    }
}
