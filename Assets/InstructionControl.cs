using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InstructionControl : MonoBehaviour {

    LinkedList<string> Inst = new LinkedList<string>();
    public Text InstText;
    
    string Inst1 = "Welcome to HFE406 Project Experiment";
    string Inst2 = "This is experiment for examine \n\"influnce of light in 3D-first person view Game\"";
    string Inst3 = "You will play simple labyrinth game.\n Your goal is to touch high pillar locate at Exit.\n As soon as you started, you will find that pillar.\n If not, feel free to ask researcher.";
    string Inst4 = "Press W or ↑ to move forward.\n Press A / D or  ← / →  to turn left / right.\n Press S or ↓ to look behind.";
    string Inst5 = "If you are ready";
    // Use this for initialization
    void Start () {
        Inst.AddFirst(Inst1);
        Inst.AddLast(Inst2);
        Inst.AddLast(Inst3);
        Inst.AddLast(Inst4);
        Inst.AddLast(Inst5);
        InstText.text = Inst1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Inst.Find(InstText.text).Next == null)
                SceneManager.LoadScene("map1");
            else
                InstText.text = Inst.Find(InstText.text).Next.Value;
        }
    }
}
