using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LSL4Unity.Samples.SimpleInlet;

public class JumpedTowerUI : MonoBehaviour
{
    SimpleInletBalanceBoard balanceBoardInput;
    [SerializeField] Image gravityCenter;

    // Start is called before the first frame update
    void Start()
    {
        balanceBoardInput = gameObject.GetComponentInParent<SimpleInletBalanceBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        gravityCenter.transform.localPosition = balanceBoardInput.CoordValues / 2f;
        //gravityCenter.transform.localPosition = balanceBoardInput.rotationValues / 2f;
    }
}
