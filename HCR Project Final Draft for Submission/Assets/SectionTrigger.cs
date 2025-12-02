using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            other.gameObject.SetActive(false);
            Debug.Log(other.gameObject.name);
            Instantiate(roadSection, new Vector3(-6.06f, 2, -13), Quaternion.identity);
            return;
        }
    }

}
