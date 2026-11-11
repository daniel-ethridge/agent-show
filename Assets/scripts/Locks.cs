using UnityEngine;

public struct KeyHole
{
    public Vector2 floorPosition;
    public MeshRenderer renderer;
    public int numActivations;
}

public enum LockValue
{
    LOCK_0 = 1 << 0,
    LOCK_1 = 1 << 1,
    LOCK_2 = 1 << 2,
    LOCK_3 = 1 << 3,
    LOCK_4 = 1 << 4,
    LOCK_5 = 1 << 5,
    LOCK_6 = 1 << 6,
    LOCK_7 = 1 << 7,
    LOCK_8 = 1 << 8,
    LOCK_9 = 1 << 9,
    LOCK_10 = 1 << 10,
    LOCK_11 = 1 << 11
}

public class Locks : MonoBehaviour
{
    public BoolVariable revealKeyInLock;
    public Transform[] trackers;
    private KeyHole[] keyHoles;
    private LockValue lockValue;

    public Texture onMesh;
    public Texture offMesh;

    public float maxDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        revealKeyInLock.Value = false;
        keyHoles = new KeyHole[transform.childCount];

        for (int i = 0; i < keyHoles.Length; i++)
        {
            Transform keyHoleTransform = transform.GetChild(i);
            keyHoles[i].floorPosition = new Vector2(
                keyHoleTransform.position.x,
                keyHoleTransform.position.z
            );
            keyHoles[i].renderer = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>();
        }
    }

    void Update()
    {
        lockValue = 0;
        for (int i = 0; i < keyHoles.Length; i++)
        {
            keyHoles[i].numActivations = 0;
        }

        for (int t = 0; t < trackers.Length; t++)
        {
            Vector2 trackerPos = new Vector2(
                trackers[t].position.x,
                trackers[t].position.z
            );

            for (int i = 0; i < keyHoles.Length; i++)
            {
                if (Vector2.Distance(keyHoles[i].floorPosition, trackerPos) <= maxDistance)
                {
                    keyHoles[i].numActivations += 1;
                    lockValue |= (LockValue)(1 << i);
                }
            }
        }

        for (int i = 0; i < keyHoles.Length; i++)
        {
            if (keyHoles[i].numActivations > 0)
            {
                keyHoles[i].renderer.material.mainTexture = onMesh;
            }
            else
            {
                keyHoles[i].renderer.material.mainTexture = offMesh;
            }
        }

        if (lockValue == (LockValue.LOCK_2 | LockValue.LOCK_9))
            revealKeyInLock.Value = true;
        else
            revealKeyInLock.Value = false;
    }

    private void ResetState()
    {

    }
}
