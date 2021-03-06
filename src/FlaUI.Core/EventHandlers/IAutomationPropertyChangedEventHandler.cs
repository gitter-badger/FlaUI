﻿using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.EventHandlers
{
    public interface IAutomationPropertyChangedEventHandler
    {
        void HandlePropertyChangedEvent(Element sender, PropertyId propertyId, object newValue);
    }
}
