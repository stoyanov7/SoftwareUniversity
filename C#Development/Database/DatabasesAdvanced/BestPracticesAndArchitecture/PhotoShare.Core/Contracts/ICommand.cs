﻿namespace PhotoShare.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
