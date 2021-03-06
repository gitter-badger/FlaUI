﻿using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using System;

namespace FlaUI.Core.Elements.PatternElements
{
    public class InvokeElement : Element
    {
        public InvokeElement(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public IInvokePattern InvokePattern => PatternFactory.GetInvokePattern();

        public void Invoke()
        {
            var invokePattern = InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
