using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public GameObject environment;

    public Transform stick;

    List<int> usedValues = new List<int>();

    public List<GameObject> environments = new List<GameObject>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        usedValues.Clear();

        Vector3 environmentPos = new Vector3(environment.transform.position.x, 5, environment.transform.position.z);

        for (int i = 10; i > 0; i--)
        {
            int rdn = Random.Range(0, 10);
            int rdn2 = Random.Range(0, 8);

            if (usedValues.Contains(rdn))
            {
                i++;
                continue;
            }
            else
            {
                if (i == 10)
                {
                    GameObject target = Instantiate(environment, new Vector3(environmentPos.x, environmentPos.y * i, environmentPos.z), Quaternion.identity);
                    target.transform.parent = stick;
                    target.GetComponent<EnvironmentController>().TopSliceControl();
                    usedValues.Add(rdn);
                    environments.Add(target);
                }
                else
                {
                    GameObject target = Instantiate(environment, new Vector3(environmentPos.x, environmentPos.y * i, environmentPos.z), Quaternion.identity);
                    target.transform.parent = stick;
                    target.GetComponent<EnvironmentController>().SliceRemover();
                    target.GetComponent<EnvironmentController>().slices[rdn2].GetComponent<Renderer>().material.color = Color.red;
                    usedValues.Add(rdn);
                    environments.Add(target);
                }
            }
        }
    }
}
