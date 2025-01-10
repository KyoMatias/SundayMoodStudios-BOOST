using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private BOOST_Manager BM_Developer;
    public string CurrentID;
    public List<string> GenKeys = new List<string>
    {
        "SpGm-C1IT-X94B",
        "SGC-X9TQ-KR71",
        "SPD-31G-CI2T",
        "XSG-459-BQTI",
        "SPC-G88T-K942",
        "Z4GM-CI-LQ21",
        "SCG-T94I-58XP",
        "SG-XQ10-C91T",
        "SCPD-IT4G-6X23",
        "SGX-C1QT-R96B",
        "SPGM-42I9-BQ4T",
        "C7G-SDPT-93IT",
        "SGQ-58IT-KR4X",
        "SPG-LT91-KXRM",
        "GMSP-XI8T-RQ41"
    };

    private void Awake()
    {
        BM_Developer = GetComponent<BOOST_Manager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        KeyValidation(CurrentID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateKeys()
    {

    }

    void KeyValidation(string keyset)
    {
        if(GenKeys.Contains(keyset))
        {
            Debug.Log("Key Is Valid");
            BOOST_Manager.instance.RegisterGame(true);
            BOOST_Manager.instance.DeveloperProperties.RegistrationID = keyset;
        }
    }
}
