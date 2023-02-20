using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gManager;
    private Fader fade;
    private Door door;
    private List<GemControl> gems;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        if (gManager == null)
        {
            gManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gems = new List<GemControl>();
    }
    public static void SetFader(Fader fd)
    {
        if (gManager == null)
        {
            return;
        }
        gManager.fade = fd;

    }
    public static void ManagerLoadLevel(int index)
    {
        if (gManager == null)
        {
            return;
        }
        gManager.fade.SetLevel(index);
    }
    public static void ManagerRestartLevel()
    {
        if (gManager == null)
        {
            return;
        }
        gManager.gems.Clear();
        gManager.fade.RestartLevel();
    }
    public static void SetDoor(Door dr)
    {
        if (gManager == null)
        {
            return;
        }
        gManager.door = dr;
    }
    public static void AddGem(GemControl addGem)
    {
        if (gManager == null)
        {
            return;
        }
        if (!gManager.gems.Contains(addGem))
        {
            gManager.gems.Add(addGem);
        }
    }
    public static void RemoveGem(GemControl removeGem)
    {
        if (gManager == null)
        {
            return;
        }
        gManager.gems.Remove(removeGem);
        if (gManager.gems.Count == 0)
        {
            gManager.door.UnlockDoor();
        }
    }








}
