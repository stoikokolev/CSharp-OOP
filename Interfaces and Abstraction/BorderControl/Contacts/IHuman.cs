﻿namespace BorderControl.Contacts
{
    public interface IHuman :  IIdentifiable, IBirthable, IBuyer
    {

        int Age { get; }
    }
}
