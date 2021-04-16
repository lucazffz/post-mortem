using UnityEngine;
using System.Collections;

public class FakeWall : MonoBehaviour
{
    public Item map;

    private bool activated;

    private void Update()
    {
        if(!activated)
        {
            if (InventoryManager.instance.ContainsItem(map)) transform.GetChild(2).gameObject.SetActive(true);
            else transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void RevealWall()
    {
        activated = true;
       

        if (InventoryManager.instance.ContainsItem(map))
        {
            StartCoroutine(Wait());
        }

    }

    IEnumerator Wait()
    {
       EndScenecut.playingCutscene = true;

        yield return new WaitForSeconds(2);

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);

        yield return new WaitForSeconds(1);

       GetComponent<DialogueTrigger>().TriggerDialogue();

        EndScenecut.playingCutscene = false;
    }
}
