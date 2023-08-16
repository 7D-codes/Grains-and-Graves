using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberJack : MonoBehaviour
{
    private Vector3 originalPosition;
    private GameObject targetTree;
    private bool choppingTree = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (!choppingTree)
        {
            FindNearestTree();
        }
        else
        {
            ChopTree();
        }
    }

    private void FindNearestTree()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        float nearestDistance = Mathf.Infinity;
        foreach (GameObject tree in trees)
        {
            float distanceToTree = Vector3.Distance(transform.position, tree.transform.position);
            if (distanceToTree < nearestDistance)
            {
                nearestDistance = distanceToTree;
                targetTree = tree;
            }
        }

        if (targetTree != null)
        {
            StartCoroutine(ChopTreeCoroutine());
        }
    }

    private IEnumerator ChopTreeCoroutine()
    {
        choppingTree = true;

        yield return new WaitForSeconds(5f);

        // Destroy the tree
        if (targetTree != null)
        {
            Destroy(targetTree);
        }

        yield return new WaitForSeconds(0.5f); // Give some time to process the destruction

        // Go back to original position
        ReturnToOriginalPosition();

        choppingTree = false;
    }

    private void ChopTree()
    {
        // You can add animation or other actions here while chopping
        // For simplicity, we are just standing still during the chopping time
    }

    private void ReturnToOriginalPosition()
    {
        float step = 3f * Time.deltaTime; // Adjust the speed of movement
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);

        // If the lumberjack is very close to the original position, reset the position exactly
        if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
        {
            transform.position = originalPosition;
        }
    }

    // Draw gizmos to visualize the lumberjack's state
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.5f); // Lumberjack's current position

        if (targetTree != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, targetTree.transform.position); // Line to target tree
            Gizmos.DrawWireSphere(targetTree.transform.position, 0.25f); // Target tree position
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(originalPosition, 0.5f); // Lumberjack's original position
    }
}