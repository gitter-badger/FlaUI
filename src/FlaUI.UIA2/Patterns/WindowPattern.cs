﻿using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class WindowPattern : PatternBaseWithInformation<UIA.WindowPattern, WindowPatternInformation>, IWindowPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.WindowPattern.Pattern.Id, "Window");
        public static readonly PropertyId CanMaximizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.CanMaximizeProperty.Id, "CanMaximize");
        public static readonly PropertyId CanMinimizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.CanMinimizeProperty.Id, "CanMinimize");
        public static readonly PropertyId IsModalProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.IsModalProperty.Id, "IsModal");
        public static readonly PropertyId IsTopmostProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.IsTopmostProperty.Id, "IsTopmost");
        public static readonly PropertyId WindowInteractionStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowInteractionStateProperty.Id, "WindowInteractionState");
        public static readonly PropertyId WindowVisualStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowVisualStateProperty.Id, "WindowVisualState");
        public static readonly EventId WindowClosedEvent = EventId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowClosedEvent.Id, "WindowClosed");
        public static readonly EventId WindowOpenedEvent = EventId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowOpenedEvent.Id, "WindowOpened");

        public WindowPattern(AutomationObjectBase automationObject, UIA.WindowPattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new WindowPatternProperties();
            Events = new WindowPatternEvents();
        }

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Cached => Cached;

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Current => Current;

        public IWindowPatternProperties Properties { get; }

        public IWindowPatternEvents Events { get; }

        public void Close()
        {
            NativePattern.Close();
        }

        public void SetWindowVisualState(WindowVisualState state)
        {
            NativePattern.SetWindowVisualState((UIA.WindowVisualState)state);
        }

        public bool WaitForInputIdle(int milliseconds)
        {
            return NativePattern.WaitForInputIdle(milliseconds);
        }

        protected override WindowPatternInformation CreateInformation(bool cached)
        {
            return new WindowPatternInformation(AutomationObject, cached);
        }
    }

    public class WindowPatternInformation : ElementInformationBase, IWindowPatternInformation
    {
        public WindowPatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool CanMaximize => Get<bool>(WindowPattern.CanMaximizeProperty);
        public bool CanMinimize => Get<bool>(WindowPattern.CanMinimizeProperty);
        public bool IsModal => Get<bool>(WindowPattern.IsModalProperty);
        public bool IsTopmost => Get<bool>(WindowPattern.IsTopmostProperty);
        public WindowInteractionState WindowInteractionState => Get<WindowInteractionState>(WindowPattern.WindowInteractionStateProperty);
        public WindowVisualState WindowVisualState => Get<WindowVisualState>(WindowPattern.WindowVisualStateProperty);
    }

    public class WindowPatternProperties : IWindowPatternProperties
    {
        public PropertyId CanMaximizeProperty => WindowPattern.CanMinimizeProperty;

        public PropertyId CanMinimizeProperty => WindowPattern.CanMinimizeProperty;

        public PropertyId IsModalProperty => WindowPattern.IsModalProperty;

        public PropertyId IsTopmostProperty => WindowPattern.IsTopmostProperty;

        public PropertyId WindowInteractionStateProperty => WindowPattern.WindowInteractionStateProperty;

        public PropertyId WindowVisualStateProperty => WindowPattern.WindowVisualStateProperty;
    }

    public class WindowPatternEvents : IWindowPatternEvents
    {
        public EventId WindowClosedEvent => WindowPattern.WindowClosedEvent;

        public EventId WindowOpenedEvent => WindowPattern.WindowOpenedEvent;
    }
}
