﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Reflection;

namespace Bifrost.Mapping
{
    /// <summary>
    /// Represents an implementation of <see cref="IMappingTarget"/> representing the default behavior for mapping to a target
    /// </summary>
    public class DefaultMappingTarget : IMappingTarget
    {
#pragma warning disable 1591 // Xml Comments
        public Type TargetType { get { return typeof(object); } }

        public void SetValue(object target, MemberInfo member, object value)
        {
            throw new NotImplementedException();
        }
#pragma warning restore 1591 // Xml Comments
    }
}
