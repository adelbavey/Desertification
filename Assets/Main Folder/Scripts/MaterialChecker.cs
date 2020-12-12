////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class MaterialChecker : MonoBehaviour
{

    #region private variables
    private RaycastHit hit;
    private Vector3 direction = Vector3.down;
    private Transform trn;
    private Vector3 checkOffset = Vector3.up * 0.1f;
    #endregion

    void Awake()
    {
        trn = transform;

        PlayerManagerN.my_obj = this;

    }

    public void CheckMaterial(GameObject go)
    {
        if (Physics.Raycast(trn.position + checkOffset, direction, out hit))
        {
            SoundMaterial sm = hit.collider.gameObject.GetComponent<SoundMaterial>();

            if (sm != null)
            {
                sm.Material.SetValue(go);
            }
        }
    }

    public AK.Wwise.Switch GetMaterial()
    {
        if (Physics.Raycast(trn.position + checkOffset, direction, out hit))
        {
            SoundMaterial sm = hit.collider.gameObject.GetComponent<SoundMaterial>();

            if (sm != null)
            {
                return sm.Material;
            }
        }
        return null;
    }

}
