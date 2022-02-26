using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFloat : MonoBehaviour
{
    [Header("Boat object")]
    public GameObject Boat;
    [Header("Boat points")]
    public Transform BoatCenter;
    public Transform BoatRight;
    public Transform BoatFront;
    public Transform BoatLeft;
    public Transform BoatBack;
    [Space]
    [Range(0, 1)] public float BuoyancySmoothing = 0.5f; 
    public float BuoyancyExaggerate = 1;
    public Texture2D WaterTexture;
    [Header("Material properties")]
    public Material SyncMaterial; 
    [Space]
    public float Speed = 1;
    public float TextureFrequency = 3;
    public float WaveHeight = 1;

    void Update()
    {
        //Update height (world space)
        BoatCenter.position = new Vector3(BoatCenter.position.x, WaveOffset(BoatCenter.position), BoatCenter.position.z);
        BoatRight.position = new Vector3(BoatRight.position.x, WaveOffset(BoatRight.position), BoatRight.position.z);
        BoatFront.position = new Vector3(BoatFront.position.x, WaveOffset(BoatFront.position), BoatFront.position.z);
        BoatLeft.position = new Vector3(BoatLeft.position.x, WaveOffset(BoatLeft.position), BoatLeft.position.z);
        BoatBack.position = new Vector3(BoatBack.position.x, WaveOffset(BoatBack.position), BoatBack.position.z);
        
        //Get local positions
        Vector3 posC = BoatCenter.localPosition,
            posR = BoatRight.localPosition,
            posL = BoatLeft.localPosition,
            posF = BoatFront.localPosition,
            posB = BoatFront.localPosition;

        //Up vector
        Vector3 Up1 = Vector3.Cross(posF - posC, posR - posC);
        Vector3 Up2 = Vector3.Cross(posL - posC, posB - posC);

        Vector3 UpAvg = Vector3.Lerp(Up1, Up2, 0.5f);

        Debug.DrawRay(transform.position + posC, UpAvg, Color.red, 0.1f);

        //Set position
        float cornerPos = (posR.y + posL.y + posF.y + posB.y) /4;
        Boat.transform.position = new Vector3(transform.position.x, Mathf.Lerp(posC.y, cornerPos, 0.75f), transform.position.z);

        //Set rotation
        Boat.transform.localRotation = Quaternion.Euler
            (-Mathf.Asin(UpAvg.z) * Mathf.Rad2Deg * BuoyancyExaggerate,
            Boat.transform.localRotation.eulerAngles.y,
            -Mathf.Asin(UpAvg.x) * Mathf.Rad2Deg * BuoyancyExaggerate);

        //Sync material
        SyncMaterial.SetFloat("_CustomTime", Time.timeSinceLevelLoad);
        SyncMaterial.SetFloat("_Speed", Speed);
        SyncMaterial.SetFloat("_TexFreq", TextureFrequency);
        SyncMaterial.SetFloat("_Height", WaveHeight);
    }

    private float WaveOffset(Vector3 ogPosition)
    {
        Vector2 ogUV = new Vector2(ogPosition.x, ogPosition.z);
        float shiftUV = (Time.timeSinceLevelLoad * Speed * .05f);

        Vector2 shiftedUV1 = -(ogUV + new Vector2(shiftUV, shiftUV)) * TextureFrequency * 0.01f;
        Vector2 shiftedUV2 = (ogUV - new Vector2(shiftUV, shiftUV)) * TextureFrequency * 0.01f;

        float wave1 = WaterTexture.GetPixelBilinear(shiftedUV1.x, shiftedUV1.y).r;
        float wave2 = WaterTexture.GetPixelBilinear(shiftedUV2.x, shiftedUV2.y).r;

        float waves = wave1 + wave2;

        float waveTarget = waves * WaveHeight * 0.1f;

        float smoothedWave = Mathf.Lerp(waveTarget, -ogPosition.y, BuoyancySmoothing);

        return -smoothedWave;
    }
}
