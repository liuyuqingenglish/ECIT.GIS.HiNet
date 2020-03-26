﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Bifrost.Security
{
    /// <summary>
    /// Encapsulates a <see cref="ISecurityRule"/> that encountered an Exception when evaluating
    /// </summary>
    public class RuleEvaluationError
    {
        /// <summary>
        /// Instantiates an instance of <see cref="RuleEvaluationError"/>
        /// </summary>
        /// <param name="rule"><see cref="ISecurityRule"/> that encounted the error when evaluating.</param>
        /// <param name="error">The error that was encountered</param>
        public RuleEvaluationError(ISecurityRule rule, Exception error)
        {
            Error = error;
            Rule = rule;
        }

        /// <summary>
        /// Gets the Exception that was encountered when evaluation the rule
        /// </summary>
        public Exception Error { get; private set; }

        /// <summary>
        /// Gets the rule instance that encountered the exception when evaluation
        /// </summary>
        public ISecurityRule Rule { get; private set; }

        /// <summary>
        /// Returns a descriptive message describing the rule
        /// </summary>
        /// <returns>String descibing the rule</returns>
        public string BuildErrorMessage()
        {
            return Rule.Description + "/" + "Error";
        }
    }
}