using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ElementController elementC = other.GetComponent<ElementController>();
        if (elementC != null)
        {
            StartCoroutine(ChangeBodies(elementC));
            /*
            GameObject newBody = Instantiate(body, elementC.currentBody.transform.parent);
            newBody.transform.localPosition = Vector3.zero;
            newBody.transform.localRotation = Quaternion.identity;

            //elementC.transform.SetAsLastSibling();
            Destroy(elementC.currentBody);

            elementC.currentBody = newBody;

            //elementC.GetComponent<Animator>().enabled = false;
            //yield return new WaitForEndOfFrame();
            elementC.GetComponent<Animator>().Rebind();
            //elementC.GetComponent<Animator>().enabled = true;
            */
        }
    }

    IEnumerator ChangeBodies(ElementController elementC)
    {
        GameObject newBody = Instantiate(body, elementC.currentBody.transform.parent);
        newBody.transform.localPosition = Vector3.zero;
        newBody.transform.localRotation = Quaternion.identity;
        newBody.name = newBody.name.Split("(Clone)")[0]; //change name for "Example (Clone)" to "Example"


        SkinnedMeshRenderer newMeshRenderer = newBody.GetComponentInChildren<SkinnedMeshRenderer>();
        newMeshRenderer.enabled = false;

        Destroy(elementC.currentBody);
        elementC.transform.SetAsLastSibling();

        elementC.currentBody = newBody;

        //elementC.GetComponent<Animator>().enabled = false;
        yield return null;
        elementC.GetComponentInChildren<Animator>().Rebind();
        newMeshRenderer.enabled = true;
        //elementC.GetComponent<Animator>().enabled = true;
    }
}
