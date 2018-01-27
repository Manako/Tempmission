using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour {
    public bool hasname;
    public string name;
    public Vector2 position;
    public Texture texture;
    public Texture prompt_texture;
    public string[] strings;
    public GUIStyle style;

    private Texture nametex;
    private int state;
    // Use this for initialization
    private const int STATIC = 0;
    private const int DRAWING = 1;
    private const int FINISHED = 2;
    private const int STARTING = 3;
    private Draw_Text_Box textbox;
    private int currentstring;
    private SpriteRenderer rend;
    private Rect usebox;
    private bool draw_prompt;
    private int counter;
    void Start () {
        state = STARTING;
        currentstring = 0;
        rend = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        
        draw_prompt = false;
        counter = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(state == STARTING)
        {
            if (currentstring < strings.Length)
            {
                //start drawing text
                textbox = gameObject.AddComponent(typeof(Draw_Text_Box)) as Draw_Text_Box;
                textbox.message = strings[currentstring];
                textbox.msg_speed = 3;
                textbox.parent = this;
                textbox.SetStyle(style);
                textbox.tex = texture;
                textbox.p_tex = prompt_texture;
                textbox.name = name;
                textbox.hasname = hasname;
                if (hasname)
                    usebox = new Rect(position.x, position.y + 25, texture.width, texture.height);
                else
                    usebox = new Rect(position.x, position.y, texture.width, texture.height);
                if (usebox == new Rect(0, 0, 0, 0))
                {
                    textbox.usebox = usebox;
                }
                else
                {
                    textbox.usebox = usebox;
                }
                state = DRAWING;
                currentstring++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if(state == DRAWING)
        {
            if (hasname)
                usebox = new Rect(position.x, position.y + 25, texture.width, texture.height);
            else
                usebox = new Rect(position.x, position.y, texture.width, texture.height);
            if (usebox == new Rect(0, 0, 0, 0))
            {
                textbox.usebox = usebox;
            }
            else
            {
                textbox.usebox = usebox;
            }
            if (Input.GetKeyDown("a"))
            {
                textbox.Skip();
                state = FINISHED;
            }
        }else if(state == FINISHED)
        {
            if (hasname)
                usebox = new Rect(position.x, position.y + 25, texture.width, texture.height);
            else
                usebox = new Rect(position.x, position.y, texture.width, texture.height);
            if (usebox == new Rect(0, 0, 0, 0))
            {
                textbox.usebox = usebox;
            }
            else
            {
                textbox.usebox = usebox;
            }
            if (Input.GetKeyDown("a"))
            {
                Destroy(textbox);
                state = STARTING;
                textbox.SetPrompt(false);
                draw_prompt = false;
                counter = 0;
            }
            if (counter > 15)
            {
                draw_prompt = !draw_prompt;
                textbox.SetPrompt(draw_prompt);
                counter = 0;
            }
            else
            {
                counter++;
            }
        }
	}

    public void Finish()
    {
        state = FINISHED;
    }
}