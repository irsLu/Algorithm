using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Keybord
{
    PRESS_J,
    RELEASE_J,
    PRESS_BlANK,
}

public class Hero
{
    private CharacterState mState;

    public Hero()
    {
        mState = new IdleState(this);
    }

    public void HandleInput(Keybord keyword)
    {
        CharacterState state = mState.HandleInput(keyword);

        if (state != null)
        {
            mState = state;
            mState.Enter();
        }
            
        
    }

    public void PlayAction(string action)
    {
        Console.WriteLine("Hero is " +action + "ing~");
    }
}

