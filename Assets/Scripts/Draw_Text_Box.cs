using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Text_Box : MonoBehaviour
{
    public bool hasname;
    public string name;
    public Texture tex;
    public Texture p_tex;
    public TextHandler parent;
    public string message;
    public int msg_speed;
    public Rect usebox;
    private int characters;
    private int timer;
    private GUIStyle style = new GUIStyle("label");
    bool draw_prompt;
	// Use this for initialization
	void Start () {
        characters = 0;
        timer = 0;
        draw_prompt = false;
    }
	
	// OnGUI is called once per frame
	void OnGUI () {
        if (timer < msg_speed)
            timer++;
        else
        {
            if (characters < message.Length)
                characters++;
            else
            {
                parent.Finish();
            }
            timer = 0;
        }
        if (usebox != new Rect(0,0,0,0))
        {
            if (hasname)
            {
                GUI.DrawTexture(new Rect(usebox.x, usebox.y - 25, usebox.width, usebox.height), tex);
                GUI.Label(new Rect(usebox.x, usebox.y - 29, usebox.width, usebox.height), name, style);
            }

            GUI.DrawTexture(usebox, tex);
            GUI.Label(usebox, message.Substring(0, characters), style);

            if(draw_prompt && p_tex != null)
                GUI.DrawTexture(new Rect(usebox.x + usebox.width - p_tex.width - 10, usebox.y + usebox.height - p_tex.height - 10, p_tex.width, p_tex.height), p_tex);
        }
        else
        {
            if (hasname)
            {
                GUI.DrawTexture(new Rect(usebox.x, usebox.y - 25, usebox.width, usebox.height), tex);
                GUI.Label(new Rect(usebox.x, usebox.y - 29, usebox.width, usebox.height), name, style);
            }

            GUI.DrawTexture(usebox, tex);
            GUI.Label(new Rect(10, 10, 100, 50), message.Substring(0, characters), style);
            if (draw_prompt && p_tex != null)
                GUI.DrawTexture(new Rect(usebox.x + usebox.width - p_tex.width - 10, usebox.y + usebox.height - p_tex.height - 10, p_tex.width, p_tex.height), p_tex);
        }
    }
    public void Skip()
    {
        characters = message.Length;
        parent.Finish();
    }
    public void SetStyle(GUIStyle sty)
    {
        style = sty;
    }
    public void SetPrompt(bool bl)
    {
        draw_prompt = bl;
    }
}