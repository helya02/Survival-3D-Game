using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftingSystem : MonoBehaviour
{
 
    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;

    public GameObject Axe_Player;

    public bool can_use_axe;
 
    public List<string> inventoryItemList = new List<string> ();
 
    //Category Buttons
    Button toolsBTN;
 
    //Craft Buttons
    Button craftAxeBTN;

    Button craftFireBTN;
 
    //Requirement Text
    TextMeshProUGUI AxeReq1, AxeReq2;

    TextMeshProUGUI FireReq1, FireReq2;
 
    public bool isOpen;

    public bool AxeCreated;

    public bool FireCreated;
 
    //All Blueprints

    //public Blueprint AxeBLP = new Blueprint("Axe",2,"Stone",2,"Stick",1);  
 
 
 
    public static CraftingSystem Instance { get; set; }
 
 
    private void Awake()
    {
        if (Instance !=null && Instance !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
 
    // Start is called before the first frame update
    void Start()
    {
 
        isOpen = false;
        Blueprint AxeBLP = new Blueprint("Axe",2,"Stone",2,"Stick",1);  
        Blueprint FireBLP = new Blueprint("Fire",2,"Stone",4,"Stick",4);
 
        toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button> ();
        toolsBTN.onClick.AddListener(delegate { OpenToolsCategory(); });
 
        // AXE
        AxeReq1 = toolsScreenUI.transform.Find("Axe").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        AxeReq2 = toolsScreenUI.transform.Find("Axe").transform.Find("req2").GetComponent<TextMeshProUGUI>();
 
        craftAxeBTN = toolsScreenUI.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
        
        craftAxeBTN.onClick.AddListener(delegate { CraftAnyItem(AxeBLP); AxeCreated = true; });

        //FIRE
        FireReq1 = toolsScreenUI.transform.Find("Fire").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        FireReq2 = toolsScreenUI.transform.Find("Fire").transform.Find("req2").GetComponent<TextMeshProUGUI>();
 
        craftFireBTN = toolsScreenUI.transform.Find("Fire").transform.Find("Button").GetComponent<Button>();
        
        craftFireBTN.onClick.AddListener(delegate { CraftAnyItem(FireBLP); FireCreated = true;});

 
    }
 
 
    void OpenToolsCategory()
    {
        craftingScreenUI.SetActive (false);
        toolsScreenUI.SetActive (true);
    }
 
 
    void CraftAnyItem(Blueprint blueprintToCraft)
    {
 
        InventorySystem.Instance.AddToInventory(blueprintToCraft.itemName);
 
 
        if (blueprintToCraft.numOfRequirements == 1) //remove resources from inventory
        {
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
        }

        else if (blueprintToCraft.numOfRequirements == 2)
        {
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2amount);
        }
 
 
        StartCoroutine(calculate());
        RefreshNeededItems();

        
 
 
 
    }

    public IEnumerator calculate()
    {
        yield return 0;        // yield return new WaitForSeconds(1f); //To wait to do something
        InventorySystem.Instance.ReCalculateList();
        RefreshNeededItems();
    }
 
 
 
    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
 
            craftingScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
 
        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false);
            if (!InventorySystem.Instance.isOpen) {
                Cursor.lockState = CursorLockMode.Locked;
            }
            isOpen = false;
        }

        if(AxeCreated && Input.GetKeyDown(KeyCode.K)){

            //Axe_Player.SetActive(true);
            can_use_axe = true;

        }
        else{
            //Axe_Player.SetActive(false);
            can_use_axe = false;

        }

        if (can_use_axe){
            if(Input.GetKeyDown(KeyCode.L)){
                Axe_Player.SetActive(false);

            }
            Axe_Player.SetActive(true);

        }

        /*if (can_use_axe && Input.GetKeyDown(KeyCode.L)){
            Axe_Player.SetActive(false);

        }*/
 
 
 
    }

    public void RefreshNeededItems()
    {
 
        int stone_count = 0;
        int stick_count = 0;
        //int log_count = 0;
        //int treeBranch_count = 0;
        //int plank_count = 0;
 
        inventoryItemList = InventorySystem.Instance.itemList;
 
        foreach (string itemName in inventoryItemList)
        {
 
            switch (itemName) 
            {
                case "Stone()":
                    stone_count++;
                    break;
                case "Stick()":
                    stick_count++;
                    break;
                /*case "Log":
                    log_count++;
                    break;
                case "Tree Branch":
                    treeBranch_count++;
                    break;
                case "Plank":
                    plank_count++;
                    break;*/
            }
        }
 
 
 
        // Axe
 
        AxeReq1.text = "Stone [" + stone_count + "/2]";
        AxeReq2.text = "Stick [" + stick_count + "/1]";
        // in if con :  && InventorySystem.Instance.CheckSlotsAvailable(1)
        if (stone_count >= 2 && stick_count >=1) 
        {
 
            craftAxeBTN.gameObject.SetActive(true);
        }
        else
        {
            craftAxeBTN.gameObject.SetActive(false);
        }

        // Fire
 
        FireReq1.text = "Stone [" + stone_count + "/4]";
        FireReq2.text = "Stick [" + stick_count + "/4]";
        // in if con :  && InventorySystem.Instance.CheckSlotsAvailable(1)
        if (stone_count >= 4 && stick_count >=4) 
        {
 
            craftFireBTN.gameObject.SetActive(true);
        }
        else
        {
            craftFireBTN.gameObject.SetActive(false);
        }
 
 
        // Plank
 
        /*PlankReq1.text = "Log [" + log_count + "/1]";
 
        if (log_count >= 1 && InventorySystem.Instance.CheckSlotsAvailable(2))
        {
            craftPlankBTN.gameObject.SetActive(true);
        }
        else
        {
            craftPlankBTN.gameObject.SetActive(false);
        }*/
 
        // Stick
 
        /*StickReq1.text = "Branch [" + treeBranch_count + "/1]";
 
        if (treeBranch_count >= 1 && InventorySystem.Instance.CheckSlotsAvailable(1))
        {
            craftStickBTN.gameObject.SetActive(true);
        }
        else
        {
            craftStickBTN.gameObject.SetActive(false);
        }
 
        // Foundation
 
        FoundationReq1.text = "Plank [" + plank_count + "/4]";
 
        if (plank_count >= 4 && InventorySystem.Instance.CheckSlotsAvailable(1))
        {
            craftFoundationBTN.gameObject.SetActive(true);
        }
        else
        {
            craftFoundationBTN.gameObject.SetActive(false);
        }
 
        // Wall
 
        WallReq1.text = "Plank [" + plank_count + "/5]";
 
        if (plank_count >= 5 && InventorySystem.Instance.CheckSlotsAvailable(1))
        {
            craftWallBTN.gameObject.SetActive(true);
        }
        else
        {
            craftWallBTN.gameObject.SetActive(false);
        }*/
 
    }
}