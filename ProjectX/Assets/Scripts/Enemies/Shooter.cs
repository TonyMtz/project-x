using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterStateMachine
{
    public enum State
    {
        IDLE,
        JUMP,
        SHOOT
    }

    public enum Command
    {
        GO_JUMP,
        GO_SHOOT,
        GO_IDLE
    }

    public class Machine
    {
        class StateTransition
        {
            readonly State CurrentState;
            readonly Command Command;

            public StateTransition(State currentState, Command command)
            {
                CurrentState = currentState;
                Command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
            }
        }

        Dictionary<StateTransition, State> transitions;
        public State CurrentState { get; set; }

        public Machine()
        {
            CurrentState = State.IDLE;
            transitions = new Dictionary<StateTransition, State>
            {
                { new StateTransition(State.IDLE, Command.GO_JUMP), State.JUMP },
                { new StateTransition(State.IDLE, Command.GO_SHOOT), State.SHOOT },
                { new StateTransition(State.JUMP, Command.GO_IDLE), State.IDLE },
                { new StateTransition(State.JUMP, Command.GO_SHOOT), State.SHOOT },
                { new StateTransition(State.SHOOT, Command.GO_IDLE), State.IDLE }
            };
        }

        public State GetNext(Command command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            State nextState;

            if (!transitions.TryGetValue(new StateTransition(CurrentState, command), out nextState))
            {
                throw new Exception("Invalid Transition: " + CurrentState + " --> " + command);
            }

            return nextState;
        }

        public State MoveNext(Command command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }
}

public class Shooter : BaseEnemy, IShooter
{
    [SerializeField]
    private float timeOut = 2f;

    private float time = 0f;

    private ShooterStateMachine.Machine myStateMachine;

    // Use this for initialization
    override public void Start()
    {
        base.Start();
        myStateMachine = new ShooterStateMachine.Machine();
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time > timeOut)
        {
            time = 0f;
            Action();
        }
    }

    private void Action()
    {
        switch (myStateMachine.CurrentState)
        {
            case ShooterStateMachine.State.IDLE:
                Idle();
                myStateMachine.MoveNext(ShooterStateMachine.Command.GO_JUMP);
                break;
            case ShooterStateMachine.State.JUMP:
                Jump();
                myStateMachine.MoveNext(ShooterStateMachine.Command.GO_IDLE);
                break;
        }
    }

    public void Idle()
    {
        print("IDLE");
    }

    public void Jump()
    {
        print("JUMP");
    }

    public void Shoot()
    {
        print("SHOOT");
    }

    public void Hurt()
    {
        print("HURT");
    }
}
