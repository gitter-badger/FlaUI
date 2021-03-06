﻿using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class InvokePattern : PatternBase<UIA.InvokePattern>,IInvokePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.InvokePattern.Pattern.Id, "Invoke");

        public InvokePattern(AutomationObjectBase automationObject, UIA.InvokePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        public void Invoke()
        {
            NativePattern.Invoke();
        }
    }
}
