using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public static EnvironmentController Instance;

    public GameObject[] slices;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SliceRemover()
    {
        int rdn = Random.Range(0, 8);
        int rdn2 = Random.Range(1, 3);

        if (rdn2 == 1)
        {
            slices[rdn].SetActive(false);
        }
        else
        {
            int rdn3 = Random.Range(rdn - 1, rdn);
            if (rdn3 == -1)
            {
                slices[rdn].SetActive(false);
                slices[rdn3 + 2].SetActive(false);
            }
            else
            {
                slices[rdn].SetActive(false);
                slices[rdn3].SetActive(false);
            }
        }
    }
    public void TopSliceControl()
    {
        int rdn = Random.Range(1, 8);
        int rdn2 = Random.Range(1, 3);

        if (rdn2 == 1)
        {
            slices[rdn].SetActive(false);
        }
        else
        {
            int rdn3 = Random.Range(rdn - 1, rdn);
            if (rdn3 == 0)
            {
                slices[rdn + 1].SetActive(false);
                slices[rdn3 + 3].SetActive(false);
            }
            else
            {
                if (rdn == 7)
                {
                    slices[rdn].SetActive(false);
                    slices[rdn3].SetActive(false);
                }
                else
                {
                    slices[rdn + 1].SetActive(false);
                    slices[rdn3 + 1].SetActive(false);
                }
            }
        }
    }
}
