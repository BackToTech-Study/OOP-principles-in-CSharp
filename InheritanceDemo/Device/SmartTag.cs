﻿namespace InheritanceDemo.Device;

public class SmartTag : CoreDevice
{
    public string value;
    private string _tagId;
    
    public SmartTag(string value, string? id = null) 
        : base()
    {
        this.value = value;
        _tagId = id ?? string.Empty;
    }
    
    // use the override method to replace the logic of a virtual method 
    public override string GetId()
    {
        if (string.IsNullOrEmpty(_tagId))
        {
            _tagId = $"ST-{base.GetId()}";
        }
        return _tagId;
    }
    
    public string GetUniqueId()
    {
        return base.GetId();
    }

    // use the override method to replace the logic of a abstract method 
    public override string GetDeviceType()
    {
        return "SmartTag";
    }
    
    public override bool Equals(CoreDevice? other)
    {
        return other is not null && (ReferenceEquals(this, other) || GetId() == other.GetId()); 
    }
    
    public SmartTag Clone()
    {
        return new SmartTag(value, GetId());
    }
    
    // use the new keyword when you are hiding a base method
    public new string GetWelcomeMessage()
    {
        return $"Welcome to the {GetDeviceType()} with ID: {GetId()} and unique ID: {GetUniqueId()}";
    }
}