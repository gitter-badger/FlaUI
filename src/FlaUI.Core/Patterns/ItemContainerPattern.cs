﻿using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ItemContainerPattern : PatternBase<IUIAutomationItemContainerPattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_ItemContainerPatternId, "ItemContainer");

        internal ItemContainerPattern(AutomationElement automationElement, IUIAutomationItemContainerPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public AutomationElement FindItemByProperty(AutomationElement startAfter, AutomationProperty property, object value)
        {
            var foundNativeElement = ComCallWrapper.Call(() =>
                NativePattern.FindItemByProperty(
                    startAfter == null ? null : startAfter.NativeElement,
                    property == null ? 0 : property.Id, NativeValueConverter.ToNative(value)));
            return ToAutomationElement(foundNativeElement);
        }
    }
}