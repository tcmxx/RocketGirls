using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public bool parenting = false;
    public Vector3 relativeSpawnRange;
    public List<InstantiateParameter> objectsToSpawn;

    public bool useAbsolutePosition = false;
    public Vector3 absolutePosition;

    [System.Serializable]
    public class InstantiateParameter
    {
        public GameObject objPreb;
        public float weight = 1;
        public float customInitializeParameter;
        public string customInitalizeMethod;
    }

    public virtual GameObject SpawnObject(InstantiateParameter param)
    {
        GameObject obj = null;
        Vector3 anchor = transform.position;
        if (useAbsolutePosition)
            anchor = absolutePosition;
        if(param.objPreb == null)
            return null;
        if(parenting)
            obj = Instantiate(param.objPreb, anchor + new Vector3(Random.Range(-relativeSpawnRange.x/2, relativeSpawnRange.x/2)
                , Random.Range(-relativeSpawnRange.y / 2, relativeSpawnRange.y / 2),
                Random.Range(-relativeSpawnRange.z / 2, relativeSpawnRange.z / 2)), Quaternion.identity,transform);
        else
        {
            obj = Instantiate(param.objPreb, anchor + new Vector3(Random.Range(-relativeSpawnRange.x / 2, relativeSpawnRange.x / 2)
                , Random.Range(-relativeSpawnRange.y / 2, relativeSpawnRange.y / 2),
                Random.Range(-relativeSpawnRange.z / 2, relativeSpawnRange.z / 2)), Quaternion.identity);
        }
        if(param.customInitalizeMethod  != "")
            obj.SendMessage(param.customInitalizeMethod, param.customInitializeParameter);
        return obj;
    }

    public void SpawnObject()
    {
        SpawnObject(NextObject());
    }
    public void SpawnObject(int count)
    {
        for(int i = 0; i < count;++i)
            SpawnObject(NextObject());
    }
    public void SpawnObjectAt(Vector3 position)
    {
        var obj = SpawnObject(NextObject());
        if(obj != null)
            obj.transform.position = position;

    }
    protected InstantiateParameter NextObject()
    {
        float[] weightArray = new float[objectsToSpawn.Count];
        int i = 0;
        foreach (var p in objectsToSpawn)
        {
            weightArray[i] = p.weight;
            i++;
        }

        int result = MathUtils.IndexByChance(weightArray);
        return objectsToSpawn[result];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, relativeSpawnRange);
    }
}
