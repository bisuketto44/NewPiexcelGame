using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InfinityScrollSetUp
{
    void OnPostSetupItems();
    void OnUpdateItem(int itemCount, GameObject obj);
}
