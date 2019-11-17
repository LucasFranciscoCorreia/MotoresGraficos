using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float radius = 3f;
    public GameObject chat;
    public Item item;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            chat.gameObject.SetActive(true);
            chat.GetComponentInChildren<Text>().text = "[F] to Pick up";
            StartCoroutine(AwaitChat());
        }
    }

    IEnumerator AwaitChat()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                chat.gameObject.SetActive(false);
                Inventory.instance.Add(item);
                Destroy(this.gameObject);

            }
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            chat.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}
