using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBase
{
    private string _commandID;
    private string _commandDesc;
    private string _commandFormat;

    public string CommandID {get {return _commandID;}}
    public string CommandDesc {get {return _commandDesc;}}
    public string CommandFormat {get {return _commandFormat;}}

    public CommandBase(string id, string description, string format)
    {
        _commandID = id;
        _commandDesc = description;
        _commandFormat = format;
    }
}

public class DebugCommand : CommandBase
{
    private Action command;
    public DebugCommand(string id, string description, string format, Action Command) : base (id, description, format)
    {
        this.command = Command;
    }

    public void Invoke()
    {
        command.Invoke();
    }

}

public class DebugCommand<T1> : CommandBase
    {
        private Action<T1> command;

        public DebugCommand(string id, string description, string format, Action<T1> command) : base (id, description,format)
        {
            this.command = command;
        }

        public void Invoke(T1 value)
        {
            command.Invoke(value);
        }
    }

