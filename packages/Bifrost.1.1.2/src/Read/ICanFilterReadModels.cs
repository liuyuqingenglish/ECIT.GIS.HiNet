﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Bifrost.Read
{
    /// <summary>
    /// Defines a filter that can be applied to a set of <see cref="IReadModel">ReadModels</see>
    /// </summary>
    /// <remarks>
    /// Typically this is applied when getting both a single <see cref="IReadModel"/> and when executing a <see cref="IQueryFor">Query</see> for a <see cref="IReadModel"/>
    /// </remarks>
    public interface ICanFilterReadModels
    {
        /// <summary>
        /// Filters an incoming <see cref="IEnumerable{IReadModel}"/>
        /// </summary>
        /// <param name="readModels"><see cref="IEnumerable{IReadModel}">ReadModels</see> to filter</param>
        /// <returns>Filtered <see cref="IEnumerable{IReadModel}">ReadModels</see></returns>
        IEnumerable<IReadModel> Filter(IEnumerable<IReadModel> readModels);
    }
}
